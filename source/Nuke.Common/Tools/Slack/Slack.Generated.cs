// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Slack/Slack.json

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

namespace Nuke.Common.Tools.Slack;

#region SlackMessage
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SlackMessage>))]
public partial class SlackMessage : Options
{
    /// <summary></summary>
    [JsonProperty("ts")] public string Timestamp => Get<string>(() => Timestamp);
    /// <summary></summary>
    [JsonProperty("thread_ts")] public string ThreadTimestamp => Get<string>(() => ThreadTimestamp);
    /// <summary></summary>
    [JsonProperty("channel")] public string Channel => Get<string>(() => Channel);
    /// <summary></summary>
    [JsonProperty("username")] public string Username => Get<string>(() => Username);
    /// <summary>Slack messages may be formatted using a simple markup language similar to <a href="https://daringfireball.net/projects/markdown/">Markdown</a>. Supported formatting includes: <c>```pre```</c>, <c>`code`</c>, <c>_italic_</c>, <c>*bold*</c>, and even <c>~strike~</c>.; full details are available on our <a href="https://slack.zendesk.com/hc/en-us/articles/202288908-how-can-i-add-formatting-to-my-messages-?sid=zd-up-t0288d531-u0a5kka1k">help site</a>.</summary>
    [JsonProperty("text")] public string Text => Get<string>(() => Text);
    /// <summary>By default bot message text will be formatted. To disable formatting on a non-user message, set the <c>mrkdwn</c> property to <c>false</c>.</summary>
    [JsonProperty("mrkdwn")] public bool? Markdown => Get<bool?>(() => Markdown);
    /// <summary></summary>
    [JsonProperty("icon_emoji")] public string Emoji => Get<string>(() => Emoji);
    /// <summary></summary>
    [JsonProperty("icon_url")] public string Icon => Get<string>(() => Icon);
    /// <summary>Attachments let you add more context to a message, making them more useful and effective.</summary>
    [JsonProperty("attachments")] public IReadOnlyList<SlackMessageAttachment> Attachments => Get<List<SlackMessageAttachment>>(() => Attachments);
}
#endregion
#region SlackMessageAttachment
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SlackMessageAttachment>))]
public partial class SlackMessageAttachment : Options
{
    /// <summary>The title is displayed as larger, bold text near the top of a message attachment.</summary>
    [JsonProperty("title")] public string Title => Get<string>(() => Title);
    /// <summary>Hyperlink used for the title.</summary>
    [JsonProperty("title_link")] public string TitleLink => Get<string>(() => TitleLink);
    /// <summary>This is optional text that appears above the message attachment block.</summary>
    [JsonProperty("pretext")] public string PreText => Get<string>(() => PreText);
    /// <summary>This is the main text in a message attachment, and can contain <a href="https://api.slack.com/docs/message-formatting">standard message markup</a>. The content will automatically collapse if it contains <b>700+ characters</b> or <b>5+ linebreaks</b>, and will display a "Show more..." link to expand the content. Links posted in the <c>text</c> field will not unfurl.</summary>
    [JsonProperty("text")] public string Text => Get<string>(() => Text);
    /// <summary>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</summary>
    [JsonProperty("mrkdwn_in")] public IReadOnlyList<string> MarkdownIn => Get<List<string>>(() => MarkdownIn);
    /// <summary>A plain-text summary of the attachment. This text will be used in clients that don't show formatted text (eg. IRC, mobile notifications) and should not contain any markup.</summary>
    [JsonProperty("fallback")] public string Fallback => Get<string>(() => Fallback);
    /// <summary>Like traffic signals, color-coding messages can quickly communicate intent and help separate them from the flow of other messages in the timeline.<para/>An optional value that can either be one of good, warning, danger, or any hex color code (eg. #439FE0). This value is used to color the border along the left side of the message attachment.</summary>
    [JsonProperty("color")] public string Color => Get<string>(() => Color);
    /// <summary>Small text used to display the author's name.</summary>
    [JsonProperty("author_name")] public string AuthorName => Get<string>(() => AuthorName);
    /// <summary>A valid URL that will hyperlink the <c>author_name</c> text mentioned above. Will only work if <c>author_name</c> is present.</summary>
    [JsonProperty("author_link")] public string AuthorLink => Get<string>(() => AuthorLink);
    /// <summary>A valid URL that displays a small 16x16px image to the left of the <c>author_name</c> text. Will only work if <c>author_name</c> is present.</summary>
    [JsonProperty("author_icon")] public string AuthorIcon => Get<string>(() => AuthorIcon);
    /// <summary>A valid URL to an image file that will be displayed inside a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.<para/>Large images will be resized to a maximum width of 360px or a maximum height of 500px, while still maintaining the original aspect ratio.</summary>
    [JsonProperty("image_url")] public string ImageUrl => Get<string>(() => ImageUrl);
    /// <summary>A valid URL to an image file that will be displayed as a thumbnail on the right side of a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.<para/>The thumbnail's longest dimension will be scaled down to 75px while maintaining the aspect ratio of the image. The filesize of the image must also be less than 500 KB.<para/>For best results, please use images that are already 75px by 75px.</summary>
    [JsonProperty("thumb_url")] public string ThumbUrl => Get<string>(() => ThumbUrl);
    /// <summary>Add some brief text to help contextualize and identify an attachment. Limited to 300 characters, and may be truncated further when displayed to users in environments with limited screen real estate.</summary>
    [JsonProperty("footer")] public string Footer => Get<string>(() => Footer);
    /// <summary>To render a small icon beside your <c>footer</c> text, provide a publicly accessible URL string in the <c>footer_icon</c> field. You must also provide a <c>footer</c> for the field to be recognized.<para/>We'll render what you provide at 16px by 16px. It's best to use an image that is similarly sized.<para/>Example: <c>https://platform.slack-edge.com/img/default_application_icon.png</c></summary>
    [JsonProperty("footer_icon")] public string FooterIcon => Get<string>(() => FooterIcon);
    /// <summary>Does your attachment relate to something happening at a specific time?<para/>By providing the <c>ts</c> field with an integer value in "<a href="https://en.wikipedia.org/wiki/Unix_time">epoch time</a>", the attachment will display an additional timestamp value as part of the attachment's footer.<para/>Use <c>ts</c> when referencing articles or happenings. Your message will have its own timestamp when published.<para/>Example: Providing <c>123456789</c> would result in a rendered timestamp of <em>Nov 29th, 1973</em>.</summary>
    [JsonProperty("ts")] public string Timestamp => Get<string>(() => Timestamp);
    /// <summary>Fields get displayed in a table-like way.</summary>
    [JsonProperty("fields")] public IReadOnlyList<SlackMessageField> Fields => Get<List<SlackMessageField>>(() => Fields);
    /// <summary>A collection of Action objects to include in the attachment. Cannot exceed 5 elements.</summary>
    [JsonProperty("actions")] public IReadOnlyList<SlackMessageAction> Actions => Get<List<SlackMessageAction>>(() => Actions);
    /// <summary>The callback id sent to the interactive message endpoint.</summary>
    [JsonProperty("callback_id")] public string CallbackId => Get<string>(() => CallbackId);
}
#endregion
#region SlackMessageField
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SlackMessageField>))]
public partial class SlackMessageField : Options
{
    /// <summary>Shown as a bold heading above the <c>value</c> text. It cannot contain markup and will be escaped for you.</summary>
    [JsonProperty("title")] public string Title => Get<string>(() => Title);
    /// <summary>The text value of the field. It may contain <a href="https://api.slack.com/docs/message-formatting">standard message markup</a> and must be escaped as normal. May be multi-line.</summary>
    [JsonProperty("value")] public string Value => Get<string>(() => Value);
    /// <summary>An optional flag indicating whether the <c>value</c> is short enough to be displayed side-by-side with other values.</summary>
    [JsonProperty("short")] public bool? Short => Get<bool?>(() => Short);
}
#endregion
#region SlackMessageAction
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SlackMessageAction>))]
public partial class SlackMessageAction : Options
{
    /// <summary>Name this specific action. The name will be returned to your Action URL along with the message's <c>callback_id</c> when this action is invoked. Use it to identify this particular response path.</summary>
    [JsonProperty("name")] public string Name => Get<string>(() => Name);
    /// <summary>The user-facing label for the message button or menu representing this action. Cannot contain markup.</summary>
    [JsonProperty("text")] public string Text => Get<string>(() => Text);
    /// <summary>Provide a string identifying this specific action. It will be sent to your Action URL along with the name and attachment's <c>callback_id</c> . If providing multiple actions with the same name, value can be strategically used to differentiate intent. Cannot exceed <c>2000</c> characters.</summary>
    [JsonProperty("value")] public string Value => Get<string>(() => Value);
    /// <summary>Leave blank to indicate that this is an ordinary button. Use <c>primary</c> or <c>danger</c> to mark important buttons.</summary>
    [JsonProperty("style")] public SlackMessageActionStyle Style => Get<SlackMessageActionStyle>(() => Style);
    /// <summary>Shows a confirmation dialog when the action is selected.</summary>
    [JsonProperty("confirm")] public SlackMessageConfirmation Confirmation => Get<SlackMessageConfirmation>(() => Confirmation);
}
#endregion
#region SlackMessageConfirmation
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SlackMessageConfirmation>))]
public partial class SlackMessageConfirmation : Options
{
    /// <summary>Title of the confirmation dialog.</summary>
    [JsonProperty("title")] public string Title => Get<string>(() => Title);
    /// <summary>Text of the confirmation dialog.</summary>
    [JsonProperty("text")] public string Text => Get<string>(() => Text);
    /// <summary>Confirm button text of the confirmation dialog.</summary>
    [JsonProperty("ok_text")] public string OkText => Get<string>(() => OkText);
    /// <summary>Dismiss button text of the confirmation dialog.</summary>
    [JsonProperty("dismiss_text")] public string DismissText => Get<string>(() => DismissText);
}
#endregion
#region SlackMessageExtensions
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SlackMessageExtensions
{
    #region Timestamp
    /// <inheritdoc cref="SlackMessage.Timestamp"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Timestamp))]
    public static T SetTimestamp<T>(this T o, string v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Timestamp, v));
    /// <inheritdoc cref="SlackMessage.Timestamp"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Timestamp))]
    public static T ResetTimestamp<T>(this T o) where T : SlackMessage => o.Modify(b => b.Remove(() => o.Timestamp));
    #endregion
    #region ThreadTimestamp
    /// <inheritdoc cref="SlackMessage.ThreadTimestamp"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.ThreadTimestamp))]
    public static T SetThreadTimestamp<T>(this T o, string v) where T : SlackMessage => o.Modify(b => b.Set(() => o.ThreadTimestamp, v));
    /// <inheritdoc cref="SlackMessage.ThreadTimestamp"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.ThreadTimestamp))]
    public static T ResetThreadTimestamp<T>(this T o) where T : SlackMessage => o.Modify(b => b.Remove(() => o.ThreadTimestamp));
    #endregion
    #region Channel
    /// <inheritdoc cref="SlackMessage.Channel"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Channel))]
    public static T SetChannel<T>(this T o, string v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Channel, v));
    /// <inheritdoc cref="SlackMessage.Channel"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Channel))]
    public static T ResetChannel<T>(this T o) where T : SlackMessage => o.Modify(b => b.Remove(() => o.Channel));
    #endregion
    #region Username
    /// <inheritdoc cref="SlackMessage.Username"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Username))]
    public static T SetUsername<T>(this T o, string v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="SlackMessage.Username"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Username))]
    public static T ResetUsername<T>(this T o) where T : SlackMessage => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Text
    /// <inheritdoc cref="SlackMessage.Text"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Text))]
    public static T SetText<T>(this T o, string v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Text, v));
    /// <inheritdoc cref="SlackMessage.Text"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Text))]
    public static T ResetText<T>(this T o) where T : SlackMessage => o.Modify(b => b.Remove(() => o.Text));
    #endregion
    #region Markdown
    /// <inheritdoc cref="SlackMessage.Markdown"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Markdown))]
    public static T SetMarkdown<T>(this T o, bool? v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Markdown, v));
    /// <inheritdoc cref="SlackMessage.Markdown"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Markdown))]
    public static T ResetMarkdown<T>(this T o) where T : SlackMessage => o.Modify(b => b.Remove(() => o.Markdown));
    /// <inheritdoc cref="SlackMessage.Markdown"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Markdown))]
    public static T EnableMarkdown<T>(this T o) where T : SlackMessage => o.Modify(b => b.Set(() => o.Markdown, true));
    /// <inheritdoc cref="SlackMessage.Markdown"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Markdown))]
    public static T DisableMarkdown<T>(this T o) where T : SlackMessage => o.Modify(b => b.Set(() => o.Markdown, false));
    /// <inheritdoc cref="SlackMessage.Markdown"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Markdown))]
    public static T ToggleMarkdown<T>(this T o) where T : SlackMessage => o.Modify(b => b.Set(() => o.Markdown, !o.Markdown));
    #endregion
    #region Emoji
    /// <inheritdoc cref="SlackMessage.Emoji"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Emoji))]
    public static T SetEmoji<T>(this T o, string v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="SlackMessage.Emoji"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : SlackMessage => o.Modify(b => b.Remove(() => o.Emoji));
    #endregion
    #region Icon
    /// <inheritdoc cref="SlackMessage.Icon"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Icon))]
    public static T SetIcon<T>(this T o, string v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Icon, v));
    /// <inheritdoc cref="SlackMessage.Icon"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Icon))]
    public static T ResetIcon<T>(this T o) where T : SlackMessage => o.Modify(b => b.Remove(() => o.Icon));
    #endregion
    #region Attachments
    /// <inheritdoc cref="SlackMessage.Attachments"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Attachments))]
    public static T SetAttachments<T>(this T o, params SlackMessageAttachment[] v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Attachments, v));
    /// <inheritdoc cref="SlackMessage.Attachments"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Attachments))]
    public static T SetAttachments<T>(this T o, IEnumerable<SlackMessageAttachment> v) where T : SlackMessage => o.Modify(b => b.Set(() => o.Attachments, v));
    /// <inheritdoc cref="SlackMessage.Attachments"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Attachments))]
    public static T AddAttachments<T>(this T o, params SlackMessageAttachment[] v) where T : SlackMessage => o.Modify(b => b.AddCollection(() => o.Attachments, v));
    /// <inheritdoc cref="SlackMessage.Attachments"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Attachments))]
    public static T AddAttachments<T>(this T o, IEnumerable<SlackMessageAttachment> v) where T : SlackMessage => o.Modify(b => b.AddCollection(() => o.Attachments, v));
    /// <inheritdoc cref="SlackMessage.Attachments"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Attachments))]
    public static T AddAttachments<T>(this T o, Configure<SlackMessageAttachment> v) where T : SlackMessage => o.Modify(b => b.AddCollection(() => o.Attachments, v.InvokeSafe(new())));
    /// <inheritdoc cref="SlackMessage.Attachments"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Attachments))]
    public static T RemoveAttachments<T>(this T o, params SlackMessageAttachment[] v) where T : SlackMessage => o.Modify(b => b.RemoveCollection(() => o.Attachments, v));
    /// <inheritdoc cref="SlackMessage.Attachments"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Attachments))]
    public static T RemoveAttachments<T>(this T o, IEnumerable<SlackMessageAttachment> v) where T : SlackMessage => o.Modify(b => b.RemoveCollection(() => o.Attachments, v));
    /// <inheritdoc cref="SlackMessage.Attachments"/>
    [Pure] [Builder(Type = typeof(SlackMessage), Property = nameof(SlackMessage.Attachments))]
    public static T ClearAttachments<T>(this T o) where T : SlackMessage => o.Modify(b => b.ClearCollection(() => o.Attachments));
    #endregion
}
#endregion
#region SlackMessageAttachmentExtensions
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SlackMessageAttachmentExtensions
{
    #region Title
    /// <inheritdoc cref="SlackMessageAttachment.Title"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Title))]
    public static T SetTitle<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Title, v));
    /// <inheritdoc cref="SlackMessageAttachment.Title"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Title))]
    public static T ResetTitle<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.Title));
    #endregion
    #region TitleLink
    /// <inheritdoc cref="SlackMessageAttachment.TitleLink"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.TitleLink))]
    public static T SetTitleLink<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.TitleLink, v));
    /// <inheritdoc cref="SlackMessageAttachment.TitleLink"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.TitleLink))]
    public static T ResetTitleLink<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.TitleLink));
    #endregion
    #region PreText
    /// <inheritdoc cref="SlackMessageAttachment.PreText"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.PreText))]
    public static T SetPreText<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.PreText, v));
    /// <inheritdoc cref="SlackMessageAttachment.PreText"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.PreText))]
    public static T ResetPreText<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.PreText));
    #endregion
    #region Text
    /// <inheritdoc cref="SlackMessageAttachment.Text"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Text))]
    public static T SetText<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Text, v));
    /// <inheritdoc cref="SlackMessageAttachment.Text"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Text))]
    public static T ResetText<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.Text));
    #endregion
    #region MarkdownIn
    /// <inheritdoc cref="SlackMessageAttachment.MarkdownIn"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.MarkdownIn))]
    public static T SetMarkdownIn<T>(this T o, params string[] v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.MarkdownIn, v));
    /// <inheritdoc cref="SlackMessageAttachment.MarkdownIn"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.MarkdownIn))]
    public static T SetMarkdownIn<T>(this T o, IEnumerable<string> v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.MarkdownIn, v));
    /// <inheritdoc cref="SlackMessageAttachment.MarkdownIn"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.MarkdownIn))]
    public static T AddMarkdownIn<T>(this T o, params string[] v) where T : SlackMessageAttachment => o.Modify(b => b.AddCollection(() => o.MarkdownIn, v));
    /// <inheritdoc cref="SlackMessageAttachment.MarkdownIn"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.MarkdownIn))]
    public static T AddMarkdownIn<T>(this T o, IEnumerable<string> v) where T : SlackMessageAttachment => o.Modify(b => b.AddCollection(() => o.MarkdownIn, v));
    /// <inheritdoc cref="SlackMessageAttachment.MarkdownIn"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.MarkdownIn))]
    public static T RemoveMarkdownIn<T>(this T o, params string[] v) where T : SlackMessageAttachment => o.Modify(b => b.RemoveCollection(() => o.MarkdownIn, v));
    /// <inheritdoc cref="SlackMessageAttachment.MarkdownIn"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.MarkdownIn))]
    public static T RemoveMarkdownIn<T>(this T o, IEnumerable<string> v) where T : SlackMessageAttachment => o.Modify(b => b.RemoveCollection(() => o.MarkdownIn, v));
    /// <inheritdoc cref="SlackMessageAttachment.MarkdownIn"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.MarkdownIn))]
    public static T ClearMarkdownIn<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.ClearCollection(() => o.MarkdownIn));
    #endregion
    #region Fallback
    /// <inheritdoc cref="SlackMessageAttachment.Fallback"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fallback))]
    public static T SetFallback<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Fallback, v));
    /// <inheritdoc cref="SlackMessageAttachment.Fallback"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fallback))]
    public static T ResetFallback<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.Fallback));
    #endregion
    #region Color
    /// <inheritdoc cref="SlackMessageAttachment.Color"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Color))]
    public static T SetColor<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="SlackMessageAttachment.Color"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Color))]
    public static T ResetColor<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region AuthorName
    /// <inheritdoc cref="SlackMessageAttachment.AuthorName"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.AuthorName))]
    public static T SetAuthorName<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.AuthorName, v));
    /// <inheritdoc cref="SlackMessageAttachment.AuthorName"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.AuthorName))]
    public static T ResetAuthorName<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.AuthorName));
    #endregion
    #region AuthorLink
    /// <inheritdoc cref="SlackMessageAttachment.AuthorLink"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.AuthorLink))]
    public static T SetAuthorLink<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.AuthorLink, v));
    /// <inheritdoc cref="SlackMessageAttachment.AuthorLink"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.AuthorLink))]
    public static T ResetAuthorLink<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.AuthorLink));
    #endregion
    #region AuthorIcon
    /// <inheritdoc cref="SlackMessageAttachment.AuthorIcon"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.AuthorIcon))]
    public static T SetAuthorIcon<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.AuthorIcon, v));
    /// <inheritdoc cref="SlackMessageAttachment.AuthorIcon"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.AuthorIcon))]
    public static T ResetAuthorIcon<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.AuthorIcon));
    #endregion
    #region ImageUrl
    /// <inheritdoc cref="SlackMessageAttachment.ImageUrl"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.ImageUrl))]
    public static T SetImageUrl<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.ImageUrl, v));
    /// <inheritdoc cref="SlackMessageAttachment.ImageUrl"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.ImageUrl))]
    public static T ResetImageUrl<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.ImageUrl));
    #endregion
    #region ThumbUrl
    /// <inheritdoc cref="SlackMessageAttachment.ThumbUrl"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.ThumbUrl))]
    public static T SetThumbUrl<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.ThumbUrl, v));
    /// <inheritdoc cref="SlackMessageAttachment.ThumbUrl"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.ThumbUrl))]
    public static T ResetThumbUrl<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.ThumbUrl));
    #endregion
    #region Footer
    /// <inheritdoc cref="SlackMessageAttachment.Footer"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Footer))]
    public static T SetFooter<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Footer, v));
    /// <inheritdoc cref="SlackMessageAttachment.Footer"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Footer))]
    public static T ResetFooter<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.Footer));
    #endregion
    #region FooterIcon
    /// <inheritdoc cref="SlackMessageAttachment.FooterIcon"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.FooterIcon))]
    public static T SetFooterIcon<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.FooterIcon, v));
    /// <inheritdoc cref="SlackMessageAttachment.FooterIcon"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.FooterIcon))]
    public static T ResetFooterIcon<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.FooterIcon));
    #endregion
    #region Timestamp
    /// <inheritdoc cref="SlackMessageAttachment.Timestamp"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Timestamp))]
    public static T SetTimestamp<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Timestamp, v));
    /// <inheritdoc cref="SlackMessageAttachment.Timestamp"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Timestamp))]
    public static T ResetTimestamp<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.Timestamp));
    #endregion
    #region Fields
    /// <inheritdoc cref="SlackMessageAttachment.Fields"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fields))]
    public static T SetFields<T>(this T o, params SlackMessageField[] v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Fields, v));
    /// <inheritdoc cref="SlackMessageAttachment.Fields"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fields))]
    public static T SetFields<T>(this T o, IEnumerable<SlackMessageField> v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Fields, v));
    /// <inheritdoc cref="SlackMessageAttachment.Fields"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fields))]
    public static T AddFields<T>(this T o, params SlackMessageField[] v) where T : SlackMessageAttachment => o.Modify(b => b.AddCollection(() => o.Fields, v));
    /// <inheritdoc cref="SlackMessageAttachment.Fields"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fields))]
    public static T AddFields<T>(this T o, IEnumerable<SlackMessageField> v) where T : SlackMessageAttachment => o.Modify(b => b.AddCollection(() => o.Fields, v));
    /// <inheritdoc cref="SlackMessageAttachment.Fields"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fields))]
    public static T AddFields<T>(this T o, Configure<SlackMessageField> v) where T : SlackMessageAttachment => o.Modify(b => b.AddCollection(() => o.Fields, v.InvokeSafe(new())));
    /// <inheritdoc cref="SlackMessageAttachment.Fields"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fields))]
    public static T RemoveFields<T>(this T o, params SlackMessageField[] v) where T : SlackMessageAttachment => o.Modify(b => b.RemoveCollection(() => o.Fields, v));
    /// <inheritdoc cref="SlackMessageAttachment.Fields"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fields))]
    public static T RemoveFields<T>(this T o, IEnumerable<SlackMessageField> v) where T : SlackMessageAttachment => o.Modify(b => b.RemoveCollection(() => o.Fields, v));
    /// <inheritdoc cref="SlackMessageAttachment.Fields"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Fields))]
    public static T ClearFields<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.ClearCollection(() => o.Fields));
    #endregion
    #region Actions
    /// <inheritdoc cref="SlackMessageAttachment.Actions"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Actions))]
    public static T SetActions<T>(this T o, params SlackMessageAction[] v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Actions, v));
    /// <inheritdoc cref="SlackMessageAttachment.Actions"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Actions))]
    public static T SetActions<T>(this T o, IEnumerable<SlackMessageAction> v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.Actions, v));
    /// <inheritdoc cref="SlackMessageAttachment.Actions"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Actions))]
    public static T AddActions<T>(this T o, params SlackMessageAction[] v) where T : SlackMessageAttachment => o.Modify(b => b.AddCollection(() => o.Actions, v));
    /// <inheritdoc cref="SlackMessageAttachment.Actions"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Actions))]
    public static T AddActions<T>(this T o, IEnumerable<SlackMessageAction> v) where T : SlackMessageAttachment => o.Modify(b => b.AddCollection(() => o.Actions, v));
    /// <inheritdoc cref="SlackMessageAttachment.Actions"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Actions))]
    public static T AddActions<T>(this T o, Configure<SlackMessageAction> v) where T : SlackMessageAttachment => o.Modify(b => b.AddCollection(() => o.Actions, v.InvokeSafe(new())));
    /// <inheritdoc cref="SlackMessageAttachment.Actions"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Actions))]
    public static T RemoveActions<T>(this T o, params SlackMessageAction[] v) where T : SlackMessageAttachment => o.Modify(b => b.RemoveCollection(() => o.Actions, v));
    /// <inheritdoc cref="SlackMessageAttachment.Actions"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Actions))]
    public static T RemoveActions<T>(this T o, IEnumerable<SlackMessageAction> v) where T : SlackMessageAttachment => o.Modify(b => b.RemoveCollection(() => o.Actions, v));
    /// <inheritdoc cref="SlackMessageAttachment.Actions"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.Actions))]
    public static T ClearActions<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.ClearCollection(() => o.Actions));
    #endregion
    #region CallbackId
    /// <inheritdoc cref="SlackMessageAttachment.CallbackId"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.CallbackId))]
    public static T SetCallbackId<T>(this T o, string v) where T : SlackMessageAttachment => o.Modify(b => b.Set(() => o.CallbackId, v));
    /// <inheritdoc cref="SlackMessageAttachment.CallbackId"/>
    [Pure] [Builder(Type = typeof(SlackMessageAttachment), Property = nameof(SlackMessageAttachment.CallbackId))]
    public static T ResetCallbackId<T>(this T o) where T : SlackMessageAttachment => o.Modify(b => b.Remove(() => o.CallbackId));
    #endregion
}
#endregion
#region SlackMessageFieldExtensions
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SlackMessageFieldExtensions
{
    #region Title
    /// <inheritdoc cref="SlackMessageField.Title"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Title))]
    public static T SetTitle<T>(this T o, string v) where T : SlackMessageField => o.Modify(b => b.Set(() => o.Title, v));
    /// <inheritdoc cref="SlackMessageField.Title"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Title))]
    public static T ResetTitle<T>(this T o) where T : SlackMessageField => o.Modify(b => b.Remove(() => o.Title));
    #endregion
    #region Value
    /// <inheritdoc cref="SlackMessageField.Value"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Value))]
    public static T SetValue<T>(this T o, string v) where T : SlackMessageField => o.Modify(b => b.Set(() => o.Value, v));
    /// <inheritdoc cref="SlackMessageField.Value"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Value))]
    public static T ResetValue<T>(this T o) where T : SlackMessageField => o.Modify(b => b.Remove(() => o.Value));
    #endregion
    #region Short
    /// <inheritdoc cref="SlackMessageField.Short"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Short))]
    public static T SetShort<T>(this T o, bool? v) where T : SlackMessageField => o.Modify(b => b.Set(() => o.Short, v));
    /// <inheritdoc cref="SlackMessageField.Short"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Short))]
    public static T ResetShort<T>(this T o) where T : SlackMessageField => o.Modify(b => b.Remove(() => o.Short));
    /// <inheritdoc cref="SlackMessageField.Short"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Short))]
    public static T EnableShort<T>(this T o) where T : SlackMessageField => o.Modify(b => b.Set(() => o.Short, true));
    /// <inheritdoc cref="SlackMessageField.Short"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Short))]
    public static T DisableShort<T>(this T o) where T : SlackMessageField => o.Modify(b => b.Set(() => o.Short, false));
    /// <inheritdoc cref="SlackMessageField.Short"/>
    [Pure] [Builder(Type = typeof(SlackMessageField), Property = nameof(SlackMessageField.Short))]
    public static T ToggleShort<T>(this T o) where T : SlackMessageField => o.Modify(b => b.Set(() => o.Short, !o.Short));
    #endregion
}
#endregion
#region SlackMessageActionExtensions
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SlackMessageActionExtensions
{
    #region Name
    /// <inheritdoc cref="SlackMessageAction.Name"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Name))]
    public static T SetName<T>(this T o, string v) where T : SlackMessageAction => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="SlackMessageAction.Name"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Name))]
    public static T ResetName<T>(this T o) where T : SlackMessageAction => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Text
    /// <inheritdoc cref="SlackMessageAction.Text"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Text))]
    public static T SetText<T>(this T o, string v) where T : SlackMessageAction => o.Modify(b => b.Set(() => o.Text, v));
    /// <inheritdoc cref="SlackMessageAction.Text"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Text))]
    public static T ResetText<T>(this T o) where T : SlackMessageAction => o.Modify(b => b.Remove(() => o.Text));
    #endregion
    #region Value
    /// <inheritdoc cref="SlackMessageAction.Value"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Value))]
    public static T SetValue<T>(this T o, string v) where T : SlackMessageAction => o.Modify(b => b.Set(() => o.Value, v));
    /// <inheritdoc cref="SlackMessageAction.Value"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Value))]
    public static T ResetValue<T>(this T o) where T : SlackMessageAction => o.Modify(b => b.Remove(() => o.Value));
    #endregion
    #region Style
    /// <inheritdoc cref="SlackMessageAction.Style"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Style))]
    public static T SetStyle<T>(this T o, SlackMessageActionStyle v) where T : SlackMessageAction => o.Modify(b => b.Set(() => o.Style, v));
    /// <inheritdoc cref="SlackMessageAction.Style"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Style))]
    public static T ResetStyle<T>(this T o) where T : SlackMessageAction => o.Modify(b => b.Remove(() => o.Style));
    #endregion
    #region Confirmation
    /// <inheritdoc cref="SlackMessageAction.Confirmation"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Confirmation))]
    public static T SetConfirmation<T>(this T o, SlackMessageConfirmation v) where T : SlackMessageAction => o.Modify(b => b.Set(() => o.Confirmation, v));
    /// <inheritdoc cref="SlackMessageAction.Confirmation"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Confirmation))]
    public static T SetConfirmation<T>(this T o, Configure<SlackMessageConfirmation> v) where T : SlackMessageAction => o.Modify(b => b.Set(() => o.Confirmation,  v.InvokeSafe(new())));
    /// <inheritdoc cref="SlackMessageAction.Confirmation"/>
    [Pure] [Builder(Type = typeof(SlackMessageAction), Property = nameof(SlackMessageAction.Confirmation))]
    public static T ResetConfirmation<T>(this T o) where T : SlackMessageAction => o.Modify(b => b.Remove(() => o.Confirmation));
    #endregion
}
#endregion
#region SlackMessageConfirmationExtensions
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SlackMessageConfirmationExtensions
{
    #region Title
    /// <inheritdoc cref="SlackMessageConfirmation.Title"/>
    [Pure] [Builder(Type = typeof(SlackMessageConfirmation), Property = nameof(SlackMessageConfirmation.Title))]
    public static T SetTitle<T>(this T o, string v) where T : SlackMessageConfirmation => o.Modify(b => b.Set(() => o.Title, v));
    /// <inheritdoc cref="SlackMessageConfirmation.Title"/>
    [Pure] [Builder(Type = typeof(SlackMessageConfirmation), Property = nameof(SlackMessageConfirmation.Title))]
    public static T ResetTitle<T>(this T o) where T : SlackMessageConfirmation => o.Modify(b => b.Remove(() => o.Title));
    #endregion
    #region Text
    /// <inheritdoc cref="SlackMessageConfirmation.Text"/>
    [Pure] [Builder(Type = typeof(SlackMessageConfirmation), Property = nameof(SlackMessageConfirmation.Text))]
    public static T SetText<T>(this T o, string v) where T : SlackMessageConfirmation => o.Modify(b => b.Set(() => o.Text, v));
    /// <inheritdoc cref="SlackMessageConfirmation.Text"/>
    [Pure] [Builder(Type = typeof(SlackMessageConfirmation), Property = nameof(SlackMessageConfirmation.Text))]
    public static T ResetText<T>(this T o) where T : SlackMessageConfirmation => o.Modify(b => b.Remove(() => o.Text));
    #endregion
    #region OkText
    /// <inheritdoc cref="SlackMessageConfirmation.OkText"/>
    [Pure] [Builder(Type = typeof(SlackMessageConfirmation), Property = nameof(SlackMessageConfirmation.OkText))]
    public static T SetOkText<T>(this T o, string v) where T : SlackMessageConfirmation => o.Modify(b => b.Set(() => o.OkText, v));
    /// <inheritdoc cref="SlackMessageConfirmation.OkText"/>
    [Pure] [Builder(Type = typeof(SlackMessageConfirmation), Property = nameof(SlackMessageConfirmation.OkText))]
    public static T ResetOkText<T>(this T o) where T : SlackMessageConfirmation => o.Modify(b => b.Remove(() => o.OkText));
    #endregion
    #region DismissText
    /// <inheritdoc cref="SlackMessageConfirmation.DismissText"/>
    [Pure] [Builder(Type = typeof(SlackMessageConfirmation), Property = nameof(SlackMessageConfirmation.DismissText))]
    public static T SetDismissText<T>(this T o, string v) where T : SlackMessageConfirmation => o.Modify(b => b.Set(() => o.DismissText, v));
    /// <inheritdoc cref="SlackMessageConfirmation.DismissText"/>
    [Pure] [Builder(Type = typeof(SlackMessageConfirmation), Property = nameof(SlackMessageConfirmation.DismissText))]
    public static T ResetDismissText<T>(this T o) where T : SlackMessageConfirmation => o.Modify(b => b.Remove(() => o.DismissText));
    #endregion
}
#endregion
#region SlackMessageActionStyle
/// <summary>Used within <see cref="SlackTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SlackMessageActionStyle>))]
public partial class SlackMessageActionStyle : Enumeration
{
    public static SlackMessageActionStyle primary = (SlackMessageActionStyle) "primary";
    public static SlackMessageActionStyle danger = (SlackMessageActionStyle) "danger";
    public static implicit operator SlackMessageActionStyle(string value)
    {
        return new SlackMessageActionStyle { Value = value };
    }
}
#endregion
