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