using Gym.Core.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            throw new NotImplementedException();
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            switch (equipmentType)
            {
                case "BoxingGloves":
                    equipment = new BoxingGloves();
                    break;
                case "Kettlebell":
                    equipment = new Kettlebell();
                    break;
                default:
                    throw new InvalidOperationException("Invalid equipment type.");
            }

            this.equipment.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            switch (gymType)
            {
                case "BoxingGym":
                    gym = new BoxingGym(gymName);
                    break;
                case "WeightliftingGym":
                    gym = new WeightliftingGym(gymName);
                    break;
                default:
                    throw new InvalidOperationException("Invalid gym type.");
            }

            this.gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            throw new NotImplementedException();
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (this.equipment.FindByType(equipmentType) is null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            this.gyms.Find(g => g.Name == gymName).AddEquipment(this.equipment.FindByType(equipmentType));
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string TrainAthletes(string gymName)
        {
            throw new NotImplementedException();
        }
    }
}
