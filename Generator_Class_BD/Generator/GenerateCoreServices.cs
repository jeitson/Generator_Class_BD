﻿/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreServices
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformHelper.TransformTable(vNombreClase);


            cuerpo.Append("using " + nameSpace + ".Domain.Dtos;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.Entities;\n");
            cuerpo.Append("using " + nameSpace + ".Infraestructure.DataAccess;\n");
            cuerpo.Append("using " + nameSpace + ".Utility;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Domain.Services\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic class " + vNombreClase + "Service\n");
            cuerpo.Append("\t{\n");

            //propiedad DI
            cuerpo.Append("\t" + PropiedadDao(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoCrear(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoModificar(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoEliminar(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoBuscarId(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoBuscarTodos(vNombreClase) + "\n\n");

            cuerpo.Append("\t}\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = $"{path}\\Domain\\Services\\";
            string fileName = $"{folder}{vNombreClase}Service.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }

        private static string PropiedadDao(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tprivate readonly IUnitOfWork _unitOfWork;\n");
            vc.Append("\t\tprivate readonly ExceptionModule _exceptionModule;\n");


            vc.Append("\t\tpublic " + vNombreClase + "Service(IUnitOfWork unitOfWork,\n");
            vc.Append("\t\t\t\tExceptionModule exceptionModule)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\t_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));\n");
            vc.Append("\t\t\t_exceptionModule = exceptionModule ?? throw new ArgumentNullException(nameof(exceptionModule));\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoCrear(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic async Task<" + vNombreClase + "> Create(" + vNombreClase + " item)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\t" + vNombreClase + " result = null;\n");
            vc.Append("\t\t\ttry\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tValidator.Validate<" + vNombreClase + ">(item);\n");
            vc.Append("\t\t\t\tresult = _unitOfWork." + vNombreClase + "Repository.Add(item);\n");
            vc.Append("\t\t\t\tawait _unitOfWork.SaveChangesAsync();\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\tcatch (Exception ex)\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tawait _exceptionModule.Log(ex);\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\treturn result;\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoModificar(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic async Task<" + vNombreClase + "> Update(" + vNombreClase + " item)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\t" + vNombreClase + " result = null;\n");
            vc.Append("\t\t\ttry\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tresult = await _unitOfWork." + vNombreClase + "Repository.GetAsync(x => x.Id == item.Id);\n");
            vc.Append("\t\t\t\tif (result != null)\n");
            vc.Append("\t\t\t\t{\n");
            vc.Append("\t\t\t\t\tawait _unitOfWork." + vNombreClase + "Repository.UpdateAsync(result);\n");
            vc.Append("\t\t\t\t\tawait _unitOfWork.SaveChangesAsync();\n");
            vc.Append("\t\t\t\t}\n");
            vc.Append("\t\t\t\telse\n");
            vc.Append("\t\t\t\t{\n");
            vc.Append("\t\t\t\t\tthrow new ArgumentException(\"El item que intentas actualizar no existe\");\n");
            vc.Append("\t\t\t\t}\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\tcatch (Exception ex)\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tawait _exceptionModule.Log(ex);\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\treturn result;\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoEliminar(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic async Task<bool> Delete(Guid id)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\t bool result = false;\n");
            vc.Append("\t\t\ttry\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\t" + vNombreClase + " item = await _unitOfWork." + vNombreClase + "Repository.GetAsync(x => x.Id == id);\n");
            vc.Append("\t\t\t\tif (item != null)\n");
            vc.Append("\t\t\t\t{\n");
            vc.Append("\t\t\t\t\t_unitOfWork." + vNombreClase + "Repository.Remove(item);\n");
            vc.Append("\t\t\t\t\tawait _unitOfWork.SaveChangesAsync();\n");
            vc.Append("\t\t\t\t\tresult = true;\n");
            vc.Append("\t\t\t\t}\n");
            vc.Append("\t\t\t\telse\n");
            vc.Append("\t\t\t\t{\n");
            vc.Append("\t\t\t\t\tthrow new ArgumentException(\"El item que intentas eliminar no existe\");\n");
            vc.Append("\t\t\t\t}\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\tcatch (Exception ex)\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tawait _exceptionModule.Log(ex);\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\treturn result;\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoBuscarTodos(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic async Task<IEnumerable<" + vNombreClase + ">> List(Pagination pagination)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\tIEnumerable<" + vNombreClase + "> result = new List<" + vNombreClase + ">();\n");
            vc.Append("\t\t\ttry\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tresult =  await _unitOfWork." + vNombreClase + "Repository.GetListAsync(pagination);\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\tcatch (Exception ex)\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tawait _exceptionModule.Log(ex);\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\treturn result;\n");
            vc.Append("\t\t}\n");
            vc.Append("\n");

            vc.Append("\t\tpublic async Task<IEnumerable<" + vNombreClase + ">> List()\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\tIEnumerable<" + vNombreClase + "> result = new List<" + vNombreClase + ">();\n");
            vc.Append("\t\t\ttry\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tresult =  await _unitOfWork." + vNombreClase + "Repository.GetListAsync();\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\tcatch (Exception ex)\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tawait _exceptionModule.Log(ex);\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\treturn result;\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoBuscarId(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic async Task<" + vNombreClase + "> Get(Guid id)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\t" + vNombreClase + " result = new " + vNombreClase + "();\n");
            vc.Append("\t\t\ttry\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tresult = await _unitOfWork." + vNombreClase + "Repository.GetAsync(x=> x.Id == id);\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\tcatch (Exception ex)\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tawait _exceptionModule.Log(ex);\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t\treturn result;\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }
    }
}