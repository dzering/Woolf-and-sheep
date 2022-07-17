using SheepsWolf.Abstracts;
using UnityEngine;
using SheepsWolf.Spawners;

namespace SheepsWolf.Sheeps.Behaviors
{
    public class AlertState : ISheepState
    {

        private readonly ISheep sheep;

        public AlertState(ISheep sheep)
        {
            this.sheep = sheep;
        }

        public void Execute()
        {
            float step = Time.deltaTime * sheep.Speed;
            sheep.CurrentTransform.position = Vector3.MoveTowards(sheep.CurrentTransform.position, Vector3.zero, step);
        }

        public void Execute(Vector3 dir)
        {
            
        }
    }
}
