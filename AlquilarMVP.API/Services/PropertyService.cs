using AlquilarMVP.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Services
{
    public class PropertyService
    {
        private readonly IMongoCollection<Property> _properties;

        public PropertyService(IAlquilarDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _properties = database.GetCollection<Property>(settings.PropertiesCollectionName);
        }

        public List<Property> Get() =>
            _properties.Find(property => true).ToList();

        public Property Get(string id) =>
            _properties.Find<Property>(property => property.Id == id).FirstOrDefault();

        public List<Property> GetByAddress(string address) =>
            _properties.Find<Property>(property => property.Address.ToLower().Contains(address.ToLower())).ToList();

        public List<Property> Find(string any) 
        {
            if (double.TryParse(any, out double algo)) {

                return _properties.Find<Property>(property =>

                    property.Price.Equals(algo) ||
                    property.Expenses.Equals(algo)

                ).ToList();
            }
            else 
            {
                return _properties.Find<Property>(property =>
                    property.Address.ToLower().Contains(any.ToLower()) ||
                    property.Description.ToLower().Contains(any.ToLower()) ||
                    property.PropertyStatus.ToLower().Contains(any.ToLower()) ||

                    property.UnitType.ToLower().Contains(any.ToLower()) ||
                    property.OperationType.ToLower().Contains(any.ToLower()) ||

                    property.TotalArea.ToLower().Contains(any.ToLower()) ||
                    property.CoveredArea.ToLower().Contains(any.ToLower()) ||

                    property.Services.Any(s => s.ToLower().Contains(any.ToLower())) ||
                    property.Installations.Any(i => i.ToLower().Contains(any.ToLower()))
                ).ToList();
            }

        }
            

        public Property Create(Property property)
        {
            _properties.InsertOne(property);
            return property;
        }

        public void Update(string id, Property propertyIn) =>
            _properties.ReplaceOne(property => property.Id == id, propertyIn);

        public void Remove(Property propertyIn) =>
            _properties.DeleteOne(property => property.Id == propertyIn.Id);

        public void Remove(string id) =>
            _properties.DeleteOne(property => property.Id == id);
    }
}
