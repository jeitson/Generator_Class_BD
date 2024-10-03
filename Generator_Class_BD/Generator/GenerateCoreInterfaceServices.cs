/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreInterfaceServices
    {
        public static void Start(string nameSpace, string vNombreClase, string path, string idPk, string typePk)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformHelper.TransformTable(vNombreClase);

            cuerpo.Append("using " + nameSpace + ".Domain.Dtos;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.Entities;\n");

            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Domain.Interfaces\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic interface I" + vNombreClase + "Service\n");
            cuerpo.Append("\t{\n");

            //propiedad DI
            cuerpo.Append("\t Task<" + vNombreClase + "> Create(" + vNombreClase + " item); \n");
            cuerpo.Append($"\t Task<bool> Delete({typePk} {idPk}); \n");
            cuerpo.Append($"\t Task<{vNombreClase}> Get({typePk} {idPk}); \n");
            cuerpo.Append("\t Task<IEnumerable<" + vNombreClase + ">> List(); \n");
            cuerpo.Append("\t Task<IEnumerable<" + vNombreClase + ">> List(Pagination pagination); \n");
            cuerpo.Append("\t Task < " + vNombreClase + "> Update(" + vNombreClase + " item); \n");


            cuerpo.Append("\t}\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = $"{path}\\Domain\\Interfaces\\";
            string fileName = $"{folder}I{vNombreClase}Service.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}