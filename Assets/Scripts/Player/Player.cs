using SheepsWolf.Abstracts;
using UnityEngine;


namespace SheepsWolf
{
    public class Player : MonoBehaviour, IMove
    {
        [SerializeField] private float speed = 2f;

        private void Start()
        {

        }

        public void Move(float x, float z)
        {
            transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<IInteractible>(out IInteractible component))
            {
                component.Interaction();
            }
        }
    }
}