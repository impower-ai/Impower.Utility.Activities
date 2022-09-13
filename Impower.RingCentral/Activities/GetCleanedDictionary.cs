using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using System.Linq;

namespace Impower.Queue.Activities.QueueItem
{
    public class GetCleanedDictionary<T> : CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Dictionary")]
        public InArgument<Dictionary<string, object>> InputDictionary { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("DefaultValue")]
        public InArgument<T> DefaultValue { get; set; }

        [Category("Output")]
        [DisplayName("CleanedDictionary")]
        public OutArgument<Dictionary<string, T>> CDictionary { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var input = InputDictionary.Get(context);
            var defaultValue = DefaultValue.Get(context);



            Dictionary<string, T> output = input.ToDictionary(x => x.Key.ToString(), v => v.Value is T ? (T) v.Value : defaultValue);
            CDictionary.Set(context, output);
        }
    }
}
