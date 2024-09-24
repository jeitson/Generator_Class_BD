using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateDataAccessMapper
    {
        public static void Start(string nameSpace, string vNombreClase, string path, DataSet dsCol)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("using " + nameSpace + ".Entity;\n");
            cuerpo.Append("using System.Data.Entity.ModelConfiguration;\n");
            cuerpo.Append("namespace " + nameSpace + ".Data.Mapper");
            cuerpo.Append("\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tinternal class " + vNombreClase + "Mapper : EntityTypeConfiguration<" + vNombreClase + "Info>\n");
            cuerpo.Append("\t{\n");

            cuerpo.Append("\t\tpublic " + vNombreClase + "Mapper(string schema)\n");
            cuerpo.Append("\t\t{\n");
            cuerpo.Append("\t\t\tthis.ToTable(\"" + vNombreClase + "\", schema);\n");
            cuerpo.Append("\t\t\tthis.HasKey(x => x.Id);\n\n");

            foreach (DataRow row in dsCol.Tables[0].Rows)//generando los atributos
            {
                cuerpo.Append("\t\t\tthis.Property(x => x." + row["column_name"].ToString() + ").HasColumnName(\"" + row["column_name"].ToString() + "\");\n");
            }

            cuerpo.Append("\t\t}");
            cuerpo.Append("\n");

            cuerpo.Append("\t}");
            cuerpo.Append("\n");
            cuerpo.Append("}");
            //fin de metodo     

            string folder = path + "\\Data\\Mapper\\";
            string fileName = path + "\\Data\\Mapper\\" + vNombreClase + "Mapper.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}
