﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# SimpleConsoleLogger.Log Method

**Declaring Type:** [SimpleConsoleLogger](../index.md)  
**Namespace:** [Grynwald.Utilities.Logging](../../index.md)  
**Assembly:** Grynwald.Utilities.Logging

Writes a log entry.

```csharp
public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);
```

## Type Parameters

`TState`

The type of the object to be written.

## Parameters

`logLevel`  LogLevel

Entry will be written on this level.

`eventId`  EventId

Id of the event.

`state`  TState

The entry to be written. Can be also an object.

`exception`  Exception

The exception related to this entry.

`formatter`  Func\<TState, Exception, string\>

Function to create a string message of the `state` and `exception`.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
