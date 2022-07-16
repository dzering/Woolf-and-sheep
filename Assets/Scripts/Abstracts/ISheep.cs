using UnityEngine.AI;

namespace SheepsWolf.Abstracts
{
    public interface ISheep
    {
        NavMeshAgent Agent { get; }
        void Walking();
        void Running();

    }
}
