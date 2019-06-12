using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    [Table("RESTAURANT")]
    public class Restaurant
    {
        [Key]
        public long RES_IDENTI { get; set; }
        public string RES_NAME { get; set; }
        public string RES_MENU { get; set; }
        public decimal RES_PRICE { get; set; }
        public TimeSpan RES_OPENING_TIME { get; set; }
        public TimeSpan RES_CLOSING_TIME { get; set; }
    }
}
