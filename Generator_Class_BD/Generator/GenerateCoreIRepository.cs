/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreIRepository
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformHelper.TransformTable(vNombreClase);


            cuerpo.Append("using " + nameSpace + ".Infraestructure.Entities;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Infraestructure.IRepositories\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic interface I" + vNombreClase + "Repository : IRepository<" + vNombreClase + ">\n");
            cuerpo.Append("\t{\n");
            cuerpo.Append("\t}\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = $"{path}\\Infraestructure\\IRepositories\\";
            string fileName = $"{folder}I{vNombreClase}Repository.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}