using Microsoft.AspNetCore.Mvc;
using Its.Onix.Core.Databases;
using Its.Onix.WebApi.Controllers.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.WebApi.Controllers.CompanyProfiles
{
    [ApiController]
    [Route("api/CompanyProfile/[controller]")]
    public class SaveCompanyProfileController : OnixSaveController
    {
        public SaveCompanyProfileController(BaseDbContext ctx) : base(ctx, "SaveCompanyProfile", "CompanyProfileId", typeof(CompanyProfile))
        {
        }
    }   
}
