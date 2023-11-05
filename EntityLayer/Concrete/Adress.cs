using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Adress 
    {
        [Key]
        public int Id { get; set; }
        public string adressName { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
