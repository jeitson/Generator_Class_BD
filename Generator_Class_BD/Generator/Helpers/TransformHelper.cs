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

            if (!nameField.CompareString("Id"))
            {
                finalField = nameField.Substring(1);
            }

            return finalField;
        }

        public static bool FieldIsNotBase(string nameField)
            => //!StringHelper.CompareString(nameField, "Id") &&
                !nameField.CompareString("CreationDate") &&
                !nameField.CompareString("CreationUser") &&
                !nameField.CompareString("ModificationDate") &&
                !nameField.CompareString("ModificationUser") &&
                !nameField.CompareString("Deleted");
    }
}
