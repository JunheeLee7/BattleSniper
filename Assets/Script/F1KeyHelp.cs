using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class F1KeyHelp : MonoBehaviour
{
    GameObject F1Help;
    private bool isHelp = false;

    private void Awake()
    {
        F1Help = gameObject.transform.GetChild(9).gameObject;
        F1Help.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            if(!isHelp)
            {
                F1Help.SetActive(true);
                isHelp = true;
            }
        }
    }

    public void GetButtonClose()
    {
        F1Help.SetActive(false);
        isHelp = false;
    }
}
