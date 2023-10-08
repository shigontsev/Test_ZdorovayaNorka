using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdorovayaNorka.Common.Entities
{
    public class Statistics
    {
        [Key]
        public int SID { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}
