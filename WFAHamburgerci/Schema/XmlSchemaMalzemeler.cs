﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 

    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/XmlSchemaMalzemeler.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/XmlSchemaMalzemeler.xsd", IsNullable=false)]
    public partial class MalzemeSchema {
        
        private MalzemeSchemaMalzeme[] malzemeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("malzeme")]
        public MalzemeSchemaMalzeme[] malzeme {
            get {
                return this.malzemeField;
            }
            set {
                this.malzemeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/XmlSchemaMalzemeler.xsd")]
    public partial class MalzemeSchemaMalzeme {
        
        private string malzemeAdiField;
        
        private decimal fiyatiField;
        
        /// <remarks/>
        public string MalzemeAdi {
            get {
                return this.malzemeAdiField;
            }
            set {
                this.malzemeAdiField = value;
            }
        }
        
        /// <remarks/>
        public decimal Fiyati {
            get {
                return this.fiyatiField;
            }
            set {
                this.fiyatiField = value;
            }
        }
    }

