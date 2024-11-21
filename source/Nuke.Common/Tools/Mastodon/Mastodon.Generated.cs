// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Mastodon/Mastodon.json

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

namespace Nuke.Common.Tools.Mastodon;

#region MastodonStatus
/// <summary>Used within <see cref="MastodonTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MastodonStatus>))]
public partial class MastodonStatus : Options
{
    /// <summary>Text of the status.</summary>
    public string Text => Get<string>(() => Text);
    /// <summary>Media files to attach to the status.</summary>
    public IReadOnlyList<string> MediaFiles => Get<List<string>>(() => MediaFiles);
}
#endregion
#region MastodonStatusExtensions
/// <summary>Used within <see cref="MastodonTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class MastodonStatusExtensions
{
    #region Text
    /// <inheritdoc cref="MastodonStatus.Text"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.Text))]
    public static T SetText<T>(this T o, string v) where T : MastodonStatus => o.Modify(b => b.Set(() => o.Text, v));
    /// <inheritdoc cref="MastodonStatus.Text"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.Text))]
    public static T ResetText<T>(this T o) where T : MastodonStatus => o.Modify(b => b.Remove(() => o.Text));
    #endregion
    #region MediaFiles
    /// <inheritdoc cref="MastodonStatus.MediaFiles"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.MediaFiles))]
    public static T SetMediaFiles<T>(this T o, params string[] v) where T : MastodonStatus => o.Modify(b => b.Set(() => o.MediaFiles, v));
    /// <inheritdoc cref="MastodonStatus.MediaFiles"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.MediaFiles))]
    public static T SetMediaFiles<T>(this T o, IEnumerable<string> v) where T : MastodonStatus => o.Modify(b => b.Set(() => o.MediaFiles, v));
    /// <inheritdoc cref="MastodonStatus.MediaFiles"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.MediaFiles))]
    public static T AddMediaFiles<T>(this T o, params string[] v) where T : MastodonStatus => o.Modify(b => b.AddCollection(() => o.MediaFiles, v));
    /// <inheritdoc cref="MastodonStatus.MediaFiles"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.MediaFiles))]
    public static T AddMediaFiles<T>(this T o, IEnumerable<string> v) where T : MastodonStatus => o.Modify(b => b.AddCollection(() => o.MediaFiles, v));
    /// <inheritdoc cref="MastodonStatus.MediaFiles"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.MediaFiles))]
    public static T RemoveMediaFiles<T>(this T o, params string[] v) where T : MastodonStatus => o.Modify(b => b.RemoveCollection(() => o.MediaFiles, v));
    /// <inheritdoc cref="MastodonStatus.MediaFiles"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.MediaFiles))]
    public static T RemoveMediaFiles<T>(this T o, IEnumerable<string> v) where T : MastodonStatus => o.Modify(b => b.RemoveCollection(() => o.MediaFiles, v));
    /// <inheritdoc cref="MastodonStatus.MediaFiles"/>
    [Pure] [Builder(Type = typeof(MastodonStatus), Property = nameof(MastodonStatus.MediaFiles))]
    public static T ClearMediaFiles<T>(this T o) where T : MastodonStatus => o.Modify(b => b.ClearCollection(() => o.MediaFiles));
    #endregion
}
#endregion
