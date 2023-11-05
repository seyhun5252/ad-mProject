using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FormElement
    {
        [Key]
        public int Id { get; set; }
        public string ElementName { get; set; }
        public string ElementType { get; set; }
        public bool IsRequired { get; set; }
        public string Description { get; set; }
        public int MVCFormDataId { get; set; }
    }
}
