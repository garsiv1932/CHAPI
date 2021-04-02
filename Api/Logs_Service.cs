using Api.Data;
using Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Api
{
    public class Logs_Service
    {
        private static Configuraciones _configuraciones = new();

        public static void Log_AgregarExcepcion(string message, string className, string methodName, string exception_msg, [CallerLineNumber] int numberNumber = 0)
        {
            try
            {
                string error_log_file = _configuraciones.Error_log_file;
                if (!string.IsNullOrWhiteSpace(error_log_file))
                {
                    using (StreamWriter writer = new(error_log_file, true))
                    {
                        string text = DateTime.Now.ToString() + ": [ln:" + numberNumber + "] " + className + ": " + methodName + "() - " + message + " " + exception_msg + ".";
                        writer.WriteLine(text);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
