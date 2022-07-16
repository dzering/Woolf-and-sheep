using UnityEngine;
using SheepsWolf.Spawners;
using SheepsWolf.Abstracts;

namespace SheepsWolf.Sheeps.States
{
    public class NormalState : ISheepState
    {
        private readonly Sheep sheep;
        public StateBehavior StateBehavior => StateBehavior.Walk;


        public NormalState(Sheep sheep)
        {
            this.sheep = sheep;
        }

        public void Execute()
        {
            sheep.Agent.destination = RandomPosition.instance.GetRandomPosition();
        }
    }
}
