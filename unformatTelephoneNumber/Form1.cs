using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unformatTelephoneNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //The isValidFormat method accepts a string argument and detrmines whether it is
        //properly formatted as a US telephone number in the following manner:
        //(XXX)XXX-XXXX
        //If the argument is properly formatted, the method returns true, otherwise false
        private bool IsValidFormat(string str) {
            const int VALID_LENGTH = 13;    //Length of a valid String 
            bool valid;                     //Flag to indicate validity

            //Determine whether str is properly formatted 
            if (str.Length == VALID_LENGTH && str[0] == '(' && str[4] == ')' && str[8] == '-')
            {
                //make the boolean value true 
                valid = true;
            }
            else {
                valid = false;
            }
            //return the boolean 
            return valid;
        }

        //THe unformat method accepts a string, by refernce, assumed
        //to contain a telephone number formatted in the same manner above
        //The method unformats the string by removing the parenthesis and the hyphen
        private void Unformat(ref string str) {
            //Delete all of the things that make it formatted the parenthesis and the hyphen
            str = str.Remove(0, 1);
            str = str.Remove(3, 1);
            str = str.Remove(6, 1);
        }

        private void unformatButton_Click(object sender, EventArgs e)
        {
            //get a trimmed copy of the users input.
            string input = numberTextBox.Text.Trim();

            //if the input is properly formatted unformat it and display it
            if (IsValidFormat(input))
            {
                Unformat(ref input);
                MessageBox.Show(input);
            }
            else {
                //Display an error message 
                MessageBox.Show("Invalid Input");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close the form 
            this.Close();
        }
    }
}
