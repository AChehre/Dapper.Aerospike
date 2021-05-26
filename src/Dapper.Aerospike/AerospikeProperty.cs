using System;
using System.Reflection;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public class AerospikeProperty<TEntity> : AerospikeProperty
    {
        private Func<TEntity, AerospikeProperty, Bin> _binBuilder;
        private Func<Record, AerospikeProperty, dynamic> _binValueBuilder;
        private Func<TEntity, AerospikeProperty, Value> _valueBuilder;


        public Bin BuildBin(TEntity entity)
        {
            if (_binBuilder != null)
            {
                return _binBuilder.Invoke(entity, this);
            }

            Value value = BuildAerospikeValue(entity);

            return new Bin(BinName, value);
        }

        public Value BuildAerospikeValue(TEntity entity)
        {
            if (_valueBuilder != null)
            {
                return _valueBuilder.Invoke(entity, this);
            }

            var value = PropertyInfo.GenerateGetterLambda().Invoke(entity);
            return Value.Get(value);
        }


        public TValue BuildValue<TValue>(Record record)
        {
            return (TValue) _binValueBuilder.Invoke(record, this);
        }


        public AerospikeProperty<TEntity> SetBinValueBuilder(
        Func<Record, AerospikeProperty, dynamic> valueBuilder)
        {
            _binValueBuilder = valueBuilder;
            return this;
        }

        public AerospikeProperty<TEntity> SetValueBuilder(Func<TEntity, AerospikeProperty, Value> valueBuilder)
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