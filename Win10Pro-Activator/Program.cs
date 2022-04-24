using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Win10Pro_Activator
{
    internal class Program
    {
        static string[] g_commands = 
        {
            "cscript /nologo C:\\Windows\\System32\\slmgr.vbs -cpky",
            "cscript /nologo C:\\Windows\\System32\\slmgr.vbs -upk",
            "cscript /nologo /nologo C:\\Windows\\System32\\slmgr.vbs -skms kms.teevee.asia",
            "cscript /nologo C:\\Windows\\System32\\slmgr.vbs -ipk W269N-WFGWX-YVC9B-4J6C9-T83GX",
            "cscript /nologo C:\\Windows\\System32\\slmgr.vbs -ato" 
        };

        static void Main(string[] args)
        {
            logger("Activating Windows 10 Pro...", true, true);
            string cmd_result = cmd_executor(g_commands);
            logger(cmd_result, false, true);

            if (!cmd_result.Contains("slui") && !cmd_result.Contains("продукт не найден") && !cmd_result.Contains("0xC004F015") && !cmd_result.Contains("заблокирован") && !cmd_result.Contains("превышен") && !cmd_result.Contains("предел") && !cmd_result.Contains("сообщил") && !cmd_result.Contains("определил"))
            {
                logger("Windows successfully activated", true, true);
            }
            else
            {
                logger("Failed activation", true, true);
            }
            logger("Press any key to exit", true, false);
            Console.ReadKey();
        }


        static string cmd_executor(string[] commands)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.AutoFlush = true;
            for (int i = 0; i < commands.Length; i++)
            {
                logger($"Step {i + 1}", true, true);
                process.StandardInput.WriteLine(commands[i]);
            }
            process.StandardInput.Close();
            return process.StandardOutput.ReadToEnd();
        }

        static void logger(string log, bool c_write, bool f_write)
        {
            if (c_write)
                Console.WriteLine($"[github.com/foxlye] {log}");

            if (f_write)
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine($"[github.com/foxlye] {log}");
                }
            }
        }
    }
}
