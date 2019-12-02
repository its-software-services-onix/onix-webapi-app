using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.WebApi.Controllers.Masters
{
    [ApiController]
    [Route("api/Master/[controller]")]
    public class SaveMasterController : OnixControllerBase
    {
        public SaveMasterController(BaseDbContext ctx) : base(ctx, "SaveMaster", "MasterId", typeof(Master))
        {
        }
    }   
}
