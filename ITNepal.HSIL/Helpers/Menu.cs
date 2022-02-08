using ITNepal.MainLibrary.SAPB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace ITNepal.HSIL.Helpers
{
    public class Menu
    {
        public static void addMenu()
        {
            //B1Helper.AddSubMenu(MenuID_UD.MODULE, "Gate Pass master", "Gate Pass", -1, string.Concat(System.Windows.Forms.Application.StartupPath, @"\Images\Icon.png"));
            //B1Helper.addMenuItem("Gate Pass master", "Gate Pass", "Gate Pass");
        }
        public static void RemoveMenu()
        {
            //B1Helper.RemoveMenuItem("3072", "Auto Item Master Code Setup", "Auto Item Master Code Setup");
        }
        public void AddMenuItems()
        {
            try
            {
                B1Helper.AddSubMenu(MenuID_UD.MODULE, "Gate Pass master", "Gate Pass", -1, string.Concat(System.Windows.Forms.Application.StartupPath, @"\Images\Icon.png"));
                B1Helper.addMenuItem("Gate Pass master", "Gate Pass", "Gate Pass");
                B1Helper.addMenuItem("2048", "Packaging List Screen", "Packaging List Screen");

            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
