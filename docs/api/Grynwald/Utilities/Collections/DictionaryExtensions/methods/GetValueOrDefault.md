﻿# DictionaryExtensions.GetValueOrDefault Method

**Declaring Type:** [DictionaryExtensions](../index.md)

## Overloads

| Signature                                                                                                                                                       | Description                                                                                                                                      |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
| [GetValueOrDefault\<TKey, TValue\>(IDictionary\<TKey, TValue\>, TKey)](#getvalueordefaulttkey-tvalueidictionarytkey-tvalue-tkey)                                | Tries to get the element with the specified key. If the dictionary does not contain a matching element, `default(TValue)` is returned            |
| [GetValueOrDefault\<TKey, TValue\>(IDictionary\<TKey, TValue\>, TKey, TValue)](#getvalueordefaulttkey-tvalueidictionarytkey-tvalue-tkey-tvalue)                 | Tries to get the element with the specified key. If the dictionary does not contain a matching element, the value of `defaultValue` is returned. |
| [GetValueOrDefault\<TKey, TValue\>(IReadOnlyDictionary\<TKey, TValue\>, TKey)](#getvalueordefaulttkey-tvalueireadonlydictionarytkey-tvalue-tkey)                | Tries to get the element with the specified key. If the dictionary does not contain a matching element, default(TValue) is returned              |
| [GetValueOrDefault\<TKey, TValue\>(IReadOnlyDictionary\<TKey, TValue\>, TKey, TValue)](#getvalueordefaulttkey-tvalueireadonlydictionarytkey-tvalue-tkey-tvalue) | Tries to get the element with the specified key. If the dictionary does not contain a matching element, `default(TValue)` is returned            |

## GetValueOrDefault\<TKey, TValue\>(IDictionary\<TKey, TValue\>, TKey)

Tries to get the element with the specified key. If the dictionary does not contain a matching element, `default(TValue)` is returned

```csharp
public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key);
```

### Type Parameters

`TKey`

The type of keys in the dictionary.

`TValue`

The type of values in the dictionary.

### Parameters

`dictionary`  IDictionary\<TKey, TValue\>

The dictionary to retrieve the value from.

`key`  TKey

The key to locate in the dictionary.

### Returns

TValue

## GetValueOrDefault\<TKey, TValue\>(IDictionary\<TKey, TValue\>, TKey, TValue)

Tries to get the element with the specified key. If the dictionary does not contain a matching element, the value of `defaultValue` is returned.

```csharp
public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue);
```

### Type Parameters

`TKey`

The type of keys in the dictionary.

`TValue`

The type of values in the dictionary.

### Parameters

`dictionary`  IDictionary\<TKey, TValue\>

The dictionary to retrieve the value from.

`key`  TKey

The key to locate in the dictionary.

`defaultValue`  TValue

The value to return if the dictionary does not contain an item with the specified key.

### Returns

TValue

## GetValueOrDefault\<TKey, TValue\>(IReadOnlyDictionary\<TKey, TValue\>, TKey)

Tries to get the element with the specified key. If the dictionary does not contain a matching element, default(TValue) is returned

```csharp
[HiddenFromReferenceAssembly("netcoreapp2.0")]
[HiddenFromReferenceAssembly("netstandard2.1")]
public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key);
```

### Type Parameters

`TKey`

The type of keys in the dictionary.

`TValue`

The type of values in the dictionary.

### Parameters

`dictionary`  IReadOnlyDictionary\<TKey, TValue\>

The dictionary to retrieve the value from.

`key`  TKey

The key to locate in the dictionary.

### Remarks

This method is not included in the reference assembly for the following frameworks because a equivalent extension method, is available there and using the built\-in method is preferable.

- .NET Core 2.0 or later
- .NET Standard 2.1 or later

### Returns

TValue

## GetValueOrDefault\<TKey, TValue\>(IReadOnlyDictionary\<TKey, TValue\>, TKey, TValue)

Tries to get the element with the specified key. If the dictionary does not contain a matching element, `default(TValue)` is returned

```csharp
[HiddenFromReferenceAssembly("netcoreapp2.0")]
[HiddenFromReferenceAssembly("netstandard2.1")]
public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue);
```

### Type Parameters

`TKey`

The type of keys in the dictionary.

`TValue`

The type of values in the dictionary.

### Parameters

`dictionary`  IReadOnlyDictionary\<TKey, TValue\>

The dictionary to retrieve the value from.

`key`  TKey

The key to locate in the dictionary.

`defaultValue`  TValue

The value to return if the dictionary does not contain an item with the specified key.

### Remarks

This method is not included in the reference assembly for the following frameworks because a equivalent extension method, is available there and using the built\-in method is preferrable.

- .NET Core 2.0 or later
- .NET Standard 2.1 or later

### Returns

TValue

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*