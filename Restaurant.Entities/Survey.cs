using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    [Table("SURVEY")]
    public class Survey
    {
        [Key]
        public long SRV_IDENTI { get; set; }
        public DateTime SRV_DATE { get; set; }
        public long SRV_STUDENT_ID { get; set; }
        public long SRV_RESTAURANT_ID { get; set; }
    }
}