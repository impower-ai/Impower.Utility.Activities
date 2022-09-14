using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using System.Linq;

namespace Impower.Utility.Queue
{
    public class GenerateQueueItem : CodeActivity
    {

        [Category("Input")]
        [DisplayName("Items")]
        [RequiredArgument]
        public InArgument<IEnumerable<object>> Items { get; set; }

        [Category("Output")]
        [DisplayName("QueueItem")]
        public OutArgument<UiPath.Core.QueueItem> QItem { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            var items = Items.Get(context);
            if (items.Count() % 2 != 0) { throw new Exception("Provided Enumerable of items not an even length"); }
            if (items.Where(item => item == null).FirstOrDefault() != null) { throw new Exception("Provided Enumerable contains null or empty items."); }

            var GeneratedDictionary = new Dictionary<string, object>();
            for (int i = 0; i < items.Count(); i += 2)
            {
                string key = items.ElementAt(i).ToString();
                object value = items.ElementAt(i + 1);
                GeneratedDictionary[key] = value;
            }
            var queueItem = new UiPath.Core.QueueItem() { SpecificContent = GeneratedDictionary };
            QItem.Set(context, queueItem);
        }
    }
}
