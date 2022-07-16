using SheepsWolf.Abstracts;
using UnityEngine;
using SheepsWolf.Spawners;

namespace SheepsWolf.Sheeps.States
{
    public class AlertState : ISheepState
    {

        private readonly Sheep sheep;
        public StateBehavior StateBehavior => StateBehavior.Walk;


        public AlertState(Sheep sheep)
        {
            this.sheep = sheep;
        }

        public void Execute()
        {
            sheep.Agent.destination = RandomPosition.instance.GetRandomPosition();
        }
    }
}
