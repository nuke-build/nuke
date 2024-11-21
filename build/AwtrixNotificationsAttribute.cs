// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;

[PublicAPI]
public class AwtrixNotificationsAttribute : BuildExtensionAttributeBase,
    IOnBuildCreated,
    IOnTargetRunning,
    IOnBuildFinished
{
    private readonly IMqttClient _mqttClient;

    public string MqttHost => EnvironmentInfo.GetVariable("NUKE_AWTRIX_MQTT_HOST");
    public int? MqttPort => EnvironmentInfo.GetVariable<int?>("NUKE_AWTRIX_MQTT_PORT").NotNull();
    public string MqttTopicPrefix => EnvironmentInfo.GetVariable("NUKE_AWTRIX_MQTT_PREFIX").NotNullOrWhiteSpace();

    public AwtrixNotificationsAttribute()
    {
        if (MqttHost == null)
            return;

        _mqttClient = new MqttFactory().CreateMqttClient();
        _mqttClient.ConnectAsync(new MqttClientOptionsBuilder()
                .WithTcpServer(MqttHost, MqttPort)
                .Build(),
            CancellationToken.None).GetAwaiter().GetResult();
    }

    public int RunningIconId { get; set; } = 13546;
    public int SuccessIconId { get; set; } = 39396;
    public int FailureIconId { get; set; } = 8510;
    public string ProjectName { get; set; } = "Build";

    protected virtual object CreateBuildCreatedPayload()
    {
        return new
               {
                   icon = RunningIconId,
                   text = ProjectName,
                   hold = true,
                   stack = false,
               };
    }

    protected virtual object CreateTargetRunningPayload(ExecutableTarget target)
    {
        var progress = (Build.SucceededTargets.Count + Build.FailedTargets.Count) / (double)Build.ExecutionPlan.Count * 100;
        return new
               {
                   icon = RunningIconId,
                   text = target.Name,
                   progress,
                   progressC = Build.IsSucceeding ? "#00ff00" : "#ff0000",
                   progressBC = "#333333",
                   hold = true,
                   stack = false,
               };
    }

    protected virtual object CreateBuildFinishedPayload()
    {
        return new
               {
                   icon = Build.IsSucceeding ? SuccessIconId : FailureIconId,
                   text = ProjectName,
                   hold = !Build.IsSucceeding,
                   stack = false,
               };
    }

    public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
    {
        PublishMqttMessage(CreateBuildCreatedPayload());
    }

    public void OnTargetRunning(ExecutableTarget target)
    {
        PublishMqttMessage(CreateTargetRunningPayload(target));
    }

    public void OnBuildFinished()
    {
        PublishMqttMessage(CreateBuildFinishedPayload());
    }

    private void PublishMqttMessage(object payload)
    {
        _mqttClient?.PublishAsync(new MqttApplicationMessageBuilder()
                .WithTopic($"{MqttTopicPrefix}/notify")
                .WithPayload(JsonConvert.SerializeObject(payload))
                .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                .Build(),
            CancellationToken.None).GetAwaiter().GetResult();
    }
}
