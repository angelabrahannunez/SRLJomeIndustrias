using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //ExecuteCommand("docker-compose up -d");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            try
            {
                //ExecuteCommand("docker rm MySQLSRLJomeIndustrias -f");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        static void ExecuteCommand(string _Command)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + _Command)
            {
                // Indicamos que la salida del proceso se redireccione en un Stream
                RedirectStandardOutput = true,
                UseShellExecute = false,

                //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
                CreateNoWindow = false
            };

            //Inicializa el proceso
            Process proc = new Process
            {
                StartInfo = procStartInfo
            };
            proc.Start();

            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
            string result = proc.StandardOutput.ReadToEnd();

            //Muestra en pantalla la salida del Comando
            Console.WriteLine(result);
        }
    }
}
