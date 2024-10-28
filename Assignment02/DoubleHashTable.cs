using System;

namespace Assignment02
{
    // DoubleHashTable class implements a hash table using double hashing for collision resolution
    public class DoubleHashTable<TKey, TValue> : IDoubleHashTable<TKey, TValue>
    {
        private readonly int _size; // Size of the hash table
        private readonly TKey[] _keys; // Array to store keys
        private readonly TValue[] _values; // Array to store values
        private readonly bool[] _isDeleted; // Flags for deleted entries

        // Constructor initializes the hash table with a specific size
        public DoubleHashTable(int size)
        {
            _size = size;
            _keys = new TKey[_size];
            _values = new TValue[_size];
            _isDeleted = new bool[_size];
            Array.Fill(_keys, default(TKey)); // Fill keys array with default values
        }

        // Primary hash function
        private int PrimaryHash(TKey key) => key.GetHashCode() % _size;

        // Secondary hash function for double hashing
        private int SecondaryHash(TKey key) => 1 + (key.GetHashCode() % (_size - 2));

        // Gets the index for a key using double hashing
        public int GetIndex(TKey key)
        {
            int index = PrimaryHash(key);
            int stepSize = SecondaryHash(key);

            while (_keys[index] != null && !_keys[index].Equals(default(TKey)) && !_keys[index].Equals(key))
            {
                index = (index + stepSize) % _size;
            }

            return index;
        }

        // Adds a new entry or updates the entry value if the key already exists
        public void AddOrUpdate(TKey key, TValue value)
        {
            int index = GetIndex(key);
            int stepSize = SecondaryHash(key);

            while (_keys[index] != null && !_keys[index].Equals(default(TKey)) && !_keys[index].Equals(key))
            {
                index = (index + stepSize) % _size;
            }

            _keys[index] = key;
            _values[index] = value;
            _isDeleted[index] = false;
        }

        // Attempts to retrieve a value for a given key, throws if not found
        public TValue TryGetValue(TKey key)
        {
            int index = GetIndex(key);
            int stepSize = SecondaryHash(key);

            while (_keys[index] != null && !_keys[index].Equals(default(TKey)))
            {
                if (_keys[index].Equals(key) && !_isDeleted[index])
                    return _values[index];

                index = (index + stepSize) % _size;
            }

            Console.WriteLine("Key not found");
            return default(TValue); // Return default if key is not found
        }

        // Removes a key from the hash table, returns true if successful
        public bool Remove(TKey key)
        {
            int index = GetIndex(key);
            int stepSize = SecondaryHash(key);

            while (_keys[index] != null && !_keys[index].Equals(default(TKey)))
            {
                if (_keys[index].Equals(key) && !_isDeleted[index])
                {
                    _isDeleted[index] = true;
                    return true;
                }

                index = (index + stepSize) % _size;
            }

            return false; // Return false if key not found
        }
    }
}
