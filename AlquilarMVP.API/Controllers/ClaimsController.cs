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
        public ActionResult<List<ClaimResponse>> Get() 
        {
            var claims = _claimService.Get();

            claims = (from c in claims
                                 orderby c.CreationDate descending
                                 select c).ToList();

            var claimsResponse = ConvertToClaimsResponse(claims);


            return claimsResponse;
        }

        [HttpGet("{id:length(24)}", Name = "GetClaim")]
        public ActionResult<ClaimResponse> Get(string id)
        {
            var Claim = _claimService.Get(id);

            if (Claim == null)
            {
                return NotFound();
            }

            var claimResponse = ConvertToClaimResponse(Claim);
            return claimResponse;
        }


        [HttpGet]
        [Route("GetClaimsByPropId/{id}")]
        public ActionResult<List<ClaimResponse>> GetClaimsByPropId(string id)
        {
            var claims = _claimService.GetByPropId(id);

            if (claims == null)
            {
                return NotFound();
            }

            claims = (from c in claims
                                 orderby c.CreationDate descending
                                select c).ToList();

            List<ClaimResponse> claimsResponse = ConvertToClaimsResponse(claims);

            return claimsResponse;
        }

        [HttpPost]
        public ActionResult<ClaimResponse> Create(Claim Claim)
        {
            _claimService.Create(Claim);

            var claimResponse = ConvertToClaimResponse(Claim);

            return CreatedAtRoute("GetClaim", new { id = claimResponse.Id.ToString() }, claimResponse);
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




        private List<ClaimResponse> ConvertToClaimsResponse(List<Claim> claims)
        {
            var claimsResponse = new List<ClaimResponse>();
            claims.ForEach(c => {
                claimsResponse.Add(ConvertToClaimResponse(c));
            });
            return claimsResponse;
        }
        private ClaimResponse ConvertToClaimResponse(Claim c)
        {
            return new ClaimResponse
            {
                Id = c.Id,
                PropId = c.PropId,
                Title = c.Title,
                Description = c.Description,
                State = c.State,
                Priority = c.Priority,
                Comments = c.Comments,

                CreationDate = c.CreationDate.Date.ToString("MM/dd/yyyy"),
                ModifiedDate = c.ModifiedDate.Date.ToString("MM/dd/yyyy"),

                //CreationDate = c.CreationDate.Date.ToString("yyyy-MM-dd"),
                //ModifiedDate = c.ModifiedDate.Date.ToString("yyyy-MM-dd"),

                CreatedBy = c.CreatedBy,
            };
        }
    }
}
