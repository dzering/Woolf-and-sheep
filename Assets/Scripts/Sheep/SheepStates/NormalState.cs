using UnityEngine;
using SheepsWolf.Spawners;
using SheepsWolf.Abstracts;

namespace SheepsWolf.Sheeps.Behaviors
{
    public class NormalState : ISheepState
    {
        private readonly ISheep sheep;

        public NormalState(ISheep sheep)
        {
            this.sheep = sheep;
        }

        public void Execute()
        {
     
        }

        public void Execute(Vector3 dir)
        {
        }
    }
}
