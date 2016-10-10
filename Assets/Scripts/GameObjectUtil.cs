using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtil {

    private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();


    public static GameObject Instantiate(GameObject prefab, Vector3 pos)
    {
        GameObject instance = null;

        instance = GameObject.Instantiate(prefab);
        instance.transform.position = pos;

        return instance;
    }

    public static void Destroy(GameObject gameObject)
    {
        var recycleGameObject = gameObject.GetComponent<RecycleGameObject>();

        if (recycleGameObject != null)
        {
            recycleGameObject.Shutdown();
        } else
        {
            GameObject.Destroy(gameObject);
        }
    }

    private static Object GetObjectPool(RecycleGameObject reference)
    {
        ObjectPool pool = null;
        if (pool.Containskey (reference))
        {
            pool = pools[reference];
        } else
        {
            var poolContainer = 
        }
    }

}
