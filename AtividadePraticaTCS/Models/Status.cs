using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtividadePraticaTCS.Models
{
    public class Status 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} size should be between {2} and {1}.")]
        public string Name { get; set; }
        public Status()
        {
        }

        public Status(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public Status(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
