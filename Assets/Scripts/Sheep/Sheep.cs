using SheepsWolf.Abstracts;
using SheepsWolf.Spawners;
using SheepsWolf.Sheeps.States;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace SheepsWolf.Sheeps
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Sheep : MonoBehaviour, IInteractible, ISheep
    {
        public NavMeshAgent Agent => agent;
        public event Action<Sheep> OnDeath;
        private NavMeshAgent agent;
        private ISheepState currentState;
        private DistanceMeter distanceMeter;
        
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            currentState = new NormalState(this);
            distanceMeter = new DistanceMeter(this);
        }

        public void Execute()
        {
            distanceMeter.Execute();
            currentState.Execute();
        }

        public void Walking()
        {
            currentState = new NormalState(this);
        }
        public void Running()
        {
            currentState = new AlertState();
        }
        private void Death()
        {
            OnDeath?.Invoke(this);
            GameObject.Destroy(gameObject);
        }


        public void Interaction()
        {
            Death();
        }

    }
}
