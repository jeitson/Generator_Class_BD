/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreEntity
    {
        public static void Start(string nameSpace, string vNombreClase, string path, DataSet dsCol)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("using Maguna.Common.Infrastructure;\n");
            cuerpo.Append("using Maguna.Common.Entity;\n");
            cuerpo.Append("using System;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Entity\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic class " + vNombreClase + "Info : ModelBase\n");
            cuerpo.Append("\t{\n");

            foreach (DataRow row in dsCol.Tables[0].Rows)//generando los atributos
            {
                if (row["column_name"].ToString().ToLower() != "id" &&
                   row["column_name"].ToString().ToLower() != "tenantid" &&
                   row["column_name"].ToString().ToLower() != "name" &&
                   row["column_name"].ToString().ToLower() != "description" &&
                   row["column_name"].ToString().ToLower() != "status" &&
                   row["column_name"].ToString().ToLower() != "createdon" &&
                   row["column_name"].ToString().ToLower() != "createdby" &&
                   row["column_name"].ToString().ToLower() != "modifiedon" &&
                   row["column_name"].ToString().ToLower() != "modifiedby")
                {
                    if (row["IS_NULLABLE"].ToString() == "NO" && row["column_name"].ToString().ToLower() != "id")
                        cuerpo.Append("\t\t[Required]\n");

                    if (!string.IsNullOrEmpty(row["CHARACTER_MAXIMUM_LENGTH"].ToString()) && row["CHARACTER_MAXIMUM_LENGTH"].ToString() != "-1")
                        cuerpo.Append("\t\t[MaxLength(MaxLength = " + row["CHARACTER_MAXIMUM_LENGTH"].ToString() + " , Message = \"The field " + row["column_name"].ToString() + " accept " + row["CHARACTER_MAXIMUM_LENGTH"].ToString() + " character(s)\")]\n");

                    cuerpo.Append("\t\tpublic " + Plantilla.ConvertirTipo(row["data_type"].ToString(), row["IS_NULLABLE"].ToString()) + " " + row["column_name"].ToString() + "{ get; set; }\n\n");
                }
            }

            cuerpo.Append("\t}\n");
            cuerpo.Append("}");

            string folder = path + "\\Domain";
            string fileName = path + "\\Domain\\" + vNombreClase + "Info.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}