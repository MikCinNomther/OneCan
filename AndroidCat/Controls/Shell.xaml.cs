using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AndroidCat.Controls
{
    public partial class Shell : UserControl
    {
        private Process Process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true,
            }
        };

        public Shell()
        {
            InitializeComponent();
            Process.Start();

            // 启动输出读取线程
            new Thread(ReadOutput)
            {
                IsBackground = true // 设置为后台线程
            }.Start();

            // 启动错误读取线程
            new Thread(ReadError)
            {
                IsBackground = true // 设置为后台线程
            }.Start();
        }

        private void ReadOutput()
        {
            try
            {
                while (!Process.HasExited)
                {
                    string line = Process.StandardOutput.ReadLine();
                    if (line != null)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Output.Text += line + Environment.NewLine;
                            // 自动滚动到底部
                            Output.ScrollToEnd();
                        });
                    }
                    Thread.Sleep(10); // 短暂休眠减少CPU使用
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                Debug.WriteLine($"读取输出时出错: {ex.Message}");
            }
        }

        private void ReadError()
        {
            try
            {
                while (!Process.HasExited)
                {
                    string line = Process.StandardError.ReadLine();
                    if (line != null)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Output.Text += $"错误: {line}{Environment.NewLine}";
                            Output.ScrollToEnd();
                        });
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"读取错误时出错: {ex.Message}");
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    if(Input.Text == "cls")
                    {
                        Output.Text = "";
                        Input.Text = "";
                        return;
                    }
                    Process.StandardInput.WriteLine(Input.Text);
                    Process.StandardInput.Flush(); // 确保输入被发送
                    Input.Text = "";
                    e.Handled = true; // 标记事件已处理
                }
                catch (Exception ex)
                {
                    Output.Text += $"发送命令时出错: {ex.Message}{Environment.NewLine}";
                }
            }
        }

        // 添加清理资源的方法
        public void Dispose()
        {
            if (!Process.HasExited)
            {
                Process.Kill();
            }
            Process.Dispose();
        }
    }
}