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
    /// ApplicationControl.xaml 的交互逻辑
    /// </summary>
    public partial class ApplicationControl : Page
    {
        public ApplicationControl()
        {
            InitializeComponent();
        }

        private void IconTextButton_Click(object sender, EventArgs e)
        {
            string file = Input.ShowInputDialog("文件：");
            if (file == null)
                return;
            CMD cmd = new CMD();
            cmd.SystemCK($"adb install \"{file}\"");
        }

        private void IconTextButton_Click_1(object sender, EventArgs e)
        {
            string file = Input.ShowInputDialog("包名：");
            if (file == null)
                return;
            CMD cmd = new CMD();
            cmd.SystemCK($"adb uninstall \"{file}\"");
        }

        private void IconTextButton_Click_2(object sender, EventArgs e)
        {
            string file = Input.ShowInputDialog("包名：");
            if (file == null)
                return;
            CMD cmd = new CMD();
            cmd.SystemCK($"adb shell pm disable-user \"{file}\"");
        }
    }
}
