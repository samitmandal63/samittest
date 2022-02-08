using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using ITNepal.MainLibrary.Utilities;
using GlobalVariable;
using SAPbobsCOM;

namespace ITNepal.HSIL.Helpers
{
    public class AddonInfoInfo
    {
        #region Members
        public int Index { get; set; }
        public bool isHana { get; set; }
        private static int RetCode = 0;
        private static string ErrMsg = null;
        #endregion

        #region Constructor
        public AddonInfoInfo()
        {
        }
        #endregion

        #region UDODEAFAUTFORMSFORLC
        public static void CreateUDOForms()
        {
            try
            {
                string[] ChildTable = new string[0];
                string[] FindColumn = new string[0];
                string[] FormColumn = new string[0];

                #region G/L Determination

                B1Helper.AddTable("ITN_OGDL", "G/L Determination", BoUTBTableType.bott_Document);
                B1Helper.AddField("ACCNAM", "Account Name", "ITN_OGDL", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tYES, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("GLLDGR", "G/L Ledger", "ITN_OGDL", BoFieldTypes.db_Alpha, 20, BoYesNoEnum.tYES, BoFldSubTypes.st_None, true, "");
                // Array.Resize(ref FindColumn, 1);
                Array.Resize(ref FormColumn, 3);
                FormColumn[0] = "DocEntry";
                FormColumn[1] = "U_ACCNAM";
                FormColumn[2] = "U_GLLDGR";
                B1Helper.CreateUdo("OGDL", "G/L Determination", "ITN_OGDL", "D", "Y", FormColumn, null);

                #endregion

                #region Terms of Payment
                B1Helper.AddTable("ITN_OLPT", "Terms of Payment", BoUTBTableType.bott_MasterData);
                B1Helper.AddField("PAYTERMS", "Payment Terms", "ITN_OLPT", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tYES, BoFldSubTypes.st_None, true, "");
                Array.Resize(ref FormColumn, 2);
                FormColumn[0] = "Code";
                FormColumn[1] = "U_PAYTERMS";
                B1Helper.CreateUdo("OLPT", "Terms Of Payment", "ITN_OLPT", "M", "Y", FormColumn, null);
                #endregion

                #region Letter Of Credit Type
                B1Helper.AddTable("ITN_OSLT", "Letter Of Credit Type", BoUTBTableType.bott_MasterData);
                B1Helper.AddField("LOCTYPE", "Letter Of Credit Type", "ITN_OSLT", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tYES, BoFldSubTypes.st_None, true, "");
                Array.Resize(ref FormColumn, 2);
                FormColumn[0] = "Code";
                FormColumn[1] = "U_LOCTYPE";
                B1Helper.CreateUdo("OSLT", "Letter Of Credit Type", "ITN_OSLT", "M", "Y", FormColumn, null);
                #endregion

                #region Customer Location
                B1Helper.AddTable("ITN_OSCL", "Customer Location", BoUTBTableType.bott_MasterData);
                B1Helper.AddField("CUSTLOC", "Customer Location", "ITN_OSCL", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tYES, BoFldSubTypes.st_None, true, "");
                Array.Resize(ref FormColumn, 2);
                FormColumn[0] = "Code";
                FormColumn[1] = "U_CUSTLOC";
                B1Helper.CreateUdo("OSCL", "Customer Location", "ITN_OSCL", "M", "Y", FormColumn, null);
                #endregion

                #region Custom clearance
                B1Helper.AddTable("ITNCUSTOM", "Customs", BoUTBTableType.bott_Document);
                //FindColumns = new List<string> { "DISTCODE", "Code", "Name" };
                B1Helper.AddField("CODE", "CUSTOM CODE", "ITNCUSTOM", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("NAME", "CUSTOM NAME", "ITNCUSTOM", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                Array.Resize(ref FormColumn, 3);
                FormColumn[0] = "DocEntry";
                FormColumn[1] = "U_CODE";
                FormColumn[2] = "U_NAME";
                CreateUDO("ITNCUSTOM", "Customs", "ITNCUSTOM", FormColumn, BoUDOObjType.boud_Document, "F");
                #endregion
            }
            catch
            {
            }

        }

        #endregion

        #region AutoUDO
        public static void AutoUDO(string code, string parm)
        {
            try
            {
                string[] ChildTable = new string[0];
                string[] FindColumn = new string[0];
                string[] FormColumn = new string[0];
                B1Helper.AddTable("ITN_" + parm, parm, BoUTBTableType.bott_MasterData);
                Array.Resize(ref FindColumn, 1);
                Array.Resize(ref FormColumn, 2);

                FormColumn[0] = "Code";
                FormColumn[1] = "Name";
                FindColumn[0] = "DocEntry";
                B1Helper.CreateUdo("UDO" + code, parm, "ITN_" + parm, "M", "Y", FormColumn, null);
            }
            catch
            {
            }
        }

        #endregion

        #region AutoCreateUDF
        public static void AutoCreateUDF(string parm)
        {
            Application.SBO_Application.StatusBar.SetText("Database structure is modifying...", SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            try
            {
                ITNepal.MainLibrary.SAPB1.B1Helper.AddField(parm, parm, "OITM", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
                //  ITNepal.MainLibrary.SAPB1.B1Helper.AddField(parm, parm, "OITM", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, false, "");
            }
            catch
            {
            }
        }

        #endregion
        
        #region UDOFORITEMMASTER
        public static void UDOForItemMaster()
        {
            try
            {
                string[] ChildTable = new string[0];
                string[] FindColumn = new string[0];
                string[] FormColumn = new string[0];

                Application.SBO_Application.StatusBar.SetText("Database structure is modifying...", SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                #region AutoItemMasterCodeSetup
                //B1Helper.AddTable("ITN_OICS", "Auto Item Master Code Setup", BoUTBTableType.bott_Document);
                //B1Helper.AddField("ITCS", "Item Master Code Status", "ITN_OICS", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                //B1Helper.AddField("ITDS", "Item Master Descrition Setup", "ITN_OICS", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                //B1Helper.AddField("ITCL", "Item Code Length", "ITN_OICS", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
                //B1Helper.AddField("ITDL", "Item Code Length", "ITN_OICS", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
                //B1Helper.AddField("ITPL", "Parameter Length", "ITN_OICS", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

                ////child
                //B1Helper.AddTable("ITN_ICS1", "Auto Item Master Code Setup CH", BoUTBTableType.bott_DocumentLines);
                //B1Helper.AddField("Code", "Code", "ITN_ICS1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
                //B1Helper.AddField("Parameter", "Parameter Name", "ITN_ICS1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
                //Array.Resize(ref FormColumn, 0);
                //Array.Resize(ref ChildTable, 1);
                //ChildTable[0] = "ITN_ICS1";
                //B1Helper.CreateUdo("OICS", "Auto Item Master Code Setup", "ITN_OICS", "D", "N", FormColumn, ChildTable);
                #endregion

                #region Item Code Logic Setup
                //B1Helper.AddTable("ITN_OILC", "Item Code Logic Setup", BoUTBTableType.bott_Document);
                //B1Helper.AddField("ITMSPTR", "Seperator", "ITN_OILC", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                //B1Helper.AddField("DESCSPTR", "Descrition Seperator", "ITN_OILC", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                //B1Helper.AddField("ITMCOD", "Item Code", "ITN_OILC", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                //B1Helper.AddField("DESCCOD", "Item Code", "ITN_OILC", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                //B1Helper.AddField("ITMCODLN", "Item Code Length", "ITN_OILC", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
                //B1Helper.AddField("DESCLEN", "Item Code Length", "ITN_OILC", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);

                ////Child
                //B1Helper.AddTable("ITN_ILC1", "Item Code Logic Setup CH", BoUTBTableType.bott_DocumentLines);
                //B1Helper.AddField("Code", "Code", "ITN_ILC1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
                //B1Helper.AddField("PARM", "Parameter Name", "ITN_ILC1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
                //B1Helper.AddField("DGTS", "No of Digits", "ITN_ILC1", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
                ////B1Helper.AddField("DESCDGTS", "No of Digits(Desc)", "ITN_ILC1", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);

                ////child
                //B1Helper.AddTable("ITN_ILC2", "Item Code Logic Setup CH", BoUTBTableType.bott_DocumentLines);
                //B1Helper.AddField("Code", "Code", "ITN_ILC2", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
                //B1Helper.AddField("PARM", "Parameter Name", "ITN_ILC2", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
                //B1Helper.AddField("DESCDGTS", "No of Digits", "ITN_ILC2", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true);
                //Array.Resize(ref FormColumn, 0);
                //Array.Resize(ref ChildTable, 2);
                //ChildTable[0] = "ITN_ILC1";
                //ChildTable[1] = "ITN_ILC2";
                //B1Helper.CreateUdo("OILC", "Item Code Logic Setup", "ITN_OILC", "D", "N", FormColumn, ChildTable);
                #endregion
            }
            catch
            {
            }
        }
        #endregion

        #region Methods
        public static bool InstallUDOs()
        {
            try
            {
                bool UDOAdded = true;

                string[] ChildTable = new string[0];
                string[] FindColumn = new string[0];
                string[] FormColumn = new string[0];
                //B1Helper.AddTable("ITN_OGDL", "G/L Determination", BoUTBTableType.bott_Document);

                #region System Tables Fields

                //B1Helper.DiCompany.StartTransaction();

                //B1Helper.AddField("GTEQNTY", "GateQuantity", "OPOR", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");



                #region GatePass
                //header table
                B1Helper.AddTable("ITN_GATEPS", "GATE PASS", BoUTBTableType.bott_Document);
                //header fields
                B1Helper.AddField("MTYPE", "Movement Type", "ITN_GATEPS", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("BASEDOCNUM", "Base Document Number", "ITN_GATEPS", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                //B1Helper.AddField("BASEDOCNUM", "Base Document Numver", "ITN_GATEPS", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
                B1Helper.AddField("VNUM", "Vehicle Numver", "ITN_GATEPS", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("TRNSNAME", "Transporter Name", "ITN_GATEPS", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("DRVNAME", "Driver Name", "ITN_GATEPS", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("DRVNUM", "Driver Number", "ITN_GATEPS", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
                B1Helper.AddField("FROM", "FROM", "ITN_GATEPS", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("TO", "TO", "ITN_GATEPS", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("DATE", "DOCUMENT DATE", "ITN_GATEPS", BoFieldTypes.db_Date, BoYesNoEnum.tNO, true);
                B1Helper.AddField("TOTLWGHT", "Total Weight", "ITN_GATEPS", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

                //Child table
                B1Helper.AddTable("ITN_ATEPS1", "Gate Pass CH1", BoUTBTableType.bott_DocumentLines);
                //Child fields
                B1Helper.AddField("WEGHT", "Weight", "ITN_ATEPS1", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, SAPbobsCOM.BoFldSubTypes.st_None, true);
                B1Helper.AddField("TIME", "TTIME", "ITN_ATEPS1", BoFieldTypes.db_Date, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_Time, true, "");
                B1Helper.AddField("REMARKS", "Remarks", "ITN_ATEPS1", BoFieldTypes.db_Alpha, 30, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

                Array.Resize(ref FormColumn, 0);
                Array.Resize(ref ChildTable, 1);
                ChildTable[0] = "ITN_ATEPS1";
                B1Helper.CreateUdo("GATEPS", "Gate Pass", "ITN_GATEPS", "D", "", FormColumn, ChildTable);
                #endregion


                #region Packaging List Screen
                //header table
                B1Helper.AddTable("NEO_OPLS", "Packaging List Screen", BoUTBTableType.bott_Document);
                //header fields

                B1Helper.AddField("DELNUM", "Delivery Number", "NEO_OPLS", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("CARDCODE", "Customer Code", "NEO_OPLS", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("CARDNAME", "Customer Name", "NEO_OPLS", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("TOTLWGHT", "Total Weight", "NEO_OPLS", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

                //Child table
                B1Helper.AddTable("NEO_PLS1", "Packaging List Screen CH1", BoUTBTableType.bott_DocumentLines);
                //Child fields
                B1Helper.AddField("IWEGHT", "Item Weight", "NEO_PLS1", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true,"");
                B1Helper.AddField("ITEMCODE", "Item Code", "NEO_PLS1", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("ITEMNAME", "Item Name", "NEO_PLS1", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("SNCODE", "SN CODE", "NEO_PLS1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("ISPRINT", "IS Printed", "NEO_PLS1", BoFieldTypes.db_Alpha, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

                B1Helper.AddTable("NEO_PLS2", "Packaging List Screen CH2", BoUTBTableType.bott_DocumentLines);
                //Child fields
                B1Helper.AddField("TWEGHT", "Total Item Weight", "NEO_PLS2", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO,BoFldSubTypes.st_None, true,"");
                B1Helper.AddField("ITEMCODE", "Item Code", "NEO_PLS2", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("ITEMNAME", "Item Name", "NEO_PLS2", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");

                Array.Resize(ref FormColumn, 0);
                Array.Resize(ref ChildTable, 2);
                ChildTable[0] = "NEO_PLS1";
                ChildTable[1] = "NEO_PLS2";
                B1Helper.CreateUdo("NEO_OPLS", "Gate Pass", "NEO_OPLS", "D", "", FormColumn, ChildTable);

                B1Helper.AddTable("TEMP_PLS1", "Temp Packaging List Screen ", BoUTBTableType.bott_DocumentLines);
                //Child fields
                B1Helper.AddField("IWEGHT", "Item Weight", "TEMP_PLS1", BoFieldTypes.db_Numeric, 10, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("ITEMCODE", "Item Code", "TEMP_PLS1", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("ITEMNAME", "Item Name", "TEMP_PLS1", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("SNCODE", "SN CODE", "TEMP_PLS1", BoFieldTypes.db_Alpha, 100, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("DPDOCENTRY", "Delivery DocEntry", "TEMP_PLS1", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");
                B1Helper.AddField("MATRIXCOUNT", "Matrix Count Line", "TEMP_PLS1", BoFieldTypes.db_Alpha, 50, BoYesNoEnum.tNO, BoFldSubTypes.st_None, true, "");


                #endregion

                #endregion



                return UDOAdded;
            }
            catch (Exception ex)
            {
             
                return false;
            }
        }

        private static bool CreateUDO(string CodeID, string Name, string TableName, string[] FormColoums, SAPbobsCOM.BoUDOObjType ObjectType, string ManageSeries)
        {
            SAPbobsCOM.UserObjectsMD oUserObjectMD = default(SAPbobsCOM.UserObjectsMD);
            try
            {
                oUserObjectMD = ((SAPbobsCOM.UserObjectsMD)(Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD)));
                if (oUserObjectMD.GetByKey(CodeID) == true)
                {
                    return true;
                }
                oUserObjectMD.CanLog = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.CanFind = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.CanClose = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.CanCancel = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.CanDelete = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.ManageSeries = SAPbobsCOM.BoYesNoEnum.tNO;
                oUserObjectMD.CanYearTransfer = SAPbobsCOM.BoYesNoEnum.tNO;

                oUserObjectMD.Code = CodeID;
                oUserObjectMD.Name = Name;
                oUserObjectMD.TableName = TableName;
                oUserObjectMD.ObjectType = ObjectType;


                oUserObjectMD.CanCreateDefaultForm = SAPbobsCOM.BoYesNoEnum.tYES;
                oUserObjectMD.EnableEnhancedForm = SAPbobsCOM.BoYesNoEnum.tNO;
                oUserObjectMD.MenuItem = SAPbobsCOM.BoYesNoEnum.tNO;
                oUserObjectMD.MenuCaption = Name;
                oUserObjectMD.FatherMenuID = 47616;
                oUserObjectMD.Position = 0;
                oUserObjectMD.MenuUID = CodeID;

                if (FormColoums != null)
                {
                    for (int i = 0; i <= FormColoums.Length - 1; i++)
                    {
                        if (FormColoums[i].Trim() != "U_RUNDB")
                        {
                            oUserObjectMD.FormColumns.FormColumnAlias = FormColoums[i];
                            oUserObjectMD.FormColumns.Editable = SAPbobsCOM.BoYesNoEnum.tNO;
                            oUserObjectMD.FormColumns.Add();
                        }
                        else
                        {
                            oUserObjectMD.FormColumns.FormColumnAlias = FormColoums[i];
                            oUserObjectMD.FormColumns.Editable = SAPbobsCOM.BoYesNoEnum.tYES;
                            oUserObjectMD.FormColumns.Add();
                        }
                    }
                }
                // check for errors in the process
                RetCode = oUserObjectMD.Add();

                if (RetCode != 0)
                {
                    if (RetCode != -1)
                    {
                        Program.oCompany.GetLastError(out RetCode, out ErrMsg);
                        Program.SBO_Application.StatusBar.SetText("Object Failed : " + ErrMsg + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    }
                }
                else
                {
                    Program.SBO_Application.StatusBar.SetText("Object Registered : " + Name + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserObjectMD);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public static bool GetCommonSettings()
        {
            string query = "SELECT T0.\"U_A_Email\", T0.\"U_S_Email\", T0.\"U_J_Email\" , \"U_ExcessDay\" , \"U_N_Email\" FROM OADM T0";
            SAPbobsCOM.Recordset rsQry = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsQry.DoQuery(query);
            if (rsQry.RecordCount > 0)
            {
                Globals.SetsAEmail(rsQry.Fields.Item(0).Value.ToString());
                Globals.SetsSEmail(rsQry.Fields.Item(1).Value.ToString());
                Globals.SetsJournal(rsQry.Fields.Item(2).Value.ToString());
                Globals.SetsExcessDay(Convert.ToDouble(rsQry.Fields.Item(3).Value.ToString()));
                Globals.SetsNEmail(rsQry.Fields.Item(4).Value.ToString());
            }

            query = "SELECT T0.\"U_BillProcees\", T0.\"U_Account\" FROM \"@Z_SCGL\"  T0";
            rsQry = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rsQry.DoQuery(query);
            if (rsQry.RecordCount > 0)
            {
                while (rsQry.EoF == false)
                {
                    if (rsQry.Fields.Item(0).Value.ToString() == "A")
                    { Globals.SetsSAdvance(rsQry.Fields.Item(1).Value.ToString()); }
                    else if (rsQry.Fields.Item(0).Value.ToString() == "C") { Globals.SetsSCredit(rsQry.Fields.Item(1).Value.ToString()); }
                    rsQry.MoveNext();
                }
            }
            rsQry = null;
            return true;

        }

        public static void SetFormFilter()
        {
            try
            {
                //SAPbouiCOM.EventFilters objFilters = new SAPbouiCOM.EventFilters();
                //SAPbouiCOM.EventFilter objFilter;

                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_FORM_LOAD);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_FORM_CLOSE);
                //objFilter.AddEx("frm_TransferItems");



                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_MENU_CLICK);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED);
                //objFilter.AddEx("frm_TransferItems");



                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_COMBO_SELECT);
                //objFilter.AddEx("frm_TransferItems");

                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_KEY_DOWN);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_LOST_FOCUS);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_VALIDATE);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_FORM_DATA_LOAD);
                //objFilter.AddEx("frm_TransferItems");



                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_CLICK);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_RIGHT_CLICK);
                //objFilter.AddEx("frm_TransferItems");


                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_DOUBLE_CLICK);
                //objFilter.AddEx("frm_TransferItems");

                //objFilter = objFilters.Add(SAPbouiCOM.BoEventTypes.et_PICKER_CLICKED);
                //objFilter.AddEx("frm_TransferItems");


                //SetFilter(objFilters);
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                // Log.LogException(LogLevel.Error, ex);
            }
        }

        public static void RemoveMenu(string menuId)
        {
            Application.SBO_Application.Menus.RemoveEx(menuId);
        }

        public static string GetNextEntryIndex(string tableName)
        {
            try
            {
                var result = B1Helper.GetNextEntryIndex(tableName);
                if (result.Equals(string.Empty))
                    result = "0";
                else
                    if (result.Equals("0"))
                    {
                        result = "1";
                    }

                return result;
            }
            catch (Exception ex)
            {
                Utility.LogException(ex);
                // Log.LogException(LogLevel.Error, ex);
                return null;
            }

        }

        protected static void SetFilter(SAPbouiCOM.EventFilters Filters)
        {
            Application.SBO_Application.SetFilter(Filters);
        }

        #endregion
    }
}

