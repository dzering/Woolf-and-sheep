using SheepsWolf.Abstracts;
using SheepsWolf.Spawners;
using UnityEngine;
using UnityEngine.AI;

namespace SheepsWolf
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Sheep : MonoBehaviour, IInteractible
    {
        private NavMeshAgent navMeshAgent;
        
        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            MoveRandom();
        }

      
        public void MoveRandom()
        {

            navMeshAgent.destination = RandomPosition.instance.GetRandomPosition();
            
        }

        public void Interaction()
        {
            Death();
        }

        private void Death()
        {
            GameObject.Destroy(gameObject);

        }
    }
}
