using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    Transform AtkPos;

    float count;
    public float CreateTime = 1f;

    bool isFind;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") isFind = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") isFind = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isFind = false;

        AtkPos = transform.Find("AtkPos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if(count > CreateTime)
        {
            if (isFind == false) return;

            if (GameObject.Find("Player") == null) return;

            Instantiate(bullet, AtkPos.position, Quaternion.identity);
            count = 0;
        }
    }
}
