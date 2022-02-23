using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsCalculator.Models;
using WinFormsCalculator.Services;

namespace WinFormsCalculator.Views
{
    public sealed partial class CalculatorView : ViewBase
    {
        #region Private Fields
        private CalculatorViewModel _model;               
        #endregion


        Double Result_Value = 0;
        String Operator_Performed = " ";
        bool PerformedOp = false;

     
        #region Public Properties
        #endregion

        public CalculatorView(CalculatorViewModel model = null) 
        {
                   
 
            // Check if a ViewModel was passed to the ctor
            if (model != null)
            {
                //Todo: Todo: Add type checking here to ensure that types of model valid only for this View type are assigend, otherwise create a default model (ExampleViewModel).
                // Assign a local reference to the model.
                _model = model;
            }
            else
            {
                // Create a new instance of the ViewModel for this specific View, as one was not provided to the ctor
                _model = new CalculatorViewModel();
            }

            InitializeComponent();

            // Bind the controls for this View to their Model's properties.
            PerformBinding();
        }


        /// <summary>
        /// Sets up binding for the tbName and lblName controls used in this ExampleView.
        /// <para>You might want to also implement an interface that ensures all of your View types implement PerformBinding() to keep everything predictable.</para>
        /// </summary>
        public sealed override void PerformBinding()
        {
            //lblOtherFunText.DataBindings.Add("Text", _model, nameof(_model.OtherFunText), false, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void button15_Click(object sender, EventArgs e)
        {
            // numbers button and point
            if (textBox_Result.Text == "0" || PerformedOp)
                textBox_Result.Clear();

            PerformedOp = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text += button.Text;
            }

            else
                textBox_Result.Text += button.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Operator_click_Event(object sender, EventArgs e)
        {
            // +, -, *, / operators
            Button button = (Button)sender;

            if (Result_Value != 0)
            {
                button16.PerformClick();
                Operator_Performed = button.Text;
                label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                PerformedOp = true;
            }
            else
            {

                Operator_Performed = button.Text;
                Result_Value = Double.Parse(textBox_Result.Text);
                label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                PerformedOp = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //CLEAR ENTRY BUTTON
            textBox_Result.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //CLEAR BUTTON
            textBox_Result.Text = "0";
            Result_Value = 0;
            label_Show_Op.Text = " ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {


            double num2 = Double.Parse(textBox_Result.Text);

            switch (Operator_Performed)
            {
                case "+":
                    textBox_Result.Text = (Result_Value + Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "-":
                    textBox_Result.Text = (Result_Value - Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "*":
                    textBox_Result.Text = (Result_Value * Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "/":
                    textBox_Result.Text = (Result_Value / Double.Parse(textBox_Result.Text)).ToString();
                    break;

                default:
                    break;

            }
                _model.CalcService.AddNewCalc(new Calc() { Num1 = Result_Value, Oper = Convert.ToChar(Operator_Performed), Num2 = num2, Result = Double.Parse(textBox_Result.Text) });
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            Result_Value = Double.Parse(textBox_Result.Text);
            label_Show_Op.Text = " ";
 
        }

    }
}