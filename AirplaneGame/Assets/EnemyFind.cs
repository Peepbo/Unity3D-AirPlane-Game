using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFind : MonoBehaviour
{
    public bool check = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player") check = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") check = false;
    }
}
