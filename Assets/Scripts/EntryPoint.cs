using UnityEngine;

namespace SheepsWolf
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Player player;
        private InputController inputController;

        private void Start()
        {
           inputController = new InputController(player as IMovable);
        }

        private void Update()
        {
            inputController.Update();
        }

    }
}