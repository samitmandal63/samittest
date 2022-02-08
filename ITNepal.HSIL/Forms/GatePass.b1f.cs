using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;
using SAPbobsCOM;
using System.IO;
using System.Threading;
using ITNepal.HSIL.Helpers;

namespace ITNepal.HSIL.Forms
{
    [FormAttribute("ITNepal.HSIL.Forms.GatePass", "Forms/GatePass.b1f")]
    class GatePass : UserFormBase
    {
        public GatePass()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_3").Specific));
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.EditText1.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.EditText1_ChooseFromListBefore);
            this.EditText1.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText1_ChooseFromListAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_19").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_22").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_25").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_27").Specific));
            this.LinkedButton1.ClickBefore += new SAPbouiCOM._ILinkedButtonEvents_ClickBeforeEventHandler(this.LinkedButton1_ClickBefore);
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataAddAfter += new SAPbouiCOM.Framework.FormBase.DataAddAfterHandler(this.Form_DataAddAfter);
            this.DataUpdateBefore += new SAPbouiCOM.Framework.FormBase.DataUpdateBeforeHandler(this.Form_DataUpdateBefore);
            this.DataAddBefore += new DataAddBeforeHandler(this.Form_DataAddBefore);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

            BasicBinding();
            ITNepal.HSIL.Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
            

        }
        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                OForm = Program.SBO_Application.Forms.ActiveForm;
                if (OForm.Title == "GatePass")
                {
                    if (!pVal.BeforeAction)
                    {
                        if (pVal.MenuUID == "1282")
                        {
                            BasicBinding();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Program.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
        }

        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbobsCOM.Recordset Rec;
        private void ResetRec()
        {
            if (Rec != null)
                Rec = null;
            if (Rec == null)
                Rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        }

        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Form OForm;
        private SAPbouiCOM.Form OForm2;


        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string cmbVal = ComboBox0.Value;
            if (cmbVal == "IN")
            {
                    
                EditText1.ChooseFromListUID ="1";
                EditText1.ChooseFromListAlias = "DocNum";
                    
            }
            else if (cmbVal == "OUT")
            {
                EditText1.ChooseFromListUID = "2";
                EditText1.ChooseFromListAlias = "DocNum";
                

            }
            else if(cmbVal == "InventoryTransfer")
            {
                EditText1.ChooseFromListUID = "3";
                EditText1.ChooseFromListAlias = "DocNum";

            }
            GetTotalWeight();
      }

        private void EditText1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflist = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable oTable = cflist.SelectedObjects;
            try
            {
                EditText1.Value = oTable.GetValue("DocNum", 0).ToString();
            }
            catch
            {
                
            }

            try
            {

                //edittext1.value = docnum;
                
                string query = "SELECT \"Filler\", \"ToWhsCode\" FROM OWTQ WHERE \"DocNum\" = '" + EditText1.Value + "'";
                SAPbobsCOM.Recordset rec = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                rec.DoQuery(query);
                string filler = rec.Fields.Item("Filler").Value.ToString();
                string whsCode = rec.Fields.Item("ToWhsCode").Value.ToString();
                EditText7.Value = whsCode;
                EditText9.Value = filler;
            }
            catch
            {

            }


        }

        private SAPbouiCOM.LinkedButton LinkedButton1;

        private void LinkedButton1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            string cmbVal = ComboBox0.Value;
            OForm = Program.SBO_Application.Forms.ActiveForm;
            string baseDocNum = EditText1.Value;
            
            if (cmbVal == "IN")
            {
                LinkedButton1.LinkedObjectType = "22";
                Program.SBO_Application.ActivateMenuItem("2305");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("8").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                GetTotalWeight();
                //OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
              
            }
            else if (cmbVal == "OUT")
            {
                LinkedButton1.LinkedObjectType = "17";
                Program.SBO_Application.ActivateMenuItem("2050");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("8").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                GetTotalWeight();
                //OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            }
            else if (cmbVal == "InventoryTransfer")
            {
                LinkedButton1.LinkedObjectType = "1250000001";
                Program.SBO_Application.ActivateMenuItem("3088");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("11").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                GetTotalWeight();
                //OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            }

        }

        private void EditText1_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            if (String.IsNullOrEmpty(ComboBox0.Value))
            {
                Program.SBO_Application.StatusBar.SetText("Please select Combobox", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                BubbleEvent = false;
            }
            BubbleEvent = true;
            int count = 1;
            string cmb = ComboBox0.Value;
            SAPbouiCOM.ChooseFromList oCFLEvento = default(SAPbouiCOM.ChooseFromList);
            SAPbouiCOM.Condition oCon = default(SAPbouiCOM.Condition);
            SAPbouiCOM.Conditions oCons = default(SAPbouiCOM.Conditions);
            SAPbobsCOM.Recordset rec = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            if (cmb == "IN")
            {
                string qry = "SELECT * FROM \"OPOR\" T0 WHERE T0.\"DocStatus\" = 'O'";
                rec.DoQuery(qry);
                oCFLEvento = this.UIAPIRawForm.ChooseFromLists.Item("1");
            }
            else if (cmb == "OUT")
            {
                string qry = "SELECT *  FROM \"ORDR\" T0 WHERE T0.\"DocStatus\"  = 'O'";
                rec.DoQuery(qry);
                oCFLEvento = this.UIAPIRawForm.ChooseFromLists.Item("2");
            }
            else if (cmb == "InventoryTransfer")
            {
                string qry = "SELECT *  FROM \"OWTQ\" T0 WHERE T0.\"DocStatus\"  = 'O'";
                rec.DoQuery(qry);
                oCFLEvento = this.UIAPIRawForm.ChooseFromLists.Item("3");
            }
            oCFLEvento.SetConditions(null);
            oCons = oCFLEvento.GetConditions();
            if (rec.RecordCount > 0)
            {
                while (!rec.EoF)
                {
                    oCon = oCons.Add();
                    oCon.Alias = "DocNum";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = rec.Fields.Item("DocNum").Value.ToString();
                    if (rec.RecordCount > 1 && rec.RecordCount != count)
                        oCon.Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                    count += 1;
                    rec.MoveNext();
                }
            }
            else
            {
                oCon = oCons.Add();
                oCon.Alias = "DocNum";
                oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCon.CondVal = "";
            }
            oCFLEvento.SetConditions(oCons);

        }
        private void GetTotalWeight() 
        {
            int rowcount = Matrix0.RowCount;

            int t_weight = 0;
            
            if (ComboBox0.Value == "IN" && rowcount >= 1)
            {
                string first_value = Matrix0.GetCellValue("Col_0", rowcount == 1 ? rowcount : rowcount - 1).ToString();
                string second_value = Matrix0.GetCellValue("Col_0", rowcount).ToString();
                int total_weight = Int32.Parse(first_value) - Int32.Parse(second_value);
                t_weight = total_weight;
            }
            else if (ComboBox0.Value == "InventoryTransfer" && rowcount >= 1 || ComboBox0.Value == "OUT" && rowcount >= 1)
            {
                string second_value = Matrix0.GetCellValue("Col_0", 1).ToString();
                string first_value = Matrix0.GetCellValue("Col_0", rowcount).ToString();
                int total_weight = Int32.Parse(first_value) - Int32.Parse(second_value);
                t_weight = total_weight;
            }
            if (t_weight < 0)
            {
                t_weight = t_weight * (-1);
            }
            EditText0.TrySetValue(t_weight.ToString());
        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            var file = Environment.CurrentDirectory;
            string csv_file_path = "C:\\weighbridge" + "\\" + "Weight.csv";

            try
            {
                var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path);
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(new string[] { ";" });
                int rowCount = Matrix0.RowCount;
                string var1;
                Matrix0.AddRow();
                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    var1 = row[0];
                    ((SAPbouiCOM.EditText)Matrix0.GetCellSpecific("Col_0", Matrix0.RowCount)).Value = var1;
                    ((SAPbouiCOM.EditText)Matrix0.GetCellSpecific("Col_1", Matrix0.RowCount)).Value = DateTime.Now.ToString("HH:mm tt");
                    ((SAPbouiCOM.EditText)Matrix0.GetCellSpecific("Col_2", Matrix0.RowCount)).Value = "";
                    Extentions.SetLineId(Matrix0);
                }
                GetTotalWeight();
                
            }
            catch (Exception)
            {
                Program.SBO_Application.SetStatusBarMessage("CSV File not found", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
            

            

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                if (Matrix0.RowCount == 0)
                {
                    BubbleEvent = false;
                    Program.SBO_Application.StatusBar.SetText("Matrix cannot be empty", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                }
                if (String.IsNullOrEmpty(ComboBox0.Value.ToString()) || String.IsNullOrEmpty(EditText1.Value) ||
                    String.IsNullOrEmpty(EditText2.Value) || String.IsNullOrEmpty(EditText3.Value) || String.IsNullOrEmpty(EditText4.Value)
                    || String.IsNullOrEmpty(EditText8.Value)
                    )
                {
                    BubbleEvent = false;
                    Program.SBO_Application.StatusBar.SetText("Fields cannot be empty", SAPbouiCOM.BoMessageTime.bmt_Long, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                }                
            }


            //Matrix0.DeleteRow(Matrix0.RowCount);
        }
        public void copycsv() 
        {
            string ticks = DateTime.Now.ToString("yyMMddHHmmssff");
            var file = Environment.CurrentDirectory;
            string sourceFile = "C:\\weighbridge" +"\\"+ "Weight.csv";
            string destinationFile = "C:\\weighbridge\\backup" + "\\" + "Weight" + ticks + ".csv";
            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }  
        }
        public void deletecsv()
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


        //public void UpdateQuantity 
        //{
        //   // string query = "UPDATE "OINV" SET "NumAtCard" = Quantity WHERE "DocEntry"=:list_of_cols_val_tab_del;"
        //}
        public void Updateform(string DocEntry, string comboValue) 
        {
            string quantity = EditText0.Value;
            SAPbobsCOM.Recordset rec = (SAPbobsCOM.Recordset)B1Helper.DiCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            if (comboValue == "IN")
            {
                //string query = "UPDATE OPOR SET (\"\")"
                string query = "update OPOR set \"U_gatepass_total\"='" + quantity + "' where \"DocEntry\"='" + DocEntry + "'";
                rec.DoQuery(query);

            }
            else if (comboValue == "OUT")
            {
                string query = "update ORDR set \"U_gatepass_total\"='" + quantity + "' where \"DocEntry\"='" + DocEntry + "'";
                rec.DoQuery(query);
            }
            else if (comboValue == "InventoryTransfer")
            {
                string query = "update OWTQ set \"U_gatepass_total\"='" + quantity + "' where \"DocEntry\"='" + DocEntry + "'";
                rec.DoQuery(query);
            }
        }

        private void Form_DataAddAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            copycsv();
            deletecsv();

        }

        private void Form_DataUpdateBefore(ref SAPbouiCOM.BusinessObjectInfo pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            copycsv();
            deletecsv();
            UIAPIRawForm.Freeze(true);
            string cmb = ComboBox0.Value;
            if (cmb == "IN")
            {
                string baseDocNum = EditText1.Value;

                Program.SBO_Application.ActivateMenuItem("2305");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("8").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                //SAPbouiCOM.EditText series_code = ((SAPbouiCOM.EditText)OForm2.Items.Item("88").Specific);
                string docEntry = OForm2.DataSources.DBDataSources.Item("OPOR").GetValue("DocEntry", 0);
                Updateform(docEntry, cmb);
                OForm2.Close();

            }
            else if (cmb == "OUT")
            {
                string baseDocNum = EditText1.Value;

                Program.SBO_Application.ActivateMenuItem("2050");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("8").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                //SAPbouiCOM.EditText series_code = ((SAPbouiCOM.EditText)OForm2.Items.Item("88").Specific);
                string docEntry = OForm2.DataSources.DBDataSources.Item("ORDR").GetValue("DocEntry", 0);
                Updateform(docEntry, cmb);
                OForm2.Close();
            }   
            else if (cmb == "InventoryTransfer")
            {
                string baseDocNum = EditText1.Value;

                Program.SBO_Application.ActivateMenuItem("3088");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("11").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                //SAPbouiCOM.EditText series_code = ((SAPbouiCOM.EditText)OForm2.Items.Item("88").Specific);
                string docEntry = OForm2.DataSources.DBDataSources.Item("OWTQ").GetValue("DocEntry", 0);
                Updateform(docEntry, cmb);
                OForm2.Close();
            }
            UIAPIRawForm.Freeze(false);  
        }
        public void BasicBinding() 
        {
            Matrix0.AutoResizeColumns();
            EditText6.Value = B1Helper.GetNextDocNum("@ITN_GATEPS").ToString();
            EditText8.Value = DateTime.Now.ToString("yyyyMMdd");
        }
        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (Button0.Caption == "Add")
            {
                BasicBinding();  
            }

        }

        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText EditText0;

        private void Form_DataAddBefore(ref SAPbouiCOM.BusinessObjectInfo pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            UIAPIRawForm.Freeze(true);
            string cmb = ComboBox0.Value;
            if (cmb == "IN")
            {
                string baseDocNum = EditText1.Value;

                Program.SBO_Application.ActivateMenuItem("2305");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("8").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                //SAPbouiCOM.EditText series_code = ((SAPbouiCOM.EditText)OForm2.Items.Item("88").Specific);
                string docEntry = OForm2.DataSources.DBDataSources.Item("OPOR").GetValue("DocEntry", 0);
                Updateform(docEntry, cmb);
                OForm2.Close();

            }
            else if (cmb == "OUT")
            {
                string baseDocNum = EditText1.Value;

                Program.SBO_Application.ActivateMenuItem("2050");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("8").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                //SAPbouiCOM.EditText series_code = ((SAPbouiCOM.EditText)OForm2.Items.Item("88").Specific);
                string docEntry = OForm2.DataSources.DBDataSources.Item("ORDR").GetValue("DocEntry", 0);
                Updateform(docEntry, cmb);
                OForm2.Close();
            }
            else if (cmb == "InventoryTransfer")
            {
                string baseDocNum = EditText1.Value;

                Program.SBO_Application.ActivateMenuItem("3088");
                OForm2 = Program.SBO_Application.Forms.ActiveForm;
                OForm2.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ((SAPbouiCOM.EditText)OForm2.Items.Item("11").Specific).Value = baseDocNum;
                SAPbouiCOM.Button Bt1 = ((SAPbouiCOM.Button)(OForm2.Items.Item("1").Specific));
                Bt1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                //SAPbouiCOM.EditText series_code = ((SAPbouiCOM.EditText)OForm2.Items.Item("88").Specific);
                string docEntry = OForm2.DataSources.DBDataSources.Item("OWTQ").GetValue("DocEntry", 0);
                Updateform(docEntry, cmb);
                OForm2.Close();
            }
            UIAPIRawForm.Freeze(false);  

        }

   
    }
}
