using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;



namespace Impower.Utility.Models
{
    public abstract class TypedDictionaryActivity<T> : CodeActivity
    {
        protected abstract override void Execute(CodeActivityContext context);

        [Category("Output")]
        [DisplayName("TypedDictionary")]
        public abstract OutArgument<Dictionary<string, T>> Dictionary { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("DefaultValue")]
        public abstract InArgument<T> DefaultValue { get; set; }
    }
}
