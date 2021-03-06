﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# EnumerableExtensions Class

**Namespace:** [Grynwald.Utilities.Collections](../index.md)  
**Assembly:** Grynwald.Utilities

Extension methods for IEnumerable\<T\>.

```csharp
public static class EnumerableExtensions
```

**Inheritance:** object → EnumerableExtensions

## Methods

| Name                                                                                                                       | Description                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------- |
| [Concat\<T\>(IEnumerable\<T\>, T)](methods/Concat.md)                                                                      | Adds the specified item at the end of the enumerable.                                                      |
| [JoinToString(IEnumerable\<object\>)](methods/JoinToString.md#jointostringienumerableobject)                               | Concatenates the items in the specified enumerable to a string.                                            |
| [JoinToString(IEnumerable\<object\>, string)](methods/JoinToString.md#jointostringienumerableobject-string)                | Concatenates the items in the specified enumerable to a string using the specified separator.              |
| [SetEqual\<T\>(IEnumerable\<T\>, IEnumerable\<T\>)](methods/SetEqual.md)                                                   | Determines if two sequences contain the same set of elements (in any order)                                |
| [ToHashSet\<T\>(IEnumerable\<T\>)](methods/ToHashSet.md#tohashsettienumerablet)                                            | Creates a new HashSet\<T\> with elements copied from the enumerable using the default equality comparer.   |
| [ToHashSet\<T\>(IEnumerable\<T\>, IEqualityComparer\<T\>)](methods/ToHashSet.md#tohashsettienumerablet-iequalitycomparert) | Creates a new HashSet\<T\> with elements copied from the enumerable using the specified equality comparer. |
| [Yield\<T\>(T)](methods/Yield.md)                                                                                          | Returns a new enumerable containing the specified item.                                                    |

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
