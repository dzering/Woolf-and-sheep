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
        [SerializeField] private AreaGame spawnPositionManager;
        [SerializeField] private AudioSource audioSourceBaa;

        private InputController inputController;
        private CameraController cameraController;
        private Spawner spawner;

        private List<Sheep> sheeps = new List<Sheep>();
        private void RemoveSheep(Sheep sheep)
        {
            sheeps.Remove(sheep);
            sheep.OnDeath -= RemoveSheep;
            sheep.OnDeath -= SoundDeath;
        }

        private void SoundDeath(Sheep sheep)
        {
            audioSourceBaa.Play();
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
                sheep.OnDeath += SoundDeath;
                sheep.Init(player.transform);
                sheeps.Add(sheep);
            }
        }

        private void Update()
        {
            inputController.Update();
            foreach (var sheep in sheeps)
            {
                sheep.Execute();
            }

        }

        private void LateUpdate()
        {
            cameraController.Update();
        }
    }
}