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
    public static class GenerateCoreInterface
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            StringBuilder cuerpo = new StringBuilder();
            vNombreClase = TransformFieldHelper.TransformTable(vNombreClase);

            cuerpo.Append("using Maguna.Common.Data.Access.IRepositories;\n");
            cuerpo.Append("using " + nameSpace + ".Entity;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Data.IRepositories\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic interface I" + vNombreClase + "Repository : IRepository<" + vNombreClase + ">\n");
            cuerpo.Append("\t{\n");
            cuerpo.Append("\t}\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = path + "\\Data\\IRepositories";
            string fileName = path + "\\Data\\IRepositories\\I" + vNombreClase + "Repository.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}