using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HL.Controls.HLControls
{
    /// <summary>
    /// A text box for entering numbers 
    /// </summary>
    public class NumeralTextbox : TextBox
    {
        private const int WM_PASTE = 0x302;

        private bool IsNumericValue(string value, out double returnValue)
        {
            return Double.TryParse(value, out returnValue);           
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                double numericValue = 0;

                if (IsNumericValue(value, out numericValue))
                {
                    base.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets the numeric value of the textbox. If no number is entered a value of 0.0 is returned
        /// </summary>
        public double Value
        {
            get
            {
                double returnValue = 0.0;

                if (IsNumericValue(Text, out returnValue))
                {
                    return returnValue;
                }
                else
                {
                    return 0.0;
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            double returnValue = 0;

            if (!IsNumericValue(e.KeyChar.ToString(), out returnValue) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;                
            }

            base.OnKeyPress(e);
        }

        protected override void WndProc(ref Message m)
        {
            // Handle copy-paste
            if (m.Msg == WM_PASTE)
            {
                string pastedValue = Clipboard.GetText();

                // Check if the data on the clipboard is a text value
                if (!String.IsNullOrEmpty(pastedValue))
                {
                    double returnValue;

                    if (IsNumericValue(pastedValue, out returnValue))
                    {
                        Text = pastedValue;
                    }
                    
                    return;
                }
            }

            base.WndProc(ref m);
        }
    }
}
