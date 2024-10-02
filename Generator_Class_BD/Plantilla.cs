/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using System;
using System.Collections.Generic;
using System.Text;

public static class Plantilla
{
    public static String Convertir(string val)
    {
        string convertido = "";
        convertido = val.Substring(0, 1).ToUpper() + val.Substring(1);
        return convertido;
    }

    public static String ConvertirTipoGet(string tipo)
    {
        string convertido = "";

        switch (tipo)
        {
            //case "char":
            //    convertido = "GetString";
            case "datetime":
            case "datetime2":
            case "time":
                convertido = "GetDateTime";
                break;

            case "float":
                convertido = "GetDouble";
                break;

            case "money":
                convertido = "GetDouble";
                break;

            case "decimal":
                convertido = "GetDouble";
                break;

            case "int":
                convertido = "GetInt32";
                break;

            case "varchar":
                convertido = "GetString";
                break;

            case "nvarchar":
                convertido = "GetString";
                break;

            case "bit":
                convertido = "GetBool";
                break;

            default:
                convertido = "GetString";
                break;
        }
        return convertido;
    }

    public static String ConvertirTipo(string tipo, string isNull)
    {
        string convertido = "";

        switch (tipo)
        {
            case "nvarchar":
            case "varchar":
            case "char":
                convertido = (isNull == "YES") ? "string?" : "string";
                break;

            case "datetime":
            case "datetime2":
            case "time":
                convertido = (isNull == "YES") ? "DateTime?" : "DateTime";
                break;

            case "float":
                convertido = (isNull == "YES") ? "double?" : "double";
                break;

            case "int":
                convertido = (isNull == "YES") ? "int?" : "int";
                break;

            case "money":
                convertido = (isNull == "YES") ? "double?" : "double";
                break;

            case "image":
                convertido = (isNull == "YES") ? "byte[]?" : "byte[]";
                break;

            case "bit":
                convertido = (isNull == "YES") ? "bool?" : "bool";
                break;

            case "uniqueidentifier":
                convertido = (isNull == "YES") ? "Guid?" : "Guid";
                break;

            case "decimal":
                convertido = (isNull == "YES") ? "decimal?" : "decimal";
                break;
            case "numeric":
                convertido = (isNull == "YES") ? "decimal?" : "decimal";
                break;

            case "varbinary":
                convertido = (isNull == "YES") ? "byte[]?" : "byte[]";
                break;
            
        }
        return convertido;
    }

    public static String ConvertirTipoSQL(string tipo)
    {
        string convertido = "";

        switch (tipo)
        {
            case "char":
                convertido = "Char";
                break;

            case "datetime":
            case "datetime2":
            case "time":
                convertido = "DateTime";
                break;

            case "float":
                convertido = "Float";
                break;

            case "int":
                convertido = "Int";
                break;

            case "varchar":
                convertido = "VarChar";
                break;

            case "nvarchar":
                convertido = "nVarChar";
                break;

            case "money":
                convertido = "Money";
                break;

            case "decimal":
                convertido = "decimal";
                break;

            case "bit":
                convertido = "bool";
                break;
        }
        return convertido;
    }
}