﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# Wildcard.IsMatch Method

**Declaring Type:** [Wildcard](../index.md)  
**Namespace:** [Grynwald.Utilities](../../index.md)  
**Assembly:** Grynwald.Utilities

Determines whether the wildcard matches the specified input string.

```csharp
public bool IsMatch(string value);
```

## Parameters

`value`  string

## Returns

bool

## Example

```csharp
var wildcard = new Wildcard("Foo*");
Debug.Assert(wildcard.IsMatch("Foobar"));
Debug.Assert(!wildcard.IsMatch("Bar"));
```
___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
