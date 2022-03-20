// Program 3
// CIS 200-01
// Due: 4/3/2020
// Grading ID: T8702

//Main Program.cs file 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibraryItems
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Prog2Form());
        }
    }
}
