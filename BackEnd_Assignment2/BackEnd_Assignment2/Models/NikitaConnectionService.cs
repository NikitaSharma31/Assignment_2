using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BackEnd_Assignment2.Models
{
    public partial class NikitaConnectionService
    {
        [Key]
        public int Id { get; set; }
        public int ProtocolTypeId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public bool? AdvanceTracking { get; set; }
        public string OperationName { get; set; }
        public int OperationReturnTypeId { get; set; }
        public bool? IsOperationReturnNullable { get; set; }
        public string OperationListType { get; set; }
        public int VerbId { get; set; }
        public int OverrideId { get; set; }
        public string ParameterName { get; set; }
        public int ParameterTypeId { get; set; }
        public bool? IsParameterTypeNullable { get; set; }
        public string ParameterListType { get; set; }

        public virtual NikitaOperationReturnTypeLookup OperationReturnType { get; set; }
        public virtual NikitaOperationReturnTypeLookup Override { get; set; }
        public virtual NikitaOperationReturnTypeLookup ParameterType { get; set; }
        public virtual NikitaProtocolTypeLookup ProtocolType { get; set; }
        public virtual NikitaOperationReturnTypeLookup Verb { get; set; }
    }
}
