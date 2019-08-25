using System;

namespace WasmShop.Model.Abstracts
{
    public class Auditable : IAuditable, ISeoable, ISwitchable
    {
        public DateTime? CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public string Status { get; set; }
    }
}