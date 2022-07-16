using UnityEngine.AI;
using SheepsWolf.Abstracts;

namespace SheepsWolf.Abstracts
{
    public interface ISheep
    {
        NavMeshAgent Agent { get; }
        ISheepState CurrentState { get; set; }
        
        void Walking();
        void Running();

    }
}
