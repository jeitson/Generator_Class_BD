/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System.Data;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreDataAccessMapper
    {
        public static void Start(string nameSpace, string vNombreClase, string path, DataSet dsCol)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformHelper.TransformTable(vNombreClase);


            cuerpo.Append("using Microsoft.EntityFrameworkCore;\n");
            cuerpo.Append("using Microsoft.EntityFrameworkCore.Metadata.Builders;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.DataAccess.Entities;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.DataAccess.Config.Base;\n");

            cuerpo.Append("namespace " + nameSpace + ".Infraestructure.DataAccess.Config");
            cuerpo.Append("\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tinternal class " + vNombreClase + "Config : BaseEntityConfig<" + vNombreClase + ">\n");
            cuerpo.Append("\t{\n");

            cuerpo.Append("\t\tpublic override void Configure(EntityTypeBuilder<" + vNombreClase + "> builder)\n");
            cuerpo.Append("\t\t{\n");
            cuerpo.Append("\t\t\tbuilder.ToTable(\"TBL_" + vNombreClase + "\");\n");
            cuerpo.Append("\t\t\tbuilder.HasKey(x => x.Id);\n\n");

            foreach (DataRow row in dsCol.Tables[0].Rows)//generando los atributos
            {
                string columName = TransformHelper.TransformField(row["column_name"].ToString());
                //crea la propiedad
                cuerpo.Append("\t\t\tbuilder.Property(x => x." + columName + ")");

                //agrega el maximo si tiene
                if (!string.IsNullOrEmpty(row["CHARACTER_MAXIMUM_LENGTH"].ToString()) && row["CHARACTER_MAXIMUM_LENGTH"].ToString() != "-1")
                    cuerpo.Append("\t\t\t\t.HasMaxLength(" + row["CHARACTER_MAXIMUM_LENGTH"].ToString() + ")\n");

                if (row["IS_NULLABLE"].ToString() == "NO" && columName.ToLower() != "id")
                    cuerpo.Append("\t\t\t\t.IsRequired()\n");

                cuerpo.Append("\t\t\t\t.HasColumnName(\"" + row["column_name"].ToString() + "\");\n\n");
            }

            cuerpo.Append("\t\t\tbase.Configure(builder);\n");

            cuerpo.Append("\t\t}");
            cuerpo.Append("\n");

            cuerpo.Append("\t}");
            cuerpo.Append("\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = $"{path}\\Infraestructure\\DataAccess\\Config\\";
            string fileName = $"{folder}{vNombreClase}Config.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}