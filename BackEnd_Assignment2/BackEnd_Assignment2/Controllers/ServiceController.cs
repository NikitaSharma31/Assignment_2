using BackEnd_Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
      
        private readonly AdventureWorks2017Context _DbContext;
        public ServiceController(AdventureWorks2017Context DbContext)
        {
            _DbContext = DbContext;
        }
        [HttpGet]
        [Route("Get")]
        public IEnumerable<NikitaConnectionService> Get()
        {
            var result = _DbContext.NikitaConnectionServices.ToList();
            return result;

        }
        [HttpGet]
        [Route("Get/{id}")]
        public IEnumerable<NikitaConnectionService> GetById(int id)
        {
            var res = _DbContext.NikitaConnectionServices.FirstOrDefault(a => a.Id == id);
            yield return res;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IEnumerable<NikitaConnectionService> Delete(int id)
        {
            var res = _DbContext.NikitaConnectionServices.FirstOrDefault(a => a.Id == id);
            if (res != null)
            {
                _DbContext.Remove(res);
                _DbContext.SaveChanges();
            }
            yield return res;
        }




        [HttpPost]
        [Route("Add")]
        public IEnumerable<NikitaConnectionService> Post([FromBody] NikitaConnectionService nikitaConnectionService)
        {

            NikitaConnectionService service = new NikitaConnectionService();
            service.Id = nikitaConnectionService.Id;
            service.ProtocolTypeId = nikitaConnectionService.ProtocolTypeId;
            service.ServiceName = nikitaConnectionService.ServiceName;
            service.ServiceDescription = nikitaConnectionService.ServiceDescription;
            service.AdvanceTracking = nikitaConnectionService.AdvanceTracking;
            service.OperationName = nikitaConnectionService.OperationName;
            service.OperationReturnTypeId = nikitaConnectionService.OperationReturnTypeId;
            service.IsOperationReturnNullable = nikitaConnectionService.IsOperationReturnNullable;
            service.OperationListType = nikitaConnectionService.OperationListType;
            service.VerbId = nikitaConnectionService.VerbId;
            service.OverrideId = nikitaConnectionService.OverrideId;
            service.ParameterName = nikitaConnectionService.ParameterName;
            service.ParameterTypeId = nikitaConnectionService.ParameterTypeId;
            service.IsParameterTypeNullable = nikitaConnectionService.IsParameterTypeNullable;
            service.ParameterListType = nikitaConnectionService.ParameterListType;
            _DbContext.NikitaConnectionServices.Add(service);

            _DbContext.SaveChanges();
           yield return service;

            
        }
        [HttpPut]
        [Route("Edit/{id}")]
        public IEnumerable<NikitaConnectionService> Put([FromBody] NikitaConnectionService nikitaConnectionService,int id)
        {
                var service = _DbContext.NikitaConnectionServices.FirstOrDefault(a => a.Id== id);
                if (service == null)
                {
                     yield return null;
                }
                else
                {
                    service.ProtocolTypeId = nikitaConnectionService.ProtocolTypeId;
                    service.ServiceName = nikitaConnectionService.ServiceName;
                    service.ServiceDescription = nikitaConnectionService.ServiceDescription;
                    service.AdvanceTracking = nikitaConnectionService.AdvanceTracking;
                    service.OperationName = nikitaConnectionService.OperationName;
                    service.OperationReturnTypeId = nikitaConnectionService.OperationReturnTypeId;
                    service.IsOperationReturnNullable = nikitaConnectionService.IsOperationReturnNullable;
                    service.OperationListType = nikitaConnectionService.OperationListType;
                    service.VerbId = nikitaConnectionService.VerbId;
                    service.OverrideId = nikitaConnectionService.OverrideId;
                    service.ParameterName = nikitaConnectionService.ParameterName;
                    service.ParameterTypeId = nikitaConnectionService.ParameterTypeId;
                    service.IsParameterTypeNullable = nikitaConnectionService.IsParameterTypeNullable;
                    service.ParameterListType = nikitaConnectionService.ParameterListType;
                    _DbContext.Entry(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _DbContext.SaveChanges();

            }
            yield return (service);


        }
    }
}
