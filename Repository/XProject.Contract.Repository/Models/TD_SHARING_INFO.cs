using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Contract.Repository.Models
{
    public class TD_SHARING_INFO :Entity
    {
		public string dd_member_account { get; set; }
		public int Mode_code { get; set; }
		public string customer_id { get; set; }
		public string customer_password { get; set; }
		public bool ? delete_flag { get; set; }
		public DateTime ? Create_date { get; set; }
		public DateTime ? Expiration_date { get; set; }
		public virtual ICollection<TD_CUSTOMER_INFO> TD_CUSTOMER_INFO { get; set; }
		public virtual ICollection<TD_FILE_INFO>  TD_FILE_INFOs { get; set; }
		public virtual TM_DD_MEMBER  TM_DD_MEMBERs { get; set; }
	}
}
