using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals, int stamina) : base(fullName, motivation, numberOfMedals, stamina)
        {
        }

        public override void Exercise()
        {
            throw new NotImplementedException();
        }
    }
}
