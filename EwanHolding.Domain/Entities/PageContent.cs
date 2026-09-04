using EwanHolding.Domain.Common;
using System.Net;
using System.Reflection;

namespace EwanHolding.Domain.Entities
{
    public class PageContent : BaseEntity
    {
        public string Key { get; set; } // The key for the page content, used to identify the content in the database
        public string Value_Ar { get; set; }
        public string Value_En { get; set; }
        public string PageName { get; set; } // The name of the page where the content is used

    }
}
