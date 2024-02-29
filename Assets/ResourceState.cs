using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceState : MonoBehaviour
{
    public int woodAmount = 0;
    public int meatAmount = 0;
    public int ropeAmount = 0;
    public int maxRope = 10;
    public int maxWood = 10;
    public int maxMeat = 6;
    private bool hasBeenRepaired = false;
    public GameObject brokenBoat;
    public GameObject repairedBoat;

    void Update()
    {
        if (meatAmount >= maxMeat && ropeAmount >= maxRope && woodAmount >= maxWood && !hasBeenRepaired)
        {
            hasBeenRepaired = true;
            brokenBoat.SetActive(false);
            repairedBoat.SetActive(true);
        }
    }
}
