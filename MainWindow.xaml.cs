using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneCan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public MainWindow App;
        public MainWindow()
        {
            InitializeComponent();
            App = this;
        }

        private void ToMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void ToClose_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("您希望退出OneCan吗？","提示",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        static Brush[][] Brusheses = new Brush[][]
        {
            new Brush[]
            {
                new SolidColorBrush(Colors.White),new SolidColorBrush(Colors.Black)
            },new Brush[]
            {
                new SolidColorBrush(Color.FromRgb(36,38,32)),new SolidColorBrush(Colors.White)
            },new Brush[]
            {
                new SolidColorBrush(Color.FromRgb(140,226,238)),new SolidColorBrush(Colors.White)
            },
            new Brush[]
            {
                new SolidColorBrush(Colors.Orange),new SolidColorBrush(Colors.White)
            },new Brush[]
            {
                new SolidColorBrush(Color.FromRgb(255,127,127)),new SolidColorBrush(Colors.White)
            },
        };
        private static int BrushIndex = 0;
        int NextBrush
        {
            get
            {
                BrushIndex = (BrushIndex + 1) % Brusheses.Length;
                return BrushIndex;
            }
        }
        Brush[] tmp_1;
        private void TraingeStyle_Click(object sender, RoutedEventArgs e)
        {
            tmp_1 = Brusheses[NextBrush];
            Application.Current.Resources["GridBackground"] = tmp_1[0];
            new Task(() =>
            {
                try { 
                    for(int i = 360; i > 0; i--)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            this.TraingeStyler.Angle = (this.TraingeStyler.Angle+1)%360;
                        });
                        Thread.Sleep(2);
                    }
                    this.Dispatcher.Invoke(() =>
                    {
                        Application.Current.Resources["Foreground"] = tmp_1[1];
                    });
                } catch { return; };
            }).Start();
        }
        bool IsTranSTying = false;
        Thread Dfs = null;
        private void TraingeStyle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if((IsTranSTying = !IsTranSTying) == true)
            {
                Dfs = new Thread(() =>
                {
                    try
                    {
                        while (IsTranSTying)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                this.TraingeStyler.Angle = (this.TraingeStyler.Angle + 1) % 360;
                            });
                            Thread.Sleep(2);
                        }
                    } catch { return; };
                });
                Dfs.Start();
            }
            else
            {
                if(null != Dfs)
                {
                    try
                    {
                        Dfs.Abort();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        Dfs = null;
                        this.TraingeStyler.Angle = 0;
                    }
                }
            }
        }
        Thread TanaTh = null;
        bool DontTana = false;
        public void TranaFrame(Page frame)
        {
            if (DontTana)
                return;
            DontTana = true;
            int ywidth = (int)this.NowFrame.ActualWidth;
            if(TanaTh != null)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        TanaTh.Abort();
                        TanaTh.Suspend();
                    }
                }
                catch {
                    return;
                }
                finally
                {
                    TanaTh = null;
                }
            }
            TanaTh = new Thread(() =>
            {
                for(int i = 0;i < ywidth;i+=5)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        NowFrame.Margin = new Thickness(0,0,i,0);
                    });
                    Thread.Sleep(1);
                }
                this.Dispatcher.Invoke(() =>
                {
                    this.NowFrame.Content = frame;
                });
                while((ywidth-=4) >= 0)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        NowFrame.Margin = new Thickness(ywidth, 0, 0, 0);
                    });
                    Thread.Sleep(1);
                }
                TanaTh = null;
                DontTana = false;
            });
            TanaTh.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.NowFrame.Content = ApplicationValues.Menu;
        }
    }
}