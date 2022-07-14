using SheepsWolf.Sheeps;
using SheepsWolf.Abstracts;
using UnityEngine;
using SheepsWolf.Spawners;

namespace SheepsWolf.Sheeps.States
{
    public class NormalState : ISheepState
    {
        public void Execute(Sheep sheep)
        {
            Debug.Log($"Sheep {sheep.name} is walking.");
            sheep.Agent.destination = RandomPosition.instance.GetRandomPosition();
        }
    }

    public class AlertState : ISheepState
    {
        public void Execute(Sheep sheep)
        {
            Debug.Log($"Sheep {sheep.name} is runing.");
            sheep.Agent.destination = RandomPosition.instance.GetRandomPosition();
        }
    }
}
