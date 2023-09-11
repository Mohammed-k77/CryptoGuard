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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Project
{
    public partial class SplashScreen : Window
    {
        DispatcherTimer DT = new DispatcherTimer();
        public SplashScreen()
        {
            InitializeComponent();

            DT.Tick += new EventHandler(dt_Tick); 
            DT.Interval = new TimeSpan( 0 , 0 , 5 );
            DT.Start();
        }

        private void dt_Tick(object sender ,EventArgs e)
        {

            MainWindow Mw = new MainWindow();
            Mw.Show();


            DT.Stop();
            this.Close();
        }
    }
}
