using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.WebApi.Controllers.Masters
{
    [ApiController]
    [Route("api/Master/[controller]")]
    public class GetMasterInfoController : OnixGetInfoController
    {
        public GetMasterInfoController(BaseDbContext ctx) : base(ctx, "GetMasterInfo", "MasterId", typeof(Master))
        {
        }          
    }   
}
