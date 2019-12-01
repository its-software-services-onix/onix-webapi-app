using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.WebApi.Controllers.Masters
{
    //http://localhost:5001/Master/GetMasterInfo/{id}
    
    [ApiController]
    [Route("api/Master/[controller]")]
    public class GetMasterInfoController : OnixControllerBase
    {
        public GetMasterInfoController(BaseDbContext ctx) : base(ctx, "GetMasterInfo", "MasterId", typeof(Master))
        {
        }          
    }   
}
