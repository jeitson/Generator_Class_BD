/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreDataAccessConfigureBase
    {
        public static void Start(string nameSpace, string path)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();


            cuerpo.Append("using Microsoft.EntityFrameworkCore;\n");
            cuerpo.Append("using Microsoft.EntityFrameworkCore.Metadata.Builders;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.DataAccess.Entities.Base;\n");

            cuerpo.Append("namespace " + nameSpace + "Infraestructure.DataAccess.Config.Base");
            cuerpo.Append("\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tinternal class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity\n");
            cuerpo.Append("\t{\n");

            cuerpo.Append("\t\tpublic virtual void Configure(EntityTypeBuilder<T> builder)\n");
            cuerpo.Append("\t\t{\n");

            cuerpo.Append("\t\t\tbuilder.Property(e => e.CreationDate)\n");
            cuerpo.Append("\t\t\t\t.HasColumnName(\"DCreationDate\")\n");
            cuerpo.Append("\t\t\t\t.HasColumnType(\"datetime\");\n");
            cuerpo.Append("\n");
            cuerpo.Append("\t\t\tbuilder.Property(e => e.CreationUser)\n");
            cuerpo.Append("\t\t\t\t.HasColumnName(\"SCreationUser\")\n");
            cuerpo.Append("\t\t\t\t.HasMaxLength(300)\n");
            cuerpo.Append("\t\t\t\t.IsUnicode(false);\n");
            cuerpo.Append("\n");
            cuerpo.Append("\t\t\tbuilder.Property(e => e.ModificationDate)\n");
            cuerpo.Append("\t\t\t\t.HasColumnName(\"DModificationDate\")\n");
            cuerpo.Append("\t\t\t\t.HasColumnType(\"datetime\");\n");
            cuerpo.Append("\n");
            cuerpo.Append("\t\t\tbuilder.Property(e => e.ModificationUser)\n");
            cuerpo.Append("\t\t\t\t.HasColumnName(\"SModificationUser\")\n");
            cuerpo.Append("\t\t\t\t.HasMaxLength(300)\n");
            cuerpo.Append("\t\t\t\t.IsUnicode(false);\n");
            cuerpo.Append("\n");
            cuerpo.Append("\t\t\tbuilder.Property(e => e.Deleted)\n");
            cuerpo.Append("\t\t\t\t.HasColumnName(\"BDeleted\")\n");
            cuerpo.Append("\t\t\t\t.IsUnicode(false);\n");

            cuerpo.Append("\t\t}");
            cuerpo.Append("\n");

            cuerpo.Append("\t}");
            cuerpo.Append("\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = $"{path}\\Infraestructure\\DataAccess\\Config\\Base\\";
            string fileName = $"{folder}BaseEntityConfig.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}