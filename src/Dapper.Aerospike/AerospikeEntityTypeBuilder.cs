﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aerospike.Client;
using AtEase.Extensions.Collections;

namespace Dapper.Aerospike
{
    public sealed class AerospikeEntityTypeBuilder<TEntity>
    {
        private readonly Dictionary<string, AerospikeProperty<TEntity>> _propertiesMap =
            new Dictionary<string, AerospikeProperty<TEntity>>();

        public AerospikeEntityTypeBuilder(string set = null)
        {
            SetSet(set);
        }


        public string Set { get; private set; }

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


        private void SetSet(string set)
        {
            Set = set;
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

        public AerospikeEntityTypeBuilder<TEntity> SetNameAsEntity()
        {
            var set = typeof(TEntity).Name;
            SetSet(set);
            return this;
        }
    }
}