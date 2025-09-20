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

namespace OneCan.Pages
{
    /// <summary>
    /// MTK.xaml 的交互逻辑
    /// </summary>
    public partial class MTK : Page
    {
        public MTK()
        {
            InitializeComponent();
        }

        static public MediaTek.Pages.FlashFencus FlashFencus = new MediaTek.Pages.FlashFencus();
        static public MediaTek.Pages.Flashit Flashit = new MediaTek.Pages.Flashit();
        static public MediaTek.Pages.Fkloack Fkloack = new MediaTek.Pages.Fkloack();
        static public MediaTek.Pages.Systemies Systemies = new MediaTek.Pages.Systemies();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Foncin.Content = MTK.FlashFencus;
        }

        private void FlushFencusButton_Click(object sender, RoutedEventArgs e)
        {
            this.Foncin.Content = MTK.FlashFencus;
        }

        private void FlashItButton_Click(object sender, RoutedEventArgs e)
        {
            this.Foncin.Content = MTK.Flashit;
        }

        private void FkLoackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Foncin.Content = MTK.Fkloack;
        }

        private void SystemiesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Foncin.Content = MTK.Systemies;
        }
    }
}
