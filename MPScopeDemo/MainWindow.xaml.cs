using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MPScopeDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MPS mps = new MPS();
        public MainWindow()
        {
            InitializeComponent();
            if (mps.ReconnectMPScope())
            {
                this.Title = "连接成功";
            }
            else
            {
                this.Title = "连接失败";
            }
        }

        private void bt_Click_Set(object sender, RoutedEventArgs e)
        {
            short args1 = Convert.ToInt16(S_MW1000.Text);
            short args2 = Convert.ToInt16(S_MW1001.Text);
            mps.SetMW(1000, args1);
            mps.SetMW(1001, args2);
        }

        private void bt_Click_Get(object sender, RoutedEventArgs e)
        {
            short args1 = mps.GetMW(1000);
            short args2 = mps.GetMW(1001);
            G_MW1000.Text = args1.ToString();
            G_MW1001.Text = args2.ToString();
        }
    }
}
