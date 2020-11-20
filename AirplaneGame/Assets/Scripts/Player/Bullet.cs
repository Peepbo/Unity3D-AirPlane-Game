using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;

    public bool isSub = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            print("Enemy die");

            ScoreManager.Instance.AddScore();

            Destroy(collision.gameObject);

            gameObject.SetActive(false);

            PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
            pf.bulletPool.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVector = Vector3.zero;

        if (!isSub) newVector = Vector3.up;
        else newVector = Vector3.forward;

        transform.Translate(newVector * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);

        PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
        pf.bulletPool.Add(gameObject);
    }
}
