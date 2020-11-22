using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int hp = 5;

    public GameObject btn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="EnemyBullet")
        {
            getDamaged(1);
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

    public void getDamaged(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            btn.SetActive(true);
            Destroy(gameObject);
        }
    }
}
