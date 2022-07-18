using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SheepsWolf.Spawners
{
    public class AreaGame : MonoBehaviour
    {

        [SerializeField] private BoxCollider floor;
        [SerializeField] private BoxCollider wall;
        [SerializeField] private float sheepSize;
        private Vector3 areaSize;
        public AreaBounds Bounds;

        public static AreaGame instance = null;

        private void Awake()
        {
            areaSize = GetSizeActiveFieldArea();
            Bounds = GetAreaBounds();
            
        }

        private void Start()
        {

            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        public Vector3 GetSizeActiveFieldArea()
        {
            Vector3 floorSize = floor.bounds.size;
            Vector3 wallSize = wall.bounds.size;

            float x = floorSize.x - 2 * wallSize.x - sheepSize / 2;
            float y = sheepSize;
            float z = floorSize.z - 2 * wallSize.x - sheepSize / 2;
            Vector3 size = new Vector3(x, y, z);

            return size;
        }

        private AreaBounds GetAreaBounds()
        {
            AreaBounds areaBounds = new AreaBounds();
            areaBounds.Left = floor.transform.position.x - areaSize.x / 2;
            areaBounds.Right = floor.transform.position.x + areaSize.x / 2;
            areaBounds.Top = floor.transform.position.z + areaSize.z / 2;
            areaBounds.Bottom = floor.transform.position.z - areaSize.z / 2;
            return areaBounds;

        }
        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(floor.transform.position.x - areaSize.x / 2, floor.transform.position.x + areaSize.x / 2);
            float y = areaSize.y;
            float z = Random.Range(floor.transform.position.z -areaSize.z / 2, floor.transform.position.z + areaSize.z / 2); 

            return new Vector3(x, y, z);
        }




    }

    public struct AreaBounds
    {
        public float Left;
        public float Top;
        public float Right; 
        public float Bottom;        

    }

}

