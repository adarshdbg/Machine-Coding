namespace Parking_Lot.HashMap
{
    using System;
    using System.Collections.Generic;

    public class HashMap<TKey, TValue>
    {
        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        private int size;
        private const double LoadFactorThreshold = 0.75;

        public HashMap(int initialCapacity = 16)
        {
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[initialCapacity];
            size = 0;
        }

        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode) % buckets.Length;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            if (size >= buckets.Length * LoadFactorThreshold)
            {
                Resize();
            }

            int index = GetBucketIndex(key);
            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists.");
                }
            }

            buckets[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            size++;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            int index = GetBucketIndex(key);
            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            int index = GetBucketIndex(key);
            if (buckets[index] != null)
            {
                var node = buckets[index].First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        buckets[index].Remove(node);
                        size--;
                        return true;
                    }
                    node = node.Next;
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            return TryGetValue(key, out _);
        }

        private void Resize()
        {
            var newBuckets = new LinkedList<KeyValuePair<TKey, TValue>>[buckets.Length * 2];
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        int newIndex = Math.Abs(pair.Key.GetHashCode()) % newBuckets.Length;
                        if (newBuckets[newIndex] == null)
                        {
                            newBuckets[newIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                        }
                        newBuckets[newIndex].AddLast(pair);
                    }
                }
            }
            buckets = newBuckets;
        }

        public int Count => size;
    }

}
