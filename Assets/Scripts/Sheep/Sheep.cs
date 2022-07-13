using SheepsWolf.Abstracts;
using SheepsWolf.Spawners;
using UnityEngine;
using UnityEngine.AI;

namespace SheepsWolf.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Sheep : EnemyBase
    {
        private NavMeshAgent agent;
        private Vector3 destination;
        
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            MoveRandom();
            destination = agent.destination;
        }

        private void Update()
        {
            CheckDestination();
        }

        private void CheckDestination()
        {
            float distance = MeasureDistance();
            Debug.Log($"distance={distance}");
            if (distance < 1f)
            {
                MoveRandom();
                destination = agent.destination;

            }

            MeasureDistance();
                Debug.Log($"{name}, position={transform.position}, destination={destination}");

        }

        private float MeasureDistance()
        {
            return Vector3.Distance(destination, transform.position);
            
        }

      
        public void MoveRandom()
        {

            agent.destination = RandomPosition.instance.GetRandomPosition();
            
        }

        public override void Interaction()
        {
            Death();
        }

        private void Death()
        {
            GameObject.Destroy(gameObject);

        }
    }
}
