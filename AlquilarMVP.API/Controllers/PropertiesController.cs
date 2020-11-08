using AlquilarMVP.API.Models;
using AlquilarMVP.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlquilarMVP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public PropertiesController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public ActionResult<List<Property>> Get() =>
            _propertyService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProperty")]
        public ActionResult<Property> Get(string id)
        {
            var property = _propertyService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            return property;
        }

        [HttpGet]
        [Route("GetPropertyByAddress/{address}")]
        public ActionResult<List<Property>> GetPropertyByAddress(string address)
        {
            var properties = _propertyService.GetByAddress(address);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }

        [HttpGet]
        [Route("GetPropertyByOwnerId/{id}")]
        public ActionResult<List<Property>> GetPropertyByOwnerId(string id)
        {
            var properties = _propertyService.GetByOwner(id);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }

        [HttpGet]
        [Route("GetPropertyByTenantId/{id}")]
        public ActionResult<List<Property>> GetPropertyByTenantId(string id)
        {
            var properties = _propertyService.GetByTenant(id);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }

        [HttpGet]
        [Route("Find/{any}")]
        public ActionResult<List<Property>> Find(string any)
        {
            var properties = _propertyService.Find(any);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }

        [HttpPost]
        public ActionResult<Property> Create(Property property)
        {
            _propertyService.Create(property);

            return CreatedAtRoute("GetProperty", new { id = property.Id.ToString() }, property);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Property propertyIn)
        {
            var property = _propertyService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            _propertyService.Update(id, propertyIn);

            return NoContent();
        }

        [HttpPut]
        [Route("UpdateContrat/{id}")]
        public IActionResult UpdateContrat(string id, Property propertyIn)
        {
            var property = _propertyService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            var resultado = _propertyService.UpdateContract(id, property, propertyIn);

            if (resultado)
                return Ok(resultado);
            else
                return Conflict(resultado);
        }

        [HttpPut]
        [Route("UpdateCurrentContrat/{id}")]
        public IActionResult UpdateCurrentContrat(string id, Property propertyIn)
        {
            var property = _propertyService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            var resultado = _propertyService.UpdateCurrentContract(id, property, propertyIn);

            if (resultado)
                return Ok(resultado);
            else
                return Conflict(resultado);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var property = _propertyService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            _propertyService.Remove(property.Id);

            return NoContent();
        }
    }
}
