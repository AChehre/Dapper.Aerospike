
[projectUri]: https://github.com/AChehre/Dapper.Aerospike
[projectGit]: git@github.com:AChehre/Dapper.Aerospike.git


# Dapper.Aerospike
[![NuGet](https://img.shields.io/nuget/v/Dapper.Aerospike.svg)](https://www.nuget.org/packages/Dapper.Aerospike)

Aerospike fluent mapper that brings type safety.

## Installation
Available for [.NET Standard 2.0+](https://docs.microsoft.com/en-gb/dotnet/standard/net-standard)

### NuGet
```
PM> Install-Package Dapper.Aerospike -Version 0.0.0-alpha.0.1
```

### How to use
Get bins name
```C#
var set = new Set<Order>("namespace");
          set.Property(p => p.Id);
          set.Property(p => p.Number);
var bins = set.GetBinNames();
```
Get bins
```C#
Set<Order> set = new Set<Order>("namespace");
          set.Property(o => o.Id);
Bin[] bins = set.GetBins(order);
```
Set custom bin builder
```C#
prop.SetBinBuilder((o, p) => new Bin(p.BinName, o.Id));
```
Set custom value builder
```C#
prop.SetValueBuilder((r, p) => r.GetLong(p.BinName));
```
Set key property
```C#
var set = new Set<Order>("namespace");
          set.KeyProperty(p => p.Id);
Key key = set.Key;
```
