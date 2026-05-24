using System;
using System.Collections.Generic;

namespace sealHkthon.Entities.ThuanVCT.Models
{
    public partial class CriteriaTemplateSetsMinhMN
    {
        public long criteriaSetIdMinhMN { get; set; }

        public string criteriaSetName { get; set; }

        public string description { get; set; }

        public bool isDefault { get; set; }

        public DateTime? createdAt { get; set; }

        public virtual ICollection<CriteriaItemsMinhMN> CriteriaItemsMinhMNs { get; set; } = new List<CriteriaItemsMinhMN>();
    }
}
