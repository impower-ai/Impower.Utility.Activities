using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using Impower.Utility.Utilities;
using System.Linq;
using Impower.Utility.Activities;
using Impower.Utility.Models;

namespace Impower.Utility.Queue
{
    public class GetTypedDictionaryFromQueueItem<T> : TypedDictionaryActivity<T>
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Queue Item")]
        public InArgument<UiPath.Core.QueueItem> InputQueueItem { get; set; }

        public override InArgument<T> DefaultValue { get; set; }

        public override OutArgument<Dictionary<string, T>> Dictionary { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var input = InputQueueItem.Get(context);
            var defaultValue = DefaultValue.Get(context);

            var output = input.ConvertedSpecificContent(defaultValue);

            Dictionary.Set(context, output);
        }

    }
}
