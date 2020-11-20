using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int hp = 5;

    public GameObject btn;

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
