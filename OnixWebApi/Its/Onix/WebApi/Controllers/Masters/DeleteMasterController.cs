using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.WebApi.Controllers.Masters
{
    [ApiController]
    [Route("api/Master/[controller]")]
    public class DeleteMasterController : OnixControllerBase
    {
        public DeleteMasterController(BaseDbContext ctx) : base(ctx, "DeleteMaster", "MasterId", typeof(Master))
        {
        }
    }   
}
