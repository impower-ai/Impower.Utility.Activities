using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using Impower.Queue.Activities.Utilities;
using System.Linq;

namespace Impower.Queue.Activities.Activities
{
    public class GetTypedDictonaryFromQueueItem<T> : CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Queue Item")]
        public InArgument<UiPath.Core.QueueItem> InputDictionary { get; set; }

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

            var output = input.ConvertSpecificContent<T>(defaultValue);

            CDictionary.Set(context, output);
        }

    }
}
