namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private LinkedList<KeyValue<TKey, TValue>>[] slots;
        public int Count { get; private set; }
        private const double loadFactor = 0.75;
        private const int initialCapacity = 16;

        public int Capacity { get => this.slots.Length; }

        public HashTable()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[initialCapacity];
            this.Count = 0;
        }

        public HashTable(int capacity = initialCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            this.Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            if (this.FillFactor() >= loadFactor)
            {
                this.Grow();
            }

            int slotIndex = FindHashCode(key);

            if (this.slots[slotIndex] == null)
            {
                this.slots[slotIndex] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var item in this.slots[slotIndex])
            {
                if (item.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists: " + key);
                }
            }

            var currEl = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotIndex].AddLast(currEl);
            this.Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {

            if (this.FillFactor() >= loadFactor)
            {
                this.Grow();
            }

            int slotIndex = FindHashCode(key);

            if (this.slots[slotIndex] == null)
            {
                this.slots[slotIndex] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var item in this.slots[slotIndex])
            {
                if (item.Key.Equals(key))
                {
                    item.Value = value;
                    return false;
                }
            }

            var currEl = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotIndex].AddLast(currEl);
            this.Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            var element = this.Find(key);

            if (element == null)
            {
                throw new KeyNotFoundException();
            }

            return element.Value;
        }

        public TValue this[TKey key]
        {
            get
            {
                var element = this.Find(key);
                if (element == null)
                {
                    throw new KeyNotFoundException();
                }
                return element.Value;
            }
            set
            {
                 this.AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);

            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int slotIndex = FindHashCode(key);
            var list = this.slots[slotIndex];

            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.Key.Equals(key))
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            var element = this.Find(key);
            return element != null;
        }

        public bool Remove(TKey key)
        {
            var SlotIndex = FindHashCode(key);

            if (this.slots[SlotIndex] != null)
            {
                var currElement = this.slots[SlotIndex].First;

                while (currElement != null)
                {
                    if (currElement.Value.Key.Equals(key))
                    {
                        this.slots[SlotIndex].Remove(currElement);
                        this.Count--;
                        return true;
                    }
                    currElement = currElement.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[initialCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys { get => this.Select(e => e.Key); }

        public IEnumerable<TValue> Values { get => this.Select(e => e.Value); }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var list in this.slots.Where(x => x != null))
            {
                foreach (var item in list)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private double FillFactor()
        {
            return (this.Count + 1) / this.Capacity;
        }

        private void Grow()
        {
            var temp = new HashTable<TKey, TValue>(this.Capacity * 2);

            foreach (var item in this)
            {
                temp.Add(item.Key, item.Value);
            }

            this.slots = temp.slots;
            this.Count = temp.Count;
        }

        private int FindHashCode(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % this.slots.Length;
        }
    }
}
