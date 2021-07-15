using System;
using System.Reflection;
using Aerospike.Client;

namespace Dapper.Aerospike
{
    public class AerospikeKey<TEntity>
    {
        private readonly string _namespace;
        private readonly AerospikeProperty<TEntity> _property;
        private readonly string _setName;


        public AerospikeKey(string @namespace,
                            string setName,
                            AerospikeProperty<TEntity> property) : this(setName, property)
        {
            _namespace = @namespace;
        }

        public AerospikeKey(string setName, AerospikeProperty<TEntity> property)
        {
            _setName = setName;
            _property = property;
        }


        public Key[] GetKeys(Guid[] keyValues)
        {
            Key[] keys = new Key[keyValues.Length];

            for (var i = 0; i < keyValues.Length; i++)
            {
                keys[i] = new Key(_namespace, _setName, keyValues[i].GetAsValue());
            }

            return keys;
        }

        public Key[] GetKeys(DateTime[] keyValues)
        {
            Key[] keys = new Key[keyValues.Length];

            for (var i = 0; i < keyValues.Length; i++)
            {
               keys[i] = new Key(_namespace, _setName, keyValues[i].GetAsValue());
            }

            return keys;
        }

        public Key[] GetKeys(long[] keyValues)
        {
            var keys = new Key[keyValues.Length];
            for (var i = 0; i < keyValues.Length; i++)
            {
                keys[i] = new Key(_namespace, _setName, Value.Get(keyValues[i]));
            }

            return keys;

        }

        public Key[] GetKeys(object[] keyValues)
        {
            var keys = new Key[keyValues.Length];
            for (var i = 0; i < keyValues.Length; i++)
            {
               keys[i] = new Key(_namespace, _setName, Value.Get(keyValues[i]));
            }

            return keys;

        }


        public Key GetKey(Guid keyValue)
        {
            return new Key(_namespace, _setName, keyValue.GetAsValue());
        }

        public Key GetKey(DateTime keyValue)
        {
            return new Key(_namespace, _setName, keyValue.GetAsValue());
        }

        public Key GetKey(object keyValue)
        {
           var value = Value.Get(keyValue);
            return new Key(_namespace, _setName, value);
        }
        public Key GetKey(TEntity entity)
        {
            return new Key(_namespace, _setName, _property.BuildAerospikeValue(entity));
        }

        public Key GetKey(string @namespace, TEntity entity)
        {
            return new Key(_namespace, _setName, _property.BuildAerospikeValue(entity));
        }
    }
}