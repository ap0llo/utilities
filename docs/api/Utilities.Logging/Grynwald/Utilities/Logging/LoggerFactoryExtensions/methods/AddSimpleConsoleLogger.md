﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# LoggerFactoryExtensions.AddSimpleConsoleLogger Method

**Declaring Type:** [LoggerFactoryExtensions](../index.md)  
**Namespace:** [Grynwald.Utilities.Logging](../../index.md)  
**Assembly:** Grynwald.Utilities.Logging

## Overloads

| Signature                                                                                                                                          | Description                                                                                                             |
| -------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| [AddSimpleConsoleLogger(ILoggerFactory)](#addsimpleconsoleloggeriloggerfactory)                                                                    | Adds a [SimpleConsoleLoggerProvider](../../SimpleConsoleLoggerProvider/index.md) logging provider to the logger factory |
| [AddSimpleConsoleLogger(ILoggerFactory, SimpleConsoleLoggerConfiguration)](#addsimpleconsoleloggeriloggerfactory-simpleconsoleloggerconfiguration) | Adds a [SimpleConsoleLoggerProvider](../../SimpleConsoleLoggerProvider/index.md) logging provider to the logger factory |

## AddSimpleConsoleLogger(ILoggerFactory)

Adds a [SimpleConsoleLoggerProvider](../../SimpleConsoleLoggerProvider/index.md) logging provider to the logger factory

```csharp
public static ILoggerFactory AddSimpleConsoleLogger(this ILoggerFactory loggerFactory);
```

### Parameters

`loggerFactory`  ILoggerFactory

### Returns

ILoggerFactory

## AddSimpleConsoleLogger(ILoggerFactory, SimpleConsoleLoggerConfiguration)

Adds a [SimpleConsoleLoggerProvider](../../SimpleConsoleLoggerProvider/index.md) logging provider to the logger factory

```csharp
public static ILoggerFactory AddSimpleConsoleLogger(this ILoggerFactory loggerFactory, SimpleConsoleLoggerConfiguration configurtation);
```

### Parameters

`loggerFactory`  ILoggerFactory

`configurtation`  [SimpleConsoleLoggerConfiguration](../../SimpleConsoleLoggerConfiguration/index.md)

### Returns

ILoggerFactory

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
