﻿# TupleComparer\<T1, T2, T3\> Class

**Namespace:** [Grynwald.Utilities](../index.md)

**Assembly:** Grynwald.Utilities

Implementation of IEqualityComparer\<T\> for tuples with three elements composed of comparers for the tuple's individual items

```csharp
public class TupleComparer<T1, T2, T3> : IEqualityComparer<ValueTuple<T1, T2, T3>>
```

**Inheritance:** object → TupleComparer\<T1, T2, T3\>

**Implements:** IEqualityComparer\<ValueTuple\<T1, T2, T3\>\>

## Type Parameters

`T1`

The type of the tuple's first element.

`T2`

The type of the tuple's second element.

`T3`

The type of the tuple's third element.

## Constructors

| Name                                                                                                              | Description                                                |
| ----------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------- |
| [TupleComparer(IEqualityComparer\<T1\>, IEqualityComparer\<T2\>, IEqualityComparer\<T3\>)](constructors/index.md) | Initializes a new instance of TupleComparer\<T1, T2, T3\>. |

## Methods

| Name                                                                            | Description |
| ------------------------------------------------------------------------------- | ----------- |
| [Equals(ValueTuple\<T1, T2, T3\>, ValueTuple\<T1, T2, T3\>)](methods/Equals.md) |             |
| [GetHashCode(ValueTuple\<T1, T2, T3\>)](methods/GetHashCode.md)                 |             |

## Example

Using this class, comparers for ValueTuple\<T1, T2, T3\> can easily be created by composing comparers for the tuple's individual elements.

```csharp
var myIntComparer = EqualityComparer<int>.Default;
var myStringComparer = StringComparer.OrdinalIgnoreCase;
var tupleComparer = new TupleComparer<int, string, string>(myIntComparer, myStringComparer, myStringComparer);
var equal = tupleComparer.Equals((1, "foo", "bar"), (1, "FOO", "bar"));
Debug.Assert(equal == true);
```

## See Also

- [TupleComparer](../TupleComparer/index.md)
- TupleComparer\<T1, T2, T3\>

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*