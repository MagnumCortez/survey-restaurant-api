using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Entities
{
    [Table("STUDENT")]
    public class Student
    {
        [Key]
        public long STD_IDENTI { get; set; }
        public string STD_NAME { get; set; }
        public long STD_RA { get; set; }
        public string STD_PASSWORD { get; set; }
    }
}
