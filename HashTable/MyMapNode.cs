using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class MyMapNode<K, V>
    {
        //Creating a structure to maintain Key Value pair in hashtable
        public struct KeyValuePair<k, v>
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
        //Declaring a local variable 
        private readonly int size;
        private readonly LinkedList<KeyValuePair<K, V>>[] listOfKeyValuePair;
        //Creating a Constructor with hashtable size parameter
        public MyMapNode(int size)
        {
            this.size = size;
            this.listOfKeyValuePair = new LinkedList<KeyValuePair<K, V>>[size];
        }
        //Creating a method to check word is already present in hashtable or not
        public bool Exists(K key)
        {
            var linkedList = GetArrayPositionAndLinkedList(key);
            foreach (KeyValuePair<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
        //creating a method to get position with linkedlist at that position of word in hashtable
        public LinkedList<KeyValuePair<K, V>> GetArrayPositionAndLinkedList(K key)
        {
            int position = GetArrayPostion(key);
            LinkedList<KeyValuePair<K, V>> linkedList = GetLinkedList(position);
            return linkedList;
        }
        //creating a method to get position of word in hashtable
        public int GetArrayPostion(K key)
        {
            int hash = key.GetHashCode(); // storing hashcode of word
            int position = hash % size; //Resizing the hash code according the size of hashtable
            return Math.Abs(position); // Take the only positive integer
        }
        //creating a linkedlist at particular position to maintain multiple key value pair at same position in hash table
        public LinkedList<KeyValuePair<K, V>> GetLinkedList(int position)
        {
            var linkedList = listOfKeyValuePair[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValuePair<K, V>>();
                listOfKeyValuePair[position] = linkedList; // If there is no linkedlist created at position then create new linked list
            }
            return linkedList;
        }
        //creating a method to get frequency of exist words in hastable 
        public V Get(K key)
        {
            var linkedList = GetArrayPositionAndLinkedList(key);
            foreach (KeyValuePair<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value; // If hash table contains word then return it's frequency
                }
            }
            return default(V);
        }
        //Creating a method to add word and it's frequency in linked list which is created at particular position in hashtable
        public void Add(K key, V value)
        {
            var linkedList = GetArrayPositionAndLinkedList(key);
            KeyValuePair<K, V> item = new KeyValuePair<K, V> { Key = key, Value = value }; // Storing word and frequency in one structure only
            if (linkedList.Count != 0)
            {
                foreach (KeyValuePair<K, V> pair in linkedList)
                {
                    if (pair.Key.Equals(key)) // 
                    {
                        Remove(key); // If word is already exists then remove this word and frequency from hashtable and add again this word with new frequency
                        break;
                    }
                }
            }
            linkedList.AddLast(item);
        }
        ////Creating a method to remove word and it's frequency in linked list which is created at particular position in hashtable
        public void Remove(K key)
        {
            var linkedList = GetArrayPositionAndLinkedList(key);
            bool keyFound = false;
            KeyValuePair<K, V> foundItem = default(KeyValuePair<K, V>);
            foreach (KeyValuePair<K, V> pair in linkedList)
            {
                if (pair.Key.Equals(key))
                {
                    keyFound = true;
                    foundItem = pair;
                }
            }
            if (keyFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        //Creating a method to display all key value pair of hash table
        public void Display()
        {
            Console.WriteLine($"Words -> Frequency");
            foreach (var list in listOfKeyValuePair)
            {
                if (list != null)
                {
                    foreach (KeyValuePair<K, V> pair in list)
                    {
                        string res = pair.ToString();
                        if (res != null)
                            Console.WriteLine($"{pair.Key} -> {pair.Value}");
                    }
                }
            }
        }

    }
}
