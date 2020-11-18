using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject BulletFactory;
    public GameObject target;
    public float fireTime = 1.0f;
    float curTime = 0.0f;
    public float fireTime1 = 1.5f;
    float curTime1 = 0.0f;
    public int bulletMax = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AutoFire2();
    }

    private void AutoFire2()
    {
        if(target != null)
        {
            curTime1 += Time.deltaTime;
            if(curTime1 > fireTime1)
            {
                for(int i = 0; i < bulletMax; i++)
                {
                    GameObject bullet = Instantiate(BulletFactory,transform.position,Quaternion.Euler(0,0,i * (360/bulletMax)));

                    //bullet.transform.position = transform.position;

                    //float angle = 360.0f / bulletMax;
                    //bullet.transform.eulerAngles = new Vector3(0, 0, 1 * angle);
                }

                curTime1 = 0.0f;
            }
        }
    }
}
