using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [SerializeField]
    int poolsize;

    [SerializeField]
    GameObject objectPrefab;

    [SerializeField]
    GameObject[] objectList;
    
    // Use this for initialization
	void Start ()
    {
        objectList = new GameObject[poolsize];
        for (int i = 0; i < poolsize; i++)
        {
            objectList[i] = GameObject.Instantiate<GameObject>(objectPrefab);
            objectList[i].SetActive(false);
        }
	}
	
    public GameObject GetAvailable ()
    {
        GameObject available = null;
        for (int i = 0; i < poolsize; i++)
        {
            if(!objectList[i].activeSelf)
            {
                available = objectList[i];
                break;
            }
        }
        return available;
    }

    public void OnDestroy ()
    {
        for (int i = 0; i < objectList.Length; i++)
        {
            Destroy(objectList[i]);
        }
    }

    public void RegisterPrefab (GameObject prefab)
    {
        objectPrefab = prefab;
    }

    public int GetPoolSize ()
    {
        return this.poolsize;
    }

    public void SetPoolSize (int size)
    {
        this.poolsize = size;
    }
}
