using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using System.Linq;
using Impower.Utility.Activities;
using Impower.Utility.Utilities;
using Impower.Utility.Models;

namespace Impower.Utility.Queue
{
    public class GetTypedDictionary<T> : TypedDictionaryActivity<T>
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Dictionary")]
        public InArgument<Dictionary<string, object>> InputDictionary { get; set; }

        public override InArgument<T> DefaultValue { get; set; }

        public override OutArgument<Dictionary<string, T>> Dictionary { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var input = InputDictionary.Get(context);
            var defaultValue = DefaultValue.Get(context);

            var output = input.ConvertedDictionary(defaultValue);
            Dictionary.Set(context, output);
        }

    }
}
