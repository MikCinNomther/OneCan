using Microsoft.Win32;
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
    /// Input.xaml 的交互逻辑
    /// </summary>
    public partial class Input : Window
    {
        private string mT;
        private string mR = null;
        private Input(String Tis)
        {
            mT = Tis;
            InitializeComponent();
        }

        static public string ShowInputDialog(String Content)
        {
            Input input = new Input(Content);
            input.ShowDialog();
            if (input.mR == string.Empty)
            {
                return null;
            }
            return input.mR;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.InputTis.Text = mT;
            this.InputResult.KeyDown += (sender, e) =>
            {
                if (e.Key == Key.Enter)
                {
                    Button_Click(sender, e);
                }
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mR = InputResult.Text;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if ((bool)openFileDialog.ShowDialog())
                {
                    InputResult.Text = openFileDialog.FileName;
                }
            }
            else if (e.Key == Key.F2)
            {
                OpenFolderDialog openFolderDialog = new OpenFolderDialog();
                if ((bool)openFolderDialog.ShowDialog())
                {
                    InputResult.Text = openFolderDialog.FolderName;
                }
            }
        }
    }
}
