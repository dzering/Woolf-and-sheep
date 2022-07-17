using UnityEngine;
using SheepsWolf.Abstracts;

namespace SheepsWolf.Abstracts
{
    public interface ISheep
    {
        Transform CurrentTransform { get;set;}
        ISheepState CurrentState { get; set; }
        float Speed { get; }

        void NormalState();
        void AlertState();

    }
}
