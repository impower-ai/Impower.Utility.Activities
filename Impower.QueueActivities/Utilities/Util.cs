using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Core;

namespace Impower.Queue.Activities.Utilities
{
    public static class Util
    {
        public static Dictionary<string, T> ConvertDictionary<T>(this Dictionary<string, object> input, T defaultValue)
        {
            return input.ToDictionary(x => x.Key.ToString(), v => v.Value is T ? (T)v.Value : DefaultValue<T>(v.Value, defaultValue));
        }

        private static T DefaultValue<T>(Object value, T defaultValue)
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

        public static Dictionary<string, T> ConvertSpecificContent<T>(this QueueItem queueItem, T defaultValue)
        {
            return ConvertDictionary<T>(queueItem.SpecificContent, defaultValue);
        }

    }
}
