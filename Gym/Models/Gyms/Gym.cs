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

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
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
            this.athletes.ForEach(a => a.Exercise());
        }

        public string GymInfo()
            => $"{this.Name} is a {this.GetType().Name}:" + Environment.NewLine 
                + $"Athletes: {(athletes.Count == 0 ? "No athletes" : string.Join(", ", this.athletes))}" + Environment.NewLine
                + $"Equipment total count: {equipment.Count}" + Environment.NewLine
                + $"Equipment total weight: {EquipmentWeight} grams";

        public bool RemoveAthlete(IAthlete athlete)
            => this.athletes.Remove(athlete);
    }
}
