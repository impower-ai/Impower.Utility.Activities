using System;
using System.Collections.Generic;
using System.Activities;
using Impower.Utility.Utilities;
using System.ComponentModel;
using Impower.Utility.Models;
using System.Data;

namespace Impower.Utility.DataTable
{
    public class DataRowToTypedDictionary<T> : TypedDictionaryActivity<T>
    {
        public override OutArgument<Dictionary<string, T>> Dictionary { get; set; }
        public override InArgument<T> DefaultValue { get; set; }

        [RequiredArgument]
        [Category("Input")]
        [DisplayName("DataRowInput")]
        public InArgument<DataRow> DataRowInput { get; set; }

        protected override void Execute(CodeActivityContext context)
        {

            var defaultValue = DefaultValue.Get(context);
            var dataRow = DataRowInput.Get(context);

            Dictionary.Set(context, dataRow.ToTypedDictionary<T>(defaultValue));

        }
    }
}
