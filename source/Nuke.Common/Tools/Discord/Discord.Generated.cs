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

namespace Nuke.Common.Tools.Discord;

#region DiscordMessage
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DiscordMessage>))]
public partial class DiscordMessage : Options
{
    /// <summary>Id of the channel.</summary>
    [JsonProperty("channel_id")] public string ChannelId => Get<string>(() => ChannelId);
    /// <summary>Message contents (up to 2000 characters).</summary>
    [JsonProperty("content")] public string Content => Get<string>(() => Content);
    /// <summary>Can be used to verify a message was sent (up to 25 characters). Value will appear in the <a href="https://discord.com/developers/docs/topics/gateway-events#message-create">Message Create event</a>.</summary>
    [JsonProperty("nonce")] public string Nonce => Get<string>(() => Nonce);
    /// <summary>Whether this is a TTS message.</summary>
    [JsonProperty("tts")] public bool? TTS => Get<bool?>(() => TTS);
    /// <summary>Embedded rich content (up to 6000 characters). See <a href="https://autocode.com/tools/discord/embed-builder/">Discord Embed Builder</a>.</summary>
    [JsonProperty("embeds")] public IReadOnlyList<DiscordEmbed> Embeds => Get<List<DiscordEmbed>>(() => Embeds);
}
#endregion
#region DiscordEmbed
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DiscordEmbed>))]
public partial class DiscordEmbed : Options
{
    /// <summary>Title of embed.</summary>
    [JsonProperty("title")] public string Title => Get<string>(() => Title);
    /// <summary><a href="https://discord.com/developers/docs/resources/channel#embed-object-embed-types">Type of embed</a> (always <c>rich</c> for webhook embeds).</summary>
    [JsonProperty("type")] public DiscordEmbedType Type => Get<DiscordEmbedType>(() => Type);
    /// <summary>Description of embed.</summary>
    [JsonProperty("description")] public string Description => Get<string>(() => Description);
    /// <summary>Url of embed.</summary>
    [JsonProperty("url")] public string Url => Get<string>(() => Url);
    /// <summary>ISO8601 timestamp of embed.</summary>
    [JsonProperty("timestamp")] public string Timestamp => Get<string>(() => Timestamp);
    /// <summary>Color code of the embed.</summary>
    [JsonProperty("color")] public int? Color => Get<int?>(() => Color);
    /// <summary>Footer information.</summary>
    [JsonProperty("footer")] public DiscordEmbedFooter Footer => Get<DiscordEmbedFooter>(() => Footer);
    /// <summary>Image information.</summary>
    [JsonProperty("image")] public DiscordEmbedImage Image => Get<DiscordEmbedImage>(() => Image);
    /// <summary>Thumbnail information.</summary>
    [JsonProperty("thumbnail")] public DiscordEmbedThumbnail Thumbnail => Get<DiscordEmbedThumbnail>(() => Thumbnail);
    /// <summary>Author information.</summary>
    [JsonProperty("author")] public DiscordEmbedAuthor Author => Get<DiscordEmbedAuthor>(() => Author);
    /// <summary>Fields information.</summary>
    [JsonProperty("fields")] public IReadOnlyList<DiscordEmbedField> Fields => Get<List<DiscordEmbedField>>(() => Fields);
}
#endregion
#region DiscordEmbedFooter
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DiscordEmbedFooter>))]
public partial class DiscordEmbedFooter : Options
{
    /// <summary>Footer text.</summary>
    [JsonProperty("text")] public string Text => Get<string>(() => Text);
    /// <summary>Url of footer icon (only supports http(s) and attachments).</summary>
    [JsonProperty("icon_url")] public string IconUrl => Get<string>(() => IconUrl);
}
#endregion
#region DiscordEmbedImage
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DiscordEmbedImage>))]
public partial class DiscordEmbedImage : Options
{
    /// <summary>Source url of image (only supports http(s) and attachments).</summary>
    [JsonProperty("url")] public string Url => Get<string>(() => Url);
    /// <summary>Height of image.</summary>
    [JsonProperty("height")] public int? Height => Get<int?>(() => Height);
    /// <summary>Width of image.</summary>
    [JsonProperty("width")] public int? Width => Get<int?>(() => Width);
}
#endregion
#region DiscordEmbedThumbnail
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DiscordEmbedThumbnail>))]
public partial class DiscordEmbedThumbnail : Options
{
    /// <summary>Source url of thumbnail (only supports http(s) and attachments).</summary>
    [JsonProperty("url")] public string Url => Get<string>(() => Url);
    /// <summary>Height of thumbnail.</summary>
    [JsonProperty("height")] public int? Height => Get<int?>(() => Height);
    /// <summary>Width of thumbnail.</summary>
    [JsonProperty("width")] public int? Width => Get<int?>(() => Width);
}
#endregion
#region DiscordEmbedAuthor
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DiscordEmbedAuthor>))]
public partial class DiscordEmbedAuthor : Options
{
    /// <summary>Name of author.</summary>
    [JsonProperty("name")] public string Name => Get<string>(() => Name);
    /// <summary>Url of author.</summary>
    [JsonProperty("url")] public string Url => Get<string>(() => Url);
    /// <summary>Url of author icon (only supports http(s) and attachments).</summary>
    [JsonProperty("icon_url")] public string IconUrl => Get<string>(() => IconUrl);
}
#endregion
#region DiscordEmbedField
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DiscordEmbedField>))]
public partial class DiscordEmbedField : Options
{
    /// <summary>Name of the field.</summary>
    [JsonProperty("name")] public string Name => Get<string>(() => Name);
    /// <summary>Value of the field.</summary>
    [JsonProperty("value")] public string Value => Get<string>(() => Value);
    /// <summary>Whether or not this field should siplay inline.</summary>
    [JsonProperty("inline")] public bool? Inline => Get<bool?>(() => Inline);
}
#endregion
#region DiscordMessageExtensions
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DiscordMessageExtensions
{
    #region ChannelId
    /// <inheritdoc cref="DiscordMessage.ChannelId"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.ChannelId))]
    public static T SetChannelId<T>(this T o, string v) where T : DiscordMessage => o.Modify(b => b.Set(() => o.ChannelId, v));
    /// <inheritdoc cref="DiscordMessage.ChannelId"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.ChannelId))]
    public static T ResetChannelId<T>(this T o) where T : DiscordMessage => o.Modify(b => b.Remove(() => o.ChannelId));
    #endregion
    #region Content
    /// <inheritdoc cref="DiscordMessage.Content"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Content))]
    public static T SetContent<T>(this T o, string v) where T : DiscordMessage => o.Modify(b => b.Set(() => o.Content, v));
    /// <inheritdoc cref="DiscordMessage.Content"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Content))]
    public static T ResetContent<T>(this T o) where T : DiscordMessage => o.Modify(b => b.Remove(() => o.Content));
    #endregion
    #region Nonce
    /// <inheritdoc cref="DiscordMessage.Nonce"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Nonce))]
    public static T SetNonce<T>(this T o, string v) where T : DiscordMessage => o.Modify(b => b.Set(() => o.Nonce, v));
    /// <inheritdoc cref="DiscordMessage.Nonce"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Nonce))]
    public static T ResetNonce<T>(this T o) where T : DiscordMessage => o.Modify(b => b.Remove(() => o.Nonce));
    #endregion
    #region TTS
    /// <inheritdoc cref="DiscordMessage.TTS"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.TTS))]
    public static T SetTTS<T>(this T o, bool? v) where T : DiscordMessage => o.Modify(b => b.Set(() => o.TTS, v));
    /// <inheritdoc cref="DiscordMessage.TTS"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.TTS))]
    public static T ResetTTS<T>(this T o) where T : DiscordMessage => o.Modify(b => b.Remove(() => o.TTS));
    /// <inheritdoc cref="DiscordMessage.TTS"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.TTS))]
    public static T EnableTTS<T>(this T o) where T : DiscordMessage => o.Modify(b => b.Set(() => o.TTS, true));
    /// <inheritdoc cref="DiscordMessage.TTS"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.TTS))]
    public static T DisableTTS<T>(this T o) where T : DiscordMessage => o.Modify(b => b.Set(() => o.TTS, false));
    /// <inheritdoc cref="DiscordMessage.TTS"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.TTS))]
    public static T ToggleTTS<T>(this T o) where T : DiscordMessage => o.Modify(b => b.Set(() => o.TTS, !o.TTS));
    #endregion
    #region Embeds
    /// <inheritdoc cref="DiscordMessage.Embeds"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Embeds))]
    public static T SetEmbeds<T>(this T o, params DiscordEmbed[] v) where T : DiscordMessage => o.Modify(b => b.Set(() => o.Embeds, v));
    /// <inheritdoc cref="DiscordMessage.Embeds"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Embeds))]
    public static T SetEmbeds<T>(this T o, IEnumerable<DiscordEmbed> v) where T : DiscordMessage => o.Modify(b => b.Set(() => o.Embeds, v));
    /// <inheritdoc cref="DiscordMessage.Embeds"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Embeds))]
    public static T AddEmbeds<T>(this T o, params DiscordEmbed[] v) where T : DiscordMessage => o.Modify(b => b.AddCollection(() => o.Embeds, v));
    /// <inheritdoc cref="DiscordMessage.Embeds"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Embeds))]
    public static T AddEmbeds<T>(this T o, IEnumerable<DiscordEmbed> v) where T : DiscordMessage => o.Modify(b => b.AddCollection(() => o.Embeds, v));
    /// <inheritdoc cref="DiscordMessage.Embeds"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Embeds))]
    public static T AddEmbeds<T>(this T o, Configure<DiscordEmbed> v) where T : DiscordMessage => o.Modify(b => b.AddCollection(() => o.Embeds, v.InvokeSafe(new())));
    /// <inheritdoc cref="DiscordMessage.Embeds"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Embeds))]
    public static T RemoveEmbeds<T>(this T o, params DiscordEmbed[] v) where T : DiscordMessage => o.Modify(b => b.RemoveCollection(() => o.Embeds, v));
    /// <inheritdoc cref="DiscordMessage.Embeds"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Embeds))]
    public static T RemoveEmbeds<T>(this T o, IEnumerable<DiscordEmbed> v) where T : DiscordMessage => o.Modify(b => b.RemoveCollection(() => o.Embeds, v));
    /// <inheritdoc cref="DiscordMessage.Embeds"/>
    [Pure] [Builder(Type = typeof(DiscordMessage), Property = nameof(DiscordMessage.Embeds))]
    public static T ClearEmbeds<T>(this T o) where T : DiscordMessage => o.Modify(b => b.ClearCollection(() => o.Embeds));
    #endregion
}
#endregion
#region DiscordEmbedExtensions
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DiscordEmbedExtensions
{
    #region Title
    /// <inheritdoc cref="DiscordEmbed.Title"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Title))]
    public static T SetTitle<T>(this T o, string v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Title, v));
    /// <inheritdoc cref="DiscordEmbed.Title"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Title))]
    public static T ResetTitle<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Title));
    #endregion
    #region Type
    /// <inheritdoc cref="DiscordEmbed.Type"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Type))]
    public static T SetType<T>(this T o, DiscordEmbedType v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Type, v));
    /// <inheritdoc cref="DiscordEmbed.Type"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Type))]
    public static T ResetType<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Type));
    #endregion
    #region Description
    /// <inheritdoc cref="DiscordEmbed.Description"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Description))]
    public static T SetDescription<T>(this T o, string v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="DiscordEmbed.Description"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Description))]
    public static T ResetDescription<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region Url
    /// <inheritdoc cref="DiscordEmbed.Url"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Url))]
    public static T SetUrl<T>(this T o, string v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="DiscordEmbed.Url"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Url))]
    public static T ResetUrl<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region Timestamp
    /// <inheritdoc cref="DiscordEmbed.Timestamp"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Timestamp))]
    public static T SetTimestamp<T>(this T o, string v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Timestamp, v));
    /// <inheritdoc cref="DiscordEmbed.Timestamp"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Timestamp))]
    public static T ResetTimestamp<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Timestamp));
    #endregion
    #region Color
    /// <inheritdoc cref="DiscordEmbed.Color"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Color))]
    public static T SetColor<T>(this T o, int? v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="DiscordEmbed.Color"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Color))]
    public static T ResetColor<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Footer
    /// <inheritdoc cref="DiscordEmbed.Footer"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Footer))]
    public static T SetFooter<T>(this T o, DiscordEmbedFooter v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Footer, v));
    /// <inheritdoc cref="DiscordEmbed.Footer"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Footer))]
    public static T SetFooter<T>(this T o, Configure<DiscordEmbedFooter> v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Footer,  v.InvokeSafe(new())));
    /// <inheritdoc cref="DiscordEmbed.Footer"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Footer))]
    public static T ResetFooter<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Footer));
    #endregion
    #region Image
    /// <inheritdoc cref="DiscordEmbed.Image"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Image))]
    public static T SetImage<T>(this T o, DiscordEmbedImage v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Image, v));
    /// <inheritdoc cref="DiscordEmbed.Image"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Image))]
    public static T SetImage<T>(this T o, Configure<DiscordEmbedImage> v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Image,  v.InvokeSafe(new())));
    /// <inheritdoc cref="DiscordEmbed.Image"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Image))]
    public static T ResetImage<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Image));
    #endregion
    #region Thumbnail
    /// <inheritdoc cref="DiscordEmbed.Thumbnail"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Thumbnail))]
    public static T SetThumbnail<T>(this T o, DiscordEmbedThumbnail v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Thumbnail, v));
    /// <inheritdoc cref="DiscordEmbed.Thumbnail"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Thumbnail))]
    public static T SetThumbnail<T>(this T o, Configure<DiscordEmbedThumbnail> v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Thumbnail,  v.InvokeSafe(new())));
    /// <inheritdoc cref="DiscordEmbed.Thumbnail"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Thumbnail))]
    public static T ResetThumbnail<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Thumbnail));
    #endregion
    #region Author
    /// <inheritdoc cref="DiscordEmbed.Author"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Author))]
    public static T SetAuthor<T>(this T o, DiscordEmbedAuthor v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Author, v));
    /// <inheritdoc cref="DiscordEmbed.Author"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Author))]
    public static T SetAuthor<T>(this T o, Configure<DiscordEmbedAuthor> v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Author,  v.InvokeSafe(new())));
    /// <inheritdoc cref="DiscordEmbed.Author"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Author))]
    public static T ResetAuthor<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.Remove(() => o.Author));
    #endregion
    #region Fields
    /// <inheritdoc cref="DiscordEmbed.Fields"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Fields))]
    public static T SetFields<T>(this T o, params DiscordEmbedField[] v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Fields, v));
    /// <inheritdoc cref="DiscordEmbed.Fields"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Fields))]
    public static T SetFields<T>(this T o, IEnumerable<DiscordEmbedField> v) where T : DiscordEmbed => o.Modify(b => b.Set(() => o.Fields, v));
    /// <inheritdoc cref="DiscordEmbed.Fields"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Fields))]
    public static T AddFields<T>(this T o, params DiscordEmbedField[] v) where T : DiscordEmbed => o.Modify(b => b.AddCollection(() => o.Fields, v));
    /// <inheritdoc cref="DiscordEmbed.Fields"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Fields))]
    public static T AddFields<T>(this T o, IEnumerable<DiscordEmbedField> v) where T : DiscordEmbed => o.Modify(b => b.AddCollection(() => o.Fields, v));
    /// <inheritdoc cref="DiscordEmbed.Fields"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Fields))]
    public static T AddFields<T>(this T o, Configure<DiscordEmbedField> v) where T : DiscordEmbed => o.Modify(b => b.AddCollection(() => o.Fields, v.InvokeSafe(new())));
    /// <inheritdoc cref="DiscordEmbed.Fields"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Fields))]
    public static T RemoveFields<T>(this T o, params DiscordEmbedField[] v) where T : DiscordEmbed => o.Modify(b => b.RemoveCollection(() => o.Fields, v));
    /// <inheritdoc cref="DiscordEmbed.Fields"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Fields))]
    public static T RemoveFields<T>(this T o, IEnumerable<DiscordEmbedField> v) where T : DiscordEmbed => o.Modify(b => b.RemoveCollection(() => o.Fields, v));
    /// <inheritdoc cref="DiscordEmbed.Fields"/>
    [Pure] [Builder(Type = typeof(DiscordEmbed), Property = nameof(DiscordEmbed.Fields))]
    public static T ClearFields<T>(this T o) where T : DiscordEmbed => o.Modify(b => b.ClearCollection(() => o.Fields));
    #endregion
}
#endregion
#region DiscordEmbedFooterExtensions
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DiscordEmbedFooterExtensions
{
    #region Text
    /// <inheritdoc cref="DiscordEmbedFooter.Text"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedFooter), Property = nameof(DiscordEmbedFooter.Text))]
    public static T SetText<T>(this T o, string v) where T : DiscordEmbedFooter => o.Modify(b => b.Set(() => o.Text, v));
    /// <inheritdoc cref="DiscordEmbedFooter.Text"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedFooter), Property = nameof(DiscordEmbedFooter.Text))]
    public static T ResetText<T>(this T o) where T : DiscordEmbedFooter => o.Modify(b => b.Remove(() => o.Text));
    #endregion
    #region IconUrl
    /// <inheritdoc cref="DiscordEmbedFooter.IconUrl"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedFooter), Property = nameof(DiscordEmbedFooter.IconUrl))]
    public static T SetIconUrl<T>(this T o, string v) where T : DiscordEmbedFooter => o.Modify(b => b.Set(() => o.IconUrl, v));
    /// <inheritdoc cref="DiscordEmbedFooter.IconUrl"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedFooter), Property = nameof(DiscordEmbedFooter.IconUrl))]
    public static T ResetIconUrl<T>(this T o) where T : DiscordEmbedFooter => o.Modify(b => b.Remove(() => o.IconUrl));
    #endregion
}
#endregion
#region DiscordEmbedImageExtensions
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DiscordEmbedImageExtensions
{
    #region Url
    /// <inheritdoc cref="DiscordEmbedImage.Url"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedImage), Property = nameof(DiscordEmbedImage.Url))]
    public static T SetUrl<T>(this T o, string v) where T : DiscordEmbedImage => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="DiscordEmbedImage.Url"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedImage), Property = nameof(DiscordEmbedImage.Url))]
    public static T ResetUrl<T>(this T o) where T : DiscordEmbedImage => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region Height
    /// <inheritdoc cref="DiscordEmbedImage.Height"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedImage), Property = nameof(DiscordEmbedImage.Height))]
    public static T SetHeight<T>(this T o, int? v) where T : DiscordEmbedImage => o.Modify(b => b.Set(() => o.Height, v));
    /// <inheritdoc cref="DiscordEmbedImage.Height"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedImage), Property = nameof(DiscordEmbedImage.Height))]
    public static T ResetHeight<T>(this T o) where T : DiscordEmbedImage => o.Modify(b => b.Remove(() => o.Height));
    #endregion
    #region Width
    /// <inheritdoc cref="DiscordEmbedImage.Width"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedImage), Property = nameof(DiscordEmbedImage.Width))]
    public static T SetWidth<T>(this T o, int? v) where T : DiscordEmbedImage => o.Modify(b => b.Set(() => o.Width, v));
    /// <inheritdoc cref="DiscordEmbedImage.Width"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedImage), Property = nameof(DiscordEmbedImage.Width))]
    public static T ResetWidth<T>(this T o) where T : DiscordEmbedImage => o.Modify(b => b.Remove(() => o.Width));
    #endregion
}
#endregion
#region DiscordEmbedThumbnailExtensions
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DiscordEmbedThumbnailExtensions
{
    #region Url
    /// <inheritdoc cref="DiscordEmbedThumbnail.Url"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedThumbnail), Property = nameof(DiscordEmbedThumbnail.Url))]
    public static T SetUrl<T>(this T o, string v) where T : DiscordEmbedThumbnail => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="DiscordEmbedThumbnail.Url"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedThumbnail), Property = nameof(DiscordEmbedThumbnail.Url))]
    public static T ResetUrl<T>(this T o) where T : DiscordEmbedThumbnail => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region Height
    /// <inheritdoc cref="DiscordEmbedThumbnail.Height"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedThumbnail), Property = nameof(DiscordEmbedThumbnail.Height))]
    public static T SetHeight<T>(this T o, int? v) where T : DiscordEmbedThumbnail => o.Modify(b => b.Set(() => o.Height, v));
    /// <inheritdoc cref="DiscordEmbedThumbnail.Height"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedThumbnail), Property = nameof(DiscordEmbedThumbnail.Height))]
    public static T ResetHeight<T>(this T o) where T : DiscordEmbedThumbnail => o.Modify(b => b.Remove(() => o.Height));
    #endregion
    #region Width
    /// <inheritdoc cref="DiscordEmbedThumbnail.Width"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedThumbnail), Property = nameof(DiscordEmbedThumbnail.Width))]
    public static T SetWidth<T>(this T o, int? v) where T : DiscordEmbedThumbnail => o.Modify(b => b.Set(() => o.Width, v));
    /// <inheritdoc cref="DiscordEmbedThumbnail.Width"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedThumbnail), Property = nameof(DiscordEmbedThumbnail.Width))]
    public static T ResetWidth<T>(this T o) where T : DiscordEmbedThumbnail => o.Modify(b => b.Remove(() => o.Width));
    #endregion
}
#endregion
#region DiscordEmbedAuthorExtensions
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DiscordEmbedAuthorExtensions
{
    #region Name
    /// <inheritdoc cref="DiscordEmbedAuthor.Name"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedAuthor), Property = nameof(DiscordEmbedAuthor.Name))]
    public static T SetName<T>(this T o, string v) where T : DiscordEmbedAuthor => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="DiscordEmbedAuthor.Name"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedAuthor), Property = nameof(DiscordEmbedAuthor.Name))]
    public static T ResetName<T>(this T o) where T : DiscordEmbedAuthor => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Url
    /// <inheritdoc cref="DiscordEmbedAuthor.Url"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedAuthor), Property = nameof(DiscordEmbedAuthor.Url))]
    public static T SetUrl<T>(this T o, string v) where T : DiscordEmbedAuthor => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="DiscordEmbedAuthor.Url"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedAuthor), Property = nameof(DiscordEmbedAuthor.Url))]
    public static T ResetUrl<T>(this T o) where T : DiscordEmbedAuthor => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region IconUrl
    /// <inheritdoc cref="DiscordEmbedAuthor.IconUrl"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedAuthor), Property = nameof(DiscordEmbedAuthor.IconUrl))]
    public static T SetIconUrl<T>(this T o, string v) where T : DiscordEmbedAuthor => o.Modify(b => b.Set(() => o.IconUrl, v));
    /// <inheritdoc cref="DiscordEmbedAuthor.IconUrl"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedAuthor), Property = nameof(DiscordEmbedAuthor.IconUrl))]
    public static T ResetIconUrl<T>(this T o) where T : DiscordEmbedAuthor => o.Modify(b => b.Remove(() => o.IconUrl));
    #endregion
}
#endregion
#region DiscordEmbedFieldExtensions
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DiscordEmbedFieldExtensions
{
    #region Name
    /// <inheritdoc cref="DiscordEmbedField.Name"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Name))]
    public static T SetName<T>(this T o, string v) where T : DiscordEmbedField => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="DiscordEmbedField.Name"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Name))]
    public static T ResetName<T>(this T o) where T : DiscordEmbedField => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Value
    /// <inheritdoc cref="DiscordEmbedField.Value"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Value))]
    public static T SetValue<T>(this T o, string v) where T : DiscordEmbedField => o.Modify(b => b.Set(() => o.Value, v));
    /// <inheritdoc cref="DiscordEmbedField.Value"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Value))]
    public static T ResetValue<T>(this T o) where T : DiscordEmbedField => o.Modify(b => b.Remove(() => o.Value));
    #endregion
    #region Inline
    /// <inheritdoc cref="DiscordEmbedField.Inline"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Inline))]
    public static T SetInline<T>(this T o, bool? v) where T : DiscordEmbedField => o.Modify(b => b.Set(() => o.Inline, v));
    /// <inheritdoc cref="DiscordEmbedField.Inline"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Inline))]
    public static T ResetInline<T>(this T o) where T : DiscordEmbedField => o.Modify(b => b.Remove(() => o.Inline));
    /// <inheritdoc cref="DiscordEmbedField.Inline"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Inline))]
    public static T EnableInline<T>(this T o) where T : DiscordEmbedField => o.Modify(b => b.Set(() => o.Inline, true));
    /// <inheritdoc cref="DiscordEmbedField.Inline"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Inline))]
    public static T DisableInline<T>(this T o) where T : DiscordEmbedField => o.Modify(b => b.Set(() => o.Inline, false));
    /// <inheritdoc cref="DiscordEmbedField.Inline"/>
    [Pure] [Builder(Type = typeof(DiscordEmbedField), Property = nameof(DiscordEmbedField.Inline))]
    public static T ToggleInline<T>(this T o) where T : DiscordEmbedField => o.Modify(b => b.Set(() => o.Inline, !o.Inline));
    #endregion
}
#endregion
#region DiscordEmbedType
/// <summary>Used within <see cref="DiscordTasks"/>.</summary>
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
