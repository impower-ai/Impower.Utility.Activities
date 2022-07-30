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

        public CleanedDictionary(Dictionary<string, object> specificContent, Type dictionaryType)
        {
            
            switch (Type.GetTypeCode(dictionaryType))
            {
                case TypeCode.Int32:
                    this.ConvertedDictionary = Util.ConvertedDictionary<int>(specificContent);
                    break;
                case TypeCode.String:
                    this.ConvertedDictionary = Util.ConvertedDictionary<string>(specificContent);
                    Console.WriteLine(this.ConvertedDictionary);
                    break;
                default:
                    throw new Exception("Could not parse provided type. Please contact Matthew.");
            }
        }


        public object this[object key] { get => ConvertedDictionary[key]; set => global::System.Console.WriteLine(value); }

        public ICollection Keys => ConvertedDictionary.Keys.ToArray();

        public ICollection Values => ConvertedDictionary.Values.ToArray();

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
