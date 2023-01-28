using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class PanelPrzyciskow : UserControl
    {
        
        private string wprowadzoneUzytkownika = "";
        public PanelPrzyciskow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            
            wprowadzoneUzytkownika += (sender as Button).Text;

            textBoxWyswietlacz.Text = wprowadzoneUzytkownika;

        }
        private void button_Wynik_Click(object sender, EventArgs e)
        {


            if (wprowadzoneUzytkownika.Contains("++") || wprowadzoneUzytkownika.Contains("--") || wprowadzoneUzytkownika.Contains("..") || wprowadzoneUzytkownika.Contains("**") || wprowadzoneUzytkownika.Contains("//"))
            {
                textBoxWyswietlacz.Text = "Błąd (podwójny znak)";
                wprowadzoneUzytkownika = "";

            }
            else
            {
                try
                {

                    textBoxWyswietlacz.Text = new DataTable().Compute(wprowadzoneUzytkownika, null).ToString();
                    wprowadzoneUzytkownika = textBoxWyswietlacz.Text;


                }
                catch (Exception)
                {
                    textBoxWyswietlacz.Text = "Błąd (Wprowadzono nie prawidłową liczbę)";
                    wprowadzoneUzytkownika = "";
                }



            }




        }
        private void button_Wyczysc_Click(object sender, EventArgs e)
        {
            textBoxWyswietlacz.Text = "0";
            wprowadzoneUzytkownika = "";
        }
        private void button_Cofnij_Click(object sender, EventArgs e)
        {
            if (wprowadzoneUzytkownika.Length > 0)
            {
                wprowadzoneUzytkownika = wprowadzoneUzytkownika.Remove(wprowadzoneUzytkownika.Length - 1, 1);
            }
            textBoxWyswietlacz.Text = wprowadzoneUzytkownika;
        }

    }
}
