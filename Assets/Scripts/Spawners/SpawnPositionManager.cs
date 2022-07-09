﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SheepsWolf.Spawners
{
    public class SpawnPositionManager : MonoBehaviour
    {
        [SerializeField] private BoxCollider floor;
        [SerializeField] private BoxCollider wall;
        [SerializeField] private BoxCollider sheep;
        private Vector3 areaSize;

        private void Start()
        {
            areaSize = GetSizeActiveFieldArea();
        }

        private Vector3 GetSizeActiveFieldArea()
        {
            Vector3 floorSize = floor.bounds.size;
            Vector3 wallSize = wall.bounds.size;
            Vector3 sheepSize = sheep.bounds.size;

            float x = floorSize.x - 2 * wallSize.x - sheepSize.x / 2;
            float y = sheepSize.y / 2;
            float z = floorSize.z - 2 * wallSize.x - sheepSize.z / 2;
            Vector3 size = new Vector3(x, y, z);

            return size;

        }
            
        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(floor.transform.position.x - areaSize.x / 2, floor.transform.position.x + areaSize.x / 2);
            float y = floor.transform.position.y + areaSize.y;
            float z = Random.Range(floor.transform.position.z -areaSize.z / 2, floor.transform.position.z + areaSize.z / 2); 

            return new Vector3(x, y, z);
        }



    }

}
