using System;
using System.Reflection;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public class AerospikeProperty<TEntity> : AerospikeProperty
    {
        private Func<TEntity, AerospikeProperty, Bin> _binBuilder;
        private Func<Record, AerospikeProperty, dynamic> _valueBuilder;

        public Bin BuildBin(TEntity entity)
        {
            if (_binBuilder != null)
            {
                return _binBuilder.Invoke(entity, this);
            }

            throw new NotImplementedException();
        }

        public TValue BuildValue<TValue>(Record record)
        {
            return (TValue) _valueBuilder.Invoke(record, this);
        }

        public AerospikeProperty<TEntity> SetValueBuilder(
        Func<Record, AerospikeProperty, dynamic> valueBuilder)
        {
            _valueBuilder = valueBuilder;
            return this;
        }

        public AerospikeProperty<TEntity> SetBinBuilder(
        Func<TEntity, AerospikeProperty, Bin> binBuilder)
        {
            _binBuilder = binBuilder;
            return this;
        }
    }

    public class AerospikeProperty
    {
        public string BinName { get; private set; }

        public Type Type { get; private set; }
        public PropertyInfo PropertyInfo { get; private set; }

        public string PropertyName { get; private set; }

        public AerospikeProperty SetPropertyInfo(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            return this;
        }

        public AerospikeProperty SetPropertyName(string name)
        {
            PropertyName = name;
            return this;
        }

        public AerospikeProperty SetType(Type type)
        {
            Type = type;
            return this;
        }

        public AerospikeProperty SetBinName(string bin)
        {
            BinName = bin;
            return this;
        }
    }
}