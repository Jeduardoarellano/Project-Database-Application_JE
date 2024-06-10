using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEase
{
    public static class UIUtilities
    {
        public static void ClearControls(this Control.ControlCollection controlsCollection, int defaultSelectedIndex = 0)
        {
            foreach (Control control in controlsCollection)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Text = string.Empty;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                    case ComboBox combo:
                        combo.SelectedIndex = 0;
                        break;
                    case GroupBox groupBox:
                        ClearControls(groupBox.Controls);
                        break;
                }
            }
        }

        public static void ClearChildControls(this Control control, int defaultSelectedIndex = 0)
        {
            ClearControls(control.Controls, defaultSelectedIndex);
        }

        public static void DisplayParentStatusStripMessage(this Form form, string message)
        {
            DisplayParentStatusStripMessage(form, message, Color.Black);
        }

        public static void DisplayParentStatusStripMessage(this Form form, string message, Color color)
        {
            MDIParent1? parentMdi = form.MdiParent as MDIParent1;
            if (parentMdi != null)
            {
                parentMdi.DisplayStatusMessage(message, color);
            }
        }
    }
}
