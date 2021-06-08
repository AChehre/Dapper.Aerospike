using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aerospike.Client;
using AtEase.Extensions;
using AtEase.Extensions.Collections;

namespace Dapper.Aerospike
{
  
    public class Set<TEntity> : ISet<TEntity>    {
        private readonly Dictionary<string, AerospikeProperty<TEntity>> _propertiesMapByPropertyName = new();

        private AerospikeKey<TEntity> _aerospikeKey;


        private Func<Record, Dictionary<string, AerospikeProperty<TEntity>>, TEntity> _valueBuilder;

        public Set(IAsyncClient client, string @namespace, string set = null) : this(@namespace, set)
        {
            Client = client;
        }

        public Set(string @namespace, string set = null)
        {
            SetNamespace(@namespace);
            SetSetName(set);
        }

        public IAsyncClient Client { get; private set; }


        public AerospikeKey<TEntity> AerospikeKey
        {
            get => _aerospikeKey;
            private set
            {
                if (_aerospikeKey.IsNotNull())
                {
                    throw new Exception("Key already defined");
                }

                _aerospikeKey = value;
            }
        }


        public string Name { get; private set; }
        public string Namespace { get; private set; }


        public Set<TEntity> SetValueBuilder(
        Func<Record, Dictionary<string, AerospikeProperty<TEntity>>, TEntity> valueBuilder)
        {
            _valueBuilder = valueBuilder;
            return this;
        }

        public string[] GetBinNames(params string[] properties)
        {
            return properties.Select(p => _propertiesMapByPropertyName[p].BinName).ToArray();
        }

        public string[] GetBinNames()
        {
            return _propertiesMapByPropertyName.Select(a => a.Value.BinName).ToArray();
        }

        public Bin[] GetBins(TEntity entity)
        {
            return _propertiesMapByPropertyName.IsNullOrEmpty()
                ? null
                : _propertiesMapByPropertyName.Values.Select(p => p.BuildBin(entity)).ToArray();
        }

        public TEntity ToEntity(Record record)
        {
            return _valueBuilder.Invoke(record, _propertiesMapByPropertyName);
        }

        public TEntity GetEntity(Record record)
        {
            return _valueBuilder.Invoke(record, _propertiesMapByPropertyName);
        }

        public AerospikeProperty[] GetProperties()
        {
            return _propertiesMapByPropertyName.Values.ToArray();
        }

        public AerospikeProperty[] GetProperties(string[] propertyNames)
        {
            return propertyNames.Select(pn => _propertiesMapByPropertyName[pn]).ToArray();
        }


        public AerospikeProperty<TEntity> Property<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            var bin = property.GetPropertyName();
            return Property(property, bin);
        }

        public AerospikeProperty<TEntity> KeyProperty<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            var bin = property.GetPropertyName();
            return KeyProperty(property, bin);
        }

        public AerospikeProperty<TEntity> Property<TProperty>(
        Expression<Func<TEntity, TProperty>> property,
        string bin)
        {
            var propertyInfo = property.GetPropertyInfo();
            var propertyName = property.GetPropertyName();

            var aerospikeProperty = new AerospikeProperty<TEntity>();
            aerospikeProperty.SetPropertyName(propertyName)
                             .SetType(typeof(TProperty))
                             .SetBinName(bin)
                             .SetPropertyInfo(propertyInfo);
            _propertiesMapByPropertyName[propertyName] = aerospikeProperty;


            return aerospikeProperty;
        }

        public AerospikeProperty<TEntity> KeyProperty<TProperty>(
        Expression<Func<TEntity, TProperty>> property,
        string bin)
        {
            var prop = Property(property, bin);
            AerospikeKey = new AerospikeKey<TEntity>(Namespace, Name, prop);


            return prop;
        }


        public AerospikeProperty GetProperty<TReturn>(Expression<Func<TEntity, TReturn>> property)
        {
            return GetProperty(property.GetPropertyName());
        }


        public AerospikeProperty GetProperty(string property)
        {
            return _propertiesMapByPropertyName[property];
        }

        public Set<TEntity> SetNameAsEntity()
        {
            var set = typeof(TEntity).Name;
            SetSetName(set);
            return this;
        }

        public void SetClient(IAsyncClient client)
        {
            Client = client;
        }

        private void SetNamespace(string @namespace)
        {
            Namespace = @namespace;
        }


        private void SetSetName(string set)
        {
            Name = set;
        }
    }
}