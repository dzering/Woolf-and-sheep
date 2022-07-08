using UnityEngine;

namespace SheepsWolf
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Player player;
        private InputController inputController;
        private CameraController cameraController;

        private void Start()
        {
           inputController = new InputController(player as IPlayar);
           cameraController = new CameraController(player.transform);
        }

        private void Update()
        {
            inputController.Update();
            
        }

        private void LateUpdate()
        {
            cameraController.Update();
        }

    }
}