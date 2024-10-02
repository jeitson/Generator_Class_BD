/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreRepository
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformHelper.TransformTable(vNombreClase);

            cuerpo.Append("using " + nameSpace + ".Infraestructure.DataAccess;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.Entities;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.IRepositories;\n");
            cuerpo.Append("using " + nameSpace + ".Utility;\n");
            cuerpo.Append("\n");

            cuerpo.Append("namespace " + nameSpace + ".Infraestructure.Repository");
            cuerpo.Append("\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic class " + vNombreClase + "Repository : Repository<" + vNombreClase + ">, I" + vNombreClase + "Repository\n");
            cuerpo.Append("\t{\n");
            cuerpo.Append("\t\tprivate ApplicationDbContext _db;\n");
            cuerpo.Append("\t\tpublic " + vNombreClase + "Repository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)\n");
            cuerpo.Append("\t\t{\n");
            cuerpo.Append("\t\t\t _db = dbContext;\n");
            cuerpo.Append("\t\t\t _system = system;\n");
            cuerpo.Append("\t\t}\n");
            cuerpo.Append("\t}");
            cuerpo.Append("\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = $"{path}\\Infraestructure\\Repositories\\";
            string fileName = $"{folder}{vNombreClase}Repository.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}
