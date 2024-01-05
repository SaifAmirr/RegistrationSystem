using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_System
{
    public class HashTable<TKey, TValue>
    {
        private const int Capacity = 100;
        private List<KeyValuePair<TKey, TValue>>[] buckets;

        public HashTable()
        {
            buckets = new List<KeyValuePair<TKey, TValue>>[Capacity];
        }

        private int GetHashIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode % Capacity);
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetHashIndex(key);

            if (buckets[index] == null)
            {
                buckets[index] = new List<KeyValuePair<TKey, TValue>>();
            }

            foreach (var kvp in buckets[index])
            {
                if (kvp.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists in the hashtable");
                }
            }

            buckets[index].Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public TValue Get(TKey key)
        {
            int index = GetHashIndex(key);

            if (buckets[index] != null)
            {
                foreach (var kvp in buckets[index])
                {
                    if (kvp.Key.Equals(key))
                    {
                        return kvp.Value;
                    }
                }
            }

            throw new KeyNotFoundException("Key not found in the hashtable");
        }

        public void Remove(TKey key)
        {
            int index = GetHashIndex(key);

            if (buckets[index] != null)
            {
                buckets[index].RemoveAll(kvp => kvp.Key.Equals(key));
            }
        }

        public bool ContainsKey(TKey key)
        {
            int index = GetHashIndex(key);

            if (buckets[index] != null)
            {
                return buckets[index].Any(kvp => kvp.Key.Equals(key));
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = GetHashIndex(key);

            if (buckets[index] != null)
            {
                foreach (var kvp in buckets[index])
                {
                    if (kvp.Key.Equals(key))
                    {
                        value = kvp.Value;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        public void Clear()
        {
            buckets = new List<KeyValuePair<TKey, TValue>>[Capacity];
        }

        public int Count
        {
            get
            {
                return buckets.Sum(bucket => bucket?.Count ?? 0);
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return buckets.Where(bucket => bucket != null)
                              .SelectMany(bucket => bucket.Select(kvp => kvp.Key));
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return buckets.Where(bucket => bucket != null)
                              .SelectMany(bucket => bucket.Select(kvp => kvp.Value));
            }
        }

    }
}
