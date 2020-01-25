using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.WebApi.Controllers.CompanyProfiles
{
    [ApiController]
    [Route("api/CompanyProfile/[controller]")]
    public class GetCompanyProfileInfoController : OnixGetInfoController
    {
        public GetCompanyProfileInfoController(BaseDbContext ctx) : base(ctx, "GetCompanyProfileInfo", "CompanyProfileId", typeof(CompanyProfile))
        {
        }          
    }   
}
