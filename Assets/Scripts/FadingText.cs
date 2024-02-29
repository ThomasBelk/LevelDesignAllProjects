using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadingText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public bool temp = false;

    void Update()
    {
        if (temp)
        {
            textMeshPro.text += "wood x1" + Environment.NewLine;
            StartCoroutine(RemoveTopLineAfterDelay(2));
            temp = false;
        }
    }

    private IEnumerator RemoveTopLineAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        string text = textMeshPro.text;

        string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        string newText = "";
        for (int i = 1; i < lines.Length; i++)
        {
            newText += lines[i];
            if (i < lines.Length - 1)
            {
                newText += Environment.NewLine;
            }
        }
        textMeshPro.text = newText;
    }
}
