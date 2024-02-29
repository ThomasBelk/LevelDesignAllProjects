using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{
    public bool isWood = false;
    public bool isRope = false;
    public bool isMeat = false;
    public ResourceState resourceState;
    public FadingText fadingText;
    public int amount = 2;
    public int totalAmount;

    public void GetResource()
    {
        if (totalAmount < 0)
        {
            return;
        }
        if (isWood)
        {
            totalAmount -= amount;
            resourceState.woodAmount += amount;
            fadingText.AddText("Wood", amount);
        }
        if (isRope)
        {
            totalAmount -= amount;
            resourceState.ropeAmount += amount;
            fadingText.AddText("Rope", amount);
        }
        if (isMeat)
        {
            totalAmount -= amount;
            resourceState.meatAmount += amount;
            fadingText.AddText("Meat", amount);
            if (totalAmount < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
