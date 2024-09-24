using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateBusiness
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("using " + nameSpace + ".Data.Access;\n");
            cuerpo.Append("using " + nameSpace + ".Entity;\n");
            cuerpo.Append("using " + nameSpace + ".Interface;\n");
            cuerpo.Append("using System.Collections.Generic;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Business\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic class " + vNombreClase + " : I" + vNombreClase + "\n");
            cuerpo.Append("\t{\n");

            //propiedad del dao
            cuerpo.Append("\t" + PropiedadDao(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoCrear(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoModificar(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoEliminar(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoBuscarId(vNombreClase) + "\n\n");

            cuerpo.Append("\t" + MetodoBuscarTodos(vNombreClase) + "\n\n");

            cuerpo.Append("\t}\n");
            cuerpo.Append("}");
            //fin de metodo     

            string folder = path + "\\Business";
            string fileName = path + "\\Business\\" + vNombreClase + ".cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }

        private static string MetodoCrear(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic " + vNombreClase + "Info Create(" + vNombreClase + "Info item)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\treturn " + vNombreClase + "Dao.Create(item);\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoModificar(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic " + vNombreClase + "Info Update(" + vNombreClase + "Info item)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\treturn " + vNombreClase + "Dao.Update(item);\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoEliminar(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic bool Delete(int id)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\t" + vNombreClase + "Dao.Delete(new " + vNombreClase + "Info(){Id = id});\n");
            vc.Append("\t\t\treturn true;\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoBuscarTodos(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic List<" + vNombreClase + "Info> List()\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\treturn " + vNombreClase + "Dao.List();\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string MetodoBuscarId(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tpublic " + vNombreClase + "Info Get(int id)\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\treturn " + vNombreClase + "Dao.Find(id);\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }

        private static string PropiedadDao(string vNombreClase)
        {
            StringBuilder vc = new StringBuilder();

            vc.Append("\tinternal " + vNombreClase + "Dao " + vNombreClase.ToLower() + "Dao  = null;\n");
            vc.Append("\t\tinternal " + vNombreClase + "Dao " + vNombreClase + "Dao\n");
            vc.Append("\t\t{\n");
            vc.Append("\t\t\tget\n");
            vc.Append("\t\t\t{\n");
            vc.Append("\t\t\t\tif (" + vNombreClase.ToLower() + "Dao == null)\n");
            vc.Append("\t\t\t\t{\n");
            vc.Append("\t\t\t\t\t" + vNombreClase.ToLower() + "Dao = new " + vNombreClase + "Dao();\n");
            vc.Append("\t\t\t\t}\n");
            vc.Append("\t\t\t\treturn " + vNombreClase.ToLower() + "Dao;\n");
            vc.Append("\t\t\t}\n");
            vc.Append("\t\t}");

            return vc.ToString();
        }
    }
}
