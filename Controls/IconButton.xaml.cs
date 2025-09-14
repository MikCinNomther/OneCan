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

namespace OneCan.Controls
{
    /// <summary>
    /// IconButton.xaml 的交互逻辑
    /// </summary>
    public partial class IconButton : UserControl
    {
        public ImageSource Icon { get; set; }
        public String Text { get; set; }

        public EventHandler EventHandler { get; set; } = new EventHandler((sender, e) => { });
        public IconButton()
        {
            InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                this.ImageBox.Source = Icon;
                this.TextBox.Text = Text;
                this.DasButton.Click += (sender, e) =>
                {
                    EventHandler.Invoke(sender, e);
                };
            };
        }
    }
}
