// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Teams/Teams.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
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

namespace Nuke.Common.Tools.Teams;

#region TeamsMessage
/// <summary>Used within <see cref="TeamsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<TeamsMessage>))]
public partial class TeamsMessage : Options
{
    /// <summary></summary>
    [JsonProperty("title")] public string Title => Get<string>(() => Title);
    /// <summary></summary>
    [JsonProperty("text")] public string Text => Get<string>(() => Text);
    /// <summary></summary>
    [JsonProperty("themeColor")] public string ThemeColor => Get<string>(() => ThemeColor);
}
#endregion
#region TeamsMessageExtensions
/// <summary>Used within <see cref="TeamsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class TeamsMessageExtensions
{
    #region Title
    /// <inheritdoc cref="TeamsMessage.Title"/>
    [Pure] [Builder(Type = typeof(TeamsMessage), Property = nameof(TeamsMessage.Title))]
    public static T SetTitle<T>(this T o, string v) where T : TeamsMessage => o.Modify(b => b.Set(() => o.Title, v));
    /// <inheritdoc cref="TeamsMessage.Title"/>
    [Pure] [Builder(Type = typeof(TeamsMessage), Property = nameof(TeamsMessage.Title))]
    public static T ResetTitle<T>(this T o) where T : TeamsMessage => o.Modify(b => b.Remove(() => o.Title));
    #endregion
    #region Text
    /// <inheritdoc cref="TeamsMessage.Text"/>
    [Pure] [Builder(Type = typeof(TeamsMessage), Property = nameof(TeamsMessage.Text))]
    public static T SetText<T>(this T o, string v) where T : TeamsMessage => o.Modify(b => b.Set(() => o.Text, v));
    /// <inheritdoc cref="TeamsMessage.Text"/>
    [Pure] [Builder(Type = typeof(TeamsMessage), Property = nameof(TeamsMessage.Text))]
    public static T ResetText<T>(this T o) where T : TeamsMessage => o.Modify(b => b.Remove(() => o.Text));
    #endregion
    #region ThemeColor
    /// <inheritdoc cref="TeamsMessage.ThemeColor"/>
    [Pure] [Builder(Type = typeof(TeamsMessage), Property = nameof(TeamsMessage.ThemeColor))]
    public static T SetThemeColor<T>(this T o, string v) where T : TeamsMessage => o.Modify(b => b.Set(() => o.ThemeColor, v));
    /// <inheritdoc cref="TeamsMessage.ThemeColor"/>
    [Pure] [Builder(Type = typeof(TeamsMessage), Property = nameof(TeamsMessage.ThemeColor))]
    public static T ResetThemeColor<T>(this T o) where T : TeamsMessage => o.Modify(b => b.Remove(() => o.ThemeColor));
    #endregion
}
#endregion
