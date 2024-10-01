﻿/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System.Data;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreEntity
    {
        public static void Start(string nameSpace, string vNombreClase, string path, DataSet dsCol)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformHelper.TransformTable(vNombreClase);


            cuerpo.Append("using System;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.DataAccess.Entities.Base\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Infraestructure.DataAccess.Entities\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic class " + vNombreClase + " : BaseEntity\n");
            cuerpo.Append("\t{\n");

            foreach (DataRow row in dsCol.Tables[0].Rows)//generando los atributos
            {
                string columnName = TransformHelper.TransformField(row["column_name"].ToString());
                if (TransformHelper.FieldIsNotBase(columnName))
                {
                    if (row["IS_NULLABLE"].ToString() == "NO")
                        cuerpo.Append("\t\t[Required]\n");

                    if (!string.IsNullOrEmpty(row["CHARACTER_MAXIMUM_LENGTH"].ToString()) && row["CHARACTER_MAXIMUM_LENGTH"].ToString() != "-1")
                        cuerpo.Append("\t\t[MaxLength(MaxLength = " + row["CHARACTER_MAXIMUM_LENGTH"].ToString() + " , Message = \"The field " + columnName + " accept " + row["CHARACTER_MAXIMUM_LENGTH"].ToString() + " character(s)\")]\n");

                    cuerpo.Append("\t\tpublic " + Plantilla.ConvertirTipo(row["data_type"].ToString(), row["IS_NULLABLE"].ToString()) + " " + columnName + "{ get; set; }\n\n");
                }
            }

            cuerpo.Append("\t}\n");
            cuerpo.Append("}");

            string folder = $"{path}\\Infraestructure\\DataAccess\\Entities\\";
            string fileName = $"{folder}{vNombreClase}.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}