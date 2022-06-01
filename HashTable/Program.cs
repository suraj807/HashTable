using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class Program
    {
        public static void CountWordFrequency(string s)   // Creating a method to Count Word Frequency of String and Pass string as parameter
        {
            MyMapNode<string, int> hashTable = new MyMapNode<string, int>(6);// Creating a Object of MyMapNode generic class and passed string size 
            string[] paragraphWords = s.Split(' '); //Separating word from string and storing in array
            //Stroring each word with frequency in hashtable
            foreach (string word in paragraphWords)
            {
                if (hashTable.Exists(word.ToLower())) // To check word is already exists in hashtable or not , Calling the method of Generic class
                {
                    hashTable.Add(word.ToLower(), hashTable.Get(word.ToLower()) + 1); // If Already exixts then update the frequency 
                }
                else
                {
                    hashTable.Add(word.ToLower(), 1); // If not then add word in hashtable with frequency 1
                }
            }
            Console.WriteLine($"Words Frequency in below string : ");
            Console.WriteLine($"\" {s} \"\n");
            hashTable.Display(); //Calling a display method
        }
        static void Main(string[] args)
        {
            string s = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations"; // Passing any string
            CountWordFrequency(s); // Calling method of this Class to Count Word Frequency of String and Pass string as parameter
            Console.ReadLine();
        }
    }
}
