using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Contract.Repository.Models
{
    public  class TD_FILE_INFO : Entity
    {
        [ForeignKey("TD_SHARING_INFO")]
        public string File_Sharing_ID { get; set; }
        public string ? File_Name { get; set; }
        public int? File_Size { get; set; }
        public DateTime Upload_Date { get; set; }

        public virtual TD_SHARING_INFO TD_SHARING_INFO { get; set; }

    }
}
