using System;
using System.Collections.Generic;

namespace AtividadePraticaTCS.Models.ViewModels
{
    public class MachineFormViewModel
    {
        public Machine Machine { get; set; }
        public ICollection<Status> Status { get; set; }
    }
}
