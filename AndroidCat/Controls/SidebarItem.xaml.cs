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

namespace AndroidCat.Controls
{
    /// <summary>
    /// SidebarItem.xaml 的交互逻辑
    /// </summary>
    public partial class SidebarItem : UserControl
    {
        private Page _page;
        private string _content;
        public SidebarItem(Page page, string content)
        {
            InitializeComponent();
            _page = page;
            _content = content;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _Label.Text = _content;
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ApplicationValues.Content = _page;
        }
    }
}
