﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# ReversibleDictionary\<TKey, TValue\>.Remove Method

**Declaring Type:** [ReversibleDictionary\<TKey, TValue\>](../index.md)  
**Namespace:** [Grynwald.Utilities.Collections](../../index.md)  
**Assembly:** Grynwald.Utilities

## Overloads

| Signature                                                              | Description                                                                  |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------------- |
| [Remove(KeyValuePair\<TKey, TValue\>)](#removekeyvaluepairtkey-tvalue) | Removes the first occurrence of a specific object from the ICollection\<T\>. |
| [Remove(TKey)](#removetkey)                                            | Removes the element with the specified key from the IDictionary\<T1, T2\>.   |

## Remove(KeyValuePair\<TKey, TValue\>)

Removes the first occurrence of a specific object from the ICollection\<T\>.

```csharp
public bool Remove(KeyValuePair<TKey, TValue> item);
```

### Parameters

`item`  KeyValuePair\<TKey, TValue\>

The object to remove from the ICollection\<T\>.

### Returns

bool

 if `item` was successfully removed from the ICollection\<T\>; otherwise, . This method also returns  if `item` is not found in the original ICollection\<T\>.

### Exceptions

NotSupportedException

The ICollection\<T\> is read\-only.

## Remove(TKey)

Removes the element with the specified key from the IDictionary\<T1, T2\>.

```csharp
public bool Remove(TKey key);
```

### Parameters

`key`  TKey

The key of the element to remove.

### Returns

bool

 if the element is successfully removed; otherwise, .  This method also returns  if `key` was not found in the original IDictionary\<T1, T2\>.

### Exceptions

ArgumentNullException

`key` is .

NotSupportedException

The IDictionary\<T1, T2\> is read\-only.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
