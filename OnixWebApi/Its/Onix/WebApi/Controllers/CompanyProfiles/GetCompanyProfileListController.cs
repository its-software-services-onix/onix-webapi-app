using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.WebApi.Controllers.CompanyProfiles
{
    [ApiController]
    [Route("api/CompanyProfile/[controller]")]
    public class GetCompanyProfileListController : OnixGetListController
    {
        public GetCompanyProfileListController(BaseDbContext ctx) : base(ctx, "GetCompanyProfileList", "CompanyProfileId", typeof(CompanyProfile))
        {
        }
    }   
}
