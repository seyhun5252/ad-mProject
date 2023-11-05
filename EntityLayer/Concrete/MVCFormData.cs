using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MVCFormData
    {
        [Key]
        public int Id { get; set; }
        public string FormName { get; set; }
        public List<FormElement> FormElements { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
