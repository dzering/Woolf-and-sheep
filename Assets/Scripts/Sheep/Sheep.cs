using SheepsWolf.Abstracts;
using SheepsWolf.Sheeps.States;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace SheepsWolf.Sheeps
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Sheep : MonoBehaviour, IInteractible, ISheep
    {
        public event Action<Sheep> OnDeath;
        public NavMeshAgent Agent => agent;
        public ISheepState CurrentState { get { return currentState; } set { currentState = value; } }

        private ISheepState currentState;
        private NavMeshAgent agent;
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
        }

        public void Walking()
        {
            currentState = new NormalState(this);
        }
        public void Running()
        {
            currentState = new AlertState(this);
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
