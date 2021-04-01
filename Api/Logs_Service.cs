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

        public static void Log_AgregarAccion(string message, string object_ID, string userID_str, string username, string IP_client = "")
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new (true);
            System.Diagnostics.StackFrame stackFrame = new ();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            using (ChapiDB_Context context = new())
            {
                Log _logs = new();
                _logs.FechaCreado = GlobalVariables_Service.GetCurrentTime();
                _logs.Usuario = username;
                _logs.Descripcion = message;
                _logs.DatoAfectado = object_ID;
                _logs.IpClient = IP_client;

                int userID = 0;
                if (!int.TryParse(userID_str, out userID))
                {
                    userID = 0;
                    Log_AgregarExcepcion("Excepcion. Convirtiendo int. ERROR:", className, methodName, userID_str);
                }
                _logs.UsuarioId = userID;
                context.Logs.Add(_logs);
                context.SaveChanges();
            }
        }
    }
}
