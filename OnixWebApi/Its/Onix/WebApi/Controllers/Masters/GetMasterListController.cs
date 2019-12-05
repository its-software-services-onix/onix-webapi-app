using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.WebApi.Controllers.Masters
{
    [ApiController]
    [Route("api/Master/[controller]")]
    public class GetMasterListController : OnixGetListController
    {
        public GetMasterListController(BaseDbContext ctx) : base(ctx, "GetMasterList", "MasterId", typeof(Master))
        {
        }
    }   
}
