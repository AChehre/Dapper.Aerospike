
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
Set property bin builder
```C#
prop.SetBinBuilder((o, p) => new Bin(p.BinName, o.Id));
```
Get bins
```C#
AerospikeEntityTypeBuilder<Order> set = new AerospikeEntityTypeBuilder<Order>();
set.Property(o => o.Id).SetBinBuilder((o, p) => new Bin(p.BinName, o.Id));
Bin[] bins = set.GetBins(order);
```
Get bins name
```C#
var set = new AerospikeEntityTypeBuilder<Order>();
          set.Property(p => p.Id);
          set.Property(p => p.Number);
var bins = set.GetBinNames();
```
Set property value builder
```C#
prop.SetValueBuilder((r, p) => r.GetLong(p.BinName));
```
