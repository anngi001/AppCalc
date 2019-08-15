using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCalc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage : ContentPage
    { 
        int currentState = 1;
        string myoperator;
        double firstNumber, secondNumber;

        public CalculatorPage()
        {

            InitializeComponent();
            OnClear(this, null);

        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;


            string pressed = button.Text;
           
            if (this.lblNumero.Text == "0" || currentState < 0)
            {
                this.lblNumero.Text = "";

                if (currentState < 0)
                    currentState *= -1;
            }

            this.lblNumero.Text += pressed;
            double number;
            if (double.TryParse(this.lblNumero.Text, out number))
            {
                this.lblNumero.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }
        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.lblNumero.Text = "0";
        }
        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            myoperator = pressed;
        }
        void OnPercentage(object sender, EventArgs e) 
        {

            if ((currentState == -1) || (currentState == 1))
            {
                var result = firstNumber / 100;
                this.lblNumero.Text = result.ToString();
                firstNumber = result;
                currentState = -1;

            }


        }
        void OnCalculate(object sender, EventArgs e) 
        {
            if (currentState == 2)
            {
                var result = Operator.Calculate(firstNumber, secondNumber, myoperator);

                this.lblNumero.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }
        
        





        private void Button1_Clicked(object sender, EventArgs e)
        {
            lblNumero.Text = "1";
        }
    }
}