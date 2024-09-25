using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator_Class_BD.Generator.Helpers
{
    public static class TransformFieldHelper
    {

        public static string TransformTable(string nameTable)
        {
            string finalTable = nameTable.Replace("TBL_", "");

            return finalTable;
        }

        public static string TransformField(string nameField)
        {
            string finalField = nameField;

            if (!string.Equals(nameField,"Id",StringComparison.OrdinalIgnoreCase))
            {
                finalField = nameField.Substring(1);
            }

            return finalField;
        }

    }
}
