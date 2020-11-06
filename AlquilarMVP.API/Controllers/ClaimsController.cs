using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlquilarMVP.API.Models;
using AlquilarMVP.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlquilarMVP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly ClaimService _claimService;

        public ClaimsController(ClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        public ActionResult<List<Claim>> Get() =>
            _claimService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClaim")]
        public ActionResult<Claim> Get(string id)
        {
            var Claim = _claimService.Get(id);

            if (Claim == null)
            {
                return NotFound();
            }

            return Claim;
        }


        [HttpGet]
        [Route("GetClaimsByPropId/{id}")]
        public ActionResult<List<Claim>> GetClaimsByPropId(string id)
        {
            var claims = _claimService.GetByPropId(id);

            if (claims == null)
            {
                return NotFound();
            }

            return claims;
        }

        [HttpPost]
        public ActionResult<Claim> Create(Claim Claim)
        {
            _claimService.Create(Claim);

            return CreatedAtRoute("GetClaim", new { id = Claim.Id.ToString() }, Claim);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Claim ClaimIn)
        {
            var Claim = _claimService.Get(id);

            if (Claim == null)
            {
                return NotFound();
            }

            _claimService.Update(id, ClaimIn);

            return NoContent();
        }

        //agregar comentario
        [HttpPut]
        [Route("UpdateClaimComments/{id}")]
        public IActionResult UpdateClaimComments(string id, Claim ClaimIn)
        {
            var Claim = _claimService.Get(id);

            if (Claim == null)
            {
                return NotFound();
            }

            _claimService.UpdateComments(id, Claim, ClaimIn);

            return NoContent();
        }

        //modificar estado
        [HttpPut]
        [Route("UpdateClaimState/{id}")]
        public IActionResult UpdateClaimState(string id, Claim ClaimIn)
        {
            var Claim = _claimService.Get(id);

            if (Claim == null)
            {
                return NotFound();
            }

            _claimService.UpdateState(id, Claim, ClaimIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Claim = _claimService.Get(id);

            if (Claim == null)
            {
                return NotFound();
            }

            _claimService.Remove(Claim.Id);

            return NoContent();
        }
    }
}
