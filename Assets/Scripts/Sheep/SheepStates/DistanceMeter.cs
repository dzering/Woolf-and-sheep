using UnityEngine;
using SheepsWolf.Abstracts;
using SheepsWolf.Spawners;

namespace SheepsWolf.Sheeps.States
{
    public class DistanceMeter
    {
        private Transform targetTransform;
        private Sheep sheep;

        public DistanceMeter(Sheep sheep)
        {
            targetTransform = GameObject.FindObjectOfType<Player>().transform;
            this.sheep = sheep;
        }
        public void Execute()
        {
            float distanceToPlayer = MeasureDistance(targetTransform.position, sheep.transform.position);
            float distanceToDestination = MeasureDistance(sheep.Agent.destination, sheep.transform.position);

            if (distanceToDestination < 1f)
            {
                sheep.CurrentState.Execute();
            }


            if(sheep.CurrentState.StateBehavior == StateBehavior.Walk && distanceToPlayer <= 2f)
            {
                sheep.Running();
                sheep.CurrentState.Execute();
                Debug.Log($"{sheep.name} is running");
            }

            if(sheep.CurrentState.StateBehavior == StateBehavior.Run || distanceToPlayer > 4f)
            {
                sheep.Walking();
                Debug.Log($"{sheep.name} is walking");
            }
        }

        private float MeasureDistance(Vector3 targetPosition, Vector3 transformPosition)
        {
            return Vector3.Distance(targetPosition, transformPosition);
        }
    }
}
