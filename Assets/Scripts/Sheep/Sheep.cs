using SheepsWolf.Abstracts;
using SheepsWolf.Spawners;
using SheepsWolf.Sheeps.States;
using UnityEngine;
using UnityEngine.AI;

namespace SheepsWolf.Sheeps
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Sheep : MonoBehaviour, IInteractible, ISheep
    {
        public NavMeshAgent Agent => agent;
        private NavMeshAgent agent;
        private Vector3 destination;
        private ISheepState currentState;
        
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            //MoveRandom();
            destination = agent.destination;
        }

        public void Walking()
        {
            currentState = new NormalState();
            currentState.Execute(this);
        }

        public void Runing()
        {
            currentState = new AlertState();
            currentState.Execute(this);
        }
        private void Death()
        {
            GameObject.Destroy(gameObject);

        }
      

        // 
        public void MoveRandom()
        {

            agent.destination = RandomPosition.instance.GetRandomPosition();
            
        }

        public void Interaction()
        {
            Death();
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
    }
}
