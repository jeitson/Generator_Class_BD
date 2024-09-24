using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Generator_Class_BD
{
    public static class GenerateDataContext
    {
        public static void Start(string nameSpace, string vNombreClase, string path, DataGridView dgvTablas)
        {
            StringBuilder cuerpo = new StringBuilder();

            cuerpo.Append("using " + nameSpace + ".Data.Mapper;\n");
            cuerpo.Append("using " + nameSpace + ".Entity;\n");
            cuerpo.Append("using " + nameSpace + ".Utility;\n");
            cuerpo.Append("using System.Data.Entity;\n");
            cuerpo.Append("\n");
            cuerpo.Append("namespace " + nameSpace + ".Data.Context\n");
            cuerpo.Append("{\n");
            cuerpo.Append("\tclass DBContext : DbContext\n");
            cuerpo.Append("\t{\n");
            cuerpo.Append("\t\tprivate string schema;\n\n");
            cuerpo.Append("\t\tpublic DBContext() : base(Constant.DatabaseConn)\n");
            cuerpo.Append("\t\t{\n");
            cuerpo.Append("\t\t\tschema = Constant.DatabaseSchema;\n");
            cuerpo.Append("\t\t}\n\n");

            foreach (DataGridViewRow row in dgvTablas.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (Boolean.Parse(row.Cells[0].Value.ToString()) == true)
                    {
                        cuerpo.Append("\t\tpublic DbSet<" + row.Cells[1].Value.ToString() + "Info> " + row.Cells[1].Value.ToString() + " { get; set; }\n");
                    }
                }
            }
            cuerpo.Append("\n");
            cuerpo.Append("\t\tprotected override void OnModelCreating(DbModelBuilder modelBuilder)\n");
            cuerpo.Append("\t\t{\n");
            cuerpo.Append("\t\t\tbase.OnModelCreating(modelBuilder);\n");

            foreach (DataGridViewRow row in dgvTablas.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (Boolean.Parse(row.Cells[0].Value.ToString()) == true)
                    {
                        cuerpo.Append("\t\t\tmodelBuilder.Configurations.Add(new " + row.Cells[1].Value.ToString() + "Mapper(schema));\n");
                    }
                }
            }

            cuerpo.Append("\t\t}\n");

            cuerpo.Append("\t}\n");
            cuerpo.Append("}");

            string folder = path + "\\Data\\Context\\";
            string fileName = path + "\\Data\\Context\\Context.cs";
            Utility.SaveFile(folder, fileName, cuerpo);
        }
    }
}
