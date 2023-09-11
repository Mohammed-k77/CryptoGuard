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
using Project.Masseges;

namespace Project
{
    /// <summary>
    /// Interaction logic for Mode.xaml
    /// </summary>
    public partial class Mode : Window
    {
        int mode1, mode2, result;

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Mode()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMode1.Text = "";
            txtMode2.Text = "";
            txtResult.Text = "";
        }

        private void btnMode_Click(object sender, RoutedEventArgs e)
        {
            if (txtMode1.Text == "" && txtMode2.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ...... ", "The Fileds are Embty ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }

            else if (txtMode1.Text == "" )
            {
                MassegeOk massege = new MassegeOk("Warrning ...... ", "Enter Numbeer Digit % ? ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }

            else if (txtMode2.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ...... ", "Enter Numbeer ? %  / Digite ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }


            else
            { 
                mode1 = int.Parse(txtMode1.Text);
            mode2 = int.Parse(txtMode2.Text);
            result = mode1 % mode2;
                if (result < 0)
                    result = result + 26;
                txtResult.Text = result.ToString();
            }
           
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                brdrOk.Opacity = 0.7;
                DragMove();
            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                brdrOk.Opacity = 1;
            }
        }
    }
}
