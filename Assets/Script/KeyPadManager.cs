using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPadManager : MonoBehaviour
{
    InventoryCreator creator;
    public TextMeshProUGUI texting;
    public bool isCreator = false;

    private void Start()
    {
        creator = FindObjectOfType<InventoryCreator>();
        texting.color = new Color(texting.color.r, texting.color.g, texting.color.b, 0);
    }

    private void Update()
    {
        if(isCreator)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                creator.transform.GetChild(6).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            StopCoroutine(StartCoroutine(PressFCode(1.5f)));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            isCreator = false;
        }
    }

    IEnumerator PressFCode(float t)
    {
        while(texting.color.a < 1)
        {
            float alpha = Time.deltaTime / t;
            texting.color = new Color(texting.color.r, texting.color.g, texting.color.b, texting.color.a + alpha);
            yield return null;
        }
        texting.color = new Color(texting.color.r, texting.color.g, texting.color.b, 1);

        while(texting.color.a > 0)
        {
            float alpha = Time.deltaTime / t;
            texting.color = new Color(texting.color.r, texting.color.g, texting.color.b, texting.color.a - alpha);
            yield return null;
        }
        texting.color = new Color(texting.color.r, texting.color.g, texting.color.b, 0);
        isCreator = true;
    }
}
