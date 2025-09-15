// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Build.Shared;

[PublicAPI]
internal record Notification(string Title, string Text, Link[] Links)
{
    public string Title { get; } = Title;
    public string Text { get; } = Text;
    public Link[] Links { get; } = Links;
}

[PublicAPI]
internal record Link(string Text, string Url)
{
    public string Text { get; } = Text;
    public string Url { get; } = Url;
}

[PublicAPI]
internal class NotificationFetcher
{
    private const string NotificationEndpoint = "https://nuke.build/notifications.json";
    private const string UtmMedium = "development";

    private readonly AbsolutePath _notificationDirectory = Constants.GlobalNukeDirectory / "received-notifications";
    private readonly string _utmSource;

    public NotificationFetcher(string utmSource)
    {
        _utmSource = utmSource;
    }

    public async Task<Notification> GetNotificationAsync()
    {
        try
        {
            return await GetNotificationInternal();
        }
        catch (Exception)
        {
            return null;
        }
    }

    private async Task<Notification> GetNotificationInternal()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(NotificationEndpoint);
        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content).RootElement;

        var notification = json.EnumerateArray()
            .Where(IsApplicable)
            .Select(x => (Json: x, File: _notificationDirectory / x.ToString().GetMD5Hash()))
            .FirstOrDefault(x => !x.File.Exists());
        if (notification.File == null)
            return null;

        notification.File.TouchFile();

        return new Notification(
            Title: notification.Json.GetProperty("title").GetString(),
            Text: notification.Json.GetProperty("text").GetString(),
            Links: notification.Json.GetProperty("links").EnumerateArray().Select(GetLink).ToArray());

        bool IsApplicable(JsonElement element)
            => !element.TryGetProperty("exclude", out var exclusions) ||
               !exclusions.EnumerateArray().Select(x => x.GetString()).Contains(_utmSource);

        Link GetLink(JsonElement obj)
        {
            var originalUrl = new Uri(obj.GetProperty("url").GetString().NotNullOrEmpty())
                .WithUtmValues(
                    medium: UtmMedium,
                    source: _utmSource,
                    campaign: obj.GetProperty("campaign").GetString());
            return new Link(
                Text: obj.GetProperty("title").GetString(),
                Url: originalUrl.AbsoluteUri);
        }
    }
}
