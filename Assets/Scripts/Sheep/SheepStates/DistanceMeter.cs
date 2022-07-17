using UnityEngine;

namespace SheepsWolf.Sheeps.Behaviors
{
    public class DistanceMeter
    {
        private Transform targetTransform;
        private Sheep sheep;

        private bool isTargeted;


        public DistanceMeter(Sheep sheep)
        {
            this.sheep = sheep;
        }
        public void Execute()
        {
            float distanceToPlayer = MeasureDistance(sheep.playerTransform.position, sheep.transform.position);
            float distanceToDestinationPoint = MeasureDistance(sheep.CurrentState.Destination, sheep.transform.position);

            if (distanceToDestinationPoint < 1f)
            {
                sheep.CurrentState.IsOnWay = false;
            }
            if(!isTargeted && distanceToPlayer < 4f)
            {
                isTargeted = true;
                sheep.AlertState();
            }

            if(isTargeted && distanceToPlayer > 6f)
            {
                isTargeted = false;
                sheep.NormalState();
            }
        }

        private float MeasureDistance(Vector3 targetPosition, Vector3 transformPosition)
        {
            return Vector3.Distance(targetPosition, transformPosition);
        }
    }
}
