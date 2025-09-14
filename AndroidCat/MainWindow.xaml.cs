using AndroidCat.Pages;
using NWC_Control;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AndroidCat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Minz_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = WindowState.Minimized;
        }

        private void Maxz_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void Cloiz_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationValues.MainContent = this.MainContent;
            this.Sidebar.Init();
            this.Sidebar.AddItem("激活應用", new ActivityApplication());
            this.Sidebar.AddItem("應用管理", new ApplicationControl());
            this.Sidebar.AddItem("設備管理", new DeviceControl());
            this.Sidebar.AddItem("刷機", new Flash());
            this.Sidebar.AddItem("Shell", Shell.S);
            Update.Update.CheckUpdateITL();
            //  this.Sidebar.AddItem("設置", null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationValues.Theme = (ApplicationValues.Theme == ApplicationValues.Themes.Light) ? ApplicationValues.Themes.Dark : ApplicationValues.Themes.Light;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb reboot system");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb reboot recovery");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb reboot fastboot");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb reboot edl");
        }

        private void FlashDeviceInfo_Click(object sender, RoutedEventArgs e)
        {
            CMD.Shell("adb.exe","shell getprop ro.product.brand",new EventHandler((sender, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Changshang.Text = $"設備廠商：{(string)sender}";
                });
            }));
            CMD.Shell("adb.exe", "shell getprop ro.product.model", new EventHandler((sender, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Xinghao.Text = $"設備型號：{(string)sender}";
                });
            }));
            CMD.Shell("adb.exe", "shell wm size", new EventHandler((sender, e) =>
            {
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        try
                        {
                            this.Fenbianlv.Text = $"分辨率：{((string)sender).Split(':')[1]}";
                        }
                        catch { }
                    });
                }
                catch { }
            }));
            CMD.Shell("adb.exe", "shell wm density", new EventHandler((sender, e) =>
            {
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        try
                        {
                            this.DPI.Text = $"DPI：{((string)sender).Split(':')[1]}";
                        }
                        catch { }
                    });
                }
                catch { }
            }));
            CMD.Shell("adb.exe", "shell getprop ro.build.version.release", new EventHandler((sender, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Anzhuobanben.Text = $"Android：{(string)sender}";
                });
            }));
            CMD.Shell("adb.exe", "shell cat /proc/meminfo", new EventHandler((sender, e) =>
            {
                try
                {
                    string rz = ((string)sender).Split('\n')[0].Split(':')[1].Replace(" ", "");
                    rz = rz.Replace("kB", "");
                    double r = ((double)int.Parse(rz) / 1024.00 / 1024.00);
                    this.Dispatcher.Invoke(() =>
                    {
                        this.Yuncun.Text = $"運行內存：{string.Format("{0:0.00}", r)}GB";
                    });
                }
                catch { }
            }));
            CMD.Shell("adb.exe", "shell getprop ro.product.device", new EventHandler((sender, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Daihao.Text = $"設備代號：{(string)sender}";
                });
            }));
            CMD.Shell("adb.exe", "shell df -k /sdcard | grep -v Filesystem | awk '{print $2}'", new EventHandler((sender, e) =>
            {
                try
                {
                    string output = (string)sender;
                    if (!string.IsNullOrEmpty(output))
                    {
                        long totalKB = long.Parse(output.Trim());
                        double totalGB = totalKB / 1048576.0; // 转换为GB

                        this.Dispatcher.Invoke(() =>
                        {
                            this.Cunchu.Text = $"存储分区：{totalGB:F1}GB";
                        });
                    }
                }
                catch { }
            }));
            CMD.Shell("adb.exe", "root", new EventHandler((sender, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Root.Text = $"Root：{((((string)sender).IndexOf("adbd cannot run as root in production builds") == -1) ? "√" : "×")}";
                });
            }));
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CMD cMD = new CMD();
            cMD.System("start http://120.79.153.186/AndroidCat/Menu.html");
        }
    }
}