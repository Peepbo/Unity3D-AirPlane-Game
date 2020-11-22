using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneFire : MonoBehaviour
{
    public GameObject prefab;
    float curCount = 0;
    public float endCount = 2;

    Transform atkPos;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        atkPos = transform.Find("AtkPos");
    }

    // Update is called once per frame
    void Update()
    {
        curCount += Time.deltaTime;

        if(curCount > endCount)
        {
            curCount = 0;

            //Vector3 angle = GameObject.Find("Player").transform.eulerAngles;
            Instantiate(prefab, atkPos.position, Quaternion.Euler( parent.transform.eulerAngles));
        }
    }
}
