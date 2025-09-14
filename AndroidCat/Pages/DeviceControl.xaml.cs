using AndroidCat.Controls;
using NWC_Control;
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

namespace AndroidCat.Pages
{
    /// <summary>
    /// DeviceControl.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceControl : Page
    {
        public DeviceControl()
        {
            InitializeComponent();
        }

        private void IconTextButton_Click(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell \"pm list users; am force-stop com.android.settings; rm /data/system_de/0/accounts_de.db /data/system_ce/0/accounts_ce.db /data/system/sync/accounts.xml /data/system/sync/status.bin /data/system/sync/stats.bin && reboot\"");
        }

        private void IconTextButton_Click_1(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb root && adb shell rm -f /data/system/device_policies.xml /data/system/device_policies.xml.bak /data/system/device_owner*.xml && adb reboot");
        }

        private void IconTextButton_Click_2(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell recovery --wipe_data");
        }

        private void IconTextButton_Click_3(object sender, EventArgs e)
        {
            string file = Input.ShowInputDialog("文件：");
            if (!File.Exists(file))
                return;
            CMD cmd = new CMD();
            cmd.System($"adb push \"{file}\" \"/sdcard/{new FileInfo(file).Name}\"");
        }

        private void IconTextButton_Click_4(object sender, EventArgs e)
        {
            string file = Input.ShowInputDialog("文件：");
            if (file == null)
                return;
            CMD cmd = new CMD();
            cmd.System($"adb sideload \"{file}\"");
        }

        private void IconTextButton_Click_5(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            string newDPI = Input.ShowInputDialog("DPI:");
            if(newDPI == null) return;
            cmd.System($"adb shell wm density {newDPI}");
        }

        private void IconTextButton_Click_6(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("fastboot oem lock");
        }
    }
}
