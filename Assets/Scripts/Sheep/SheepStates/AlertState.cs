using SheepsWolf.Abstracts;
using UnityEngine;
using SheepsWolf.Spawners;

namespace SheepsWolf.Sheeps.Behaviors
{
    public class AlertState : ISheepState
    {

        private readonly Sheep sheep;
        private Vector3 dir;

        public AlertState(Sheep sheep)
        {
            this.sheep = sheep;
        }

        public void Execute()
        {
            if (dir == Vector3.zero)
            {
                dir = (sheep.transform.position - sheep.playerTransform.position) * 4;
                Debug.DrawLine(sheep.transform.position, sheep.playerTransform.position, Color.blue, 10f);
            }

            float step = Time.deltaTime * sheep.Speed;
            sheep.CurrentTransform.position = Vector3.MoveTowards(sheep.CurrentTransform.position, dir, step);
        }
            
    }
}
