using SheepsWolf.Abstracts;
using UnityEngine;

namespace SheepsWolf
{
    public class Sheep : MonoBehaviour, IInteractible
    {
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
