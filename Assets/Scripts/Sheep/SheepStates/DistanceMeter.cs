using UnityEngine;
using SheepsWolf.Abstracts;

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
            Debug.Log($"Sheep {sheep.name} is walking.");
            float distanceToPlayer = MeasureDistance(targetTransform.position, sheep.transform.position);
            Debug.Log($"distance={distanceToPlayer}");
            if(distanceToPlayer <= 2f)
            {
                sheep.Running();
                Debug.Log($"{sheep.name} is running");
            }else if(distanceToPlayer > 2f)
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
