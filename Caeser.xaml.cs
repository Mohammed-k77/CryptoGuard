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
    /// Interaction logic for Caeser.xaml
    /// </summary>
    public partial class Caeser : UserControl
    {
        int key;
        char[] arry1;
        int[] arry2;
        int[] arry3;
        public Caeser()
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
                arry3 = new int[size];
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
                for (int i = 0; i < size; i++)
                {
                    if (arry1[i] == 32)
                        arry3[i] = arry1[i];

                    if (arry1[i] > 90 && arry1[i] < 123)
                    {
                        arry2[i] = arry1[i] - 97;
                        arry2[i] = arry2[i] + key;
                        arry3[i] = arry2[i] % 26; 
                        arry3[i] = arry3[i] + 65;
                    }
                    else if (arry1[i] > 64 && arry1[i] < 91)
                        {
                        arry2[i] = arry1[i] - 65;
                        arry2[i] = arry2[i] + key;
                        arry3[i] = arry2[i] % 26;
                        arry3[i] = arry3[i] + 65;
                    }
                }

                for (int j = 0; j < size; j++)
                {
                    arry1[j] = (Char)arry3[j];
                    txtChiperText.Text += arry1[j];
                }

            }
        }

        private void btnEClear_Click(object sender, RoutedEventArgs e)
        {
            txtChiperText.Text = "";
            txtKey.Text = "";
            txtPlainText.Text = "";
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
                {
                    txtPlainText1.Text = "";
                    string PlainTxet = txtChiperText1.Text;
                    int size = PlainTxet.Length;
                    arry1 = new char[size];
                    arry2 = new int[size];
                    arry3 = new int[size];
                    for (int i = 0; i < size; i++)
                        arry1[i] = PlainTxet[i];
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
                    for (int i = 0; i < size; i++)
                    {
                        if (arry1[i] == 32)
                            arry3[i] = arry1[i];

                        if (arry1[i] > 90 && arry1[i] < 123)
                            {
                                arry2[i] = arry1[i] - 97;
                                arry2[i] = arry2[i] - key;
                                arry3[i] = arry2[i] % 26;

                                if (arry3[i] < 0)
                                {
                                    arry3[i] = arry3[i] + 26;
                                    arry3[i] = arry3[i] + 65;
                                }
                                else
                                {
                                    arry3[i] = arry3[i] + 65;
                                }
                            }
                        else if (arry1[i] > 64 && arry1[i] < 91) 
                        {
                            arry2[i] = arry1[i] - 65;
                            arry2[i] = arry2[i] - key;
                            arry3[i] = arry2[i] % 26;

                            if (arry3[i] < 0)
                            {
                                arry3[i] = arry3[i] + 26;
                                arry3[i] = arry3[i] + 65;
                            }

                            else
                            {
                                arry3[i] = arry3[i] + 65;
                            }


                        }
                    }

                    for (int j = 0; j < size; j++)
                    {
                        arry1[j] = (Char)arry3[j];
                        txtPlainText1.Text += arry1[j];
                    }
                }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnDClear_Click(object sender, RoutedEventArgs e)
        {
            txtChiperText1.Text = "";
            txtPlainText1.Text = "";
            txtKey1.Text = "";
        }
    }
}
