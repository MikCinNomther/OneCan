using NWC_Control;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Update
{
    static public class Update
    {
        static public UInt128 a = 3;
        static public void CheckUpdateITL()
        {
            WebClient webClient = new WebClient();
            UInt128 r = UInt128.Parse(webClient.DownloadString("http://120.79.153.186/AndroidCat/NewestVersion.txt"));
            if(r > a)
            {
                if(MessageBox.Show("哇嗚！安喵有了新版本！快去更新吧！","是新版本鴨！",MessageBoxButton.YesNo,MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    CMD cMD = new CMD();
                    cMD.System("start http://120.79.153.186/AndroidCat/Installer.exe");
                    Thread.Sleep(1000);
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
    }
}
namespace NWC_Control
{
    public class CMD
    {
        private Process process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true
            }
        };

        public CMD(String Argunment = "") {
            process.StartInfo.Arguments = Argunment;
        }
        public CMD(String Process, String Argunment = "")
        {
            process.StartInfo.FileName = Process;
            process.StartInfo.Arguments = Argunment;
        }

        public void System(string Command)
        {
            process.Start();
            process.StandardInput.WriteLine(Command);
        }
        public void System(string[] Commands)
        {
            process.Start();
            foreach (string Command in Commands)
                process.StandardInput.WriteLine(Command);
        }

        static public void Shell(string processName, string command, EventHandler callback)
        {
                Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = processName,
                        Arguments = command,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                // 异步读取输出
                Thread thread = new Thread(() =>
                {
                        string result = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();

                        // 等待进程结束
                        process.WaitForExit();

                        // 在主线程上下文执行回调（如果需要）
                        if (callback != null)
                        {
                            callback.Invoke(result, null);
                        }
                });
                thread.Start();
            }
        }
    }