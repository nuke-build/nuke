// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Serilog;
using static Nuke.Common.ControlFlow;

namespace Nuke.Common.Tools.SignPath
{
    [PublicAPI]
    public static class SignPathTasks
    {
        private class SigningRequestStatus
        {
            public const string Completed = nameof(Completed);
            public const string Denied = nameof(Denied);
            public const string Failed = nameof(Failed);
            public const string Cancelled = nameof(Cancelled);
            public const string Processing = nameof(Processing);
            public const string QueuedForProcessing = nameof(QueuedForProcessing);
            public const string RetrievingArtifact = nameof(RetrievingArtifact);
        }

        public static string SignPathApiUrl => "https://app.signpath.io/api/v1";
        public static TimeSpan ServiceUnavailableRetryTimeoutInSeconds = TimeSpan.FromSeconds(3);
        public static TimeSpan DefaultHttpClientTimeout = TimeSpan.FromSeconds(15);
        public static TimeSpan UploadAndDownloadRequestTimeout = TimeSpan.FromSeconds(15);
        public static TimeSpan WaitForCompletionRetryTimeout = TimeSpan.FromSeconds(5);
        public static int WaitForCompletionRetryAttempts = 100;

        public static string GetSigningRequestUrl(string organizationId, string signingRequestId)
        {
            return $"{SignPathApiUrl}/{organizationId}/SignRequests/{signingRequestId}";
        }

        private static string GetSignPathAppVeyorIntegrationUrl(string organizationId, string projectSlug, string signingPolicySlug)
        {
            return $"{SignPathApiUrl}/{organizationId}/Integrations/AppVeyor?ProjectSlug={projectSlug}&SigningPolicySlug={signingPolicySlug}";
        }

        public static async Task<string> GetSigningRequestUrlViaAppVeyor(
            string authToken,
            string organizationId,
            string projectSlug,
            string signingPolicySlug)
        {
            using (SwitchSecurityProtocol())
            {
                var contentType = "application/json";
                var content = new
                              {
                                  AppVeyor.Instance.AccountName,
                                  AppVeyor.Instance.ProjectSlug,
                                  AppVeyor.Instance.BuildVersion,
                                  AppVeyor.Instance.BuildId,
                                  AppVeyor.Instance.JobId
                              };

                using var httpClient = CreateAuthorizedHttpClient(authToken, DefaultHttpClientTimeout);
                var response = await httpClient.PostAsync(
                    GetSignPathAppVeyorIntegrationUrl(organizationId, projectSlug, signingPolicySlug),
                    new StringContent(content.ToJson(), Encoding.UTF8, contentType));
                response.AssertStatusCode(HttpStatusCode.Created);

                Log.Information("Signing request created: {Url}", response.Headers.Location.AbsoluteUri.Replace("api/v1", "Web"));
                return response.Headers.Location.AbsoluteUri;
            }
        }

        // static void SubmitSigningRequest(
        //     string userToken,
        //     string organizationId,
        //     string artifactConfigurationId,
        //     string signingPolicyId,
        //     string projectSlug,
        //     string artifactConfigurationSlug,
        //     string signingPolicySlug,
        //     string inputArtifactPath,
        //     string description,
        //     string apiUrl = "https://app.signpath.io/api/v1")
        // {
        //     CreateAndUseAuthorizedHttpClient(userToken, DefaultHttpClientTimeout,
        //         defaultHttpClient =>
        //         {
        //             CreateAndUseAuthorizedHttpClient(userToken, UploadAndDownloadRequestTimeout,
        //                 uploadAndDownloadHttpClient =>
        //                 {
        //                     var outputArtifactPath =
        //                         Path.ChangeExtension(
        //                             inputArtifactPath,
        //                             $".signed{Path.GetExtension(inputArtifactPath)}");
        //                     var submitUrl = $"{apiUrl}/{organizationId}/SigningRequests";
        //                     var getUrl = SubmitVia(
        //                         uploadAndDownloadHttpClient,
        //                         submitUrl, projectSlug, signingPolicySlug, signingPolicyId, description, artifactConfigurationId, artifactConfigurationSlug,
        //                         inputArtifactPath);
        //
        //                     var downloadUrl = GetSignedArtifactUrl(
        //                         defaultHttpClient,
        //                         getUrl);
        //                     DownloadArtifact(
        //                         uploadAndDownloadHttpClient,
        //                         downloadUrl,
        //                         outputArtifactPath);
        //                 });
        //         });
        // }

        public static async Task DownloadSignedArtifactFromUrl(
            string apiToken,
            string signingRequestUrl,
            AbsolutePath outputPath)
        {
            using (SwitchSecurityProtocol())
            {
                var defaultHttpClient = CreateAuthorizedHttpClient(apiToken, DefaultHttpClientTimeout);
                var downloadUrl = GetSignedArtifactUrl(defaultHttpClient, signingRequestUrl);
                Log.Information("Signed artifact is available: {DownloadUrl}", downloadUrl);

                var downloadHttpClient = CreateAuthorizedHttpClient(apiToken, UploadAndDownloadRequestTimeout);
                using var response = SendGetRequestWithRetry(downloadHttpClient, downloadUrl);
                var downloadStream = await response.Content.ReadAsStreamAsync();

                outputPath.Parent.CreateDirectory();
                using var fileStream = File.Open(outputPath, FileMode.Create);
                await downloadStream.CopyToAsync(fileStream);
                Log.Information("Signed artifact downloaded to: {OutputPath}", outputPath);
            }
        }

        private static string GetSignedArtifactUrl(HttpClient httpClient, string signingRequestUrl)
        {
            string signedArtifactUrl = null;
            string signingRequestStatus = null;
            ExecuteWithRetry(
                () =>
                {
                    var response = SendGetRequestWithRetry(httpClient, signingRequestUrl);
                    var rawContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var jsonContent = rawContent.GetJson();
                    signingRequestStatus = jsonContent["status"].NotNull().Value<string>();
                    signedArtifactUrl = signingRequestStatus switch
                    {
                        SigningRequestStatus.Completed => jsonContent["signedArtifactLink"].NotNull().Value<string>(),
                        SigningRequestStatus.Failed => null,
                        SigningRequestStatus.Denied => null,
                        SigningRequestStatus.Cancelled => null,
                        _ => throw new Exception(signingRequestStatus)
                    };
                },
                delay: WaitForCompletionRetryTimeout,
                retryAttempts: WaitForCompletionRetryAttempts,
                logAction: Log.Debug);

            return signedArtifactUrl.NotNull($"Signing Request {signingRequestStatus}");
        }

        private static IDisposable SwitchSecurityProtocol()
        {
            return DelegateDisposable.SetAndRestore(() => ServicePointManager.SecurityProtocol, SecurityProtocolType.Tls12);
        }

        private static HttpClient CreateAuthorizedHttpClient(string apiToken, TimeSpan timeout)
        {
            return new HttpClient
                   {
                       Timeout = timeout,
                       DefaultRequestHeaders =
                       {
                           Authorization = new AuthenticationHeaderValue("Bearer", apiToken)
                       }
                   };
        }

        private static HttpResponseMessage SendRequestWithRetry(
            HttpClient httpClient,
            Func<HttpRequestMessage> requestFactory,
            HttpStatusCode expectedStatusCode)
        {
            HttpResponseMessage response = null;
            ExecuteWithRetry(
                () =>
                {
                    var request = requestFactory.Invoke();
                    response = httpClient.SendAsync(request).GetAwaiter().GetResult().AssertStatusCode(expectedStatusCode);
                },
                delay: ServiceUnavailableRetryTimeoutInSeconds,
                logAction: Log.Debug);
            return response;
        }

        private static HttpResponseMessage SendGetRequestWithRetry(HttpClient httpClient, string url)
        {
            return SendRequestWithRetry(httpClient, () => new HttpRequestMessage(HttpMethod.Get, url), expectedStatusCode: HttpStatusCode.OK);
        }

        private static string SubmitVia(
            HttpClient httpClient,
            string url,
            [CanBeNull] string projectSlug,
            [CanBeNull] string signingPolicySlug,
            [CanBeNull] string signingPolicyId,
            string description,
            [CanBeNull] string artifactConfigurationId,
            [CanBeNull] string artifactConfigurationSlug,
            string artifactFile)
        {
            StreamContent GetStreamContent()
            {
                var contentType = "application/octet-stream";
                using var content = new FileStream(artifactFile, FileMode.Open);

                var streamContent = new StreamContent(content);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                return streamContent;
            }

            HttpRequestMessage CreateHttpRequest()
            {
                var content = new MultipartFormDataContent();
                var data = new[]
                           {
                               (nameof(artifactConfigurationId), artifactConfigurationId),
                               (nameof(signingPolicyId), signingPolicyId),
                               (nameof(projectSlug), projectSlug),
                               (nameof(artifactConfigurationSlug), artifactConfigurationSlug),
                               (nameof(signingPolicySlug), signingPolicySlug),
                               (nameof(description), description)
                           }
                    .Where(x => x.Item2 != null).ToList();
                data.ForEach(x => content.Add(new StringContent(x.Item2), x.Item1));
                content.Add(GetStreamContent(), "Artifact", artifactFile);

                return new HttpRequestMessage(HttpMethod.Post, url) { Content = content };
            }

            var response = SendRequestWithRetry(httpClient, CreateHttpRequest, HttpStatusCode.Created);
            return response.Headers.Location.AbsoluteUri;
        }

        private static HttpResponseMessage AssertStatusCode(this HttpResponseMessage response, HttpStatusCode statusCode)
        {
            if (response.StatusCode != statusCode)
            {
                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jobject = content.GetJson();
                Assert.Fail($"[{response.StatusCode}] {jobject.GetChildren<JValue>("").Select(x => x.Value<string>()).JoinNewLine()}");
            }

            return response;
        }
    }
}
