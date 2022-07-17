using SheepsWolf.Abstracts;
using UnityEngine;
using SheepsWolf.Spawners;

namespace SheepsWolf.Sheeps.Behaviors
{
    public class AlertState : ISheepState
    {

        private readonly Sheep sheep;
        private Vector3 dir;
        private Vector3 targetPosition;
        public bool IsOnWay { get; set; }

        public Vector3 Destination => targetPosition;

        public AlertState(Sheep sheep)
        {
            this.sheep = sheep;
        }

        public void Execute()
        {
            //if (destination == Vector3.zero)
            //{
            //    destination = (sheep.transform.position - sheep.playerTransform.position).normalized * 4;
            //    targetPosition = sheep.transform.position + destination;

            //    Debug.DrawLine(Vector3.zero, sheep.transform.position, Color.green, 10f);
            //    Debug.DrawLine(Vector3.zero, sheep.playerTransform.position, Color.green, 10f);
            //    Debug.DrawLine(sheep.transform.position, sheep.playerTransform.position, Color.blue, 10f);
            //    Debug.DrawLine(sheep.transform.position, targetPosition, Color.red, 10f);
            //}
            if (IsOnWay)
            {
                float step = Time.deltaTime * sheep.Speed;
                Vector3 currentPosition = sheep.transform.position;
                sheep.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);
                Debug.Log($"{currentPosition} - {targetPosition}");
            }
            else
            {
                IsOnWay = true;
                dir = (sheep.transform.position - sheep.playerTransform.position).normalized * 4;
                targetPosition = sheep.transform.position + dir;





                Debug.DrawLine(Vector3.zero, sheep.transform.position, Color.green, 10f);
                Debug.DrawLine(Vector3.zero, sheep.playerTransform.position, Color.green, 10f);
                Debug.DrawLine(sheep.transform.position, sheep.playerTransform.position, Color.blue, 10f);
                Debug.DrawLine(sheep.transform.position, targetPosition, Color.red, 10f);
            }
        }
            
    }
}
