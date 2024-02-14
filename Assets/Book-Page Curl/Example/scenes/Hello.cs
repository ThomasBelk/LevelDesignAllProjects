using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    public AutoFlip flipper;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            flipper.FlipRightPage();
        }
        if (Input.GetKey(KeyCode.C))
        {
            flipper.FlipLeftPage();
        }
    }

}
