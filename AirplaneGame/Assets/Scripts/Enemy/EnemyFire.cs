using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    Transform AtkPos;

    float count;
    public float CreateTime = 0.5f;

    EnemyFind eF;

    // Start is called before the first frame update
    void Start()
    { 
        AtkPos = transform.Find("AtkPos").transform;

        eF = transform.Find("AtkPos").GetComponent<EnemyFind>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if(count > CreateTime)
        {
            if (eF.check == false) return;

            if (GameObject.Find("Player") == null) return;

            Instantiate(bullet, AtkPos.position, Quaternion.identity);
            count = 0;
        }
    }
}
