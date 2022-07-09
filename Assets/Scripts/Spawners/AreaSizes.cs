using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SheepsWolf.Spawners
{
    public class AreaSizes : MonoBehaviour
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
            Vector3 wallSize = floor.bounds.size;
            Vector3 sheepSize = floor.bounds.size;

            float x = floorSize.x - 2 * wallSize.x - sheepSize.x / 2;
            float y = sheepSize.y / 2;
            float z = floorSize.z - 2 * wallSize.x - sheepSize.z / 2;
            Vector3 size = new Vector3(x, y, z);

            return size;

        }

        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(- areaSize.x / 2, areaSize.x / 2);
            float y = areaSize.y;
            float z = Random.Range(-areaSize.z / 2, areaSize.z / 2); 

            return new Vector3(x, y, z);
        }



    }

}

