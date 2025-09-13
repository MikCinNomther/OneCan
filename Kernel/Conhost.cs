using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCan.Kernel
{
    class Conhost
    {
        public Process Process;
        public string FileName;
        public string Arguments;
        public bool RedirectInput;
        public bool RedirectOutput;
        public bool CreateNoWindow;
        public bool UseShellExecute;
        public Conhost(string FileName = "cmd.exe",string Arguments = null,bool RedirectInput = false,bool RedirectOutput = false,bool CreateNoWindow = false,bool UseShellExecute = false)
        {
            this.Process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = (this.FileName = FileName),
                    Arguments = (this.Arguments = Arguments),
                    RedirectStandardInput = (this.RedirectInput = RedirectInput),
                    RedirectStandardOutput = (this.RedirectOutput = RedirectOutput),
                    CreateNoWindow = (this.CreateNoWindow = CreateNoWindow),
                    UseShellExecute = (this.UseShellExecute = UseShellExecute),
                }
            };
        }

        public void Start()
        {
            this.Process.Start();
        }

        public void StartWithCommand(string Command)
        {
            this.Process.Start();
            this.Process.StandardInput.WriteLine(Command);
        }
        public void StartWithCommands(string[] Commands)
        {
            this.Process.Start();
            foreach(string Command in Commands)
                this.Process.StandardInput.WriteLine(Command);
        }

        public String StartAndGetOutput()
        {
            this.Process.Start();
            return this.Process.StandardOutput.ReadToEnd();
        }

        public String StartAndGetOutputWithCommand(string Command)
        {
            this.Process.Start();
            this.Process.StandardInput.WriteLine(Command);
            return this.Process.StandardOutput.ReadToEnd();
        }

        public String StartAndGetOutputWithCommands(string[] Commands)
        {
            this.Process.Start();
            foreach (string Command in Commands)
                this.Process.StandardInput.WriteLine(Command);
            return this.Process.StandardOutput.ReadToEnd();
        }
    }
}
