using UnityEngine;
using SheepsWolf.Abstracts;
using SheepsWolf.Spawners;


namespace SheepsWolf
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private GameObject sheepPrefab;
        [SerializeField] private int quantitySheeps;
        [SerializeField] private SpawnPositionManager spawnPositionManager;

        private InputController inputController;
        private CameraController cameraController;
        private Spawner spawner;

        private void Start()
        {
            inputController = new InputController(player as IPlayar);
            cameraController = new CameraController(player.transform);
            spawner = new Spawner(sheepPrefab);
            SpawnSheep();
        }

        private void SpawnSheep()
        {
            for (int i = 0; i < quantitySheeps; i++)
            {
                spawner.SpawningObject(spawnPositionManager.GetRandomPosition());

            }
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