using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class StartAGame
    {
        public static string StartGame()
        {
            Process proc = null;
            try
            {

                if (Environment.CurrentDirectory.Contains(' '))
                {
                    throw new Exception("If you want to use this feature, you must place the application on a path that does not contain whitespaces.\nExample:\nC:\\Users\\User1\\Desktop\\My directory\\ - WRONG\nC:\\Users\\User1\\Desktop\\MyDirectory\\ - RIGHT");
                }

                string text = "";
                using (StreamReader sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"Resources\DOSBoxPortable\Data\settings\dosbox.conf")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        text += line + "\n";
                        if (line == "# Lines in this section will be run at startup.")
                        {
                            break;
                        }
                    }
                }

                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"Resources\DOSBoxPortable\Data\settings\dosbox.conf"), text);


                using (StreamWriter sw = File.AppendText(Path.Combine(Environment.CurrentDirectory, @"Resources\DOSBoxPortable\Data\settings\dosbox.conf")))
                {
                    sw.WriteLine($"mount c " + Path.Combine(Environment.CurrentDirectory, @"Resources\DOSBoxPortable\CommanderKeen6"));
                    sw.WriteLine(@"C:");
                    sw.WriteLine("KEEN6");
                }

                string batDir = string.Format(@"Resources\DOSBoxPortable");

                batDir = Path.Combine(Environment.CurrentDirectory, batDir);

                proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = "runme.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
                return ex.Message;
            }
        }

    }
}
