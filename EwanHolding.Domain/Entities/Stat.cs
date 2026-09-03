using EwanHolding.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwanHolding.Domain.Entities
{
    public class Stat : BaseEntity
    {
        public string Label_Ar { get; set; }
        public string Label_En { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
    }
}
