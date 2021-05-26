using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aerospike.Client;
using AtEase.Extensions.Collections;

namespace Dapper.Aerospike
{
    public sealed class Set<TEntity>
    {
        private readonly Dictionary<string, AerospikeProperty<TEntity>> _propertiesMap =
            new Dictionary<string, AerospikeProperty<TEntity>>();

        private Func<Record, Dictionary<string, AerospikeProperty<TEntity>>, TEntity> _valueBuilder;


        public Set(string set = null)
        {
            SetSetName(set);
        }


        public string SetName { get; private set; }


        public Set<TEntity> SetValueBuilder(
        Func<Record, Dictionary<string, AerospikeProperty<TEntity>>, TEntity> valueBuilder)
        {
            _valueBuilder = valueBuilder;
            return this;
        }

        public string[] GetBinNames(params string[] properties)
        {
            return properties.Select(p => _propertiesMap[p].BinName).ToArray();
        }

        public string[] GetBinNames()
        {
            return _propertiesMap.Select(a => a.Value.BinName).ToArray();
        }

        public Bin[] GetBins(TEntity entity)
        {
            return _propertiesMap.IsNullOrEmpty()
                ? null
                : _propertiesMap.Values.Select(p => p.BuildBin(entity)).ToArray();
        }

        public TEntity ToEntity(Record record)
        {
            return _valueBuilder.Invoke(record, _propertiesMap);
        }

        private void SetSetName(string set)
        {
            SetName = set;
        }


        public AerospikeProperty[] GetProperties()
        {
            return _propertiesMap.Values.ToArray();
        }

        public AerospikeProperty[] GetProperties(string[] propertyNames)
        {
            return propertyNames.Select(pn => _propertiesMap[pn]).ToArray();
        }


        public AerospikeProperty<TEntity> Property<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            var bin = property.GetPropertyName();
            return Property(property, bin);
        }

        public AerospikeProperty<TEntity> Property<TProperty>(
        Expression<Func<TEntity, TProperty>> property,
        string bin)
        {
            var propertyName = property.GetPropertyName();

            var aerospikeProperty = new AerospikeProperty<TEntity>();
            aerospikeProperty.SetPropertyName(propertyName).SetType(typeof(TProperty)).SetBinName(bin);
            _propertiesMap[propertyName] = aerospikeProperty;


            return aerospikeProperty;
        }

        public AerospikeProperty GetProperty<TReturn>(Expression<Func<TEntity, TReturn>> property)
        {
            return GetProperty(property.GetPropertyName());
        }


        public AerospikeProperty GetProperty(string property)
        {
            return _propertiesMap[property];
        }

        public Set<TEntity> SetNameAsEntity()
        {
            var set = typeof(TEntity).Name;
            SetSetName(set);
            return this;
        }
    }
}