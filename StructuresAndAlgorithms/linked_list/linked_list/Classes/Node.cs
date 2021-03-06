﻿using System;
using System.Collections.Generic;
using System.Text;

namespace linked_list.Classes
{
    public class Node
    {
        public Object Value { get; set; }

        // for linked lists
        public Node Next { get; set; }

        // for trees
        public Node Left { get; set; }
        public Node Right { get; set; }

        // for hashtables
        public Object Key { get; set; }

        /// <summary>
        /// Constructor - require value at node creation
        /// </summary>
        /// <param name="value"></param>
        public Node(Object value)
        {
            Value = value;
            Next = null;
            Left = null;
            Right = null;
            Neighbors = new List<Tuple<Node, int>>();
            Visited = false;
        }

        /// <summary>
        /// Constructor - require value and key at node creation (for hashtable)
        /// </summary>
        /// <param name="key"> value of 'Key' </param>
        /// <param name="value"> value of 'Value' </param>
        public Node(Object key, Object value)
        {
            Key = key;
            Value = value;
            Next = null;
            Left = null;
            Right = null;
        }

        // for graphs
        public bool Visited { get; set; }
        public List<Tuple<Node,int>> Neighbors { get; set; }


    }
}
