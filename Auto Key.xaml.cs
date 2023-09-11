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
    /// Interaction logic for Auto_Key.xaml
    /// </summary>
    public partial class Auto_Key : UserControl
    {
        int key;
        char[] arry1;
        int[] arry2;
        int[] arry3;
        int[] arry4;
        public Auto_Key()
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
            {
                txtChiperText.Text = "";
                string PlainTxet = txtPlainText.Text;
                int size = PlainTxet.Length;
                arry1 = new char[size];
                arry2 = new int[size];
                for (int i = 0; i < size; i++)
                    arry1[i] = PlainTxet[i];

                try
                {
                    key = int.Parse(txtKey.Text);
                }
                catch (Exception)
                {

                    MassegeOk massege = new MassegeOk("Warrning ......  ", "Enter Digit no String", @"/Images/error.png", @"/Images/askquestion.png");
                    massege.ShowDialog();
                    return;
                }

                int size2 = 0;
                for (int i=0,j=0 ; i < size ; i++)
                {
                    if (arry1[i] != 32)
                    { 
                        arry2[j]=(arry1[i]);
                        size2 += 1;
                        j++;                     
                    }
                }

                arry3 = new int[size2];
                arry4 = new int[size2];
                for (int i = 0; i < size2; i++)
                {
                    if (arry2[i] > 90)
                    {
                        arry3[i] = arry2[i] - 97;
                        arry4[i] = arry2[i] - 97;
                     }
                    else
                    {
                        arry3[i] = arry2[i] - 65;
                        arry4[i] = arry2[i] - 65;
                    }
                }


                for (int i = size2-1; i > 0; i--)
                {
                    arry3[i] = arry3[i - 1];
                }

                arry3[0] =int.Parse(txtKey.Text);

                for (int j = 0; j < size2; j++)
                {
                    arry3[j] = arry3[j] + arry4[j];
                    arry3[j] = arry3[j] % 26;
                    arry3[j] = arry3[j] + 65;
                }

                for(int i=0,j=0 ; i < size; i++)
                {
                    if (arry1[i] == 32)
                    { 
                        arry2[i] = arry1[i];
                    }
                    else
                    { 
                        arry2[i] = arry3[j];
                        j++;
                    }
                }

                for (int j = 0; j < size; j++)
                {
                    arry1[j] = (Char)arry2[j];
                    txtChiperText.Text += arry1[j];
                }

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnEClear_Click(object sender, RoutedEventArgs e)
        {
            txtChiperText.Text = "" ;
            txtKey.Text = "" ;
            txtPlainText.Text = "" ;
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
                MassegeOk massege = new MassegeOk("Warrning ...... ", "You missing Inter Plain Text ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }

            else if (txtKey1.Text == "")
            {
                MassegeOk massege = new MassegeOk("Warrning ......  ", "You missing Inter Key ", @"/Images/error.png", @"/Images/askquestion.png");
                massege.ShowDialog();
            }

            else
            {
                txtPlainText1.Text = "";
                string ChiperTxet = txtChiperText1.Text;
                int size = ChiperTxet.Length;
                arry1 = new char[size];
                arry2 = new int[size];
                for (int i = 0; i < size; i++)
                    arry1[i] = ChiperTxet[i];
                try
                {
                    key = int.Parse(txtKey1.Text);
                }
                catch (Exception)
                {
                    MassegeOk massege = new MassegeOk("Warrning ......  ", "Enter Digit no String", @"/Images/error.png", @"/Images/askquestion.png");
                    massege.ShowDialog();
                    return;
                }

                int size2 = 0;
                for (int i = 0, j = 0; i < size; i++)
                {
                    if (arry1[i] != 32)
                    {
                        arry2[j] = (arry1[i]);
                        size2 += 1;
                        j++;
                    }
                }
                arry3 = new int[size2];
                arry4 = new int[size2];

                for (int i = 0; i < size2; i++)
                {
                    if (arry2[i] > 90)
                    {
                        arry3[i] = arry2[i] - 97;
                    }
                    else
                    {
                        arry3[i] = arry2[i] - 65;
                    }

                }

                arry4[0] = arry3[0] - key;
                arry4[0] = arry4[0] % 26;
                if (arry4[0] < 0)
                  arry4[0] = arry4[0] + 26;               

                for (int i = 0; i < size2 - 1; i++)
                {
                    arry4[i + 1] = arry3[i+1] - arry4[i];
                    arry4[i + 1] = arry4[i + 1] % 26;

                    if (arry4[i + 1] < 0)
                        arry4[i + 1] =  arry4[i + 1] + 26;
                    
                }

                for (int i = 0, j = 0; i < size ; i++)
                {
                    if (arry1[i] == 32)
                    {
                        arry2[i] = arry1[i];
                    }
                    else
                    {
                        arry2[i] = arry4[j];
                        j++;
                    }
                }


                for (int j = 0; j < size; j++)
                {
                    if (arry2[j] != 32)
                        arry2[j] = arry2[j] + 65;
                    arry1[j] = (Char)arry2[j];
                    txtPlainText1.Text += arry1[j];
                }

            }

        }

        private void btnDClear_Click(object sender, RoutedEventArgs e)
        {
            txtPlainText1.Text = "";
            txtChiperText1.Text = "";
            txtKey1.Text = "";
        }
    }
}
