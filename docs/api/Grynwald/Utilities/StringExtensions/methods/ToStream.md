﻿# StringExtensions.ToStream Method

**Declaring Type:** [StringExtensions](../index.md)

Creates a in\-memory stream and writes the string's content to it.

```csharp
public static Stream ToStream(this string s);
```

## Parameters

`s`  string

The value to write to the stream.

## Returns

Stream

Returns a new in\-memory stream which content is equivalent to the specified string. The resulting stream's reading position will be 0.

## See Also

- MemoryStream

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*