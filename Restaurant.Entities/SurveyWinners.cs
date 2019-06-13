using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    [Table("SURVEY_WINNERS")]
    public class SurveyWinners
    {
        [Key]
        public long SVW_RESTAURANT_ID { get; set; }
        public DateTime SVW_DATE { get; set; }
        public int SVW_VOTES { get; set; }
        public int SVW_TOTAL_VOTES { get; set; }
    }
}
