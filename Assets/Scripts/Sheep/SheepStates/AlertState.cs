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
                dir = (sheep.transform.position - sheep.playerTransform.position).normalized * 4;

                Debug.DrawLine(Vector3.zero, sheep.transform.position, Color.green, 10f);
                Debug.DrawLine(Vector3.zero, sheep.playerTransform.position, Color.green, 10f);
                Debug.DrawLine(sheep.transform.position, sheep.playerTransform.position, Color.blue, 10f);
                Debug.DrawLine(sheep.transform.position, dir, Color.red, 10f);
            }

            float step = Time.deltaTime * sheep.Speed;

            sheep.transform.position = Vector3.MoveTowards(sheep.transform.position, sheep.transform.position + dir, step);
        }
            
    }
}
