// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.Utilities.Text.Json;

[PublicAPI]
public class Base64JsonConverter<T> : TypeConverter
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string base64Json)
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(base64Json));
            return JsonConvert.DeserializeObject<T>(json);
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return false;
    }
}
