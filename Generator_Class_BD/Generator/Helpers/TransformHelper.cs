namespace Generator_Class_BD.Generator.Helpers
{
    public static class TransformHelper
    {

        public static string TransformTable(string nameTable)
        {
            string finalTable = nameTable.Replace("TBL_", "");

            return finalTable;
        }

        public static string TransformField(string nameField)
        {
            string finalField = nameField;

            if (!StringHelper.CompareString(nameField, "Id"))
            {
                finalField = nameField.Substring(1);
            }

            return finalField;
        }

        public static bool FieldIsNotBase(string nameField)
            => !StringHelper.CompareString(nameField, "Id") &&
                !StringHelper.CompareString(nameField, "CreationDate") &&
                !StringHelper.CompareString(nameField, "CreationUser") &&
                !StringHelper.CompareString(nameField, "ModificationDate") &&
                !StringHelper.CompareString(nameField, "ModificationUser") &&
                !StringHelper.CompareString(nameField, "Deleted");
    }
}
