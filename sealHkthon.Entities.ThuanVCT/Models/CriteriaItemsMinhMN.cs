using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sealHkthon.Entities.ThuanVCT.Models
{
    public partial class CriteriaItemsMinhMN
    {
        public long criteriaIdMinhMN { get; set; }
        public long criteriaSetIdMinhMN { get; set; }
        public string criteriaName { get; set; }
        public string description { get; set; }
        public long weight { get; set; }
        public long maxScore { get; set; }
        public virtual CriteriaTemplateSetsMinhMN CriteriaTemplateSetsMinhMN { get; set; }
    }
}
