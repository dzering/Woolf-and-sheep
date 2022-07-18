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
            if (IsOnWay)
            {
                float step = Time.deltaTime * sheep.Speed;
                Vector3 currentPosition = sheep.transform.position;
                sheep.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);

            }
            else
            {
                IsOnWay = true;

                Vector3 playerPosition = sheep.PlayerTransform.position;
                playerPosition.y = sheep.transform.position.y;

                dir = (sheep.transform.position - playerPosition).normalized * 2;
                targetPosition = sheep.transform.position + dir;
                targetPosition = Quaternion.AngleAxis(Random.Range(-15,15), Vector3.up) * targetPosition;
                AreaOffBoard(targetPosition);

                

                Debug.DrawLine(Vector3.zero, sheep.transform.position, Color.green, 10f);
                Debug.DrawLine(Vector3.zero, sheep.PlayerTransform.position, Color.green, 10f);
                Debug.DrawLine(sheep.transform.position, sheep.PlayerTransform.position, Color.blue, 10f);
                Debug.DrawLine(sheep.transform.position, targetPosition, Color.red, 10f);
            }
        }

        private void AreaOffBoard(Vector3 position) 
        {
            AreaBounds areaBounds = AreaGame.instance.Bounds;

            bool x = (position.x < areaBounds.Left || position.x > areaBounds.Right);
            bool z = (position.z < areaBounds.Bottom || position.z > areaBounds.Top);
            Debug.Log($"x = {x}, z = {z}");

            if (x || z)
            {
                Debug.Log($"x = {x}, z = {z}");
                Debug.Log("New logic for destination");
                targetPosition = AreaGame.instance.GetRandomPosition();
                return;
            }

        }
            
    }
}
