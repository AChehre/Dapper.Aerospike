using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public interface ISet<TEntity>
    {
        IAsyncClient Client { get; }
        AerospikeKey<TEntity> AerospikeKey { get; }
        string Name { get; }
        string Namespace { get; }

        Set<TEntity> SetValueBuilder(
        Func<Record, Dictionary<string, AerospikeProperty<TEntity>>, TEntity> valueBuilder);

        string[] GetBinNames(params string[] properties);
        string[] GetBinNames();
        Bin[] GetBins(TEntity entity);
        TEntity ToEntity(Record record);
        TEntity GetEntity(Record record);
        AerospikeProperty[] GetProperties();
        AerospikeProperty[] GetProperties(string[] propertyNames);
        AerospikeProperty<TEntity> Property<TProperty>(Expression<Func<TEntity, TProperty>> property);

        AerospikeProperty<TEntity> Property<TProperty>(
        Expression<Func<TEntity, TProperty>> property,
        string bin);

        AerospikeProperty<TEntity> KeyProperty<TProperty>(Expression<Func<TEntity, TProperty>> property);

        AerospikeProperty<TEntity> KeyProperty<TProperty>(
        Expression<Func<TEntity, TProperty>> property,
        string bin);

        AerospikeProperty GetProperty<TReturn>(Expression<Func<TEntity, TReturn>> property);
        AerospikeProperty GetProperty(string property);
        Set<TEntity> SetNameAsEntity();
    }
}