﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Matrix {
    
    private bool affectsFormModeField;
    
    private long backColorField;
    
    private string descriptionField;
    
    private bool displayDescField;
    
    private bool enabledField;
    
    private long fontSizeField;
    
    private long foreColorField;
    
    private long fromPaneField;
    
    private long heightField;
    
    private long layoutField;
    
    private long leftField;
    
    private string linkToField;
    
    private bool rightJustifiedField;
    
    private long textStyleField;
    
    private long topField;
    
    private long toPaneField;
    
    private long typeField;
    
    private string uniqueIDField;
    
    private bool visibleField;
    
    private long widthField;
    
    private List<MatrixColumnInfo> columnsInfoField;
    
    private List<MatrixRow> rowsField;
    
    /// <remarks/>
    public bool AffectsFormMode {
        get {
            return this.affectsFormModeField;
        }
        set {
            this.affectsFormModeField = value;
        }
    }
    
    /// <remarks/>
    public long BackColor {
        get {
            return this.backColorField;
        }
        set {
            this.backColorField = value;
        }
    }
    
    /// <remarks/>
    public string Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public bool DisplayDesc {
        get {
            return this.displayDescField;
        }
        set {
            this.displayDescField = value;
        }
    }
    
    /// <remarks/>
    public bool Enabled {
        get {
            return this.enabledField;
        }
        set {
            this.enabledField = value;
        }
    }
    
    /// <remarks/>
    public long FontSize {
        get {
            return this.fontSizeField;
        }
        set {
            this.fontSizeField = value;
        }
    }
    
    /// <remarks/>
    public long ForeColor {
        get {
            return this.foreColorField;
        }
        set {
            this.foreColorField = value;
        }
    }
    
    /// <remarks/>
    public long FromPane {
        get {
            return this.fromPaneField;
        }
        set {
            this.fromPaneField = value;
        }
    }
    
    /// <remarks/>
    public long Height {
        get {
            return this.heightField;
        }
        set {
            this.heightField = value;
        }
    }
    
    /// <remarks/>
    public long Layout {
        get {
            return this.layoutField;
        }
        set {
            this.layoutField = value;
        }
    }
    
    /// <remarks/>
    public long Left {
        get {
            return this.leftField;
        }
        set {
            this.leftField = value;
        }
    }
    
    /// <remarks/>
    public string LinkTo {
        get {
            return this.linkToField;
        }
        set {
            this.linkToField = value;
        }
    }
    
    /// <remarks/>
    public bool RightJustified {
        get {
            return this.rightJustifiedField;
        }
        set {
            this.rightJustifiedField = value;
        }
    }
    
    /// <remarks/>
    public long TextStyle {
        get {
            return this.textStyleField;
        }
        set {
            this.textStyleField = value;
        }
    }
    
    /// <remarks/>
    public long Top {
        get {
            return this.topField;
        }
        set {
            this.topField = value;
        }
    }
    
    /// <remarks/>
    public long ToPane {
        get {
            return this.toPaneField;
        }
        set {
            this.toPaneField = value;
        }
    }
    
    /// <remarks/>
    public long Type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    public string UniqueID {
        get {
            return this.uniqueIDField;
        }
        set {
            this.uniqueIDField = value;
        }
    }
    
    /// <remarks/>
    public bool Visible {
        get {
            return this.visibleField;
        }
        set {
            this.visibleField = value;
        }
    }
    
    /// <remarks/>
    public long Width {
        get {
            return this.widthField;
        }
        set {
            this.widthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ColumnInfo", IsNullable=false)]
    public List<MatrixColumnInfo> ColumnsInfo {
        get {
            return this.columnsInfoField;
        }
        set {
            this.columnsInfoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Row", IsNullable=false)]
    public List<MatrixRow> Rows {
        get {
            return this.rowsField;
        }
        set {
            this.rowsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class MatrixColumnInfo {
    
    private bool affectsFormModeField;
    
    private long backColorField;
    
    private string chooseFromListAliasField;
    
    private string chooseFromListUIDField;
    
    private MatrixColumnInfoDataBind dataBindField;
    
    private string descriptionField;
    
    private bool displayDescField;
    
    private bool editableField;
    
    private long fontSizeField;
    
    private long foreColorField;
    
    private bool rightJustifiedField;
    
    private long textStyleField;
    
    private string titleField;
    
    private long typeField;
    
    private string uniqueIDField;
    
    private List<MatrixColumnInfoValidValue> validValuesField;
    
    private string valOFFField;
    
    private string valONField;
    
    private bool visibleField;
    
    private long widthField;
    
    /// <remarks/>
    public bool AffectsFormMode {
        get {
            return this.affectsFormModeField;
        }
        set {
            this.affectsFormModeField = value;
        }
    }
    
    /// <remarks/>
    public long BackColor {
        get {
            return this.backColorField;
        }
        set {
            this.backColorField = value;
        }
    }
    
    /// <remarks/>
    public string ChooseFromListAlias {
        get {
            return this.chooseFromListAliasField;
        }
        set {
            this.chooseFromListAliasField = value;
        }
    }
    
    /// <remarks/>
    public string ChooseFromListUID {
        get {
            return this.chooseFromListUIDField;
        }
        set {
            this.chooseFromListUIDField = value;
        }
    }
    
    /// <remarks/>
    public MatrixColumnInfoDataBind DataBind {
        get {
            return this.dataBindField;
        }
        set {
            this.dataBindField = value;
        }
    }
    
    /// <remarks/>
    public string Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public bool DisplayDesc {
        get {
            return this.displayDescField;
        }
        set {
            this.displayDescField = value;
        }
    }
    
    /// <remarks/>
    public bool Editable {
        get {
            return this.editableField;
        }
        set {
            this.editableField = value;
        }
    }
    
    /// <remarks/>
    public long FontSize {
        get {
            return this.fontSizeField;
        }
        set {
            this.fontSizeField = value;
        }
    }
    
    /// <remarks/>
    public long ForeColor {
        get {
            return this.foreColorField;
        }
        set {
            this.foreColorField = value;
        }
    }
    
    /// <remarks/>
    public bool RightJustified {
        get {
            return this.rightJustifiedField;
        }
        set {
            this.rightJustifiedField = value;
        }
    }
    
    /// <remarks/>
    public long TextStyle {
        get {
            return this.textStyleField;
        }
        set {
            this.textStyleField = value;
        }
    }
    
    /// <remarks/>
    public string Title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }
    
    /// <remarks/>
    public long Type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    public string UniqueID {
        get {
            return this.uniqueIDField;
        }
        set {
            this.uniqueIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ValidValue", IsNullable=false)]
    public List<MatrixColumnInfoValidValue> ValidValues {
        get {
            return this.validValuesField;
        }
        set {
            this.validValuesField = value;
        }
    }
    
    /// <remarks/>
    public string ValOFF {
        get {
            return this.valOFFField;
        }
        set {
            this.valOFFField = value;
        }
    }
    
    /// <remarks/>
    public string ValON {
        get {
            return this.valONField;
        }
        set {
            this.valONField = value;
        }
    }
    
    /// <remarks/>
    public bool Visible {
        get {
            return this.visibleField;
        }
        set {
            this.visibleField = value;
        }
    }
    
    /// <remarks/>
    public long Width {
        get {
            return this.widthField;
        }
        set {
            this.widthField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class MatrixColumnInfoDataBind {
    
    private string aliasField;
    
    private bool dataBoundField;
    
    private bool dataBoundFieldSpecified;
    
    private string tableNameField;
    
    /// <remarks/>
    public string Alias {
        get {
            return this.aliasField;
        }
        set {
            this.aliasField = value;
        }
    }
    
    /// <remarks/>
    public bool DataBound {
        get {
            return this.dataBoundField;
        }
        set {
            this.dataBoundField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DataBoundSpecified {
        get {
            return this.dataBoundFieldSpecified;
        }
        set {
            this.dataBoundFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string TableName {
        get {
            return this.tableNameField;
        }
        set {
            this.tableNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class MatrixColumnInfoValidValue {
    
    private string descriptionField;
    
    private string valueField;
    
    /// <remarks/>
    public string Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class MatrixRow {
    
    private bool visibleField;
    
    private List<MatrixRowColumn> columnsField;
    
    /// <remarks/>
    public bool Visible {
        get {
            return this.visibleField;
        }
        set {
            this.visibleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Column", IsNullable=false)]
    public List<MatrixRowColumn> Columns {
        get {
            return this.columnsField;
        }
        set {
            this.columnsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class MatrixRowColumn {
    
    private string idField;
    
    private string valueField;
    
    /// <remarks/>
    public string ID {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}