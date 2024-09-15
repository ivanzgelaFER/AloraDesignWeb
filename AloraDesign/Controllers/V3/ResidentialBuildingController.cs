using System.Security.Claims;
using AutoMapper;
using AloraDesign.Data;
using AloraDesign.Data.Helpers;
using AloraDesign.Data.Services;
using AloraDesign.Domain.DTOs;
using AloraDesign.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AloraDesign.Controllers.V3
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ResidentialBuildingController : ControllerBase
    {
        private readonly AppUserManager userManager;
        private readonly IMapper mapper;
        private readonly BuildingsContext context;
        private readonly IResidentialBuildingService residentialBuildingService;

        public ResidentialBuildingController(AppUserManager userManager, BuildingsContext context, IMapper mapper, IResidentialBuildingService residentialBuildingService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.context = context;
            this.residentialBuildingService = residentialBuildingService;
        }
        [HttpGet("all")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetResidentialBuildings()
        {
            AppUser user = await context.Users.SingleOrDefaultAsync(u => u.Guid == Guid.Parse(User.FindFirstValue("guid")));
            return Ok(await residentialBuildingService.GetResidentialBuildings(user));
        }

        [HttpGet("{guid}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetResidentialBuildingByGuid([FromRoute] Guid guid)
        {
            return Ok(await residentialBuildingService.GetResidentialBuildingByGuid(guid));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateResidentialBuilding([FromBody] NewResidentialBuildingDto dto)
        {
            AppUser user = await context.Users.SingleOrDefaultAsync(u => u.Guid == Guid.Parse(User.FindFirstValue("guid")));
            await residentialBuildingService.CreateResidentialBuilding(dto, user);
            return Ok();
        }

        [HttpPatch]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> PatchResidentialBuilding([FromBody] ResidentialBuildingDto dto)
        {
            AppUser user = await context.Users.SingleOrDefaultAsync(u => u.Guid == Guid.Parse(User.FindFirstValue("guid")));
            bool isSuperAdmin = await userManager.IsInRoleAsync(user, "SuperAdmin");
            return Ok(await residentialBuildingService.EditResidentialBuilding(dto));
        }


        [HttpDelete("{guid}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteResidentialBuilding([FromRoute] Guid guid)
        {
            AppUser user = await context.Users.SingleOrDefaultAsync(u => u.Guid == Guid.Parse(User.FindFirstValue("guid")));
            await residentialBuildingService.DeleteResidentialBuilding(guid, user.ResidentialBuildingId);
            return Ok();
        }
    }
}
