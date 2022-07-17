using UnityEngine;
using SheepsWolf.Spawners;
using SheepsWolf.Abstracts;

namespace SheepsWolf.Sheeps.Behaviors
{
    public class NormalState : ISheepState
    {
        private readonly Sheep sheep;

        private Vector3 destination;
        public Vector3 Destination => destination;

        public bool IsOnWay { get; set; }

        public NormalState(Sheep sheep)
        {
            this.sheep = sheep;
            destination = RandomPosition.instance.GetRandomPosition();
            IsOnWay = true;
        }

        public void Execute()
        {
            if (IsOnWay)
            {
                sheep.transform.position = Vector3.MoveTowards(
                                            sheep.transform.position
                                            ,destination
                                            ,Time.deltaTime * sheep.Speed);
            }
            else
            {
                IsOnWay = true;
                destination = RandomPosition.instance.GetRandomPosition();
            }
     
        }
    }
}
