// Program 3
// CIS 200-01
// Due: 4/3/2020
// Grading ID: T8702

//This is a form that allows a Book item to be selected to be edited 
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
    
    public partial class BookEdit : Form
    {
        private List<LibraryItem> _items; //List that holds all of the LibraryItems
        private List<int> bookIndicies = new List<int>();   //List that holds the items that are books indicies
            // Preconditions: None
            // Postconditions: Form is initialiized and _items is set to the library's items list
        public BookEdit(List<LibraryItem> items)
        {
            InitializeComponent();

            _items = items;
        }
        public int bookIndex
        {
            // Preconditions: None
            // Postconditions: The index of form's selected book combo box has been returned
            get
            {
                if(slctBookComBox.SelectedIndex != -1)
                {
                    return bookIndicies[slctBookComBox.SelectedIndex];
                }
                return -1;
            }
        }

            // Preconditions: Button is clicked, fields pass validation
            // Postconditions: Dialog result is set to OK if fields are validated
        private void Button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }
            // Preconditions: Focus is shifting from slctBookComBox
            // Postconditions: If selection is invalid, field is highlighted and error provider 
            // is shown
        private void BookEdit_Validating(object sender, CancelEventArgs e)
        {
            if (slctBookComBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(slctBookComBox, "Must select a Patron");
            }
        }
            // Preconditions: Validating is not cancelled, so data is good
            // Postconditions: Error provider is cleared and focus shifts
        private void BookEdit_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(slctBookComBox, "");
        }
            //Preconditions: Items must be in _items list
            //Postconditions: If item is a LibraryBook, it will  be shown in the slctBookComBox
        private void BookEdit_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < _items.Count(); i++)
            {
                if(_items[i] is LibraryBook)
                {
                    slctBookComBox.Items.Add(_items[i].Title);
                    bookIndicies.Add(i);
                }
            }
        }
    }
}
