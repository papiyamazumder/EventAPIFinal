using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEntity
{
    public class UserModel //DbSet<UserMode>
    {
        [Key]// -identifiing id is primary key

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]// we can manually add id bye using None
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // otherwise by default is identity field
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //dataAnnotations:usedfor validation
        public int Id { get; set; }//defaul is Pk-- None- it is Pk but not identity field, we have to pass value manually

        [Required]//- validation :the name cannot be null
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Range(20, int.MaxValue)]//setting min and max value of phone number
        public int phone { get; set; }

    }
}
