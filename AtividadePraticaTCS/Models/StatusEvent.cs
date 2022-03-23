using System;
using System.Collections.Generic;

namespace AtividadePraticaTCS.Models
{
    public class StatusEvent
    {
        public int Id { get; set; }
        public string CodeStatus { get; set; }
        public int MachineId { get; set; }
        public DateTime Date { get; set; }

        public StatusEvent()
        {
        }
        public StatusEvent(int id, string codeStatus, DateTime date)
        {
            Id = id;
            CodeStatus = codeStatus;
            Date = date;
        }
    }
}
