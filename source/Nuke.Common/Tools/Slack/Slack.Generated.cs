// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: Local.
// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/Slack.json.

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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Slack
{
    #region SlackMessage
    /// <summary><p>Used within <see cref="SlackTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SlackMessage : ISettingsEntity
    {
        [JsonProperty("channel")]
        public virtual string Channel { get; internal set; }
        [JsonProperty("username")]
        public virtual string Username { get; internal set; }
        /// <summary><p>Slack messages may be formatted using a simple markup language similar to <a href="https://daringfireball.net/projects/markdown/">Markdown</a>. Supported formatting includes: <c>```pre```</c>, <c>`code`</c>, <c>_italic_</c>, <c>*bold*</c>, and even <c>~strike~</c>.; full details are available on our <a href="https://slack.zendesk.com/hc/en-us/articles/202288908-how-can-i-add-formatting-to-my-messages-?sid=zd-up-t0288d531-u0a5kka1k">help site</a>.</p></summary>
        [JsonProperty("text")]
        public virtual string Text { get; internal set; }
        /// <summary><p>By default bot message text will be formatted. To disable formatting on a non-user message, set the <c>mrkdwn</c> property to <c>false</c>.</p></summary>
        [JsonProperty("mrkdwn")]
        public virtual bool? Markdown { get; internal set; }
        [JsonProperty("icon_emoji")]
        public virtual string Emoji { get; internal set; }
        [JsonProperty("icon_url")]
        public virtual string Icon { get; internal set; }
        /// <summary><p>Attachments let you add more context to a message, making them more useful and effective.</p></summary>
        [JsonProperty("attachments")]
        public virtual IReadOnlyList<SlackMessageAttachment> Attachments => AttachmentsInternal.AsReadOnly();
        internal List<SlackMessageAttachment> AttachmentsInternal { get; set; } = new List<SlackMessageAttachment>();
    }
    #endregion
    #region SlackMessageAttachment
    /// <summary><p>Used within <see cref="SlackTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SlackMessageAttachment : ISettingsEntity
    {
        /// <summary><p>The title is displayed as larger, bold text near the top of a message attachment.</p></summary>
        [JsonProperty("title")]
        public virtual string Title { get; internal set; }
        /// <summary><p>Hyperlink used for the title.</p></summary>
        [JsonProperty("title_link")]
        public virtual string TitleLink { get; internal set; }
        /// <summary><p>This is optional text that appears above the message attachment block.</p></summary>
        [JsonProperty("pretext")]
        public virtual string PreText { get; internal set; }
        /// <summary><p>This is the main text in a message attachment, and can contain <a href="https://api.slack.com/docs/message-formatting">standard message markup</a>. The content will automatically collapse if it contains <b>700+ characters</b> or <b>5+ linebreaks</b>, and will display a "Show more..." link to expand the content. Links posted in the <c>text</c> field will not unfurl.</p></summary>
        [JsonProperty("text")]
        public virtual string Text { get; internal set; }
        /// <summary><p>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</p></summary>
        [JsonProperty("mrkdwn_in")]
        public virtual IReadOnlyList<string> MarkdownIn => MarkdownInInternal.AsReadOnly();
        internal List<string> MarkdownInInternal { get; set; } = new List<string>();
        /// <summary><p>A plain-text summary of the attachment. This text will be used in clients that don't show formatted text (eg. IRC, mobile notifications) and should not contain any markup.</p></summary>
        [JsonProperty("fallback")]
        public virtual string Fallback { get; internal set; }
        /// <summary><p>Like traffic signals, color-coding messages can quickly communicate intent and help separate them from the flow of other messages in the timeline.<para/>An optional value that can either be one of good, warning, danger, or any hex color code (eg. #439FE0). This value is used to color the border along the left side of the message attachment.</p></summary>
        [JsonProperty("color")]
        public virtual string Color { get; internal set; }
        /// <summary><p>Small text used to display the author's name.</p></summary>
        [JsonProperty("author_name")]
        public virtual string AuthorName { get; internal set; }
        /// <summary><p>A valid URL that will hyperlink the <c>author_name</c> text mentioned above. Will only work if <c>author_name</c> is present.</p></summary>
        [JsonProperty("author_link")]
        public virtual string AuthorLink { get; internal set; }
        /// <summary><p>A valid URL that displays a small 16x16px image to the left of the <c>author_name</c> text. Will only work if <c>author_name</c> is present.</p></summary>
        [JsonProperty("author_icon")]
        public virtual string AuthorIcon { get; internal set; }
        /// <summary><p>A valid URL to an image file that will be displayed inside a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.<para/>Large images will be resized to a maximum width of 360px or a maximum height of 500px, while still maintaining the original aspect ratio.</p></summary>
        [JsonProperty("image_url")]
        public virtual string ImageUrl { get; internal set; }
        /// <summary><p>A valid URL to an image file that will be displayed as a thumbnail on the right side of a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.<para/>The thumbnail's longest dimension will be scaled down to 75px while maintaining the aspect ratio of the image. The filesize of the image must also be less than 500 KB.<para/>For best results, please use images that are already 75px by 75px.</p></summary>
        [JsonProperty("thumb_url")]
        public virtual string ThumbUrl { get; internal set; }
        /// <summary><p>Add some brief text to help contextualize and identify an attachment. Limited to 300 characters, and may be truncated further when displayed to users in environments with limited screen real estate.</p></summary>
        [JsonProperty("footer")]
        public virtual string Footer { get; internal set; }
        /// <summary><p>To render a small icon beside your <c>footer</c> text, provide a publicly accessible URL string in the <c>footer_icon</c> field. You must also provide a <c>footer</c> for the field to be recognized.<para/>We'll render what you provide at 16px by 16px. It's best to use an image that is similarly sized.<para/>Example: <c>https://platform.slack-edge.com/img/default_application_icon.png</c></p></summary>
        [JsonProperty("footer_icon")]
        public virtual string FooterIcon { get; internal set; }
        /// <summary><p>Does your attachment relate to something happening at a specific time?<para/>By providing the <c>ts</c> field with an integer value in "<a href="https://en.wikipedia.org/wiki/Unix_time">epoch time</a>", the attachment will display an additional timestamp value as part of the attachment's footer.<para/>Use <c>ts</c> when referencing articles or happenings. Your message will have its own timestamp when published.<para/>Example: Providing <c>123456789</c> would result in a rendered timestamp of <em>Nov 29th, 1973</em>.</p></summary>
        [JsonProperty("ts")]
        public virtual string Timestamp { get; internal set; }
        /// <summary><p>Fields get displayed in a table-like way.</p></summary>
        [JsonProperty("fields")]
        public virtual IReadOnlyList<SlackMessageField> Fields => FieldsInternal.AsReadOnly();
        internal List<SlackMessageField> FieldsInternal { get; set; } = new List<SlackMessageField>();
    }
    #endregion
    #region SlackMessageField
    /// <summary><p>Used within <see cref="SlackTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SlackMessageField : ISettingsEntity
    {
        /// <summary><p>Shown as a bold heading above the <c>value</c> text. It cannot contain markup and will be escaped for you.</p></summary>
        [JsonProperty("title")]
        public virtual string Title { get; internal set; }
        /// <summary><p>The text value of the field. It may contain <a href="https://api.slack.com/docs/message-formatting">standard message markup</a> and must be escaped as normal. May be multi-line.</p></summary>
        [JsonProperty("value")]
        public virtual string Value { get; internal set; }
        /// <summary><p>An optional flag indicating whether the <c>value</c> is short enough to be displayed side-by-side with other values.</p></summary>
        [JsonProperty("short")]
        public virtual bool? Short { get; internal set; }
    }
    #endregion
    #region SlackMessageExtensions
    /// <summary><p>Used within <see cref="SlackTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SlackMessageExtensions
    {
        #region Channel
        /// <summary><p><em>Sets <see cref="SlackMessage.Channel"/>.</em></p></summary>
        [Pure]
        public static SlackMessage SetChannel(this SlackMessage toolSettings, string channel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = channel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessage.Channel"/>.</em></p></summary>
        [Pure]
        public static SlackMessage ResetChannel(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary><p><em>Sets <see cref="SlackMessage.Username"/>.</em></p></summary>
        [Pure]
        public static SlackMessage SetUsername(this SlackMessage toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessage.Username"/>.</em></p></summary>
        [Pure]
        public static SlackMessage ResetUsername(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Text
        /// <summary><p><em>Sets <see cref="SlackMessage.Text"/>.</em></p><p>Slack messages may be formatted using a simple markup language similar to <a href="https://daringfireball.net/projects/markdown/">Markdown</a>. Supported formatting includes: <c>```pre```</c>, <c>`code`</c>, <c>_italic_</c>, <c>*bold*</c>, and even <c>~strike~</c>.; full details are available on our <a href="https://slack.zendesk.com/hc/en-us/articles/202288908-how-can-i-add-formatting-to-my-messages-?sid=zd-up-t0288d531-u0a5kka1k">help site</a>.</p></summary>
        [Pure]
        public static SlackMessage SetText(this SlackMessage toolSettings, string text)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = text;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessage.Text"/>.</em></p><p>Slack messages may be formatted using a simple markup language similar to <a href="https://daringfireball.net/projects/markdown/">Markdown</a>. Supported formatting includes: <c>```pre```</c>, <c>`code`</c>, <c>_italic_</c>, <c>*bold*</c>, and even <c>~strike~</c>.; full details are available on our <a href="https://slack.zendesk.com/hc/en-us/articles/202288908-how-can-i-add-formatting-to-my-messages-?sid=zd-up-t0288d531-u0a5kka1k">help site</a>.</p></summary>
        [Pure]
        public static SlackMessage ResetText(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = null;
            return toolSettings;
        }
        #endregion
        #region Markdown
        /// <summary><p><em>Sets <see cref="SlackMessage.Markdown"/>.</em></p><p>By default bot message text will be formatted. To disable formatting on a non-user message, set the <c>mrkdwn</c> property to <c>false</c>.</p></summary>
        [Pure]
        public static SlackMessage SetMarkdown(this SlackMessage toolSettings, bool? markdown)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Markdown = markdown;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessage.Markdown"/>.</em></p><p>By default bot message text will be formatted. To disable formatting on a non-user message, set the <c>mrkdwn</c> property to <c>false</c>.</p></summary>
        [Pure]
        public static SlackMessage ResetMarkdown(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Markdown = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SlackMessage.Markdown"/>.</em></p><p>By default bot message text will be formatted. To disable formatting on a non-user message, set the <c>mrkdwn</c> property to <c>false</c>.</p></summary>
        [Pure]
        public static SlackMessage EnableMarkdown(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Markdown = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SlackMessage.Markdown"/>.</em></p><p>By default bot message text will be formatted. To disable formatting on a non-user message, set the <c>mrkdwn</c> property to <c>false</c>.</p></summary>
        [Pure]
        public static SlackMessage DisableMarkdown(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Markdown = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SlackMessage.Markdown"/>.</em></p><p>By default bot message text will be formatted. To disable formatting on a non-user message, set the <c>mrkdwn</c> property to <c>false</c>.</p></summary>
        [Pure]
        public static SlackMessage ToggleMarkdown(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Markdown = !toolSettings.Markdown;
            return toolSettings;
        }
        #endregion
        #region Emoji
        /// <summary><p><em>Sets <see cref="SlackMessage.Emoji"/>.</em></p></summary>
        [Pure]
        public static SlackMessage SetEmoji(this SlackMessage toolSettings, string emoji)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Emoji = emoji;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessage.Emoji"/>.</em></p></summary>
        [Pure]
        public static SlackMessage ResetEmoji(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Emoji = null;
            return toolSettings;
        }
        #endregion
        #region Icon
        /// <summary><p><em>Sets <see cref="SlackMessage.Icon"/>.</em></p></summary>
        [Pure]
        public static SlackMessage SetIcon(this SlackMessage toolSettings, string icon)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Icon = icon;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessage.Icon"/>.</em></p></summary>
        [Pure]
        public static SlackMessage ResetIcon(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Icon = null;
            return toolSettings;
        }
        #endregion
        #region Attachments
        /// <summary><p><em>Sets <see cref="SlackMessage.Attachments"/> to a new list.</em></p><p>Attachments let you add more context to a message, making them more useful and effective.</p></summary>
        [Pure]
        public static SlackMessage SetAttachments(this SlackMessage toolSettings, params SlackMessageAttachment[] attachments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttachmentsInternal = attachments.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="SlackMessage.Attachments"/> to a new list.</em></p><p>Attachments let you add more context to a message, making them more useful and effective.</p></summary>
        [Pure]
        public static SlackMessage SetAttachments(this SlackMessage toolSettings, IEnumerable<SlackMessageAttachment> attachments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttachmentsInternal = attachments.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SlackMessage.Attachments"/>.</em></p><p>Attachments let you add more context to a message, making them more useful and effective.</p></summary>
        [Pure]
        public static SlackMessage AddAttachments(this SlackMessage toolSettings, params SlackMessageAttachment[] attachments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttachmentsInternal.AddRange(attachments);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SlackMessage.Attachments"/>.</em></p><p>Attachments let you add more context to a message, making them more useful and effective.</p></summary>
        [Pure]
        public static SlackMessage AddAttachments(this SlackMessage toolSettings, IEnumerable<SlackMessageAttachment> attachments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttachmentsInternal.AddRange(attachments);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="SlackMessage.Attachments"/>.</em></p><p>Attachments let you add more context to a message, making them more useful and effective.</p></summary>
        [Pure]
        public static SlackMessage ClearAttachments(this SlackMessage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttachmentsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SlackMessage.Attachments"/>.</em></p><p>Attachments let you add more context to a message, making them more useful and effective.</p></summary>
        [Pure]
        public static SlackMessage RemoveAttachments(this SlackMessage toolSettings, params SlackMessageAttachment[] attachments)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<SlackMessageAttachment>(attachments);
            toolSettings.AttachmentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SlackMessage.Attachments"/>.</em></p><p>Attachments let you add more context to a message, making them more useful and effective.</p></summary>
        [Pure]
        public static SlackMessage RemoveAttachments(this SlackMessage toolSettings, IEnumerable<SlackMessageAttachment> attachments)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<SlackMessageAttachment>(attachments);
            toolSettings.AttachmentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SlackMessageAttachmentExtensions
    /// <summary><p>Used within <see cref="SlackTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SlackMessageAttachmentExtensions
    {
        #region Title
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.Title"/>.</em></p><p>The title is displayed as larger, bold text near the top of a message attachment.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetTitle(this SlackMessageAttachment toolSettings, string title)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = title;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.Title"/>.</em></p><p>The title is displayed as larger, bold text near the top of a message attachment.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetTitle(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = null;
            return toolSettings;
        }
        #endregion
        #region TitleLink
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.TitleLink"/>.</em></p><p>Hyperlink used for the title.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetTitleLink(this SlackMessageAttachment toolSettings, string titleLink)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TitleLink = titleLink;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.TitleLink"/>.</em></p><p>Hyperlink used for the title.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetTitleLink(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TitleLink = null;
            return toolSettings;
        }
        #endregion
        #region PreText
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.PreText"/>.</em></p><p>This is optional text that appears above the message attachment block.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetPreText(this SlackMessageAttachment toolSettings, string preText)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreText = preText;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.PreText"/>.</em></p><p>This is optional text that appears above the message attachment block.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetPreText(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreText = null;
            return toolSettings;
        }
        #endregion
        #region Text
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.Text"/>.</em></p><p>This is the main text in a message attachment, and can contain <a href="https://api.slack.com/docs/message-formatting">standard message markup</a>. The content will automatically collapse if it contains <b>700+ characters</b> or <b>5+ linebreaks</b>, and will display a "Show more..." link to expand the content. Links posted in the <c>text</c> field will not unfurl.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetText(this SlackMessageAttachment toolSettings, string text)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = text;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.Text"/>.</em></p><p>This is the main text in a message attachment, and can contain <a href="https://api.slack.com/docs/message-formatting">standard message markup</a>. The content will automatically collapse if it contains <b>700+ characters</b> or <b>5+ linebreaks</b>, and will display a "Show more..." link to expand the content. Links posted in the <c>text</c> field will not unfurl.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetText(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Text = null;
            return toolSettings;
        }
        #endregion
        #region MarkdownIn
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.MarkdownIn"/> to a new list.</em></p><p>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetMarkdownIn(this SlackMessageAttachment toolSettings, params string[] markdownIn)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownInInternal = markdownIn.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.MarkdownIn"/> to a new list.</em></p><p>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetMarkdownIn(this SlackMessageAttachment toolSettings, IEnumerable<string> markdownIn)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownInInternal = markdownIn.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SlackMessageAttachment.MarkdownIn"/>.</em></p><p>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</p></summary>
        [Pure]
        public static SlackMessageAttachment AddMarkdownIn(this SlackMessageAttachment toolSettings, params string[] markdownIn)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownInInternal.AddRange(markdownIn);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SlackMessageAttachment.MarkdownIn"/>.</em></p><p>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</p></summary>
        [Pure]
        public static SlackMessageAttachment AddMarkdownIn(this SlackMessageAttachment toolSettings, IEnumerable<string> markdownIn)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownInInternal.AddRange(markdownIn);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="SlackMessageAttachment.MarkdownIn"/>.</em></p><p>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</p></summary>
        [Pure]
        public static SlackMessageAttachment ClearMarkdownIn(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownInInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SlackMessageAttachment.MarkdownIn"/>.</em></p><p>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</p></summary>
        [Pure]
        public static SlackMessageAttachment RemoveMarkdownIn(this SlackMessageAttachment toolSettings, params string[] markdownIn)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(markdownIn);
            toolSettings.MarkdownInInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SlackMessageAttachment.MarkdownIn"/>.</em></p><p>By default bot message attachments will not be formatted. To enable formatting on attachment fields, set the mrkdwn_in array on each attachment to the list of fields to process.</p></summary>
        [Pure]
        public static SlackMessageAttachment RemoveMarkdownIn(this SlackMessageAttachment toolSettings, IEnumerable<string> markdownIn)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(markdownIn);
            toolSettings.MarkdownInInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Fallback
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.Fallback"/>.</em></p><p>A plain-text summary of the attachment. This text will be used in clients that don't show formatted text (eg. IRC, mobile notifications) and should not contain any markup.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetFallback(this SlackMessageAttachment toolSettings, string fallback)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fallback = fallback;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.Fallback"/>.</em></p><p>A plain-text summary of the attachment. This text will be used in clients that don't show formatted text (eg. IRC, mobile notifications) and should not contain any markup.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetFallback(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fallback = null;
            return toolSettings;
        }
        #endregion
        #region Color
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.Color"/>.</em></p><p>Like traffic signals, color-coding messages can quickly communicate intent and help separate them from the flow of other messages in the timeline.<para/>An optional value that can either be one of good, warning, danger, or any hex color code (eg. #439FE0). This value is used to color the border along the left side of the message attachment.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetColor(this SlackMessageAttachment toolSettings, string color)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Color = color;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.Color"/>.</em></p><p>Like traffic signals, color-coding messages can quickly communicate intent and help separate them from the flow of other messages in the timeline.<para/>An optional value that can either be one of good, warning, danger, or any hex color code (eg. #439FE0). This value is used to color the border along the left side of the message attachment.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetColor(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Color = null;
            return toolSettings;
        }
        #endregion
        #region AuthorName
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.AuthorName"/>.</em></p><p>Small text used to display the author's name.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetAuthorName(this SlackMessageAttachment toolSettings, string authorName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorName = authorName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.AuthorName"/>.</em></p><p>Small text used to display the author's name.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetAuthorName(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorName = null;
            return toolSettings;
        }
        #endregion
        #region AuthorLink
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.AuthorLink"/>.</em></p><p>A valid URL that will hyperlink the <c>author_name</c> text mentioned above. Will only work if <c>author_name</c> is present.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetAuthorLink(this SlackMessageAttachment toolSettings, string authorLink)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorLink = authorLink;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.AuthorLink"/>.</em></p><p>A valid URL that will hyperlink the <c>author_name</c> text mentioned above. Will only work if <c>author_name</c> is present.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetAuthorLink(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorLink = null;
            return toolSettings;
        }
        #endregion
        #region AuthorIcon
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.AuthorIcon"/>.</em></p><p>A valid URL that displays a small 16x16px image to the left of the <c>author_name</c> text. Will only work if <c>author_name</c> is present.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetAuthorIcon(this SlackMessageAttachment toolSettings, string authorIcon)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorIcon = authorIcon;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.AuthorIcon"/>.</em></p><p>A valid URL that displays a small 16x16px image to the left of the <c>author_name</c> text. Will only work if <c>author_name</c> is present.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetAuthorIcon(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorIcon = null;
            return toolSettings;
        }
        #endregion
        #region ImageUrl
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.ImageUrl"/>.</em></p><p>A valid URL to an image file that will be displayed inside a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.<para/>Large images will be resized to a maximum width of 360px or a maximum height of 500px, while still maintaining the original aspect ratio.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetImageUrl(this SlackMessageAttachment toolSettings, string imageUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImageUrl = imageUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.ImageUrl"/>.</em></p><p>A valid URL to an image file that will be displayed inside a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.<para/>Large images will be resized to a maximum width of 360px or a maximum height of 500px, while still maintaining the original aspect ratio.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetImageUrl(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImageUrl = null;
            return toolSettings;
        }
        #endregion
        #region ThumbUrl
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.ThumbUrl"/>.</em></p><p>A valid URL to an image file that will be displayed as a thumbnail on the right side of a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.<para/>The thumbnail's longest dimension will be scaled down to 75px while maintaining the aspect ratio of the image. The filesize of the image must also be less than 500 KB.<para/>For best results, please use images that are already 75px by 75px.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetThumbUrl(this SlackMessageAttachment toolSettings, string thumbUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThumbUrl = thumbUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.ThumbUrl"/>.</em></p><p>A valid URL to an image file that will be displayed as a thumbnail on the right side of a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.<para/>The thumbnail's longest dimension will be scaled down to 75px while maintaining the aspect ratio of the image. The filesize of the image must also be less than 500 KB.<para/>For best results, please use images that are already 75px by 75px.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetThumbUrl(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThumbUrl = null;
            return toolSettings;
        }
        #endregion
        #region Footer
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.Footer"/>.</em></p><p>Add some brief text to help contextualize and identify an attachment. Limited to 300 characters, and may be truncated further when displayed to users in environments with limited screen real estate.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetFooter(this SlackMessageAttachment toolSettings, string footer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Footer = footer;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.Footer"/>.</em></p><p>Add some brief text to help contextualize and identify an attachment. Limited to 300 characters, and may be truncated further when displayed to users in environments with limited screen real estate.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetFooter(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Footer = null;
            return toolSettings;
        }
        #endregion
        #region FooterIcon
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.FooterIcon"/>.</em></p><p>To render a small icon beside your <c>footer</c> text, provide a publicly accessible URL string in the <c>footer_icon</c> field. You must also provide a <c>footer</c> for the field to be recognized.<para/>We'll render what you provide at 16px by 16px. It's best to use an image that is similarly sized.<para/>Example: <c>https://platform.slack-edge.com/img/default_application_icon.png</c></p></summary>
        [Pure]
        public static SlackMessageAttachment SetFooterIcon(this SlackMessageAttachment toolSettings, string footerIcon)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FooterIcon = footerIcon;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.FooterIcon"/>.</em></p><p>To render a small icon beside your <c>footer</c> text, provide a publicly accessible URL string in the <c>footer_icon</c> field. You must also provide a <c>footer</c> for the field to be recognized.<para/>We'll render what you provide at 16px by 16px. It's best to use an image that is similarly sized.<para/>Example: <c>https://platform.slack-edge.com/img/default_application_icon.png</c></p></summary>
        [Pure]
        public static SlackMessageAttachment ResetFooterIcon(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FooterIcon = null;
            return toolSettings;
        }
        #endregion
        #region Timestamp
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.Timestamp"/>.</em></p><p>Does your attachment relate to something happening at a specific time?<para/>By providing the <c>ts</c> field with an integer value in "<a href="https://en.wikipedia.org/wiki/Unix_time">epoch time</a>", the attachment will display an additional timestamp value as part of the attachment's footer.<para/>Use <c>ts</c> when referencing articles or happenings. Your message will have its own timestamp when published.<para/>Example: Providing <c>123456789</c> would result in a rendered timestamp of <em>Nov 29th, 1973</em>.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetTimestamp(this SlackMessageAttachment toolSettings, string timestamp)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timestamp = timestamp;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageAttachment.Timestamp"/>.</em></p><p>Does your attachment relate to something happening at a specific time?<para/>By providing the <c>ts</c> field with an integer value in "<a href="https://en.wikipedia.org/wiki/Unix_time">epoch time</a>", the attachment will display an additional timestamp value as part of the attachment's footer.<para/>Use <c>ts</c> when referencing articles or happenings. Your message will have its own timestamp when published.<para/>Example: Providing <c>123456789</c> would result in a rendered timestamp of <em>Nov 29th, 1973</em>.</p></summary>
        [Pure]
        public static SlackMessageAttachment ResetTimestamp(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timestamp = null;
            return toolSettings;
        }
        #endregion
        #region Fields
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.Fields"/> to a new list.</em></p><p>Fields get displayed in a table-like way.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetFields(this SlackMessageAttachment toolSettings, params SlackMessageField[] fields)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal = fields.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="SlackMessageAttachment.Fields"/> to a new list.</em></p><p>Fields get displayed in a table-like way.</p></summary>
        [Pure]
        public static SlackMessageAttachment SetFields(this SlackMessageAttachment toolSettings, IEnumerable<SlackMessageField> fields)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal = fields.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SlackMessageAttachment.Fields"/>.</em></p><p>Fields get displayed in a table-like way.</p></summary>
        [Pure]
        public static SlackMessageAttachment AddFields(this SlackMessageAttachment toolSettings, params SlackMessageField[] fields)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal.AddRange(fields);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SlackMessageAttachment.Fields"/>.</em></p><p>Fields get displayed in a table-like way.</p></summary>
        [Pure]
        public static SlackMessageAttachment AddFields(this SlackMessageAttachment toolSettings, IEnumerable<SlackMessageField> fields)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal.AddRange(fields);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="SlackMessageAttachment.Fields"/>.</em></p><p>Fields get displayed in a table-like way.</p></summary>
        [Pure]
        public static SlackMessageAttachment ClearFields(this SlackMessageAttachment toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FieldsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SlackMessageAttachment.Fields"/>.</em></p><p>Fields get displayed in a table-like way.</p></summary>
        [Pure]
        public static SlackMessageAttachment RemoveFields(this SlackMessageAttachment toolSettings, params SlackMessageField[] fields)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<SlackMessageField>(fields);
            toolSettings.FieldsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SlackMessageAttachment.Fields"/>.</em></p><p>Fields get displayed in a table-like way.</p></summary>
        [Pure]
        public static SlackMessageAttachment RemoveFields(this SlackMessageAttachment toolSettings, IEnumerable<SlackMessageField> fields)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<SlackMessageField>(fields);
            toolSettings.FieldsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SlackMessageFieldExtensions
    /// <summary><p>Used within <see cref="SlackTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SlackMessageFieldExtensions
    {
        #region Title
        /// <summary><p><em>Sets <see cref="SlackMessageField.Title"/>.</em></p><p>Shown as a bold heading above the <c>value</c> text. It cannot contain markup and will be escaped for you.</p></summary>
        [Pure]
        public static SlackMessageField SetTitle(this SlackMessageField toolSettings, string title)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = title;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageField.Title"/>.</em></p><p>Shown as a bold heading above the <c>value</c> text. It cannot contain markup and will be escaped for you.</p></summary>
        [Pure]
        public static SlackMessageField ResetTitle(this SlackMessageField toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = null;
            return toolSettings;
        }
        #endregion
        #region Value
        /// <summary><p><em>Sets <see cref="SlackMessageField.Value"/>.</em></p><p>The text value of the field. It may contain <a href="https://api.slack.com/docs/message-formatting">standard message markup</a> and must be escaped as normal. May be multi-line.</p></summary>
        [Pure]
        public static SlackMessageField SetValue(this SlackMessageField toolSettings, string value)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Value = value;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageField.Value"/>.</em></p><p>The text value of the field. It may contain <a href="https://api.slack.com/docs/message-formatting">standard message markup</a> and must be escaped as normal. May be multi-line.</p></summary>
        [Pure]
        public static SlackMessageField ResetValue(this SlackMessageField toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Value = null;
            return toolSettings;
        }
        #endregion
        #region Short
        /// <summary><p><em>Sets <see cref="SlackMessageField.Short"/>.</em></p><p>An optional flag indicating whether the <c>value</c> is short enough to be displayed side-by-side with other values.</p></summary>
        [Pure]
        public static SlackMessageField SetShort(this SlackMessageField toolSettings, bool? @short)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = @short;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SlackMessageField.Short"/>.</em></p><p>An optional flag indicating whether the <c>value</c> is short enough to be displayed side-by-side with other values.</p></summary>
        [Pure]
        public static SlackMessageField ResetShort(this SlackMessageField toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SlackMessageField.Short"/>.</em></p><p>An optional flag indicating whether the <c>value</c> is short enough to be displayed side-by-side with other values.</p></summary>
        [Pure]
        public static SlackMessageField EnableShort(this SlackMessageField toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SlackMessageField.Short"/>.</em></p><p>An optional flag indicating whether the <c>value</c> is short enough to be displayed side-by-side with other values.</p></summary>
        [Pure]
        public static SlackMessageField DisableShort(this SlackMessageField toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SlackMessageField.Short"/>.</em></p><p>An optional flag indicating whether the <c>value</c> is short enough to be displayed side-by-side with other values.</p></summary>
        [Pure]
        public static SlackMessageField ToggleShort(this SlackMessageField toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = !toolSettings.Short;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
