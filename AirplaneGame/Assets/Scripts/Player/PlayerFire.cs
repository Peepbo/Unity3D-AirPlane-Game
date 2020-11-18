using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject Bullet;
    Transform AtkPos;

    //사운드
    public AudioSource[] audio;
    public AudioClip shotSound;

    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        AtkPos = transform.Find("AtkPos");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, AtkPos.position, Quaternion.identity);
            audio[0].PlayOneShot(shotSound);
            Instantiate(effect, AtkPos.position, Quaternion.identity);
        }

        if(Input.GetButtonDown("Fire2"))
        {
            for(int i = 0; i < 36; i++)
            {
                Instantiate(Bullet, AtkPos.position, Quaternion.Euler(0, 0, 10f * i));
            }
        }
    }
}
