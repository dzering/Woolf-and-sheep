using SheepsWolf.Sheeps;
using UnityEngine;


namespace SheepsWolf.Abstracts
{
    public interface ISheepState
    {
        bool IsOnWay { get; set; }
        Vector3 Destination { get; }
        void Execute();
    }
}