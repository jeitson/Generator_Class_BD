using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateInterface
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("using " + nameSpace + ".Entity;\n");
            cuerpo.Append("using System.Collections.Generic;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Interface\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic interface I" + vNombreClase + "\n");
            cuerpo.Append("\t{\n");

            cuerpo.Append("\t\t" + vNombreClase + "Info Create(" + vNombreClase + "Info item);\n\n");
            cuerpo.Append("\t\t" + vNombreClase + "Info Update(" + vNombreClase + "Info item);\n\n");
            cuerpo.Append("\t\tbool Delete(int id);\n\n");
            cuerpo.Append("\t\t" + vNombreClase + "Info Get(int id);\n\n");
            cuerpo.Append("\t\tList<" + vNombreClase + "Info> List();\n");

            cuerpo.Append("\t}\n");
            cuerpo.Append("}");
            //fin de metodo     

            string folder = path + "\\Interface";
            string fileName = path + "\\Interface\\I" + vNombreClase + ".cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}
