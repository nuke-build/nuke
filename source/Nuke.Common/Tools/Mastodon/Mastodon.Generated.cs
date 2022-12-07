// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Mastodon/Mastodon.json

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

namespace Nuke.Common.Tools.Mastodon
{
    #region MastodonStatus
    /// <summary>
    ///   Used within <see cref="MastodonTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MastodonStatus : ISettingsEntity
    {
        /// <summary>
        ///   Text of the status.
        /// </summary>
        public virtual string Text { get; internal set; }
        /// <summary>
        ///   Media files to attach to the status.
        /// </summary>
        public virtual IReadOnlyList<string> MediaFiles => MediaFilesInternal.AsReadOnly();
        internal List<string> MediaFilesInternal { get; set; } = new List<string>();
    }
    #endregion
    #region MastodonStatusExtensions
    /// <summary>
    ///   Used within <see cref="MastodonTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MastodonStatusExtensions
    {
        #region Text
        /// <summary>
        ///   <p><em>Sets <see cref="MastodonStatus.Text"/></em></p>
        ///   <p>Text of the status.</p>
        /// </summary>
        [Pure]
        public static T SetText<T>(this T toolSettings, string text) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = text;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MastodonStatus.Text"/></em></p>
        ///   <p>Text of the status.</p>
        /// </summary>
        [Pure]
        public static T ResetText<T>(this T toolSettings) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = null;
            return toolSettings;
        }
        #endregion
        #region MediaFiles
        /// <summary>
        ///   <p><em>Sets <see cref="MastodonStatus.MediaFiles"/> to a new list</em></p>
        ///   <p>Media files to attach to the status.</p>
        /// </summary>
        [Pure]
        public static T SetMediaFiles<T>(this T toolSettings, params string[] mediaFiles) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MediaFilesInternal = mediaFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MastodonStatus.MediaFiles"/> to a new list</em></p>
        ///   <p>Media files to attach to the status.</p>
        /// </summary>
        [Pure]
        public static T SetMediaFiles<T>(this T toolSettings, IEnumerable<string> mediaFiles) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MediaFilesInternal = mediaFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MastodonStatus.MediaFiles"/></em></p>
        ///   <p>Media files to attach to the status.</p>
        /// </summary>
        [Pure]
        public static T AddMediaFiles<T>(this T toolSettings, params string[] mediaFiles) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MediaFilesInternal.AddRange(mediaFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MastodonStatus.MediaFiles"/></em></p>
        ///   <p>Media files to attach to the status.</p>
        /// </summary>
        [Pure]
        public static T AddMediaFiles<T>(this T toolSettings, IEnumerable<string> mediaFiles) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MediaFilesInternal.AddRange(mediaFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MastodonStatus.MediaFiles"/></em></p>
        ///   <p>Media files to attach to the status.</p>
        /// </summary>
        [Pure]
        public static T ClearMediaFiles<T>(this T toolSettings) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MediaFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MastodonStatus.MediaFiles"/></em></p>
        ///   <p>Media files to attach to the status.</p>
        /// </summary>
        [Pure]
        public static T RemoveMediaFiles<T>(this T toolSettings, params string[] mediaFiles) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(mediaFiles);
            toolSettings.MediaFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MastodonStatus.MediaFiles"/></em></p>
        ///   <p>Media files to attach to the status.</p>
        /// </summary>
        [Pure]
        public static T RemoveMediaFiles<T>(this T toolSettings, IEnumerable<string> mediaFiles) where T : MastodonStatus
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(mediaFiles);
            toolSettings.MediaFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
