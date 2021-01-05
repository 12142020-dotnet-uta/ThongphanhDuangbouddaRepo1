using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class TicketNumber
    {
        private int ticketNumber;
        [Key]
        public int TicketId
        {
            get => ticketNumber;
            set => ticketNumber = value;
        }
    }
}
