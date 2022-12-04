
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.CalculateWeight();

        private double CalculateWeight()
        {
            double result = 0;
            this.equipment.ForEach(e => result += e.Weight);
            return result;
        }

        public ICollection<IEquipment> Equipment => this.equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => this.athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (this.athletes.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            this.athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            if (this.GetType().Name == "WeightliftingGym")
            {
                this.athletes.Where(a => a.GetType().Name == "Weightlifter").ToList().ForEach(a => a.Exercise());
            }
            else
            {
                this.athletes.Where(a => a.GetType().Name == "Boxer").ToList().ForEach(a => a.Exercise());
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();

            var athleteNames = new List<string>();
            foreach (var athlete in this.athletes)
                athleteNames.Add(athlete.FullName);

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {(athletes.Count == 0 ? "No athletes" : string.Join(", ", athleteNames))}");
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }
        
        public bool RemoveAthlete(IAthlete athlete)
            => this.athletes.Remove(athlete);
    }
}
