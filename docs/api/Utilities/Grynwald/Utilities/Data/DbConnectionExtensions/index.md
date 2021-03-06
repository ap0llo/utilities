﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# DbConnectionExtensions Class

**Namespace:** [Grynwald.Utilities.Data](../index.md)  
**Assembly:** Grynwald.Utilities

Extension methods for IDbConnection.

```csharp
public static class DbConnectionExtensions
```

**Inheritance:** object → DbConnectionExtensions

## Methods

| Name                                                                                                    | Description                                                                                                                  |
| ------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------- |
| [ExecuteNonQuery(IDbConnection, string, ValueTuple\<string, object\>\[\])](methods/ExecuteNonQuery.md)  | Executes the specified query and returns the number of affected rows.                                                        |
| [ExecuteScalar\<T\>(IDbConnection, string, ValueTuple\<string, object\>\[\])](methods/ExecuteScalar.md) | Executes the specified query and converts the value of the first column of the first returned row to the specified type `T`. |
| [TableExists(IDbConnection, string)](methods/TableExists.md)                                            | Determines if a table with the specified name exists in the underlying database                                              |

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
