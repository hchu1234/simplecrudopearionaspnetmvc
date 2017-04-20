using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Common
{
    public class Constants
    {
        public class Validation
        {
            public class Expressions
            {
                public const string HtmlTagWithNewLine = @"^?!(</?\w+((\s+\w+(\s*=\s*(?:""(.|\n)*?""|'(.|\n)*?'|[^'"">\s]+))?)+\s*|\s*)/?>).*$";  //- 1
                public const string HtmlTag = @"^(?!(</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>)).*$"; // - 1 Works without new line
                public const string Phone = @"^\d{10}$";
                public const string Mobile = @"^\d{10}$";
                public const string Email = @"^([0-9a-zA-Z]+[-._+&amp;])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
                public const string EmailCommaSeperated = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*";
                public const string ZipCode = @"^\d{3}\s?\d{3}$";
                public const string Url = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
            }
        }
    }
}
