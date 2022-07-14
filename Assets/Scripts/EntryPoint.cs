using UnityEngine;
using SheepsWolf.Abstracts;
using SheepsWolf.Spawners;
using System.Collections.Generic;
using SheepsWolf.Sheeps;

namespace SheepsWolf
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private GameObject sheepPrefab;
        [SerializeField] private int quantitySheeps;
        [SerializeField] private RandomPosition spawnPositionManager;

        private InputController inputController;
        private CameraController cameraController;
        private Spawner spawner;

        private List<Sheep> sheeps = new List<Sheep>();
        private void RemoveSheep(Sheep sheep)
        {
            sheeps.Remove(sheep);
            sheep.OnDeath -= RemoveSheep;
        }

        private void Start()
        {
            inputController = new InputController(player as IMove);
            cameraController = new CameraController(player.transform);
            spawner = new Spawner(sheepPrefab);
            SpawnSheep();
        }

        private void SpawnSheep()
        {
            for (int i = 0; i < quantitySheeps; i++)
            {
                Sheep sheep = spawner.SpawningObject(spawnPositionManager.GetRandomPosition());
                sheep.OnDeath += RemoveSheep;
                sheeps.Add(sheep);
            }
        }

        private void Update()
        {
            inputController.Update();

            if (Input.GetKey(KeyCode.Alpha1))
            {
                foreach (var sheep in sheeps)
                {
                    sheep.Walking();
                }
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                foreach (var sheep in sheeps)
                {
                    sheep.Runing();
                }
            }
        }

        private void LateUpdate()
        {
            cameraController.Update();
        }

    }
}