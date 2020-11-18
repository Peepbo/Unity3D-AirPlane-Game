using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;

    float count = 0f;
    public float maxCount = 2f;

    Transform min, max;
    // Start is called before the first frame update
    void Start()
    {
        min = transform.Find("minPos");
        max = transform.Find("maxPos");
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if(count > maxCount)
        {
            Vector3 createPos = min.position;
            createPos.x = Random.Range(min.position.x, max.position.x);

            Instantiate(Enemy, createPos, Quaternion.identity);

            count = 0;
        }
    }
}
