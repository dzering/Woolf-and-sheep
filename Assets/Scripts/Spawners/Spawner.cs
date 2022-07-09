using System;
using UnityEngine;


namespace SheepsWolf.Spawners
{
    public class Spawner
    {
        private GameObject pref;

	    public Spawner(GameObject spawnObject)
        {
            pref = spawnObject;
        }

        public GameObject SpawningObject(Vector3 targetposition)
        {
            GameObject gameObject = GameObject.Instantiate(pref, targetposition, Quaternion.identity);
            return gameObject;
        }

    }

}

