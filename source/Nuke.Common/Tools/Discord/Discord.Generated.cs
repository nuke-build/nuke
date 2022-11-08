// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Discord/Discord.json

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

namespace Nuke.Common.Tools.Discord
{
    #region DiscordMessage
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DiscordMessage : ISettingsEntity
    {
        /// <summary>
        ///   Id of the channel.
        /// </summary>
        [JsonProperty("channel_id")]
        public virtual string ChannelId { get; internal set; }
        /// <summary>
        ///   Message contents (up to 2000 characters).
        /// </summary>
        [JsonProperty("content")]
        public virtual string Content { get; internal set; }
        /// <summary>
        ///   Can be used to verify a message was sent (up to 25 characters). Value will appear in the <a href="https://discord.com/developers/docs/topics/gateway-events#message-create">Message Create event</a>.
        /// </summary>
        [JsonProperty("nonce")]
        public virtual string Nonce { get; internal set; }
        /// <summary>
        ///   Whether this is a TTS message.
        /// </summary>
        [JsonProperty("tts")]
        public virtual bool? TTS { get; internal set; }
        /// <summary>
        ///   Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.
        /// </summary>
        [JsonIgnore]
        public virtual IReadOnlyList<DiscordEmbed> Embeds => EmbedsInternal.AsReadOnly();
        [JsonProperty("embeds")]
        internal List<DiscordEmbed> EmbedsInternal { get; set; } = new List<DiscordEmbed>();
    }
    #endregion
    #region DiscordEmbed
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DiscordEmbed : ISettingsEntity
    {
        /// <summary>
        ///   Title of embed.
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; internal set; }
        /// <summary>
        ///   <a href="https://discord.com/developers/docs/resources/channel#embed-object-embed-types">Type of embed</a> (always <c>rich</c> for webhook embeds).
        /// </summary>
        [JsonProperty("type")]
        public virtual DiscordEmbedType Type { get; internal set; }
        /// <summary>
        ///   Description of embed.
        /// </summary>
        [JsonProperty("description")]
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   Url of embed.
        /// </summary>
        [JsonProperty("url")]
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   ISO8601 timestamp of embed.
        /// </summary>
        [JsonProperty("timestamp")]
        public virtual string Timestamp { get; internal set; }
        /// <summary>
        ///   Color code of the embed.
        /// </summary>
        [JsonProperty("color")]
        public virtual int? Color { get; internal set; }
        /// <summary>
        ///   Footer information.
        /// </summary>
        [JsonProperty("footer")]
        public virtual DiscordEmbedFooter Footer { get; internal set; }
        /// <summary>
        ///   Image information.
        /// </summary>
        [JsonProperty("image")]
        public virtual DiscordEmbedImage Image { get; internal set; }
        /// <summary>
        ///   Thumbnail information.
        /// </summary>
        [JsonProperty("thumbnail")]
        public virtual DiscordEmbedThumbnail Thumbnail { get; internal set; }
        /// <summary>
        ///   Author information.
        /// </summary>
        [JsonProperty("author")]
        public virtual DiscordEmbedAuthor Author { get; internal set; }
        /// <summary>
        ///   Fields information.
        /// </summary>
        [JsonIgnore]
        public virtual IReadOnlyList<DiscordEmbedField> Fields => FieldsInternal.AsReadOnly();
        [JsonProperty("fields")]
        internal List<DiscordEmbedField> FieldsInternal { get; set; } = new List<DiscordEmbedField>();
    }
    #endregion
    #region DiscordEmbedFooter
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DiscordEmbedFooter : ISettingsEntity
    {
        /// <summary>
        ///   Footer text.
        /// </summary>
        [JsonProperty("text")]
        public virtual string Text { get; internal set; }
        /// <summary>
        ///   Url of footer icon (only supports http(s) and attachments).
        /// </summary>
        [JsonProperty("icon_url")]
        public virtual string IconUrl { get; internal set; }
    }
    #endregion
    #region DiscordEmbedImage
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DiscordEmbedImage : ISettingsEntity
    {
        /// <summary>
        ///   Source url of image (only supports http(s) and attachments).
        /// </summary>
        [JsonProperty("url")]
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   Height of image.
        /// </summary>
        [JsonProperty("height")]
        public virtual int? Height { get; internal set; }
        /// <summary>
        ///   Width of image.
        /// </summary>
        [JsonProperty("width")]
        public virtual int? Width { get; internal set; }
    }
    #endregion
    #region DiscordEmbedThumbnail
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DiscordEmbedThumbnail : ISettingsEntity
    {
        /// <summary>
        ///   Source url of thumbnail (only supports http(s) and attachments).
        /// </summary>
        [JsonProperty("url")]
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   Height of thumbnail.
        /// </summary>
        [JsonProperty("height")]
        public virtual int? Height { get; internal set; }
        /// <summary>
        ///   Width of thumbnail.
        /// </summary>
        [JsonProperty("width")]
        public virtual int? Width { get; internal set; }
    }
    #endregion
    #region DiscordEmbedAuthor
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DiscordEmbedAuthor : ISettingsEntity
    {
        /// <summary>
        ///   Name of author.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Url of author.
        /// </summary>
        [JsonProperty("url")]
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   Url of author icon (only supports http(s) and attachments).
        /// </summary>
        [JsonProperty("icon_url")]
        public virtual string IconUrl { get; internal set; }
    }
    #endregion
    #region DiscordEmbedField
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DiscordEmbedField : ISettingsEntity
    {
        /// <summary>
        ///   Name of the field.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Value of the field.
        /// </summary>
        [JsonProperty("value")]
        public virtual string Value { get; internal set; }
        /// <summary>
        ///   Whether or not this field should siplay inline.
        /// </summary>
        [JsonProperty("inline")]
        public virtual bool? Inline { get; internal set; }
    }
    #endregion
    #region DiscordMessageExtensions
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DiscordMessageExtensions
    {
        #region ChannelId
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordMessage.ChannelId"/></em></p>
        ///   <p>Id of the channel.</p>
        /// </summary>
        [Pure]
        public static T SetChannelId<T>(this T toolSettings, string channelId) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChannelId = channelId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordMessage.ChannelId"/></em></p>
        ///   <p>Id of the channel.</p>
        /// </summary>
        [Pure]
        public static T ResetChannelId<T>(this T toolSettings) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChannelId = null;
            return toolSettings;
        }
        #endregion
        #region Content
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordMessage.Content"/></em></p>
        ///   <p>Message contents (up to 2000 characters).</p>
        /// </summary>
        [Pure]
        public static T SetContent<T>(this T toolSettings, string content) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Content = content;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordMessage.Content"/></em></p>
        ///   <p>Message contents (up to 2000 characters).</p>
        /// </summary>
        [Pure]
        public static T ResetContent<T>(this T toolSettings) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Content = null;
            return toolSettings;
        }
        #endregion
        #region Nonce
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordMessage.Nonce"/></em></p>
        ///   <p>Can be used to verify a message was sent (up to 25 characters). Value will appear in the <a href="https://discord.com/developers/docs/topics/gateway-events#message-create">Message Create event</a>.</p>
        /// </summary>
        [Pure]
        public static T SetNonce<T>(this T toolSettings, string nonce) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Nonce = nonce;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordMessage.Nonce"/></em></p>
        ///   <p>Can be used to verify a message was sent (up to 25 characters). Value will appear in the <a href="https://discord.com/developers/docs/topics/gateway-events#message-create">Message Create event</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetNonce<T>(this T toolSettings) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Nonce = null;
            return toolSettings;
        }
        #endregion
        #region TTS
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordMessage.TTS"/></em></p>
        ///   <p>Whether this is a TTS message.</p>
        /// </summary>
        [Pure]
        public static T SetTTS<T>(this T toolSettings, bool? tts) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TTS = tts;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordMessage.TTS"/></em></p>
        ///   <p>Whether this is a TTS message.</p>
        /// </summary>
        [Pure]
        public static T ResetTTS<T>(this T toolSettings) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TTS = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DiscordMessage.TTS"/></em></p>
        ///   <p>Whether this is a TTS message.</p>
        /// </summary>
        [Pure]
        public static T EnableTTS<T>(this T toolSettings) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TTS = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DiscordMessage.TTS"/></em></p>
        ///   <p>Whether this is a TTS message.</p>
        /// </summary>
        [Pure]
        public static T DisableTTS<T>(this T toolSettings) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TTS = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DiscordMessage.TTS"/></em></p>
        ///   <p>Whether this is a TTS message.</p>
        /// </summary>
        [Pure]
        public static T ToggleTTS<T>(this T toolSettings) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TTS = !toolSettings.TTS;
            return toolSettings;
        }
        #endregion
        #region Embeds
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordMessage.Embeds"/> to a new list</em></p>
        ///   <p>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</p>
        /// </summary>
        [Pure]
        public static T SetEmbeds<T>(this T toolSettings, params DiscordEmbed[] embeds) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EmbedsInternal = embeds.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordMessage.Embeds"/> to a new list</em></p>
        ///   <p>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</p>
        /// </summary>
        [Pure]
        public static T SetEmbeds<T>(this T toolSettings, IEnumerable<DiscordEmbed> embeds) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EmbedsInternal = embeds.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DiscordMessage.Embeds"/></em></p>
        ///   <p>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</p>
        /// </summary>
        [Pure]
        public static T AddEmbeds<T>(this T toolSettings, params DiscordEmbed[] embeds) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EmbedsInternal.AddRange(embeds);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a value to <see cref="DiscordMessage.Embeds"/></em></p>
        ///   <p>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</p>
        /// </summary>
        [Pure]
        public static T AddEmbed<T>(this T toolSettings, Configure<DiscordEmbed> configurator) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EmbedsInternal.Add(configurator.InvokeSafe(new DiscordEmbed()));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DiscordMessage.Embeds"/></em></p>
        ///   <p>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</p>
        /// </summary>
        [Pure]
        public static T AddEmbeds<T>(this T toolSettings, IEnumerable<DiscordEmbed> embeds) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EmbedsInternal.AddRange(embeds);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DiscordMessage.Embeds"/></em></p>
        ///   <p>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</p>
        /// </summary>
        [Pure]
        public static T ClearEmbeds<T>(this T toolSettings) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EmbedsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DiscordMessage.Embeds"/></em></p>
        ///   <p>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</p>
        /// </summary>
        [Pure]
        public static T RemoveEmbeds<T>(this T toolSettings, params DiscordEmbed[] embeds) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<DiscordEmbed>(embeds);
            toolSettings.EmbedsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DiscordMessage.Embeds"/></em></p>
        ///   <p>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</p>
        /// </summary>
        [Pure]
        public static T RemoveEmbeds<T>(this T toolSettings, IEnumerable<DiscordEmbed> embeds) where T : DiscordMessage
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<DiscordEmbed>(embeds);
            toolSettings.EmbedsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DiscordEmbedExtensions
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DiscordEmbedExtensions
    {
        #region Title
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Title"/></em></p>
        ///   <p>Title of embed.</p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Title"/></em></p>
        ///   <p>Title of embed.</p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = null;
            return toolSettings;
        }
        #endregion
        #region Type
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Type"/></em></p>
        ///   <p><a href="https://discord.com/developers/docs/resources/channel#embed-object-embed-types">Type of embed</a> (always <c>rich</c> for webhook embeds).</p>
        /// </summary>
        [Pure]
        public static T SetType<T>(this T toolSettings, DiscordEmbedType type) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Type = type;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Type"/></em></p>
        ///   <p><a href="https://discord.com/developers/docs/resources/channel#embed-object-embed-types">Type of embed</a> (always <c>rich</c> for webhook embeds).</p>
        /// </summary>
        [Pure]
        public static T ResetType<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Type = null;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Description"/></em></p>
        ///   <p>Description of embed.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Description"/></em></p>
        ///   <p>Description of embed.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Url"/></em></p>
        ///   <p>Url of embed.</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Url"/></em></p>
        ///   <p>Url of embed.</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region Timestamp
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Timestamp"/></em></p>
        ///   <p>ISO8601 timestamp of embed.</p>
        /// </summary>
        [Pure]
        public static T SetTimestamp<T>(this T toolSettings, string timestamp) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timestamp = timestamp;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Timestamp"/></em></p>
        ///   <p>ISO8601 timestamp of embed.</p>
        /// </summary>
        [Pure]
        public static T ResetTimestamp<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timestamp = null;
            return toolSettings;
        }
        #endregion
        #region Color
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Color"/></em></p>
        ///   <p>Color code of the embed.</p>
        /// </summary>
        [Pure]
        public static T SetColor<T>(this T toolSettings, int? color) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Color = color;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Color"/></em></p>
        ///   <p>Color code of the embed.</p>
        /// </summary>
        [Pure]
        public static T ResetColor<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Color = null;
            return toolSettings;
        }
        #endregion
        #region Footer
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Footer"/></em></p>
        ///   <p>Footer information.</p>
        /// </summary>
        [Pure]
        public static T SetFooter<T>(this T toolSettings, DiscordEmbedFooter footer) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Footer = footer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Footer"/></em></p>
        ///   <p>Footer information.</p>
        /// </summary>
        [Pure]
        public static T ResetFooter<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Footer = null;
            return toolSettings;
        }
        #endregion
        #region Image
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Image"/></em></p>
        ///   <p>Image information.</p>
        /// </summary>
        [Pure]
        public static T SetImage<T>(this T toolSettings, DiscordEmbedImage image) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Image = image;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Image"/></em></p>
        ///   <p>Image information.</p>
        /// </summary>
        [Pure]
        public static T ResetImage<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Image = null;
            return toolSettings;
        }
        #endregion
        #region Thumbnail
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Thumbnail"/></em></p>
        ///   <p>Thumbnail information.</p>
        /// </summary>
        [Pure]
        public static T SetThumbnail<T>(this T toolSettings, DiscordEmbedThumbnail thumbnail) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Thumbnail = thumbnail;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Thumbnail"/></em></p>
        ///   <p>Thumbnail information.</p>
        /// </summary>
        [Pure]
        public static T ResetThumbnail<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Thumbnail = null;
            return toolSettings;
        }
        #endregion
        #region Author
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Author"/></em></p>
        ///   <p>Author information.</p>
        /// </summary>
        [Pure]
        public static T SetAuthor<T>(this T toolSettings, DiscordEmbedAuthor author) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Author = author;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbed.Author"/></em></p>
        ///   <p>Author information.</p>
        /// </summary>
        [Pure]
        public static T ResetAuthor<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Author = null;
            return toolSettings;
        }
        #endregion
        #region Fields
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Fields"/> to a new list</em></p>
        ///   <p>Fields information.</p>
        /// </summary>
        [Pure]
        public static T SetFields<T>(this T toolSettings, params DiscordEmbedField[] fields) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal = fields.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbed.Fields"/> to a new list</em></p>
        ///   <p>Fields information.</p>
        /// </summary>
        [Pure]
        public static T SetFields<T>(this T toolSettings, IEnumerable<DiscordEmbedField> fields) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal = fields.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DiscordEmbed.Fields"/></em></p>
        ///   <p>Fields information.</p>
        /// </summary>
        [Pure]
        public static T AddFields<T>(this T toolSettings, params DiscordEmbedField[] fields) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal.AddRange(fields);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a value to <see cref="DiscordEmbed.Fields"/></em></p>
        ///   <p>Fields information.</p>
        /// </summary>
        [Pure]
        public static T AddField<T>(this T toolSettings, Configure<DiscordEmbedField> configurator) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal.Add(configurator.InvokeSafe(new DiscordEmbedField()));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DiscordEmbed.Fields"/></em></p>
        ///   <p>Fields information.</p>
        /// </summary>
        [Pure]
        public static T AddFields<T>(this T toolSettings, IEnumerable<DiscordEmbedField> fields) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal.AddRange(fields);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DiscordEmbed.Fields"/></em></p>
        ///   <p>Fields information.</p>
        /// </summary>
        [Pure]
        public static T ClearFields<T>(this T toolSettings) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DiscordEmbed.Fields"/></em></p>
        ///   <p>Fields information.</p>
        /// </summary>
        [Pure]
        public static T RemoveFields<T>(this T toolSettings, params DiscordEmbedField[] fields) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<DiscordEmbedField>(fields);
            toolSettings.FieldsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DiscordEmbed.Fields"/></em></p>
        ///   <p>Fields information.</p>
        /// </summary>
        [Pure]
        public static T RemoveFields<T>(this T toolSettings, IEnumerable<DiscordEmbedField> fields) where T : DiscordEmbed
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<DiscordEmbedField>(fields);
            toolSettings.FieldsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DiscordEmbedFooterExtensions
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DiscordEmbedFooterExtensions
    {
        #region Text
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedFooter.Text"/></em></p>
        ///   <p>Footer text.</p>
        /// </summary>
        [Pure]
        public static T SetText<T>(this T toolSettings, string text) where T : DiscordEmbedFooter
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = text;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedFooter.Text"/></em></p>
        ///   <p>Footer text.</p>
        /// </summary>
        [Pure]
        public static T ResetText<T>(this T toolSettings) where T : DiscordEmbedFooter
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = null;
            return toolSettings;
        }
        #endregion
        #region IconUrl
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedFooter.IconUrl"/></em></p>
        ///   <p>Url of footer icon (only supports http(s) and attachments).</p>
        /// </summary>
        [Pure]
        public static T SetIconUrl<T>(this T toolSettings, string iconUrl) where T : DiscordEmbedFooter
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IconUrl = iconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedFooter.IconUrl"/></em></p>
        ///   <p>Url of footer icon (only supports http(s) and attachments).</p>
        /// </summary>
        [Pure]
        public static T ResetIconUrl<T>(this T toolSettings) where T : DiscordEmbedFooter
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IconUrl = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DiscordEmbedImageExtensions
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DiscordEmbedImageExtensions
    {
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedImage.Url"/></em></p>
        ///   <p>Source url of image (only supports http(s) and attachments).</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : DiscordEmbedImage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedImage.Url"/></em></p>
        ///   <p>Source url of image (only supports http(s) and attachments).</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : DiscordEmbedImage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region Height
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedImage.Height"/></em></p>
        ///   <p>Height of image.</p>
        /// </summary>
        [Pure]
        public static T SetHeight<T>(this T toolSettings, int? height) where T : DiscordEmbedImage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Height = height;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedImage.Height"/></em></p>
        ///   <p>Height of image.</p>
        /// </summary>
        [Pure]
        public static T ResetHeight<T>(this T toolSettings) where T : DiscordEmbedImage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Height = null;
            return toolSettings;
        }
        #endregion
        #region Width
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedImage.Width"/></em></p>
        ///   <p>Width of image.</p>
        /// </summary>
        [Pure]
        public static T SetWidth<T>(this T toolSettings, int? width) where T : DiscordEmbedImage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Width = width;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedImage.Width"/></em></p>
        ///   <p>Width of image.</p>
        /// </summary>
        [Pure]
        public static T ResetWidth<T>(this T toolSettings) where T : DiscordEmbedImage
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Width = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DiscordEmbedThumbnailExtensions
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DiscordEmbedThumbnailExtensions
    {
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedThumbnail.Url"/></em></p>
        ///   <p>Source url of thumbnail (only supports http(s) and attachments).</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : DiscordEmbedThumbnail
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedThumbnail.Url"/></em></p>
        ///   <p>Source url of thumbnail (only supports http(s) and attachments).</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : DiscordEmbedThumbnail
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region Height
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedThumbnail.Height"/></em></p>
        ///   <p>Height of thumbnail.</p>
        /// </summary>
        [Pure]
        public static T SetHeight<T>(this T toolSettings, int? height) where T : DiscordEmbedThumbnail
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Height = height;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedThumbnail.Height"/></em></p>
        ///   <p>Height of thumbnail.</p>
        /// </summary>
        [Pure]
        public static T ResetHeight<T>(this T toolSettings) where T : DiscordEmbedThumbnail
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Height = null;
            return toolSettings;
        }
        #endregion
        #region Width
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedThumbnail.Width"/></em></p>
        ///   <p>Width of thumbnail.</p>
        /// </summary>
        [Pure]
        public static T SetWidth<T>(this T toolSettings, int? width) where T : DiscordEmbedThumbnail
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Width = width;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedThumbnail.Width"/></em></p>
        ///   <p>Width of thumbnail.</p>
        /// </summary>
        [Pure]
        public static T ResetWidth<T>(this T toolSettings) where T : DiscordEmbedThumbnail
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Width = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DiscordEmbedAuthorExtensions
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DiscordEmbedAuthorExtensions
    {
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedAuthor.Name"/></em></p>
        ///   <p>Name of author.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : DiscordEmbedAuthor
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedAuthor.Name"/></em></p>
        ///   <p>Name of author.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : DiscordEmbedAuthor
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedAuthor.Url"/></em></p>
        ///   <p>Url of author.</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : DiscordEmbedAuthor
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedAuthor.Url"/></em></p>
        ///   <p>Url of author.</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : DiscordEmbedAuthor
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region IconUrl
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedAuthor.IconUrl"/></em></p>
        ///   <p>Url of author icon (only supports http(s) and attachments).</p>
        /// </summary>
        [Pure]
        public static T SetIconUrl<T>(this T toolSettings, string iconUrl) where T : DiscordEmbedAuthor
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IconUrl = iconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedAuthor.IconUrl"/></em></p>
        ///   <p>Url of author icon (only supports http(s) and attachments).</p>
        /// </summary>
        [Pure]
        public static T ResetIconUrl<T>(this T toolSettings) where T : DiscordEmbedAuthor
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IconUrl = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DiscordEmbedFieldExtensions
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DiscordEmbedFieldExtensions
    {
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedField.Name"/></em></p>
        ///   <p>Name of the field.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedField.Name"/></em></p>
        ///   <p>Name of the field.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Value
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedField.Value"/></em></p>
        ///   <p>Value of the field.</p>
        /// </summary>
        [Pure]
        public static T SetValue<T>(this T toolSettings, string value) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Value = value;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedField.Value"/></em></p>
        ///   <p>Value of the field.</p>
        /// </summary>
        [Pure]
        public static T ResetValue<T>(this T toolSettings) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Value = null;
            return toolSettings;
        }
        #endregion
        #region Inline
        /// <summary>
        ///   <p><em>Sets <see cref="DiscordEmbedField.Inline"/></em></p>
        ///   <p>Whether or not this field should siplay inline.</p>
        /// </summary>
        [Pure]
        public static T SetInline<T>(this T toolSettings, bool? inline) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Inline = inline;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DiscordEmbedField.Inline"/></em></p>
        ///   <p>Whether or not this field should siplay inline.</p>
        /// </summary>
        [Pure]
        public static T ResetInline<T>(this T toolSettings) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Inline = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DiscordEmbedField.Inline"/></em></p>
        ///   <p>Whether or not this field should siplay inline.</p>
        /// </summary>
        [Pure]
        public static T EnableInline<T>(this T toolSettings) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Inline = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DiscordEmbedField.Inline"/></em></p>
        ///   <p>Whether or not this field should siplay inline.</p>
        /// </summary>
        [Pure]
        public static T DisableInline<T>(this T toolSettings) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Inline = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DiscordEmbedField.Inline"/></em></p>
        ///   <p>Whether or not this field should siplay inline.</p>
        /// </summary>
        [Pure]
        public static T ToggleInline<T>(this T toolSettings) where T : DiscordEmbedField
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Inline = !toolSettings.Inline;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DiscordEmbedType
    /// <summary>
    ///   Used within <see cref="DiscordTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<DiscordEmbedType>))]
    public partial class DiscordEmbedType : Enumeration
    {
        public static DiscordEmbedType rich = (DiscordEmbedType) "rich";
        public static DiscordEmbedType image = (DiscordEmbedType) "image";
        public static DiscordEmbedType video = (DiscordEmbedType) "video";
        public static DiscordEmbedType gifv = (DiscordEmbedType) "gifv";
        public static DiscordEmbedType article = (DiscordEmbedType) "article";
        public static DiscordEmbedType link = (DiscordEmbedType) "link";
        public static implicit operator DiscordEmbedType(string value)
        {
            return new DiscordEmbedType { Value = value };
        }
    }
    #endregion
}
