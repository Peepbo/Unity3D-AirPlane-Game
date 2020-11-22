using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;

    public bool isSub = false;

    public GameObject Eft;

    public void EftPlay()
    {
        Instantiate(Eft, transform.position, Quaternion.identity);
    }

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}