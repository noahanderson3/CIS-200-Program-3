// Program 3
// CIS 200-01
// Due: 4/3/2020
// Grading ID: T8702

// File: Prog2Form.cs
// This class creates the main GUI for Program 3. It provides a
// File menu with About and Exit items, an Insert menu with Patron and
// Book items, an Item menu with Check Out and Return items, and a
// Report menu with Patron List, Item List, and Checked Out Items items.
// Allows saving and opening a Library file and editing to Patron and
// Book items

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LibraryItems
{
    
    public partial class Prog2Form : Form
    {
        private Library outputLib; //Library item that is used currently in the form

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test items and patrons
        //                are added to the library
        public Prog2Form()
        {
            InitializeComponent();

            outputLib = new Library();

        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // NewLine shortcut

            MessageBox.Show($"Program 2{NL}By: Andrew L. Wright{NL}CIS 200-01{NL}Spring 2020",
                "About Program 2");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Report, Patron List menu item activated
        // Postcondition: The list of patrons is displayed in the reportTxt
        //                text box
        private void patronListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<LibraryPatron> patrons;     // List of patrons
            string NL = Environment.NewLine; // NewLine shortcut

            patrons = outputLib.GetPatronsList();

            reportTxt.Text = $"Patron List - {patrons.Count} patrons{NL}{NL}";

            foreach (LibraryPatron p in patrons)
                reportTxt.AppendText($"{p}{NL}{NL}");

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Report, Item List menu item activated
        // Postcondition: The list of items is displayed in the reportTxt
        //                text box
        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<LibraryItem> items;         // List of library items
            string NL = Environment.NewLine; // NewLine shortcut

            items = outputLib.GetItemsList();

            reportTxt.Text = $"Item List - {items.Count} items{NL}{NL}";

            foreach (LibraryItem item in items)
                reportTxt.AppendText($"{item}{NL}{NL}");

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Report, Checked Out Items menu item activated
        // Postcondition: The list of checked out items is displayed in the
        //                reportTxt text box
        private void checkedOutItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<LibraryItem> items;         // List of library items
            string NL = Environment.NewLine; // NewLine shortcut

            items = outputLib.GetItemsList();

            // LINQ: selects checked out items
            var checkedOutItems =
                from item in items
                where item.IsCheckedOut()
                select item;

            reportTxt.Text = $"Checked Out Items - {checkedOutItems.Count()} items{NL}{NL}";

            foreach (LibraryItem item in checkedOutItems)
                reportTxt.AppendText($"{item}{NL}{NL}");

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Insert, Patron menu item activated
        // Postcondition: The Patron dialog box is displayed. If data entered
        //                are OK, a LibraryPatron is created and added to the library
        private void patronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatronForm patronForm = new PatronForm(); // The patron dialog box form

            DialogResult result = patronForm.ShowDialog(); // Show form as dialog and store result

            if (result == DialogResult.OK) // Only add if OK
            {
                // Use form's properties to get patron info to send to library
                outputLib.AddPatron(patronForm.PatronName, patronForm.PatronID);
            }

            patronForm.Dispose(); // Good .NET practice - will get garbage collected anyway
        }

        // Precondition:  Insert, Book menu item activated
        // Postcondition: The Book dialog box is displayed. If data entered
        //                are OK, a LibraryBook is created and added to the library
        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(); // The book dialog box form

            DialogResult result = bookForm.ShowDialog(); // Show form as dialog and store result

            if (result == DialogResult.OK) // Only add if OK
            {
                try
                {
                    // Use form's properties to get book info to send to library
                    outputLib.AddLibraryBook(bookForm.ItemTitle, bookForm.ItemPublisher, int.Parse(bookForm.ItemCopyrightYear),
                        int.Parse(bookForm.ItemLoanPeriod), bookForm.ItemCallNumber, bookForm.BookAuthor);
                }

                catch (FormatException) // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Book Validation!", "Validation Error");
                }
            }

            bookForm.Dispose(); // Good .NET practice - will get garbage collected anyway
        }

        // Precondition:  Item, Check Out menu item activated
        // Postcondition: The Checkout dialog box is displayed. If data entered
        //                are OK, an item is checked out from the library by a patron
        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<LibraryItem> items;     // List of library items
            List<LibraryPatron> patrons; // List of patrons

            items = outputLib.GetItemsList();
            patrons = outputLib.GetPatronsList();

            if (((items.Count - outputLib.GetCheckedOutCount()) == 0) || (patrons.Count() == 0)) // Must have items and patrons
                MessageBox.Show("Must have items and patrons to check out!", "Check Out Error");
            else
            {
                CheckoutForm checkoutForm = new CheckoutForm(items, patrons); // The check out dialog box form

                DialogResult result = checkoutForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only add if OK
                {
                    outputLib.CheckOut(checkoutForm.ItemIndex, checkoutForm.PatronIndex);
                }

                checkoutForm.Dispose(); // Good .NET practice - will get garbage collected anyway
            }
        }

        // Precondition:  Item, Return menu item activated
        // Postcondition: The Return dialog box is displayed. If data entered
        //                are OK, an item is returned to the library
        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<LibraryItem> items;     // List of library items

            items = outputLib.GetItemsList();

            if ((outputLib.GetCheckedOutCount() == 0)) // Must have items to return
                MessageBox.Show("Must have items to return!", "Return Error");
            else
            {
                ReturnForm returnForm = new ReturnForm(items); // The return dialog box form

                DialogResult result = returnForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only add if OK
                {
                    outputLib.ReturnToShelf(returnForm.ItemIndex);
                }

                returnForm.Dispose(); // Good .NET practice - will get garbage collected anyway
            }
        }

        // Precondition: File, Save Library menu item activated
        // Postcondition: Save dialog is displayed and item is able to be saved
        private void SaveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter(); //This allows the item to be formatted into Binary
            FileStream output = null;                          //This allows the file to be created and able to write to a file
            DialogResult result;                               //Dialog Result of the SaveDialog
            string fileName;                                   //Name of the file that the user inputs for validation

            using(SaveFileDialog fileChooser = new SaveFileDialog()) //Creates the SaveFileDialog and makes it disposible 
            {
                fileChooser.CheckFileExists = false; //Makes sure file name doesn't exist already

                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }
            if(result == DialogResult.OK)
            {
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        output = new FileStream(fileName, FileMode.Create, FileAccess.Write); //Creates file stream for the File to be created

                        formatter.Serialize(output, outputLib);                               //Serializes the file 
                    }
                    //Exception handlers
                    catch(IOException)
                    {
                        MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SerializationException)
                    {
                        MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (output != null)
                            output.Close(); //Closes the file stream
                    }
                }
            }
        }
        // Precondition: File, Open Library menu item activated
        // Postcondition: Open dialog is displayed and item is able to be opened
        private void OpenLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();      //This allows the item to be formatted into Binary
            FileStream input = null;                                //This allows the file to be created and able to write to a file
            DialogResult result;                                    //Dialog Result of the OpenDialog
            string fileName;                                        //Name of the file that the user inputs for validation
            Library tempLib;                                        //Temporary Library used to hold Deserialized file 

            using (OpenFileDialog fileChooser = new OpenFileDialog()) //Creates the OpenFileDialog and makes it disposible 
            {
                fileChooser.CheckFileExists = true;                   //Makes sure the file trying to be opened exists

                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            if(result == DialogResult.OK)
            {
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        input = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite); //Creates filestream so the file can be opened and edited/read

                        tempLib = (Library)formatter.Deserialize(input); //Deserializes the file to be read

                        outputLib = tempLib;
                    }
                    //Exception Handlers
                    catch(IOException)
                    {
                        MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SerializationException)
                    {
                        MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (input != null)
                            input.Close(); //Closes input
                    }
                }
            }
        }
        // Precondition: Edit, Patron menu item activated
        // Postcondition: Select Patron is displayed and then Patron form is opened to edit the Patron object
        private void PatronToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<LibraryPatron> Patrons;                            //List of Patrons in the Library
            int changeIndex;                                        //Index of the Patron that is selected to be changed

            Patrons = outputLib._patrons;                           //Sets Patrons to libraries _patrons list

            if(Patrons.Count() == 0)                                //Checks that there are in fact Patrons
            {
                MessageBox.Show("Please add Patrons to edit.");
            }
            else
            {
                PatronEdit patronEdit = new PatronEdit(Patrons);    //New PatronEdit form to select the Patron
                DialogResult result = patronEdit.ShowDialog();

                if(result == DialogResult.OK)
                {
                    changeIndex = patronEdit.patronIndex;           //changeIndex is now selected Patron

                    if(changeIndex >= 0)
                    {
                        LibraryPatron editPatron = Patrons[changeIndex];

                        PatronForm patronForm = new PatronForm();   //Creates new Patron form

                        patronForm.PatronName = editPatron.PatronName;//Sets the Patron object Name to be edited in new Patron form
                        patronForm.PatronID = editPatron.PatronID;    //Sets the Patron object ID to be edited in new Patron form

                        DialogResult editDialogResult = patronForm.ShowDialog();

                        if(editDialogResult == DialogResult.OK)
                        {
                            editPatron.PatronName = patronForm.PatronName;  //Actually makes the changes to Edited Patron's Name
                            editPatron.PatronID = patronForm.PatronID;      //Actually makes the changes to Edited Patron's Name
                        }
                        patronForm.Dispose();
                    }
                }
                patronEdit.Dispose();
            }
        }
        // Precondition: Edit, Book menu item activated
        // Postcondition: Select Book is displayed and then Book form is opened to edit the LibraryBook object
        private void BookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int changeIndex;                                       //Index of the Patron that is selected to be changed
            int bookCount = 0;                                     //Count of Book Items 
            List<LibraryItem> items = new List<LibraryItem>();     // List of library items


            foreach(LibraryBook book in outputLib._items)
            {
                items.Add(book);                                    //Adds LibraryBook items in the Library's _item list
                bookCount++;                                        //Increments the count of Books
            }

            if (bookCount == 0)
            {
                MessageBox.Show("Please add Books to edit.");
            }
            else
            {
                BookEdit bookEdit = new BookEdit(items);            //New select Book form loading in with the list of Book items
                DialogResult result = bookEdit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    changeIndex = bookEdit.bookIndex;               //Change index set to book index

                    if (changeIndex >= 0)
                    {
                        LibraryBook editBook = outputLib._items[changeIndex] as LibraryBook;        //Sets editBook 

                        BookForm bookForm = new BookForm();         //New BookForm 

                        //Sets editBook properties to bookForms to be edited
                        bookForm.ItemTitle = editBook.Title;       
                        bookForm.ItemPublisher = editBook.Publisher;
                        bookForm.ItemLoanPeriod = editBook.LoanPeriod.ToString();
                        bookForm.ItemCallNumber = editBook.CallNumber;
                        bookForm.ItemCopyrightYear = editBook.CopyrightYear.ToString();
                        bookForm.BookAuthor = editBook.Author;

                        DialogResult editDialogResult = bookForm.ShowDialog();

                        if (editDialogResult == DialogResult.OK)
                        {
                            //Sets now changed bookFields properties to editBook to make changes
                            editBook.Title = bookForm.ItemTitle;
                            editBook.Publisher = bookForm.ItemPublisher;
                            editBook.LoanPeriod = Int32.Parse(bookForm.ItemLoanPeriod);
                            editBook.CallNumber = bookForm.ItemCallNumber;
                            editBook.CopyrightYear = Int32.Parse(bookForm.ItemCopyrightYear);
                            editBook.Author = bookForm.BookAuthor;
                        }
                        bookForm.Dispose();
                    }
                }
                bookEdit.Dispose();
            }
        }
    }
}
