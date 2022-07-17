using UnityEngine;

namespace SheepsWolf.Sheeps.Behaviors
{
    public class DistanceMeter
    {
        private Transform targetTransform;
        private Sheep sheep;
        private State state = State.Normal;
        private bool isTargeted;


        public DistanceMeter(Sheep sheep)
        {
            this.sheep = sheep;
        }
        public void Execute()
        {
            float distanceToPlayer = MeasureDistance(sheep.playerTransform.position, sheep.transform.position);
            

            //if (distanceToDestination < 1f)
            //{
            //    sheep.CurrentState.Execute();
            //}

            //if (isTargeted && distanceToPlayer > 40f)
            //{
            //    isTargeted = false;
            //    sheep.Walking();
            //}

            if (isTargeted)
            {
                return;
            }

            if (distanceToPlayer <= 4f)
            {
                isTargeted = true;
                sheep.AlertState();
                Debug.Log($"{sheep.name} is running");
            }

        }

        private float MeasureDistance(Vector3 targetPosition, Vector3 transformPosition)
        {
            return Vector3.Distance(targetPosition, transformPosition);
        }
    }
}
