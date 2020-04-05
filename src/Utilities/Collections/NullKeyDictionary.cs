﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Implementation of <see cref="IDictionary{TKey, TValue}"/> that allows using <c>null</c> as key.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public class NullKeyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        bool m_ContainsNull = false;
        TValue m_NullValue;
        readonly IDictionary<TKey, TValue> m_InnerDictionary;
        readonly IEqualityComparer<TValue> m_ValueComparer = EqualityComparer<TValue>.Default;

        /// <inheritdoc />
        public TValue this[TKey key]
        {
            get
            {
                if (key == null)
                {
                    return m_ContainsNull ? m_NullValue : throw new KeyNotFoundException();
                }
                else
                {
                    return m_InnerDictionary[key];
                }
            }
            set
            {
                if (key == null)
                {
                    m_ContainsNull = true;
                    m_NullValue = value;
                }
                else
                {
                    m_InnerDictionary[key] = value;
                }
            }
        }

        /// <inheritdoc />
        public ICollection<TKey> Keys
        {
            get
            {
                if (m_ContainsNull)
                    return m_InnerDictionary.Keys.Union(default(TKey).Yield()).ToList();
                else
                    return m_InnerDictionary.Keys;
            }
        }

        /// <inheritdoc />
        public ICollection<TValue> Values
        {
            get
            {
                if (m_ContainsNull)
                    return m_InnerDictionary.Values.Union(m_NullValue.Yield()).ToList();
                else
                    return m_InnerDictionary.Values;
            }
        }

        /// <inheritdoc />
        public int Count => m_InnerDictionary.Count + (m_ContainsNull ? 1 : 0);

        /// <inheritdoc />
        public bool IsReadOnly => m_InnerDictionary.IsReadOnly;


        /// <summary>
        /// Initializes a new instance of <see cref="NullKeyDictionary{TKey, TValue}"/>.
        /// </summary>
        public NullKeyDictionary() =>
            m_InnerDictionary = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Initializes a new instance of <see cref="NullKeyDictionary{TKey, TValue}"/> using the specified key comparer.
        /// </summary>
        public NullKeyDictionary(IEqualityComparer<TKey> keyComparer) =>
            m_InnerDictionary = new Dictionary<TKey, TValue>(keyComparer);


        /// <inheritdoc />
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            IEnumerable<KeyValuePair<TKey, TValue>> enumerable = m_InnerDictionary;

            if (m_ContainsNull)
            {
                enumerable = enumerable.Union(new KeyValuePair<TKey, TValue>(default(TKey), m_NullValue).Yield());
            }

            return enumerable.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        /// <inheritdoc />
        public void Clear()
        {
            m_NullValue = default(TValue);
            m_ContainsNull = false;
            m_InnerDictionary.Clear();
        }

        /// <inheritdoc />
        public bool Contains(KeyValuePair<TKey, TValue> item) =>
            ContainsKey(item.Key) && m_ValueComparer.Equals(item.Value, this[item.Key]);

        /// <inheritdoc />
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) =>
            throw new NotSupportedException();

        /// <inheritdoc />
        public bool Remove(KeyValuePair<TKey, TValue> item) =>
            throw new NotSupportedException();

        /// <inheritdoc />
        public bool ContainsKey(TKey key) =>
            key == null ? m_ContainsNull : m_InnerDictionary.ContainsKey(key);

        /// <inheritdoc />
        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                if (m_ContainsNull)
                {
                    throw new ArgumentException("An item with the same key already exists");
                }

                m_ContainsNull = true;
                m_NullValue = value;
            }
            else
            {
                m_InnerDictionary.Add(key, value);
            }
        }

        /// <inheritdoc />
        public bool Remove(TKey key)
        {
            if (key == null)
            {
                if (m_ContainsNull)
                {
                    m_ContainsNull = false;
                    m_NullValue = default(TValue);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return m_InnerDictionary.Remove(key);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
            {
                value = m_NullValue;
                return m_ContainsNull;
            }
            else
            {
                return m_InnerDictionary.TryGetValue(key, out value);
            }
        }
    }
}
