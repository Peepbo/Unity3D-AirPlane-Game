﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rigid;

    public Vector2 margin;

    public Animator anim;

    public GameObject[] Chick = new GameObject[2];
    bool cloneActive = true;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        Chick[0] = GameObject.Find("Toon Chick0");
        Chick[1] = GameObject.Find("Toon Chick1");
    }

    public void FireAnimation()
    {
        //anim.SetBool("isFire", true);
    }

    // Update is called once per frame
    void Update()
    {
        ChickActive();
        //if(anim.GetBool("isFire"))
        //{
        //    print(animCount);
        //    animCount += Time.deltaTime;

        //    if(animCount > 0.6f)
        //    {
        //        anim.SetBool("isFire", false);
        //        animCount = 0;
        //    }
        //}

        //float Hinput = Input.GetAxis("Horizontal");
        //float Vinput = Input.GetAxis("Vertical");

        //if (Hinput == 0 && Vinput == 0)
        //{
        //    Hinput = joyStick.Horizontal;
        //    Vinput = joyStick.Vertical;
        //}



        ////if(Hinput != 0 || Vinput != 0)
        ////{
        //rigid.velocity = new Vector3(Hinput * speed + Time.deltaTime, Vinput * speed + Time.deltaTime, 0f);
        //}

        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0.0f + margin.x, 1.0f - margin.x);
        position.y = Mathf.Clamp(position.y, 0.0f + margin.y, 1.0f - margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    private void ChickActive()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Chick[0].activeSelf)
            {
                Chick[0].SetActive(false);
                Chick[1].SetActive(false);
            }

            else
            {
                Chick[0].SetActive(true);
                Chick[1].SetActive(true);
            }
        }
    }
}