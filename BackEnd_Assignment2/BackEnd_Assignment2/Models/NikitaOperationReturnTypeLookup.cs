using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd_Assignment2.Models
{
    public partial class NikitaOperationReturnTypeLookup
    {
        public NikitaOperationReturnTypeLookup()
        {
            NikitaConnectionServiceOperationReturnTypes = new HashSet<NikitaConnectionService>();
            NikitaConnectionServiceOverrides = new HashSet<NikitaConnectionService>();
            NikitaConnectionServiceParameterTypes = new HashSet<NikitaConnectionService>();
            NikitaConnectionServiceVerbs = new HashSet<NikitaConnectionService>();
        }

        public int Id { get; set; }
        public string OperationReturnType { get; set; }

        public virtual ICollection<NikitaConnectionService> NikitaConnectionServiceOperationReturnTypes { get; set; }
        public virtual ICollection<NikitaConnectionService> NikitaConnectionServiceOverrides { get; set; }
        public virtual ICollection<NikitaConnectionService> NikitaConnectionServiceParameterTypes { get; set; }
        public virtual ICollection<NikitaConnectionService> NikitaConnectionServiceVerbs { get; set; }
    }
}
