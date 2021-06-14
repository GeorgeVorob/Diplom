using System;

namespace DiplomCore.Models
{
    public class PublicPropAttribute : Attribute
    {
        public string htmlType { get; set; }
        public string publicName { get; set; }

        public PublicPropAttribute(string htmlType, string publicName)
        {
            this.htmlType = htmlType;
            this.publicName = publicName;
        }
    }
}