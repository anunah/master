using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class head
    {
        private headElement[] itemsField;
        /// 
        [System.Xml.Serialization.XmlElementAttribute("element", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public headElement[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class headElement
    {
        private headElementSubElement1[] subElement1Field;
        private headElementSubElement2[] subElement2Field;
        private headElementSubElement3[] subElement3Field;
        private string numberField;
        /// 
        [System.Xml.Serialization.XmlElementAttribute("subElement1", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public headElementSubElement1[] subElement1
        {
            get
            {
                return this.subElement1Field;
            }
            set
            {
                this.subElement1Field = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlElementAttribute("subElement2", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public headElementSubElement2[] subElement2
        {
            get
            {
                return this.subElement2Field;
            }
            set
            {
                this.subElement2Field = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlElementAttribute("subElement3", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public headElementSubElement3[] subElement3
        {
            get
            {
                return this.subElement3Field;
            }
            set
            {
                this.subElement3Field = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class headElementSubElement1
    {
        private string subnumberField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string subnumber
        {
            get
            {
                return this.subnumberField;
            }
            set
            {
                this.subnumberField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class headElementSubElement2
    {
        private string subnumberField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string subnumber
        {
            get
            {
                return this.subnumberField;
            }
            set
            {
                this.subnumberField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class headElementSubElement3
    {
        private string subnumberField;
        private string valueField;
        /// 
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string subnumber
        {
            get
            {
                return this.subnumberField;
            }
            set
            {
                this.subnumberField = value;
            }
        }
        /// 
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}