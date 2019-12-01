using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;

namespace Its.Onix.WebApi.Controllers.Masters
{
    //http://localhost:5001/Master/GetMasterList 

    [ApiController]
    [Route("api/Master/[controller]")]
    public class GetMasterListController : OnixControllerBase
    {
        public GetMasterListController(BaseDbContext ctx) : base(ctx, "GetMasterList")
        {
        }
    }   
}
