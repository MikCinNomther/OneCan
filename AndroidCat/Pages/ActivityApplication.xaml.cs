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
    /// ActivityApplication.xaml 的交互逻辑
    /// </summary>
    public partial class ActivityApplication : Page
    {
        public ActivityApplication()
        {
            InitializeComponent();
        }

        private void IconTextButton_Click(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell sh /sdcard/android/data/moe.shizuku.privileged.api/start.sh");
        }

        private void IconTextButton_Click_1(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell dpm set-device-owner web1n.stopapp/.receiver.AdminReceiver");
        }

        private void IconTextButton_Click_2(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell sh /sdcard/Android/data/web1n.stopapp/files/demon.sh");
        }

        private void IconTextButton_Click_3(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell sh /sdcard/Android/data/com.catchingnow.icebox/files/start.sh");
        }

        private void IconTextButton_Click_4(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell sh /data/data/me.piebridge.brevent/brevent.sh");
        }

        private void IconTextButton_Click_5(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell dpm set-device-owner cf.playhi.freezeyou/.DeviceAdminReceiver");
        }

        private void IconTextButton_Click_6(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell dpm set-device-owner me.weishu.exp/.DeviceAdmin");
        }

        private void IconTextButton_Click_7(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell dpm set-device-owner com.hld.anzenbokusu/.DeviceAdmin");
        }

        private void IconTextButton_Click_8(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell dpm set-device-owner com.oasisfeng.island/.IslandDeviceAdminReceiver");
        }

        private void IconTextButton_Click_9(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System(new string[]
            {
                "adb shell pm grant com.venyx.blackhole android.permission.MANAGE_USERS",
                "adb shell pm grant com.venyx.blackhole android.permission.SUSPEND_APPS"
            });
        }

        private void IconTextButton_Click_10(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell dpm set-device-owner com.web1n.freezer/.MainReceiver");
        }

        private void IconTextButton_Click_11(object sender, EventArgs e)
        {
            CMD cmd = new CMD();
            cmd.System("adb shell pm grant com.oasisfeng.greenify android.permission.PACKAGE_USAGE_STATS");
        }
    }
}
