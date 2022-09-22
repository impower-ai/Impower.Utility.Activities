using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using Impower.Utility.Utilities;
using System.Linq;
using Impower.Utility.Activities;
using System.Data;

namespace Impower.Utility.DataTable
{
    public class DataRowToDictionary : UtilityActivity
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("DataRow to Convert")]
        public InArgument<DataRow> DataRowInput { get; set; }


        [Category("Output")]
        [DisplayName("Created Dictionary")]
        public OutArgument<Dictionary<string, object>> Dictionary { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var dataRow = DataRowInput.Get(context);

            var dictionary = dataRow.ToDictionary();

            Dictionary.Set(context, dictionary);

        }
    }
}
