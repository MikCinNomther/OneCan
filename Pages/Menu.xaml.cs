using NWC_Control;
using OneCan.Document;
using OneCan.Kernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneCan.Pages
{
    /// <summary>
    /// Menu.xaml 的交互逻辑
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }
        static Help Help = new Help();
        static Policy Policy = new Policy();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.GoToGithub.DasButton.Click += (sender, e) =>
            {
                Conhost conhost = new Conhost("cmd.exe",null,true,false,true);
                conhost.StartWithCommand("start http://github.com/MikCinNomther/OneCan");
            };
            this.WorkPath.DasButton.Click += (sender, e) =>
            {
                Conhost conhost = new Conhost("cmd.exe", null, true, false, true);
                conhost.StartWithCommand($"explorer \"{new FileInfo(this.GetType().Assembly.Location).DirectoryName}\"");
            };
            this.GetHelp.DasButton.Click+= (sender, e) =>
            {
                MainWindow.App.TranaFrame(Help);
            };
            this.UserPolicy.DasButton.Click += new RoutedEventHandler((sender, e) =>
            {
                MainWindow.App.TranaFrame(Policy);
            });
            this.CheckInvironment.DasButton.Click += new RoutedEventHandler((sender, e) =>
            {
                new Thread(async () =>
                {
                    bool Python = true;
                    string PyVer = null;
                    try
                    {
                        PyVer = await CMD.RunCMD("python --version");
                    }
                    catch
                    {
                        Python = false;
                    }

                    bool MTK = true;
                    string MTKVer = null;
                    try
                    {
                        MTKVer = await CMD.RunCMD("mtk version");
                    }
                    catch
                    {
                        MTK = false;
                    }
                    if (Python && MTK)
                    {
                        this.Dispatcher.BeginInvoke(() =>
                        {
                            MessageBox.Show("您的必要依赖已就绪。","完成",MessageBoxButton.OK,MessageBoxImage.Information);
                        });
                    }
                    else
                    {
                        StringBuilder stringBuilder = new StringBuilder("您还需要安装以下依赖：");
                        if(Python == false)
                        {
                            stringBuilder.Append("\r\n\tPython");
                        }
                        if (MTK == false)
                        {
                            stringBuilder.Append("\r\n\tMTKClient");
                        }
                        this.Dispatcher.BeginInvoke(() =>
                        {
                            MessageBox.Show(stringBuilder.ToString(), "问题", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                }).Start();
            });
        }
    }
}
