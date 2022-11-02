using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd_Assignment2.Models
{
    public partial class NikitaProtocolTypeLookup
    {
        public NikitaProtocolTypeLookup()
        {
            NikitaConnectionServices = new HashSet<NikitaConnectionService>();
        }

        public int Id { get; set; }
        public string ProtocolType { get; set; }

        public virtual ICollection<NikitaConnectionService> NikitaConnectionServices { get; set; }
    }
}
