﻿using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using System.Linq;
using Impower.Queue.Activities.Utilities;

namespace Impower.Queue.Activities.Activities
{
    public class GetTypedDictionary<T> : CodeActivity
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

            var output = input.ConvertDictionary<T>(defaultValue);
            CDictionary.Set(context, output);
        }

    }
}