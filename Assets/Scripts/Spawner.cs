using System;
using UnityEngine;

public class Spawner
{
    private GameObject pref;

	public Spawner(GameObject spawnObject)
    {
        pref = spawnObject;
    }

    public GameObject SpawningObject()
    {
        GameObject gameObject = GameObject.Instantiate(pref);
        return gameObject;
    }

}

