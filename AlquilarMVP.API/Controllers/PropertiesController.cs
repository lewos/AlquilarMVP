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
            var book = _propertyService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
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
