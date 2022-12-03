using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym()
        {

        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public double EquipmentWeight { get; private set; }

        public ICollection<IEquipment> Equipment => this.equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => this.athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            throw new NotImplementedException();
        }

        public void AddEquipment(IEquipment equipment)
        {
            throw new NotImplementedException();
        }

        public void Exercise()
        {
            throw new NotImplementedException();
        }

        public string GymInfo()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            throw new NotImplementedException();
        }
    }
}
