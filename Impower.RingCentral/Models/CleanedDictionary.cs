using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impower.Queue.Activities.Utilities;

namespace Impower.Queue.Activities.Models
{
    public class CleanedDictionary : IDictionary
    {

        private dynamic ConvertedDictionary { get; set; }
        private Dictionary<string, object> SpecificContent { get; set; }

        public CleanedDictionary(Dictionary<string, object> specificContent, Type dictionaryType)
        {
            this.SpecificContent = specificContent;

            switch (Type.GetTypeCode(dictionaryType))
            {
                case TypeCode.Int32:
                    this.ConvertedDictionary = Util.ConvertedDictionary<int>(specificContent);
                    Console.WriteLine("YUP");
                    break;
                case TypeCode.String:
                    this.ConvertedDictionary = Util.ConvertedDictionary<string>(specificContent);
                    Console.WriteLine(this.ConvertedDictionary);
                    break;
                default:
                    throw new Exception("Could not parse provided type. Please contact Matthew.");
            }
            foreach(var item in specificContent)
            {
                if (!this.ContainsKey(item.Key))
                {
                    Console.WriteLine("angy");
                   // ConvertedDictionary[item.Key] = null;

                }
            }
        }

        public object this[object key] 
        { 
            get
            {
                Console.WriteLine("in get");
                if (this.ContainsKey(key))
                {
                    foreach(var item in ConvertedDictionary.Keys)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine(this.ConvertedDictionary[key]);
                    return this.ConvertedDictionary[key];
                }
                Console.WriteLine("ayo?");
                if (this.SpecificContent.ContainsKey(key.ToString())) return null;
                Console.WriteLine("past");
                throw new Exception("Key not in dictionary");
            }
            set
            {
                this[key] = value;
            }
        
        
        }

        public ICollection Keys => SpecificContent.Keys;

        public bool ContainsKey(object key)
        {
            Console.WriteLine(this.ConvertedDictionary.Keys);
            foreach(var existingKey in this.ConvertedDictionary.Keys)
            {
                if (existingKey.Equals(key))
                {
                    Console.WriteLine("has the key");
                    return true;
                }
            }
            return false;
        }

        public ICollection Values => ConvertedDictionary.Values;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public int Count => ConvertedDictionary.Count;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void Add(object key, object value)
        {
            ConvertedDictionary.Add(key, value);
        }

        public void Clear()
        {
            ConvertedDictionary = null;
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            ConvertedDictionary?.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
