// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Microsoft.AspNetCore.SignalR.Client;
using Serilog;

namespace Nuke.Notifications;

public partial class NotificationsAttribute
{
    private HubConnection CreateHubConnection()
    {
        try
        {
            var connection = new HubConnectionBuilder()
                .WithUrl(BuildInteractionEndpoint,
                    options =>
                    {
                        options.Headers["x-nuke-cookie"] = _cookie.ToString();
                        options.Headers["x-nuke-access-token"] = AccessToken;
                    })
                .WithAutomaticReconnect()
                .Build();
            connection.On<string>("executeCommand", ExecuteAction);
            connection.StartAsync().GetAwaiter().GetResult();
            return connection;
        }
        catch (Exception exception)
        {
            Log.Warning(exception, "Establishing back-channel with {Endpoint} failed", BuildInteractionEndpoint);
            return null;
        }
    }
}
