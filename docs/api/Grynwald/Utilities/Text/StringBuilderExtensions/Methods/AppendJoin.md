# StringBuilderExtensions.AppendJoin Method

**Declaring Type:** [StringBuilderExtensions](../index.md)

## Overloads

| Signature                                                                                                 | Description                                                                |
| --------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------- |
| [AppendJoin(StringBuilder, char, object\[\])](#appendjoinstringbuilder-char-object)                       | Appends the members of a collection, separated by the specified separator. |
| [AppendJoin(StringBuilder, char, string\[\])](#appendjoinstringbuilder-char-string)                       | Appends the members of a collection, separated by the specified separator. |
| [AppendJoin(StringBuilder, string, object\[\])](#appendjoinstringbuilder-string-object)                   | Appends the members of a collection, separated by the specified separator. |
| [AppendJoin(StringBuilder, string, string\[\])](#appendjoinstringbuilder-string-string)                   | Appends the members of a collection, separated by the specified separator. |
| [AppendJoin\<T\>(StringBuilder, char, IEnumerable\<T\>)](#appendjointstringbuilder-char-ienumerablet)     | Appends the members of a collection, separated by the specified separator. |
| [AppendJoin\<T\>(StringBuilder, string, IEnumerable\<T\>)](#appendjointstringbuilder-string-ienumerablet) | Appends the members of a collection, separated by the specified separator. |

## AppendJoin(StringBuilder, char, object\[\])

Appends the members of a collection, separated by the specified separator.

```csharp
[HiddenFromReferenceAssembly("netcoreapp2.0")]
[HiddenFromReferenceAssembly("netstandard2.1")]
public static StringBuilder AppendJoin(this StringBuilder stringBuilder, char separator, object[] values);
```

### Parameters

`stringBuilder`  StringBuilder

The StringBuilder instance to append the value to.

`separator`  char

The separator to insert between the values.

`values`  object\[\]

The values to concatenate.

### Remarks

AppendJoin() was added to StringBuilder in .NET Core 2.0 \/ .NET Standard 2.1. This extension method makes it available on earlier versions and to projects targeting .NET Standard 2.0 or .NET Framework.

This method is excluded from the reference assembly for .NET Core 2.0 and .NET Standard 2.1 so projects targeting this will use the built\-in method.

### Returns

StringBuilder

Returns the specified StringBuilder.

## AppendJoin(StringBuilder, char, string\[\])

Appends the members of a collection, separated by the specified separator.

```csharp
[HiddenFromReferenceAssembly("netcoreapp2.0")]
[HiddenFromReferenceAssembly("netstandard2.1")]
public static StringBuilder AppendJoin(this StringBuilder stringBuilder, char separator, string[] values);
```

### Parameters

`stringBuilder`  StringBuilder

The StringBuilder instance to append the value to.

`separator`  char

The separator to insert between the values.

`values`  string\[\]

The values to concatenate.

### Remarks

AppendJoin() was added to StringBuilder in .NET Core 2.0 \/ .NET Standard 2.1. This extension method makes it available on earlier versions and to projects targeting .NET Standard 2.0 or .NET Framework.

This method is excluded from the reference assembly for .NET Core 2.0 and .NET Standard 2.1 so projects targeting this will use the built\-in method.

### Returns

StringBuilder

Returns the specified StringBuilder.

## AppendJoin(StringBuilder, string, object\[\])

Appends the members of a collection, separated by the specified separator.

```csharp
[HiddenFromReferenceAssembly("netcoreapp2.0")]
[HiddenFromReferenceAssembly("netstandard2.1")]
public static StringBuilder AppendJoin(this StringBuilder stringBuilder, string separator, object[] values);
```

### Parameters

`stringBuilder`  StringBuilder

The StringBuilder instance to append the value to.

`separator`  string

The separator to insert between the values.

`values`  object\[\]

The values to concatenate.

### Remarks

AppendJoin() was added to StringBuilder in .NET Core 2.0 \/ .NET Standard 2.1. This extension method makes it available on earlier versions and to projects targeting .NET Standard 2.0 or .NET Framework.

This method is excluded from the reference assembly for .NET Core 2.0 and .NET Standard 2.1 so projects targeting this will use the built\-in method.

### Returns

StringBuilder

Returns the specified StringBuilder.

## AppendJoin(StringBuilder, string, string\[\])

Appends the members of a collection, separated by the specified separator.

```csharp
[HiddenFromReferenceAssembly("netcoreapp2.0")]
[HiddenFromReferenceAssembly("netstandard2.1")]
public static StringBuilder AppendJoin(this StringBuilder stringBuilder, string separator, string[] values);
```

### Parameters

`stringBuilder`  StringBuilder

The StringBuilder instance to append the value to.

`separator`  string

The separator to insert between the values.

`values`  string\[\]

The values to concatenate.

### Remarks

AppendJoin() was added to StringBuilder in .NET Core 2.0 \/ .NET Standard 2.1. This extension method makes it available on earlier versions and to projects targeting .NET Standard 2.0 or .NET Framework.

This method is excluded from the reference assembly for .NET Core 2.0 and .NET Standard 2.1 so projects targeting this will use the built\-in method.

### Returns

StringBuilder

Returns the specified StringBuilder.

## AppendJoin\<T\>(StringBuilder, char, IEnumerable\<T\>)

Appends the members of a collection, separated by the specified separator.

```csharp
[HiddenFromReferenceAssembly("netcoreapp2.0")]
[HiddenFromReferenceAssembly("netstandard2.1")]
public static StringBuilder AppendJoin<T>(this StringBuilder stringBuilder, char separator, IEnumerable<T> values);
```

### Type Parameters

`T`

### Parameters

`stringBuilder`  StringBuilder

The StringBuilder instance to append the value to.

`separator`  char

The separator to insert between the values.

`values`  IEnumerable\<T\>

The values to concatenate.

### Remarks

AppendJoin() was added to StringBuilder in .NET Core 2.0 \/ .NET Standard 2.1. This extension method makes it available on earlier versions and to projects targeting .NET Standard 2.0 or .NET Framework.

This method is excluded from the reference assembly for .NET Core 2.0 and .NET Standard 2.1 so projects targeting this will use the built\-in method.

### Returns

StringBuilder

Returns the specified StringBuilder.

## AppendJoin\<T\>(StringBuilder, string, IEnumerable\<T\>)

Appends the members of a collection, separated by the specified separator.

```csharp
[HiddenFromReferenceAssembly("netcoreapp2.0")]
[HiddenFromReferenceAssembly("netstandard2.1")]
public static StringBuilder AppendJoin<T>(this StringBuilder stringBuilder, string separator, IEnumerable<T> values);
```

### Type Parameters

`T`

The type of the members of values.

### Parameters

`stringBuilder`  StringBuilder

The StringBuilder instance to append the value to.

`separator`  string

The separator to insert between the values.

`values`  IEnumerable\<T\>

The values to concatenate.

### Remarks

AppendJoin() was added to StringBuilder in .NET Core 2.0 \/ .NET Standard 2.1. This extension method makes it available on earlier versions and to projects targeting .NET Standard 2.0 or .NET Framework.

This method is excluded from the reference assembly for .NET Core 2.0 and .NET Standard 2.1 so projects targeting this will use the built\-in method.

### Returns

StringBuilder

Returns the specified StringBuilder.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
