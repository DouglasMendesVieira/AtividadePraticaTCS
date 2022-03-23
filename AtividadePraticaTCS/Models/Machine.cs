using System.ComponentModel.DataAnnotations;

namespace AtividadePraticaTCS.Models
{
    public class Machine
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} size should be between {2} and {1}.")]
        public string Name { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }

        public Machine()
        {
        }

        public Machine(int id, string name, Status status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}
