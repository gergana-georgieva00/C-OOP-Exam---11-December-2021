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
            this.models.Add(model);
        }

        public IGym FindByType(string type)
            => this.models.Find(m => m.GetType().Name == type);

        public bool Remove(IGym model)
            => this.models.Remove(model);
    }
}
