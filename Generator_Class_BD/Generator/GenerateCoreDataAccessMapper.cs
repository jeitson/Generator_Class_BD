/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreDataAccessMapper
    {
        public static void Start(string nameSpace, string vNombreClase, string path, DataSet dsCol)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformFieldHelper.TransformTable(vNombreClase);
            

            cuerpo.Append("using Microsoft.EntityFrameworkCore;\n");
            cuerpo.Append("using Microsoft.EntityFrameworkCore.Metadata.Builders;\n");
            cuerpo.Append("using " + nameSpace + ".Entity;\n");
            cuerpo.Append("namespace " + nameSpace + ".Data.Access.Mapper");
            cuerpo.Append("\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tinternal class " + vNombreClase + "Mapper : IEntityTypeConfiguration<" + vNombreClase + ">\n");
            cuerpo.Append("\t{\n");

            cuerpo.Append("\t\tpublic void Configure(EntityTypeBuilder<" + vNombreClase + "> builder)\n");
            cuerpo.Append("\t\t{\n");
            cuerpo.Append("\t\t\tbuilder.ToTable(\"TBL_" + vNombreClase + "\");\n");
            cuerpo.Append("\t\t\tbuilder.HasKey(x => x.Id);\n\n");

            foreach (DataRow row in dsCol.Tables[0].Rows)//generando los atributos
            {
                string columName = TransformFieldHelper.TransformField(row["column_name"].ToString());
                //crea la propiedad
                cuerpo.Append("\t\t\tbuilder.Property(x => x." + columName + ")");

                //agrega el maximo si tiene
                if (!string.IsNullOrEmpty(row["CHARACTER_MAXIMUM_LENGTH"].ToString()) && row["CHARACTER_MAXIMUM_LENGTH"].ToString() != "-1")
                    cuerpo.Append(".HasMaxLength(" + row["CHARACTER_MAXIMUM_LENGTH"].ToString() + ")");

                if (row["IS_NULLABLE"].ToString() == "NO" && columName.ToLower() != "id")
                    cuerpo.Append(".IsRequired()");

                cuerpo.Append(".HasColumnName(\"" + row["column_name"].ToString() + "\");\n");
            }

            cuerpo.Append("\t\t}");
            cuerpo.Append("\n");

            cuerpo.Append("\t}");
            cuerpo.Append("\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = path + "\\Data\\Access\\Mapper\\";
            string fileName = path + "\\Data\\Access\\Mapper\\" + vNombreClase + "Mapper.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}