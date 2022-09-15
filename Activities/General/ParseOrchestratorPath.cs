using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using System.Linq;
using Impower.Utility.Utilities;
using System.IO;
using Impower.Utility.Activities;

namespace Impower.Utility.General
{
    public class ParseOrchestratorPath : UtilityActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Full Path to Item")]
        public InArgument<string> FullPath { get; set; }

        [Category("Output")]
        [DisplayName("Folder")]
        public OutArgument<string> Folder { get; set; }

        [Category("Output")]
        [DisplayName("Name")]
        public OutArgument<string> Name { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            var path = FullPath.Get(context);

            Name.Set(context, Path.GetFileName(path));
            Folder.Set(context, Path.GetDirectoryName(path)?.Replace("\\", "/"));
        }
    }
}
