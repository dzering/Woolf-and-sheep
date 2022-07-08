using SheepsWolf;
using UnityEngine;

namespace SheepsWolf
{
    public class InputController 
    {
        private readonly IMovable movableObject;

        public InputController(IMovable movableObject)
        {
            this.movableObject = movableObject;
        }

        public void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            movableObject.Move(x, z);
        }
    }
}
