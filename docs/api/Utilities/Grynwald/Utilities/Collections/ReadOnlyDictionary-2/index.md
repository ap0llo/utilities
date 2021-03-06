﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# ReadOnlyDictionary\<TKey, TValue\> Class

**Namespace:** [Grynwald.Utilities.Collections](../index.md)  
**Assembly:** Grynwald.Utilities

Singleton implementation of IReadOnlyDictionary\<T1, T2\> .

```csharp
public class ReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
```

**Inheritance:** object → ReadOnlyDictionary\<TKey, TValue\>

**Implements:** IReadOnlyDictionary\<TKey, TValue\>,IEnumerable\<KeyValuePair\<TKey, TValue\>\>,IEnumerable,IReadOnlyCollection\<KeyValuePair\<TKey, TValue\>\>

## Type Parameters

`TKey`

The type of keys in the dictionary.

`TValue`

The type of values in the dictionary.

## Remarks

ReadOnlyDictionary\<T1, T2\> provides a empty singleton dictionary             analogous to Empty\<T\>()

## Fields

| Name                     | Description                                            |
| ------------------------ | ------------------------------------------------------ |
| [Empty](fields/Empty.md) | The singleton instance of ReadOnlyDictionary\<T1, T2\> |

## Properties

| Name                           | Description |
| ------------------------------ | ----------- |
| [Count](properties/Count.md)   |             |
| [Keys](properties/Keys.md)     |             |
| [Values](properties/Values.md) |             |

## Indexers

| Name                             | Description |
| -------------------------------- | ----------- |
| [Item\[TKey\]](indexers/Item.md) |             |

## Methods

| Name                                                | Description |
| --------------------------------------------------- | ----------- |
| [ContainsKey(TKey)](methods/ContainsKey.md)         |             |
| [GetEnumerator()](methods/GetEnumerator.md)         |             |
| [TryGetValue(TKey, TValue)](methods/TryGetValue.md) |             |

## Example

public void Method1(IReadOnlyDictionary\<string, string\> dictionary \= null) {     dictionary \= dictionary ?? ReadOnlyDictionar\<string, string\>.Empty; }

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
