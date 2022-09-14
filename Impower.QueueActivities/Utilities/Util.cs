using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Core;

namespace Impower.Utility.Utilities
{
    public static class Util
    {
        public static Dictionary<string, T> ConvertedDictionary<T>(this Dictionary<string, object> input, T defaultValue)
        {
            return input.ToDictionary(x => x.Key.ToString(), v => v.Value is T ? (T)v.Value : ConvertedValue<T>(v.Value, defaultValue));
        }

        public static T ConvertedValue<T>(this Object value, T defaultValue)
        {
            if (value == null) return defaultValue;
            if (value as IConvertible == null) return defaultValue;

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception e)
            {
                return defaultValue;
            }

        }

        public static Dictionary<string, T> ConvertedSpecificContent<T>(this QueueItem queueItem, T defaultValue)
        {
            return ConvertedDictionary<T>(queueItem.SpecificContent, defaultValue);
        }

    }
}
