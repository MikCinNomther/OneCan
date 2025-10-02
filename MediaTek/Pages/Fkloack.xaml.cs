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

namespace OneCan.MediaTek.Pages
{
    /// <summary>
    /// Fkloack.xaml 的交互逻辑
    /// </summary>
    public partial class Fkloack : Page
    {
        public Fkloack()
        {
            InitializeComponent();
        }

        private void UnlockBootLoader_Click(object sender, RoutedEventArgs e)
        {
            CMD cMD = new CMD();
            cMD.SystemCK("python mtk e metadata,userdata,md_udc python mtk seccfg unlock");
        }

        private void LockBootloader_Click(object sender, RoutedEventArgs e)
        {
            CMD cMD = new CMD();
            cMD.SystemCK("python mtk seccfg lock");
        }
    }
}
