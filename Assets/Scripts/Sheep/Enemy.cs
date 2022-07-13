using UnityEngine;

namespace SheepsWolf.Abstracts
{
    public abstract class EnemyBase : MonoBehaviour, IInteractible
    {
        public abstract void Interaction();
    }
}
