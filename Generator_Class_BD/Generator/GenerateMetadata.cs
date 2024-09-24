using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateMetadata
    {
        public static void Start(string vNombreClase, string path, DataSet dsCol)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MetadataInsert]') AND type in (N'P', N'PC'))\n");
            cuerpo.Append("\tDROP PROCEDURE [dbo].[MetadataInsert]\n");
            cuerpo.Append("GO\n\n");
            cuerpo.Append("CREATE PROCEDURE [dbo].[MetadataInsert]\n");
            foreach (DataRow row in dsCol.Tables[0].Rows)
            {
                if (row["data_type"].ToString() == "varchar")
                    cuerpo.Append("\t@"+row["column_name"].ToString()+ "\t\t\t\t"+ row["data_type"].ToString() + "("+ row["CHARACTER_MAXIMUM_LENGTH"] +"),\n");
                else
                    cuerpo.Append("\t@" + row["column_name"].ToString() + "\t\t\t\t" + row["data_type"].ToString() + ",\n");
            }
            cuerpo.Append("AS\n");
            cuerpo.Append("BEGIN\n");
            cuerpo.Append("\tSET IdENTITY_INSERT ["+ vNombreClase + "] ON\n\n");
            cuerpo.Append("\tIF EXISTS (SELECT 1 FROM ["+vNombreClase+"] WHERE [Id] = @Id )\n");
            cuerpo.Append("\t\tUPDATE [" + vNombreClase + "]\n");
            cuerpo.Append("\t\tSET \n");
            foreach (DataRow row in dsCol.Tables[0].Rows)
            {
                cuerpo.Append("\t\t\t[" + row["column_name"].ToString() + "] = @" + row["column_name"].ToString() + ",\n");
            }
            cuerpo.Append("\t\tWHERE [Id] = @Id\n");
            cuerpo.Append("\tELSE\n");
            cuerpo.Append("\t\tINSERT INTO [" + vNombreClase + "](\n");
            foreach (DataRow row in dsCol.Tables[0].Rows)
            {
                cuerpo.Append("\t\t\t[" + row["column_name"].ToString() + "],\n");
            }
            cuerpo.Append("\t\t)VALUES(\n");
            foreach (DataRow row in dsCol.Tables[0].Rows)
            {
                cuerpo.Append("\t\t\t@" + row["column_name"].ToString() + ",\n");
            }
            cuerpo.Append("\t\t)\n");
            cuerpo.Append("\tSET IdENTITY_INSERT ["+ vNombreClase + "] OFF\n");
            cuerpo.Append("END\n");
            cuerpo.Append("GO\n");
            cuerpo.Append("Print '"+ vNombreClase + " DONE!!'");
            
            string folder = path + "\\Metadata";
            string fileName = path + "\\Metadata\\" + vNombreClase + "Meta.sql";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}
