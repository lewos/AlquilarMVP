using AlquilarMVP.API.Models;
using AlquilarMVP.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlquilarMVP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyService _propertyService;
        private readonly ClaimService _claimService;

        public PropertiesController(PropertyService propertyService, ClaimService claimService)
        {
            _propertyService = propertyService;
            _claimService = claimService;
        }

        [HttpGet]
        public ActionResult<List<PropertyResponse>> Get() 
        {
           var properties = _propertyService.Get();
           return ConvertToPropertiesResponse(properties);
           
        }

        private ActionResult<List<PropertyResponse>> ConvertToPropertiesResponse(List<Property> properties)
        {
            var propertiesResponse = new List<PropertyResponse>();
            properties.ForEach(p => {
                propertiesResponse.Add(ConvertToPropertyResponse(p));
            });
            return propertiesResponse;
        }
        private PropertyResponse ConvertToPropertyResponse(Property p)
        {
            return new PropertyResponse
            {
                Id = p.Id,
                Address = p.Address,
                Province = p.Province,
                City = p.City,
                UnitType = p.UnitType,
                OperationType = p.OperationType,
                Price = p.Price,
                Currency = p.Currency,
                Expenses = p.Expenses,
                Floor = p.Floor,
                Apartment = p.Apartment,
                TotalArea = p.TotalArea,
                CoveredArea = p.CoveredArea,
                Rooms = p.Rooms,
                BathRooms = p.BathRooms,
                Garages = p.Garages,
                BedRooms = p.BedRooms,
                Age = p.Age,
                PropertyStatus = p.PropertyStatus,
                Description = p.Description,
                ImagePath = p.ImagePath,
                Services = p.Services,
                Installations = p.Installations,
                CurrentContract = p.CurrentContract,
                Contract = p.Contract,
                Tenant = p.Tenant,
                Owner = p.Owner,

                Status = p.Status.ToString(),

                ClaimsCount = p.ClaimsCount
            };
        }

        private int getClaims(Property p)
        {
            var claims =_claimService.GetByPropId(p.Id).FindAll(c => c.State != "Solucionado");
            return claims.Count;
        }

        [HttpGet("{id:length(24)}", Name = "GetProperty")]
        public ActionResult<PropertyResponse> Get(string id)
        {
            var property = _propertyService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            return ConvertToPropertyResponse(property);
            //return property;
        }

        [HttpGet]
        [Route("GetPropertyByAddress/{address}")]
        public ActionResult<List<PropertyResponse>> GetPropertyByAddress(string address)
        {
            var properties = _propertyService.GetByAddress(address);

            if (properties == null)
            {
                return NotFound();
            }

            return ConvertToPropertiesResponse(properties);
            //return properties;
        }

        [HttpGet]
        [Route("GetPropertyByOwnerId/{id}")]
        public ActionResult<List<PropertyResponse>> GetPropertyByOwnerId(string id)
        {
            var properties = _propertyService.GetByOwner(id);

            if (properties == null)
            {
                return NotFound();
            }

            foreach (var p in properties)
            {
                p.ClaimsCount = getClaims(p);
            }

            return ConvertToPropertiesResponse(properties);
            //return properties;
        }       

        [HttpGet]
        [Route("GetPropertyByTenantId/{id}")]
        public ActionResult<List<PropertyResponse>> GetPropertyByTenantId(string id)
        {
            var properties = _propertyService.GetByTenant(id);

            if (properties == null)
            {
                return NotFound();
            }

            foreach (var p in properties)
            {
                p.ClaimsCount = getClaims(p);
            }

            return ConvertToPropertiesResponse(properties);
            //return properties;
        }

        [HttpGet]
        [Route("Find/{any}")]
        public ActionResult<List<PropertyResponse>> Find(string any)
        {
            var properties = _propertyService.Find(any);

            if (properties == null)
            {
                return NotFound();
            }
             return ConvertToPropertiesResponse(properties);
            //return properties;
        }

        [HttpPost]
        public ActionResult<PropertyResponse> Create(Property property)
        {
            _propertyService.Create(property);

            return CreatedAtRoute("GetProperty", new { id = property.Id.ToString() }, ConvertToPropertyResponse(property));
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
