// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.Execution;
using Nuke.Common.ValueInjection;

namespace Nuke.Common
{
    /// <summary>
    ///     Injected parameters are resolved case-insensitively in the following order:
    ///     <ul>
    ///         <li>From command-line arguments (e.g., <c>-arg value</c>)</li>
    ///         <li>From environment variables (e.g., <c>Arg=value</c>)</li>
    ///     </ul>
    ///     <para/>
    ///     For value-types, there is a distinction between pure value-types, and their <em>nullable</em>
    ///     counterparts. For instance, <c>int</c> will have its default value <c>0</c> even when it's not
    ///     supplied via command-line or environment variable.
    ///     <para/>
    /// </summary>
    /// <example>
    ///     <code>
    /// [Parameter("Configuration to build")] readonly Configuration Configuration;
    /// [Parameter("API key for NuGet")] readonly string ApiKey;
    /// [Parameter("Custom items")] readonly string[] Items;
    ///     </code>
    /// </example>
    [PublicAPI]
    public class ParameterAttribute : ValueInjectionAttributeBase
    {
        public ParameterAttribute(string description = null)
        {
            Description = description;
        }

        public virtual string Description { get; }

        [CanBeNull]
        public string Name { get; set; }

        [CanBeNull]
        public string Separator { get; set; }

        public virtual bool List { get; set; } = true;

        [CanBeNull]
        public string ValueProvider { get; set; }

        [CanBeNull]
        public override object GetValue(MemberInfo member, object instance)
        {
            return EnvironmentInfo.GetParameter<object>(member, member.GetMemberType().GetNullableType());
        }

        public virtual IEnumerable<(string, object)> GetValueSet(MemberInfo member, object instance)
        {
            return null;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RequiredAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class SecretAttribute : Attribute
    {
        public virtual JsonConverter GetConverter(MemberInfo member, string key)
        {
            ControlFlow.Assert(member.GetMemberType() == typeof(string),
                $"Member '{member.Name}' must be of type 'string' when using '{nameof(SecretAttribute)}'.");

            return new DelegateConverter(
                x => Encrypt(x as string, key),
                x => Decrypt(x as string, key));
        }

        protected virtual string Decrypt(string cipherText, string key)
        {
            var cipherBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"));

            using var ms = new MemoryStream();
            using var cs = GetCryptoStream(ms, key, x => x.CreateDecryptor());
            cs.Write(cipherBytes, 0, cipherBytes.Length);
            cs.Close();

            return Encoding.Unicode.GetString(ms.ToArray());
        }

        protected virtual string Encrypt(string clearText, string key)
        {
            var clearBytes = Encoding.Unicode.GetBytes(clearText);

            using var ms = new MemoryStream();
            using var cs = GetCryptoStream(ms, key, x => x.CreateEncryptor());
            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        private Stream GetCryptoStream(Stream stream, string key, Func<SymmetricAlgorithm, ICryptoTransform> transformSelector)
        {
            var salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
            var pdb = new Rfc2898DeriveBytes(key, salt);
            using var symmetricAlgorithm = Aes.Create().NotNull();
            symmetricAlgorithm.Key = pdb.GetBytes(32);
            symmetricAlgorithm.IV = pdb.GetBytes(16);

            return new CryptoStream(stream, transformSelector(symmetricAlgorithm), CryptoStreamMode.Write);
        }
    }
}
