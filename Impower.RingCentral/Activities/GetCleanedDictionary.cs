using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using System.Linq;
using Impower.Queue.Activities.Models;

namespace Impower.Queue.Activities.QueueItem
{
    public class GetCleanedDictionary : CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("QueueItem")]
        public InArgument<UiPath.Core.QueueItem> QItem { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("OutputType")]
        public InArgument<Type> GValue { get; set; }

        [Category("Output")]
        [DisplayName("CleanedDictionary")]
        public OutArgument<CleanedDictionary> CDictionary { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var CleanDict = new CleanedDictionary(QItem.Get(context).SpecificContent, GValue.Get(context));
            CDictionary.Set(context, CleanDict);
        }
    }
}
