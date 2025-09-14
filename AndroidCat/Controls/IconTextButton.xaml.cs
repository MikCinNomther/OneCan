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
    /// IconTextButton.xaml 的交互逻辑
    /// </summary>
    public partial class IconTextButton : UserControl
    {

        public ImageSource IconSource { get; set; }
        public delegate void ButtonClick(object sender, EventArgs e); // 定义委托类型
        public event ButtonClick Click = null;
        public string IconText { get; set; }
        public IconTextButton()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IconText = IconText.Replace("\\n","\n");
            this.Image.Source = IconSource;
            this.Text.Text = IconText;
            this.ToolTip = IconText;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Click != null) 
            Click.Invoke(this, e);
        }
    }
}
