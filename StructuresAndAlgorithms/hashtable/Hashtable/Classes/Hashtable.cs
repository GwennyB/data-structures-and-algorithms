﻿using System;
using System.Collections.Generic;
using System.Text;
using linked_list.Classes;

namespace Hashtable.Classes
{
    class Hashtable
    {
        // associative array
        private int _size;
        private LinkedList[] Buckets { get; set; }

        /// <summary>
        /// CONSTRUCTOR: builds the associative array of specified length to store key-value pairs
        /// </summary>
        /// <param name="size"> desired length of associative array </param>
        public Hashtable(int size)
        {
            _size = size;
            Buckets = new LinkedList[size];
        }

        /// <summary>
        /// converts a key into an associated index
        /// </summary>
        /// <param name="key"> key to hash </param>
        /// <returns> hashed index </returns>
        public int Hash(Object key)
        {
            string keyString = (string)key;
            int num = 1;
            foreach (char item in keyString)
            {
                num *= item;
            }
            return num % _size;
        }

        /// <summary>
        /// creates a new linked list in the hashtable index if empty
        /// adds key/value pair to the appropriate location in the hashtable
        /// </summary>
        /// <param name="key"> value of 'Key' </param>
        /// <param name="value"> value of 'Value' </param>
        public void Add(Object key, Object value)
        {
            int idx = Hash(key);
            if (Buckets[idx] == null)
            {
                Buckets[idx] = new LinkedList();
            }
            if (Get(key) == null)
            {
                Buckets[idx].Append(new Node(key, value));
            }
        }

        /// <summary>
        /// locates a key in hashtable and returns its associated value
        /// </summary>
        /// <param name="key"> key to locate in hashtable </param>
        /// <returns> value associated with key, or 'null' if not found </returns>
        public Object Get(Object key)
        {
            int idx = Hash(key);
            if (Buckets[idx] == null)
            {
                return null;
            }
            return Buckets[idx].Find(key);
        }

        /// <summary>
        /// finds specified key in hashtable
        /// if present, compares values
        /// if matching, return true
        /// </summary>
        /// <param name="key"> value of 'key' to locate </param>
        /// <param name="value"> value of 'value' to confirm </param>
        /// <returns></returns>
        public bool Contains(Object key, Object value)
        {
            return Get(key).Equals(value) ? true : false;
        }

    }
}
