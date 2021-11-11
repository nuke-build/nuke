// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;

namespace Nuke.Notifications
{
    public partial class NotificationsAttribute
    {
        private static readonly Dictionary<string, Action> s_actions = new Dictionary<string, Action>();

        public static BuildAction CreateLinkAction(
            string caption,
            string link,
            BuildActionStyle style = BuildActionStyle.Normal,
            BuildActionConfirmation confirmation = null)
        {
            return new BuildAction
                   {
                       Type = BuildActionType.Link,
                       Caption = caption,
                       Data = link,
                       Style = style,
                       Confirmation = confirmation
                   };
        }

        public static BuildAction CreateLocalAction(
            string caption,
            Action action,
            BuildActionStyle style = BuildActionStyle.Normal,
            BuildActionConfirmation confirmation = null)
        {
            var buttonId = Guid.NewGuid().ToString();
            s_actions[buttonId] = action;
            return new BuildAction
                   {
                       Id = buttonId,
                       Type = BuildActionType.Local,
                       Caption = caption,
                       Style = style,
                       Confirmation = confirmation
                   };
        }

        public static void ExecuteAction(string actionId)
        {
            s_actions.GetValueOrDefault(actionId)?.Invoke();
        }
    }
}
