using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace English.Models
{
    public class Word
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]        
        public string WordText { get; set; }
        public string Translation { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public virtual IEnumerable<Example> Examples{ get; set; }
    }
    public class Example
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string ExampleText { get; set; }
        [DataType(DataType.MultilineText)]
        public string ExampleTranslation { get; set; }
        public int WordID { get; set; }
    }
}
