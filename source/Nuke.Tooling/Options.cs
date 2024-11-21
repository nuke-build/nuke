// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling;

public interface IOptions
{
    T Get<T>(Expression<Func<object>> provider);

    void Set<T>(Expression<Func<T>> provider, object value);
    void Remove<T>(Expression<Func<T>> provider);

    void SetDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, TKey key, TValue value);
    void AddDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, TKey key, TValue value);
    void AddDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, Dictionary<TKey, TValue> value);
    void AddDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, ReadOnlyDictionary<TKey, TValue> value);
    void RemoveDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, TKey key);
    void ClearDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider);

    void SetLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, params TValue[] values);
    void SetLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, IEnumerable<TValue> values);
    void AddLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, params TValue[] values);
    void AddLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, IEnumerable<TValue> values);
    void RemoveLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key);
    void RemoveLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, TValue value);
    void ClearLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider);

    void AddCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, params T[] value);
    void AddCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, IEnumerable<T> value);
    void RemoveCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, params T[] value);
    void RemoveCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, IEnumerable<T> value);
    void ClearCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider);
}

[JsonConverter(typeof(TypeConverter))]
public class Options : IOptions
{
    public class TypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is Options options)
                JToken.FromObject(options.InternalOptions, serializer).WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var options = (Options)objectType.CreateInstance();
            options.InternalOptions = JObject.Load(reader);
            return options;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(Options));
        }
    }

    private static JsonConverter LookupTableConverter = new ObjectFromFieldConverter(typeof(LookupTable<,>), "_dictionary");
    private static JsonConverter OptionsBuilderConverter = new ObjectFromFieldConverter(typeof(Options), "InternalOptions");

    internal static JsonSerializer JsonSerializer = new() { Converters = { LookupTableConverter, OptionsBuilderConverter } };
    internal static JsonSerializerSettings JsonSerializerSettings = new() { Converters = new[] { LookupTableConverter, OptionsBuilderConverter } };

    protected internal JObject InternalOptions = new();

    private static string GetOptionName(LambdaExpression lambdaExpression)
    {
        var member = lambdaExpression.GetMemberInfo();
        return member.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? member.Name;
    }

    void IOptions.Set<T>(Expression<Func<T>> provider, object value)
    {
        Set(GetOptionName(provider), value);
    }

    protected internal void Set<T>(Expression<Func<T>> provider, object value)
    {
        ((IOptions)this).Set(provider, value);
    }

    internal void Set(string propertyName, object value)
    {
        if (value != null)
        {
            var internalOption = JValue.FromObject(value, JsonSerializer);
            InternalOptions[propertyName] = internalOption;
        }
        else
        {
            InternalOptions.Property(propertyName)?.Remove();
        }
    }

    void IOptions.Remove<T>(Expression<Func<T>> provider)
    {
        InternalOptions.Property(GetOptionName(provider))?.Remove();
    }

    T IOptions.Get<T>(Expression<Func<object>> provider)
    {
        return Get<T>((LambdaExpression)provider);
    }

    protected T Get<T>(Expression<Func<object>> provider)
    {
        return Get<T>((LambdaExpression)provider);
    }

    private T Get<T>(LambdaExpression provider)
    {
        return InternalOptions[GetOptionName(provider)] is { } token ? token.ToObject<T>(JsonSerializer) : default;
    }

    #region Dictionary

    private void UsingDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, Action<Dictionary<TKey, TValue>> action)
    {
        var dictionary = Get<Dictionary<TKey, TValue>>(provider) ?? new Dictionary<TKey, TValue>();
        action.Invoke(dictionary);
        Set(provider, dictionary);
    }

    void IOptions.SetDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, TKey key, TValue value)
    {
        UsingDictionary(provider, dictionary => dictionary[key] = value);
    }

    void IOptions.AddDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, TKey key, TValue value)
    {
        UsingDictionary(provider, dictionary => dictionary.Add(key, value));
    }

    void IOptions.AddDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, Dictionary<TKey, TValue> value)
    {
        UsingDictionary(provider, dictionary => dictionary.AddDictionary(value));
    }

    void IOptions.AddDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, ReadOnlyDictionary<TKey, TValue> value)
    {
        UsingDictionary(provider, dictionary => dictionary.AddDictionary(value));
    }

    void IOptions.RemoveDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider, TKey key)
    {
        UsingDictionary(provider, dictionary => dictionary.Remove(key));
    }

    void IOptions.ClearDictionary<TKey, TValue>(Expression<Func<IReadOnlyDictionary<TKey, TValue>>> provider)
    {
        UsingDictionary(provider, dictionary => dictionary.Clear());
    }

    #endregion

    #region Lookup

    private void UsingLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, Action<LookupTable<TKey, TValue>> action)
    {
        var lookup = Get<LookupTable<TKey, TValue>>(provider) ?? new LookupTable<TKey, TValue>();
        action.Invoke(lookup);
        Set(provider, lookup);
    }

    void IOptions.SetLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, params TValue[] values)
    {
        UsingLookup(provider, lookup => lookup[key] = values);
    }

    void IOptions.SetLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, IEnumerable<TValue> values)
    {
        UsingLookup(provider, lookup => lookup[key] = values);
    }

    void IOptions.AddLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, params TValue[] values)
    {
        UsingLookup(provider, lookup => lookup.AddRange(key, values));
    }

    void IOptions.AddLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, IEnumerable<TValue> values)
    {
        UsingLookup(provider, lookup => lookup.AddRange(key, values));
    }

    void IOptions.RemoveLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key)
    {
        UsingLookup(provider, lookup => lookup.Remove(key));
    }

    void IOptions.RemoveLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider, TKey key, TValue value)
    {
        UsingLookup(provider, lookup => lookup.Remove(key, value));
    }

    void IOptions.ClearLookup<TKey, TValue>(Expression<Func<ILookup<TKey, TValue>>> provider)
    {
        UsingLookup(provider, lookup => lookup.Clear());
    }

    #endregion

    #region List

    private void UsingCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, Action<List<T>> action)
    {
        var collection = Get<List<T>>(provider) ?? new List<T>();
        action.Invoke(collection);
        Set(provider, collection);
    }

    void IOptions.AddCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, params T[] value)
    {
        UsingCollection(provider, collection => collection.AddRange(value));
    }

    void IOptions.AddCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, IEnumerable<T> value)
    {
        UsingCollection(provider, collection => collection.AddRange(value));
    }

    void IOptions.RemoveCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, params T[] value)
    {
        UsingCollection(provider, collection => collection.RemoveAll(value.Contains));
    }

    void IOptions.RemoveCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider, IEnumerable<T> value)
    {
        UsingCollection(provider, collection => collection.RemoveAll(value.ToList().Contains));
    }

    void IOptions.ClearCollection<T>(Expression<Func<IReadOnlyCollection<T>>> provider)
    {
        UsingCollection(provider, collection => collection.Clear());
    }

    #endregion
}
