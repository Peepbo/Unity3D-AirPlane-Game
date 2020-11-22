using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneMgr.Instance.LoadScene("gameScene");
    }
}