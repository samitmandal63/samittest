using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITNepal.MainLibrary.SAPB1;
using SAPbouiCOM.Framework;
using SAPbobsCOM;
using System.IO;
using System.Collections;

namespace ITNepal.HSIL.Forms
{
    [FormAttribute("ITNepal.HSIL.Forms.Packaging_List_Screen", "Forms/Packaging List Screen.b1f")]
    class Packaging_List_Screen : UserFormBase
    {
        public Packaging_List_Screen()
        {
        }
        private string DocEntry;
        ArrayList ItemCodeList;
        ArrayList ItemCodeListCount;
        ArrayList ItemCodeListWeight;
        Double weight;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtDNum = ((SAPbouiCOM.EditText)(this.GetItem("txtDNum").Specific));
            this.txtDNum.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtDNum_ChooseFromListAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.txtCcode = ((SAPbouiCOM.EditText)(this.GetItem("txtCcode").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.txtCName = ((SAPbouiCOM.EditText)(this.GetItem("txtCName").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.txtDocNum = ((SAPbouiCOM.EditText)(this.GetItem("txtDocNum").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_8").Specific));
            this.Matrix0.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix0_ClickAfter);
            this.Matrix0.DoubleClickAfter += new SAPbouiCOM._IMatrixEvents_DoubleClickAfterEventHandler(this.Matrix0_DoubleClickAfter);
            this.Matrix0.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.Matrix0_ChooseFromListBefore);
            this.Matrix0.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix0_ChooseFromListAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.btnWegt = ((SAPbouiCOM.Button)(this.GetItem("btnWegt").Specific));
            this.btnWegt.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.btnWegt_ClickBefore);
            this.btnWegt.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.btnWegt_ClickAfter);
            this.btnPrnt = ((SAPbouiCOM.Button)(this.GetItem("btnPrnt").Specific));
            this.btnPrnt.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.btnPrnt_ClickAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.txtDate = ((SAPbouiCOM.EditText)(this.GetItem("txtDate").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_15").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.txtWeight = ((SAPbouiCOM.EditText)(this.GetItem("txtWeight").Specific));
            this.Oform = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.OnCustomInitialize();

        }

        private void BasicBindig()
        {
            txtDocNum.Value = B1Helper.GetNextDocNum("@NEO_OPLS").ToString();
            txtDate.Value = DateTime.Now.ToString("yyyyMMdd");

            Extentions.AddLine(Matrix0);
            Extentions.SetLineId(Matrix0);
            Matrix0.AutoResizeColumns();
            UIAPIRawForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
        }
        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Form OForm;

        private void OnCustomInitialize()
        {
            BasicBindig();
            ITNepal.HSIL.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
            UIAPIRawForm.EnableMenu("1292", true);
            UIAPIRawForm.EnableMenu("1293", true);
        }

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                OForm = Program.SBO_Application.Forms.ActiveForm;
                if (OForm.Title == "Packaging List Screen")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1292")
                        {
                            BasicBindig();
                            if (Oform.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                            {
                                SAPbouiCOM.Form oForm = Program.SBO_Application.Forms.ActiveForm;
                                string UDocEntry = oForm.DataSources.DBDataSources.Item("@NEO_OPLS").GetValue("DocEntry", 0).ToString();
                                string qry = "SELECT *  FROM \"@NEO_PLS2\"  T0 WHERE T0.\"DocEntry\" ='" + UDocEntry + "' ";
                                rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                rec.DoQuery(qry);
                                string OEntry;
                                ItemCodeList = new ArrayList();
                                ItemCodeListCount = new ArrayList();
                                ItemCodeListWeight = new ArrayList();
                                weight = 0;
                                while (!rec.EoF)
                                {
                                    OEntry = rec.Fields.Item("U_ITEMCODE").Value.ToString();
                                    if (!string.IsNullOrEmpty(OEntry))
                                    {
                                        ItemCodeList.Add(OEntry);
                                        ItemCodeListCount.Add(1);
                                        ItemCodeListWeight.Add(0);
                                    }
                                    rec.MoveNext();
                                }
                            }
                           
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Program.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
        }

        private SAPbouiCOM.EditText txtDNum;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText txtCcode;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText txtCName;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText txtDocNum;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button btnWegt;
        private SAPbouiCOM.Button btnPrnt;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText txtDate;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText txtWeight;
        private SAPbouiCOM.Form Oform;

        private void txtDNum_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflist = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable oTable = cflist.SelectedObjects;
            try
            {
                txtDNum.Value = oTable.GetValue("DocEntry", 0).ToString();
            }
            catch { }
            try
            {
                txtCcode.Value = oTable.GetValue("CardCode", 0).ToString();
            }
            catch { }
            try
            {
                txtCName.Value = oTable.GetValue("CardName", 0).ToString();
            }
            catch { }
            try
            {
                DocEntry = oTable.GetValue("DocEntry", 0).ToString();
            }
            catch { }
            string qry = "SELECT DISTINCT T1.\"ItemCode\", T1.\"Dscription\" FROM \"DRF1\"  T1 WHERE T1.\"DocEntry\" ='" + DocEntry + "' ";
            rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rec.DoQuery(qry);
            int row = 1;
            string OEntry;
            Matrix1.Clear();
            Extentions.AddLine(Matrix1);
            Extentions.SetLineId(Matrix1);
            Matrix1.AutoResizeColumns();
            ItemCodeList = new ArrayList();
            ItemCodeListCount = new ArrayList();
            ItemCodeListWeight = new ArrayList();
            weight = 0;
            while (!rec.EoF)
            {
                if (!String.IsNullOrEmpty(Matrix1.GetCellValue("1", Matrix1.RowCount).ToString()))
                {
                    Extentions.AddLine(Matrix1);
                    Extentions.SetLineId(Matrix1);
                }

                ((SAPbouiCOM.EditText)(Matrix1.GetCellSpecific("1", row))).Value = rec.Fields.Item("ItemCode").Value.ToString();
                ((SAPbouiCOM.EditText)(Matrix1.GetCellSpecific("2", row))).Value = rec.Fields.Item("Dscription").Value.ToString();
                OEntry = rec.Fields.Item("ItemCode").Value.ToString();
                ItemCodeList.Add(OEntry);
                ItemCodeListCount.Add(1);
                ItemCodeListWeight.Add(0);
                row++;
                rec.MoveNext();
            }



        }

        private void Matrix0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "ITEMCODE")
                {
                    SAPbouiCOM.ISBOChooseFromListEventArg chList = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                    SAPbouiCOM.DataTable oTable = chList.SelectedObjects;
                    if (oTable.Rows.Count == 0)
                        return;

                    try
                    {
                        // ((SAPbouiCOM.EditText)(Matrix0.GetCellSpecific("ITEMCODE", pVal.Row + row))).Value = oTable.GetValue("ItemCode", row).ToString();
                        Matrix0.SetCellValue("ITEMCODE", pVal.Row, oTable.GetValue("ItemCode", 0).ToString());
                    }
                    catch { }
                    try
                    {
                        Matrix0.SetCellValue("ITEMNAME", pVal.Row, oTable.GetValue("ItemName", 0).ToString());
                    }
                    catch { }

                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private SAPbobsCOM.Recordset rec;
        private void Matrix0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (pVal.ColUID == "ITEMCODE")
                {
                    int count = 1;
                    string qry;

                    if (Oform.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                    {
                       string UDocEntry = UIAPIRawForm.DataSources.DBDataSources.Item("@NEO_OPLS").GetValue("DocEntry", 0);
                        qry = "SELECT *  FROM \"@NEO_PLS2\"  T0 WHERE T0.\"DocEntry\" ='" + UDocEntry + "' ";

                    }
                    else
                    {
                        qry = "SELECT T1.\"ItemCode\", T1.\"Dscription\" FROM \"DRF1\"  T1 WHERE T1.\"DocEntry\" ='" + DocEntry + "' ";

                    }
                    rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    rec.DoQuery(qry);
                    SAPbouiCOM.ChooseFromList oCFLEvento = default(SAPbouiCOM.ChooseFromList);
                    SAPbouiCOM.Condition oCon = default(SAPbouiCOM.Condition);
                    SAPbouiCOM.Conditions oCons = default(SAPbouiCOM.Conditions);

                    oCFLEvento = this.UIAPIRawForm.ChooseFromLists.Item("itemcode");

                    oCFLEvento.SetConditions(null);
                    oCons = oCFLEvento.GetConditions();
                    if (rec.RecordCount > 0)
                    {
                        while (!rec.EoF)
                        {
                            oCon = oCons.Add();
                            oCon.Alias = "ItemCode";
                            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                            if (Oform.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                            {
                                oCon.CondVal = rec.Fields.Item("U_ITEMCODE").Value.ToString();
                            }
                            else
                            {
                                oCon.CondVal = rec.Fields.Item("ItemCode").Value.ToString();
                            }
                            if (rec.RecordCount > 1 && rec.RecordCount != count)
                                oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                            count += 1;
                            rec.MoveNext();
                        }
                    }
                    else
                    {
                        oCon = oCons.Add();
                        oCon.Alias = "ItemCode";
                        oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                        oCon.CondVal = "";
                    }
                    oCFLEvento.SetConditions(oCons);

                }
                if (rec != null)
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(rec);
                rec = null;
            }
            catch
            {
            }
        }

        private void btnWegt_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (!string.IsNullOrEmpty(Matrix0.GetCellValue("WEGHT", Matrix0.RowCount).ToString()))
            {
                copycsv();
                deletecsv();
                try
                {

                    //string sQuery = "insert into \"@TEMP_PLS1\" (\"DocEntry\",\"LineId\",\"U_ITEMCODE\",\"U_ITEMNAME\",\"U_IWEGHT\",\"U_SNCODE\",\"U_DPDOCENTRY\",\"U_MATRIXCOUNT\") " +
                    //     " values ((SELECT ifnull(max( cast( \"DocEntry\" as integer)),0) + 1 FROM \"@TEMP_PLS1\") , '"+ Matrix0.RowCount + "', " +
                    // "  '" + Matrix0.GetCellValue("ITEMCODE", Matrix0.RowCount).ToString() + "' , '" + Matrix0.GetCellValue("ITEMNAME", Matrix0.RowCount).ToString() + "' , '" +
                    // Matrix0.GetCellValue("WEGHT", Matrix0.RowCount).ToString() + "' , '" + Matrix0.GetCellValue("SNCODE", Matrix0.RowCount).ToString() + "', '" + DocEntry + "', '" + Matrix0.RowCount + "') ";
                    // rec.DoQuery(sQuery);

                }
                catch (Exception)
                {

                    throw;
                }
                if (!String.IsNullOrEmpty(Matrix0.GetCellValue("ITEMCODE", Matrix0.RowCount).ToString()))
                {
                    Extentions.AddLine(Matrix0);
                    Extentions.SetLineId(Matrix0);
                }
            }
        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (Button0.Caption == "Add")
                {
                    BasicBindig();
                }

            }
            catch (Exception ex)
            {
                Program.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        public void copycsv()
        {
            try
            {
                string ticks = DateTime.Now.ToString("yyMMddHHmmssff");
                var file = Environment.CurrentDirectory;
                string sourceFile = "C:\\weighbridge" + "\\" + "Weight.csv";
                string destinationFile = "C:\\weighbridge\\PackingListBackup" + "\\" + "Weight" + ticks + ".csv";
                try
                {
                    File.Copy(sourceFile, destinationFile, true);
                }
                catch (IOException iox)
                {
                    Console.WriteLine(iox.Message);
                }
            }
            catch (Exception ex)
            {

                Program.SBO_Application.SetStatusBarMessage("CSV File not Copy", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }
        public void deletecsv()
        {
            try
            {
                var file = Environment.CurrentDirectory;
                string csv_file_path = "C:\\weighbridge";
                string weightFile = "Weight.csv";
                if (File.Exists(Path.Combine(csv_file_path, weightFile)))
                {
                    // If file found, delete it    
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(Path.Combine(csv_file_path, weightFile));
                    Console.WriteLine("File deleted.");
                }
            }
            catch (Exception ex)
            {

                Program.SBO_Application.SetStatusBarMessage("CSV File not Delete", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        private void btnWegt_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            var file = Environment.CurrentDirectory;
            string csv_file_path = "C:\\weighbridge" + "\\" + "Weight.csv";

            try
            {
                var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path);
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(new string[] { ";" });
                int rowCount = Matrix0.RowCount;
                if (!string.IsNullOrEmpty(Matrix0.GetCellValue("ITEMCODE", rowCount).ToString()))
                {

                    string var1;
                    // Matrix0.AddRow();
                    while (!parser.EndOfData)
                    {

                        string[] row = parser.ReadFields();
                        var1 = row[0];
                        weight = weight + Convert.ToDouble(var1);
                        for (int i = 0; i < ItemCodeList.Count; i++)
                        {
                            if (Matrix0.GetCellValue("ITEMCODE", rowCount).Equals(ItemCodeList[i]))
                            {
                                ((SAPbouiCOM.EditText)Matrix0.GetCellSpecific("WEGHT", rowCount)).Value = var1;
                                ((SAPbouiCOM.EditText)Matrix0.GetCellSpecific("SNCODE", rowCount)).Value = Matrix0.GetCellValue("ITEMNAME", rowCount).ToString() + "-" + var1 + "-" + ItemCodeListCount[i];
                                ItemCodeListCount[i] = Convert.ToInt32(ItemCodeListCount[i]) + 1;
                                ItemCodeListWeight[i] = Convert.ToDouble(ItemCodeListWeight[i]) + Convert.ToDouble(var1);
                                ((SAPbouiCOM.EditText)Matrix1.GetCellSpecific("3", i + 1)).Value = ItemCodeListWeight[i].ToString();
                            }
                        }

                    }
                    txtWeight.Value = weight.ToString();
                }


            }
            catch (Exception ex)
            {
                Program.SBO_Application.SetStatusBarMessage("CSV File not found", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }



        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                if (!Validation())
                {
                    BubbleEvent = false;
                    UIAPIRawForm.Refresh();
                    return;
                }
                for (int i = Matrix0.RowCount; i == Matrix0.RowCount; i++)
                {
                    if (string.IsNullOrEmpty(Matrix0.GetCellValue("ITEMCODE", i).ToString()))
                    {
                        Matrix0.DeleteRow(i);
                    }
                }
            }
        }


        public bool Validation()
        {

            try
            {
                if (string.IsNullOrEmpty(txtDNum.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Please Select Delivery Number", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if (string.IsNullOrEmpty(txtCcode.Value))
                {
                    Program.SBO_Application.StatusBar.SetText("Customer Code Should be Empty", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }
                if (Matrix0.RowCount == 1)
                {
                    Program.SBO_Application.StatusBar.SetText("Please Select atleast one Document in line level", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {

                Program.SBO_Application.SetStatusBarMessage("Exception while Validation:" + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return false;
            }
        }

        private void btnPrnt_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (Oform.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                {
                    SAPbouiCOM.Form oForm = Program.SBO_Application.Forms.ActiveForm;
                    string DocEntry = oForm.DataSources.DBDataSources.Item("@NEO_OPLS").GetValue("DocEntry", 0).ToString();
                    string ReportName2 = "Packing list";
                    bool Result2 = Layout_Preview(ReportName2, DocEntry);
                }
            }
            catch (Exception EX)
            {
            }
        }

        private bool Layout_Preview(string ReportName, string First_Parameter)
        {

            Recordset oRS = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            string Qstr = "SELECT \"MenuUID\" FROM OCMN WHERE \"Name\" = '" + ReportName + "' AND \"Type\" = 'C'";
            oRS.DoQuery(Qstr);
            SAPbouiCOM.Form form = null;
            if (oRS.RecordCount > 0)
            {
                string MenuID = oRS.Fields.Item(0).Value.ToString();
                Program.SBO_Application.ActivateMenuItem(MenuID);
                form = Program.SBO_Application.Forms.ActiveForm;
                ((SAPbouiCOM.EditText)form.Items.Item("1000003").Specific).Value = First_Parameter;
                form.Items.Item("1").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                form.Visible = false;
                return true;
            }
            else
            {

                Program.SBO_Application.MessageBox("Report '" + ReportName + "' not found.", 0, "OK", null, null);
                return false;
            }
            

        }

        private void Matrix0_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
          

        }

        private void Matrix0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "PRINT" && pVal.Row > 0)
                {
                    var test = Matrix0.GetCellValue("PRINT", pVal.Row).ToString();
                    if (Matrix0.GetCellValue("PRINT", pVal.Row).ToString() == "True")
                    {
                        SAPbouiCOM.Form oForm = Program.SBO_Application.Forms.ActiveForm;
                        string Weight = Matrix0.GetCellValue("WEGHT", pVal.Row).ToString();
                        string SName = Matrix0.GetCellValue("SNCODE", pVal.Row).ToString();
                        string ReportName = "Qr code";
                        Recordset oRS = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                        string Qstr = "SELECT \"MenuUID\" FROM OCMN WHERE \"Name\" = '" + ReportName + "' AND \"Type\" = 'C'";
                        oRS.DoQuery(Qstr);
                        SAPbouiCOM.Form form = null;
                        if (oRS.RecordCount > 0)
                        {
                            string MenuID = oRS.Fields.Item(0).Value.ToString();
                            Program.SBO_Application.ActivateMenuItem(MenuID);
                            form = Program.SBO_Application.Forms.ActiveForm;
                            ((SAPbouiCOM.EditText)form.Items.Item("1000003").Specific).Value = SName;
                            ((SAPbouiCOM.EditText)form.Items.Item("1000009").Specific).Value = "2022";
                            ((SAPbouiCOM.EditText)form.Items.Item("1000015").Specific).Value = "50";
                            ((SAPbouiCOM.EditText)form.Items.Item("1000021").Specific).Value = "10";
                            ((SAPbouiCOM.EditText)form.Items.Item("1000027").Specific).Value = Weight;
                            form.Items.Item("1").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                            form.Visible = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
