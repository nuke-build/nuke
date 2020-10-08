// Generated from https://github.com/VolkmarR/nuke/blob/master/build/specifications/Teams.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Teams
{
    #region TeamsMessage
    /// <summary>
    ///   Used within <see cref="TeamsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TeamsMessage : ISettingsEntity
    {
        [JsonProperty("title")]
        public virtual string Title { get; internal set; }
        [JsonProperty("text")]
        public virtual string Text { get; internal set; }
        [JsonProperty("themeColor")]
        public virtual string ThemeColor { get; internal set; }
    }
    #endregion
    #region TeamsMessageExtensions
    /// <summary>
    ///   Used within <see cref="TeamsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TeamsMessageExtensions
    {
        #region Title
        /// <summary>
        ///   <p><em>Sets <see cref="TeamsMessage.Title"/></em></p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : TeamsMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TeamsMessage.Title"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : TeamsMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = null;
            return toolSettings;
        }
        #endregion
        #region Text
        /// <summary>
        ///   <p><em>Sets <see cref="TeamsMessage.Text"/></em></p>
        /// </summary>
        [Pure]
        public static T SetText<T>(this T toolSettings, string text) where T : TeamsMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = text;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TeamsMessage.Text"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetText<T>(this T toolSettings) where T : TeamsMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = null;
            return toolSettings;
        }
        #endregion
        #region ThemeColor
        /// <summary>
        ///   <p><em>Sets <see cref="TeamsMessage.ThemeColor"/></em></p>
        /// </summary>
        [Pure]
        public static T SetThemeColor<T>(this T toolSettings, string themeColor) where T : TeamsMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemeColor = themeColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TeamsMessage.ThemeColor"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetThemeColor<T>(this T toolSettings) where T : TeamsMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemeColor = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
