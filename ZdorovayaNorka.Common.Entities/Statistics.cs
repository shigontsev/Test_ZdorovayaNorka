using System;
using System.ComponentModel.DataAnnotations;

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
