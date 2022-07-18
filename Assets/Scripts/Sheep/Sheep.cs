using SheepsWolf.Abstracts;
using SheepsWolf.Sheeps.Behaviors;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace SheepsWolf.Sheeps
{
    public class Sheep : MonoBehaviour, IInteractible, ISheep
    {
        private AudioSource audioSource;
        public event Action<Sheep> OnDeath;
        public Transform CurrentTransform { get; set; }
        public Transform PlayerTransform;
        public ISheepState CurrentState { get { return currentState; } set { currentState = value; } }

        public float Speed => 2f;

        private ISheepState currentState;
        private DistanceMeter distanceMeter;

        public void Init(Transform playerTransform)
        {
            PlayerTransform = playerTransform;
        }
        private void Start()
        {
            CurrentTransform = transform;
            currentState = new NormalState(this);
            distanceMeter = new DistanceMeter(this);
            audioSource =GetComponent<AudioSource>();
        }

        public void Execute()
        {
            distanceMeter.Execute();
            currentState.Execute();
        }
        public void NormalState()
        {
            currentState = new NormalState(this);
        }
        public void AlertState()
        {
            currentState = new AlertState(this);
        }
        public void Interaction()
        {
            Death();
        }
        private void Death()
        {
            OnDeath?.Invoke(this);
            GameObject.Destroy(gameObject);
        }

    }
}
