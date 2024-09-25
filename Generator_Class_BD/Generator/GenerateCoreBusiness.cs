/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using Generator_Class_BD.Generator.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreBusiness
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformFieldHelper.TransformTable(vNombreClase);

            cuerpo.Append("using Maguna.Common.Data.Access.IRepositories;\n");
            cuerpo.Append("using Maguna.Common.Infrastructure;\n");
            cuerpo.Append("using " + nameSpace + ".Data.IRepositories;\n");
            cuerpo.Append("using " + nameSpace + ".Data.Repositories;\n");
            cuerpo.Append("using " + nameSpace + ".Entity;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Business\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic class " + vNombreClase + "Module\n");
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

            string folder = path + "\\Module";
            string fileName = path + "\\Module\\" + vNombreClase + ".cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }

        private static string PropiedadDao(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tprivate readonly IUnitOfWork _unitOfWork;\n");
            vc.Append("\t\tprivate readonly ExceptionModule _exceptionModule;\n");
            

            vc.Append("\t\tpublic " + vNombreClase + "Module(IUnitOfWork unitOfWork,\n");
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