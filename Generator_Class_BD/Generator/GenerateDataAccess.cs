using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateDataAccess
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("using " + nameSpace + ".Entity;");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Data.Access");
            cuerpo.Append("\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tinternal class " + vNombreClase + "Dao : ManagerDao<" + vNombreClase + "Info>\n");
            cuerpo.Append("\t{\n");
            cuerpo.Append("\t}");
            cuerpo.Append("\n");
            cuerpo.Append("}");
            //fin de metodo     

            string folder = path + "\\Data\\Access\\";
            string fileName = path + "\\Data\\Access\\" + vNombreClase + "Dao.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}
