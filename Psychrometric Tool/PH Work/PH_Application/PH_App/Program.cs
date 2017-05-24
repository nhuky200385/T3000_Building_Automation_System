using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PH_App;

namespace PH_App
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

      //Show the language select dialog
      MultiLang.SelectLanguage frmLang = new MultiLang.SelectLanguage() ;
      frmLang.LoadSettingsAndShow() ;
      frmLang.Dispose() ;
      frmLang = null ;

            InitialDatabaseSetupController idb;//= new InitialDatabaseSetupController();

            var fm = new Form_Main_PH_Application();
           //fm.objectInitialization();
            idb = fm.idsc;

            idb.InitialProcessingForDatabaseAndApp();
            //Application.Run(new Form1());
           // BuildingOperation b = fm.bo;//new BuildingOperation();

            Application.Run(fm);// new Form_Main_PH_Application()
        }
    }
}