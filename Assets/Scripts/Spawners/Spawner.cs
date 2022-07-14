using SheepsWolf.Sheeps;
using System;
using UnityEngine;


namespace SheepsWolf.Spawners
{
    public class Spawner
    {
        private GameObject prefab;
        private Transform parantTransform;

	    public Spawner(GameObject prefab)
        {
            parantTransform = new GameObject("Sheeps").transform;
            this.prefab = prefab;
        }

        public Sheep SpawningObject(Vector3 targetposition)
        {
            GameObject gameObject = GameObject.Instantiate(prefab, targetposition, Quaternion.identity);
            gameObject.transform.SetParent(parantTransform);
            Sheep sheep = gameObject.GetComponent<Sheep>();
            return  sheep;
        }

    }

}

