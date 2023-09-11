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
using Project.Masseges;

namespace Project
{
    /// <summary>
    /// Interaction logic for DES.xaml
    /// </summary>
    public partial class DES : UserControl
    {
        Security Security = new Security();
        public DES()
        {
            InitializeComponent();
        }

        private void btnEnc_Click(object sender, RoutedEventArgs e)
        {
            if (txtPlainText.Text == "" && txtKey.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ...... ", "The Fileds are Embty ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }


            else if (txtPlainText.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ...... ", "You missing Inter Plain Text ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }

            else if (txtKey.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ......  ", "You missing Inter Key ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }

            else
                txtChiperText.Text = Security.GetEncryptor(txtKey.Text , txtPlainText.Text);
        }

        private void btnDec_Click(object sender, RoutedEventArgs e)
        {
            if (txtChiperText1.Text == "" && txtKey1.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ...... ", "The Fileds are Embty ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }


            else if (txtChiperText1.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ...... ", "You missing Inter Chiper Text ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }

            else if (txtKey1.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ......  ", "You missing Inter Key ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }

            else
                txtPlainText1.Text = Security.GetDecryptor(txtKey1.Text , txtChiperText.Text);

        }

        private void btnDClear_Click(object sender, RoutedEventArgs e)
        {
            txtChiperText1.Text = "";
            txtPlainText1.Text = "";
            txtKey1.Text = "";
        }

        private void btnEClear_Click(object sender, RoutedEventArgs e)
        {
            txtChiperText.Text = "";
            txtKey.Text = "";
            txtPlainText.Text = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
