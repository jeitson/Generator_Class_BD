/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreController
    {
        public static void Start(string nameSpace, string vNombreClase, string path, string idPk, string typePk)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformHelper.TransformTable(vNombreClase);

            string classBase = " Base";
            if (idPk.CompareString("Code"))
                classBase += "Master";

            cuerpo.Append("using " + nameSpace + ".Application.Controllers.Base;\n");
            cuerpo.Append("using " + nameSpace + ".Domain.Dtos;\n");
            cuerpo.Append("using " + nameSpace + ".Domain.Interfaces;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.Entities;\n");
            cuerpo.Append("using Microsoft.AspNetCore.Mvc;\n");
            cuerpo.Append("using System.Net;\n");

            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Application.Controllers\n");
            cuerpo.Append("{\n");
            cuerpo.Append($"\t[Route(\"/api/v1/ccvp_apwb_nego/{vNombreClase.ToSnakeCase()}\")]\n");
            cuerpo.Append($"\tpublic class {vNombreClase}sController : {classBase}Controller<{vNombreClase},{typePk},I{vNombreClase}Service>\n");
            cuerpo.Append("\t{\n");

            //propiedad DI
            cuerpo.Append($"\t\tprivate readonly I{vNombreClase}Service t_iService; \n");
            cuerpo.Append("\n");

            //propiedad ctor
            cuerpo.Append($"\t\tpublic {vNombreClase}sController (\n");
            cuerpo.Append($"\t\t\tI{vNombreClase}Service service \n");
            cuerpo.Append($"\t\t\t) : base(service) \n");
            cuerpo.Append("\t\t { \n");
            cuerpo.Append($"\t\t\t_iService = service; \n");
            cuerpo.Append("\t\t } \n");

            cuerpo.Append("\t}\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = $"{path}\\Application\\Controllers\\";
            string fileName = $"{folder}{vNombreClase}sController.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}