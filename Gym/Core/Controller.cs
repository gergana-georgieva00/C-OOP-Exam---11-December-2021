using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
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
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }
            if ((athleteType == "Boxer" && gymName == "WeightliftingGym") || (athleteType == "Weightlifter" && gymName == "BoxingGym"))
            {
                return "The gym is not appropriate.";
            }

            IAthlete athlete;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            this.gyms.Find(g => g.Name == gymName).AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";
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
            => $"The total weight of the equipment in the gym {gymName} is {(gyms.Find(g => g.Name == gymName).EquipmentWeight):f2} grams.";

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
            var gym = gyms.Find(g => g.Name == gymName);
            gym.Exercise();

            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
