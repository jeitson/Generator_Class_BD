/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    public static class GenerateCoreRepository
    {
        public static void Start(string nameSpace, string vNombreClase, string path)
        {
            //metodo CrearClase
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("using Maguna.Common.Data.Access.Repositories;\n");
            cuerpo.Append("using Maguna.Common.Infrastructure;\n");
            cuerpo.Append("using " + nameSpace + ".Data.IRepositories;\n");
            cuerpo.Append("using " + nameSpace + ".Entity;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Data.Repositories");
            cuerpo.Append("\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tpublic class " + vNombreClase + "Repository : Repository<" + vNombreClase + "Info>, I" + vNombreClase + "Repository\n");
            cuerpo.Append("\t{\n");
            cuerpo.Append("\t\tprivate CustomerDbContext _db;\n");
            cuerpo.Append("\t\tpublic " + vNombreClase + "Repository(CustomerDbContext dbContext, ISystem system) : base(dbContext, system)\n");
            cuerpo.Append("\t\t{\n");
            cuerpo.Append("\t\t\t _db = dbContext;\n");
            cuerpo.Append("\t\t\t _system = system;\n");
            cuerpo.Append("\t\t}\n");
            cuerpo.Append("\t}");
            cuerpo.Append("\n");
            cuerpo.Append("}");
            //fin de metodo

            string folder = path + "\\Data\\Repositories\\";
            string fileName = path + "\\Data\\Repositories\\" + vNombreClase + "Repository.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}