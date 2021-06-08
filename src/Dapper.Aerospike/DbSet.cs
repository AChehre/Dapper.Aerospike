using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public class DbSet<TEntity> : AsyncClient, ISet<TEntity>
    {
        private readonly Set<TEntity> _set;

        public DbSet(string hostname, int port, string @namespace, string set = null) : base(hostname, port)
        {
            _set = new Set<TEntity>(this, @namespace, set);
        }

        public DbSet(AsyncClientPolicy policy, string hostname, int port, string @namespace, string set = null) : base(
        policy,
        hostname,
        port)
        {
            _set = new Set<TEntity>(this,@namespace, set);
        }

        public DbSet(AsyncClientPolicy policy, string @namespace, string set = null, params Host[] hosts) : base(
        policy,
        hosts)
        {
            _set = new Set<TEntity>(this,@namespace, set);
        }

        public AerospikeKey<TEntity> AerospikeKey => _set.AerospikeKey;

        public string Name => _set.Name;

        public string Namespace => _set.Namespace;

        public IAsyncClient Client => _set.Client;

        public string[] GetBinNames(params string[] properties)
        {
            return _set.GetBinNames(properties);
        }

        public string[] GetBinNames()
        {
            return _set.GetBinNames();
        }

        public Bin[] GetBins(TEntity entity)
        {
            return _set.GetBins(entity);
        }

        public TEntity GetEntity(Record record)
        {
            return _set.GetEntity(record);
        }

        public AerospikeProperty[] GetProperties()
        {
            return _set.GetProperties();
        }

        public AerospikeProperty[] GetProperties(string[] propertyNames)
        {
            return _set.GetProperties(propertyNames);
        }

        public AerospikeProperty GetProperty<TReturn>(Expression<Func<TEntity, TReturn>> property)
        {
            return _set.GetProperty(property);
        }

        public AerospikeProperty GetProperty(string property)
        {
            return _set.GetProperty(property);
        }

        public AerospikeProperty<TEntity> KeyProperty<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            return _set.KeyProperty(property);
        }

        public AerospikeProperty<TEntity> KeyProperty<TProperty>(Expression<Func<TEntity, TProperty>> property,
                                                                 string bin)
        {
            return _set.KeyProperty(property);
        }

        public AerospikeProperty<TEntity> Property<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            return _set.Property(property);
        }

        public AerospikeProperty<TEntity> Property<TProperty>(Expression<Func<TEntity, TProperty>> property, string bin)
        {
            return _set.Property(property);
        }

        public Set<TEntity> SetNameAsEntity()
        {
            return _set.SetNameAsEntity();
        }

        public Set<TEntity> SetValueBuilder(
        Func<Record, Dictionary<string, AerospikeProperty<TEntity>>, TEntity> valueBuilder)
        {
            return _set.SetValueBuilder(valueBuilder);
        }

        public TEntity ToEntity(Record record)
        {
            return _set.ToEntity(record);
        }

        public void SetClient(IAsyncClient client)
        {
            _set.SetClient(client);
        }
    }
}