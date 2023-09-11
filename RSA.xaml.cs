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
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
using Project.Masseges;


namespace Project
{

    public partial class RSA : UserControl
    {
        RSAParameters pubkey;
        RSAParameters prikey;

        public RSA()
        {
            InitializeComponent();


            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);

             pubkey = csp.ExportParameters(false);
             prikey = csp.ExportParameters(true);

        }

        private void btnEnc_Click(object sender, RoutedEventArgs e)
        {
            if (txtPlainText.Text == "")
                {
                    MassegeOk massege = new MassegeOk("Warrning ...... ", "You missing Inter Plain Text ", @"/Images/error.png", @"/Images/askquestion.png");
                    massege.ShowDialog();
                }
            else
            { 
                RSACryptoServiceProvider cspenc = new RSACryptoServiceProvider();
                cspenc.ImportParameters(pubkey);

                byte[] mbytearray = Encoding.UTF8.GetBytes(txtPlainText.Text);

                byte[] cbytearray = cspenc.Encrypt(mbytearray,false);

                txtChiperText.Text = Convert.ToBase64String(cbytearray);
            }
        }

        private void btnECleare_Click(object sender, RoutedEventArgs e)
        {
            txtPlainText.Text = " ";
            txtChiperText.Text = " ";
        }

        private void btnDec_Click(object sender, RoutedEventArgs e)
        {
            if (txtChiperText1.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ...... ", "You missing Inter Chiper Text ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }
            else
            {
                RSACryptoServiceProvider cspdec = new RSACryptoServiceProvider();
                cspdec.ImportParameters(prikey);

                byte[] cbytearray = Convert.FromBase64String(txtChiperText1.Text);

                byte[] mbytearray = cspdec.Decrypt(cbytearray, false);

                txtPlainText1.Text = Encoding.UTF8.GetString(mbytearray);
            }
        }

        private void btnDClear_Click(object sender, RoutedEventArgs e)
        {
            txtPlainText1.Text = " ";
            txtChiperText1.Text = " ";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
