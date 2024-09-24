using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateEntity
    {
        public static void Start(string nameSpace, string vNombreClase, string path, DataSet dsCol)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("using System;\n");
            cuerpo.Append("using System.Data;\n");
            cuerpo.Append("using System.Data.SqlClient;\n");
            cuerpo.Append("using System.Collections.Generic;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Entity\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic class " + vNombreClase + "Info\n");
            cuerpo.Append("\t{\n");

            foreach (DataRow row in dsCol.Tables[0].Rows)//generando los atributos
            {
                if (row["IS_NULLABLE"].ToString() == "NO" && row["column_name"].ToString().ToLower() != "id")
                    cuerpo.Append("\t\t[Required]\n");

                if (!string.IsNullOrEmpty(row["CHARACTER_MAXIMUM_LENGTH"].ToString()) && row["CHARACTER_MAXIMUM_LENGTH"].ToString() != "-1")
                    cuerpo.Append("\t\t[MaxLength(MaxLength = "+ row["CHARACTER_MAXIMUM_LENGTH"].ToString() + " , Message = \"The field "+ row["column_name"].ToString() +" accept "+ row["CHARACTER_MAXIMUM_LENGTH"].ToString() + " character(s)\")]\n");

                cuerpo.Append("\t\tpublic " + Plantilla.ConvertirTipo(row["data_type"].ToString(), row["IS_NULLABLE"].ToString()) + " " + row["column_name"].ToString() + "{ get; set; }\n\n");
            }
           
            cuerpo.Append("\t}\n");
            cuerpo.Append("}");

            string folder = path + "\\Entity";
            string fileName = path + "\\Entity\\" + vNombreClase + "Info.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}
