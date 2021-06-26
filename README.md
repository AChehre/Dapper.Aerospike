
[projectUri]: https://github.com/AChehre/Dapper.Aerospike
[projectGit]: git@github.com:AChehre/Dapper.Aerospike.git


# Dapper.Aerospike
[![NuGet](https://img.shields.io/nuget/v/Dapper.Aerospike.svg)](https://www.nuget.org/packages/Dapper.Aerospike)

[Aerospike](https://github.com/aerospike) is a distributed, scalable NoSQL database.

And Dapper.Aerospike is fluent mapper that brings type safety and reducing some of the brittleness of the code.

## Installation
Available for [.NET Standard 2.0+](https://docs.microsoft.com/en-gb/dotnet/standard/net-standard)

### NuGet
```
PM> Install-Package Dapper.Aerospike -Version 0.0.0-alpha.0.23
```

### How to use

Define client
```C#
// define DB set
ISet set = new DbSet<Order>(Host,Port,Namespace, optional setName);
set.KeyProperty(p => p.Id);
set.Property(p => p.Number);

// define set
ISet set = new Set<Order>(Namespace, optional setName);
set.KeyProperty(p => p.Id);
set.Property(p => p.Number);

// define set with Client
ISet set = new Set<Order>(Client, Namespace, optional setName);
set.KeyProperty(p => p.Id);
set.Property(p => p.Number);
```

Add to database
```C#
set.Add(order, cancellationToken);
```

Get and query from database
```C#
// define set
set.SetValueBuilder((record, properties) =>
          {
              return new Order()
              {
                  Id = record.GetLong(properties[nameof(Order.Id)].BinName),
                  Number = record.GetString(properties[nameof(Order.Number)].BinName)
              };
          });

// Get from database
Order order = set.Get(orderId, cancellationToken);

// Query all from database
List<Order> orders = set.Query();        
```


Get bins name
```C#
string bins = set.GetBinNames();
```
Get bins
```C#
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
set.KeyProperty(p => p.Id);

// get key
Key key = set.Key(orderId);
```
