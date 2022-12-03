using Gym.Models.Gyms.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IGym>
    {
        private List<IGym> models;

        public EquipmentRepository()
        {
            this.models = new List<IGym>();
        }

        public IReadOnlyCollection<IGym> Models => this.models.AsReadOnly();

        public void Add(IGym model)
        {
            throw new NotImplementedException();
        }

        public IGym FindByType(string type)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IGym model)
        {
            throw new NotImplementedException();
        }
    }
}
