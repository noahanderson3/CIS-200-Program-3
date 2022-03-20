// Program 3
// CIS 200-01
// Due: 4/3/2020
// Grading ID: T8702

//This is the form to select the Patron to be edited
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryItems
{
    public partial class PatronEdit : Form
    {
        private List<LibraryPatron> patronList; //List of patrons in the library
            // Preconditions: None
            // Postconditions: Initializes form, sets patronList to Patrons 
        public PatronEdit(List<LibraryPatron> Patrons)
        {
            InitializeComponent();

            patronList = Patrons;
        }
        public int patronIndex
        {
            // Preconditions: None
            // Postconditions: The index of form's selected patron combo box has been returned
            get
            {
                return slctPatronCmBox.SelectedIndex;
            }
        }
            // Preconditions: Items must be in slctPatronComBox
            // Postconditions: All patrons in patronList are in slctPatronCmBox 
        private void PatronEdit_Load(object sender, EventArgs e)
        {
            foreach(LibraryPatron patron in patronList)
            {
                slctPatronCmBox.Items.Add(patron.PatronName);
            }
        }
            // Preconditions: Edit is clicked 
            // Postconditions: If all fields pass validation, dialogresult is set to OK
        private void EditPatronButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }
            // Preconditions: Validating is not cancelled, so data is good
            // Postconditions: Error provider is cleared and focus shifts 
        private void PatronEdit_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(slctPatronCmBox, "");
        }
            // Preconditions: Focus is shifting from slctPatronCmBox
            // Postconditions: If selection is invalid, field is highlighted and error provider 
            // is shown
        private void PatronEdit_Validating(object sender, CancelEventArgs e)
        {
            if (slctPatronCmBox.SelectedIndex == -1) // Nothing selected
            {
                e.Cancel = true;
                errorProvider1.SetError(slctPatronCmBox, "Must select a Patron");
            }
        }
    }
}
