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


            if (Type == typeof(decimal?))
            {
                var value = PropertyInfo.GenerateNullableDecimalGetterLambda().Invoke(entity);
                return value.GetAsValue();
            }

            if (Type == typeof(decimal))
            {
                var value = PropertyInfo.GenerateDecimalGetterLambda().Invoke(entity);
                return value.GetAsValue();
            }
            if (Type == typeof(Guid))
            {
                var value = PropertyInfo.GenerateGuidGetterLambda().Invoke(entity);
                return value.GetAsValue();
            }
            if (Type == typeof(Guid?))
            {
                var value = PropertyInfo.GenerateNullableGuidGetterLambda().Invoke(entity);
                return value.GetAsValue();
            }


            if (Type == typeof(DateTime))
            {
                var value = PropertyInfo.GenerateDateTimeGetterLambda().Invoke(entity);
                return value.GetAsValue();
            }
            if (Type == typeof(DateTime?))
            {
                var value = PropertyInfo.GenerateNullableDateTimeGetterLambda().Invoke(entity);
                return value.GetAsValue();
            }

            if (Type == typeof(DateTimeOffset))
            {
                var value = PropertyInfo.GenerateDateTimeOffsetGetterLambda().Invoke(entity);
                return value.GetAsValue();
            }
            if (Type == typeof(DateTimeOffset?))
            {
                var value = PropertyInfo.GenerateNullableDateTimeOffsetGetterLambda().Invoke(entity);
                return value.GetAsValue();
            }

            var objectValue = PropertyInfo.GenerateGetterLambda().Invoke(entity);

            return Value.Get(objectValue);
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