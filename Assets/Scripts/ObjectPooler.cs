using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
   public class poolClass
    {
        public string b_Tag;
        public GameObject b_ToPool;
        public int b_amountToPool;
    }

    public List<poolClass> b_pool;
    public Dictionary<string, Queue<GameObject>> pooledObjects;

    #region Singleton
    public static ObjectPooler SharedInstance { get; private set; }

    private void Awake()
    {
        SharedInstance = this;
    }
    #endregion

    private void Start()
    {
        pooledObjects = new Dictionary<string, Queue<GameObject>>();

        foreach (poolClass pool in b_pool)
        {
            Queue<GameObject> poolQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.b_amountToPool; i++)
            {
                GameObject obj = Instantiate(pool.b_ToPool);
                obj.SetActive(false);
                poolQueue.Enqueue(obj);
                obj.transform.SetParent(this.transform);
            }
            pooledObjects.Add(pool.b_Tag, poolQueue);
        }
    }

    public GameObject GetPooledBullet(string tag)
    {
        if (!pooledObjects.ContainsKey(tag))
        {
            Debug.LogWarning("Tag is not correct");
            return null;
        }

        GameObject bulletToSpawn = pooledObjects[tag].Dequeue();
        bulletToSpawn.SetActive(true);        

        pooledObjects[tag].Enqueue(bulletToSpawn);

        return bulletToSpawn;
    }
}
