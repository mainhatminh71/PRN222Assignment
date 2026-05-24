using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sealHkthon.Entities.MinhMN.Models
{
    public partial class CriteriaItemsMinhMN
    {
        public long CriteriaIdMinhMN { get; set; }
        public long CriteriaSetIdMinhMN { get; set; }
        public string CriteriaName { get; set; }
        public string Description { get; set; }
        public long Weight { get; set; }
        public long MaxScore { get; set; }
        public virtual CriteriaTemplateSetsMinhMN CriteriaTemplateSetsMinhMN { get; set; }
    }
}
