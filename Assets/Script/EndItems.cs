using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndItems : MonoBehaviour
{
    public TextMeshProUGUI pressF;
    private bool isEnd = false;

    private void Update()
    {
        if(isEnd)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                isEnd = false;
                SceneManager.LoadSceneAsync(3);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            StartCoroutine(GetPressF(1.5f));
        }
    }

    IEnumerator GetPressF(float t)
    {
        isEnd = true;
        while (pressF.color.a < 1)
        {
            float alpha = Time.deltaTime / t;
            pressF.color = new Color(pressF.color.r, pressF.color.g, pressF.color.b, pressF.color.a + alpha);
            yield return null;
        }
        pressF.color = new Color(pressF.color.r, pressF.color.g, pressF.color.b, 1);

        while (pressF.color.a > 0)
        {
            float alpha = Time.deltaTime / t;
            pressF.color = new Color(pressF.color.r, pressF.color.g, pressF.color.b, pressF.color.a - alpha);
            yield return null;
        }
        pressF.color = new Color(pressF.color.r, pressF.color.g, pressF.color.b, 0);
    }
}
