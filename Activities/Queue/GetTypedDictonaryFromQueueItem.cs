using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using Impower.Utility.Utilities;
using System.Linq;
using Impower.Utility.Activities;

namespace Impower.Utility.Queue
{
    public class GetTypedDictionaryFromQueueItem<T> : UtilityActivity
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Queue Item")]
        public InArgument<UiPath.Core.QueueItem> InputQueueItem { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("DefaultValue")]
        public InArgument<T> DefaultValue { get; set; }

        [Category("Output")]
        [DisplayName("CleanedDictionary")]
        public OutArgument<Dictionary<string, T>> CDictionary { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var input = InputQueueItem.Get(context);
            var defaultValue = DefaultValue.Get(context);

            var output = input.ConvertedSpecificContent(defaultValue);

            CDictionary.Set(context, output);
        }

    }
}
