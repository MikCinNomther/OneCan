using AndroidCat.Controls;
using NWC_Control;
using System;
using System.Collections.Generic;
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

namespace AndroidCat.Pages
{
    /// <summary>
    /// Flash.xaml 的交互逻辑
    /// </summary>
    public partial class Flash : Page
    {
        public Flash()
        {
            InitializeComponent();
        }

        private void IconTextButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Input.ShowInputDialog("文件位置：");
        }


        private void IconTextButton_Click(object sender, EventArgs e)
        {
            string file = Input.ShowInputDialog("文件：");
            if (file == null)
                return;
            CMD cmd = new CMD();
            cmd.System($"fastboot flash recovery \"{file}\"");
        }

        private void IconTextButton_Click_1(object sender, EventArgs e)
        {
            string file = Input.ShowInputDialog("文件：");
            if (file == null)
                return;
            CMD cmd = new CMD();
            cmd.System($"fastboot flash boot \"{file}\"");
        }
    }
}
