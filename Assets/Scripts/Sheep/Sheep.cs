using SheepsWolf.Abstracts;
using SheepsWolf.Sheeps.Behaviors;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace SheepsWolf.Sheeps
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Sheep : MonoBehaviour, IInteractible, ISheep
    {
        public event Action<Sheep> OnDeath;
        public Transform CurrentTransform { get; set; }
        public Transform playerTransform;
        public ISheepState CurrentState { get { return currentState; } set { currentState = value; } }

        public float Speed => 2f;

        private ISheepState currentState;
        private DistanceMeter distanceMeter;

        private void Awake()
        {
            playerTransform = GameObject.FindObjectOfType<Player>().transform;
        }
        private void Start()
        {
            
            CurrentTransform = transform;
            currentState = new NormalState(this);
            distanceMeter = new DistanceMeter(this);
        }

        public void Execute()
        {
            distanceMeter.Execute();
            Move();
        }
        public void NormalState()
        {
            currentState = new NormalState(this);
        }
        public void AlertState()
        {
            currentState = new AlertState(this);
        }

        private void Move()
        {
            currentState.Execute();
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
