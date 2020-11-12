using AlquilarMVP.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AlquilarMVP.API.Services
{
    public class ClaimService
    {
        private readonly IMongoCollection<Claim> _claims;

        public ClaimService(IAlquilarDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _claims = database.GetCollection<Claim>(settings.ClaimsCollectionName);
        }

        public List<Claim> Get() =>
            _claims.Find(Claim => true).ToList();

        public Claim Get(string id) =>
            _claims.Find<Claim>(Claim => Claim.Id == id).FirstOrDefault();

        public List<Claim> GetByPropId(string id) =>
            _claims.Find<Claim>(claim => claim.PropId == id).ToList();

        public Claim Create(Claim Claim)
        {
            var fecha = DateTime.Now.ToLocalTime();
            Claim.CreationDate = Claim.CreationDate;
            Claim.ModifiedDate = fecha;
            _claims.InsertOne(Claim);
            return Claim;
        }

        public void Update(string id, Claim ClaimIn) =>
            _claims.ReplaceOne(Claim => Claim.Id == id, ClaimIn);

        public void UpdateComments(string id, Claim OldClaim, Claim ClaimIn) 
        {
            if (ClaimIn.Comments?.Count() > 0 && ClaimIn.Comments?.Count() == 1) 
            {
                if (OldClaim.Comments == null) 
                {
                    OldClaim.Comments = new List<Comment>();
                }
                OldClaim.Comments.Add(ClaimIn.Comments[0]);
                _claims.ReplaceOne(Claim => Claim.Id == id, OldClaim);
            }
        }

        public void UpdateState(string id, Claim OldClaim, Claim ClaimIn)
        {
            if (!string.IsNullOrEmpty(ClaimIn.State))
            {
                OldClaim.State = ClaimIn.State;
                OldClaim.ModifiedDate = DateTime.Now.ToLocalTime();
                _claims.ReplaceOne(Claim => Claim.Id == id, OldClaim);
            }
        }

        public void Remove(Claim ClaimIn) =>
            _claims.DeleteOne(Claim => Claim.Id == ClaimIn.Id);

        public void Remove(string id) =>
            _claims.DeleteOne(Claim => Claim.Id == id);
    }
}
