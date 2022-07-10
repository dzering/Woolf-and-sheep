using SheepsWolf.Abstracts;
using UnityEngine;

namespace SheepsWolf
{
    public class InputController 
    {
        private readonly IMove player;

        public InputController(IMove player)
        {
            this.player = player;
        }

        public void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            player.Move(x, z);
        }
    }
}
