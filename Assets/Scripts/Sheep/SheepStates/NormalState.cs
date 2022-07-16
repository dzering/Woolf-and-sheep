using UnityEngine;
using SheepsWolf.Spawners;

namespace SheepsWolf.Sheeps.States
{
    public class NormalState : ISheepState
    {
        private readonly Sheep sheep;
        private readonly Transform playerTransform;
        public NormalState(Sheep sheep)
        {
            this.sheep = sheep;
            playerTransform = GameObject.FindObjectOfType<Player>().transform;
            sheep.Agent.destination = RandomPosition.instance.GetRandomPosition();
        }

        public void Execute()
        {
            Debug.Log($"Sheep {sheep.name} is walking.");
            float distanceDestination = MeasureDistance(sheep.Agent.destination, sheep.transform.position);
            Debug.Log($"distance={distanceDestination}");

            if (distanceDestination < 1f)
            {
                sheep.Agent.destination = RandomPosition.instance.GetRandomPosition();
            }
            Debug.Log($"{sheep.name}, position={sheep.transform.position}, destination={sheep.Agent.destination}");
        }
        private float MeasureDistance(Vector3 targetPosition, Vector3 transformPosition)
        {
            return Vector3.Distance(targetPosition, transformPosition);
        }
    }
}
