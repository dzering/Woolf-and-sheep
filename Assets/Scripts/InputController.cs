using SheepsWolf;
using UnityEngine;

namespace SheepsWolf
{
    public class InputController 
    {
        private readonly IPlayar player;

        public InputController(IPlayar player)
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
