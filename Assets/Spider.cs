using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float attackRange;

    public Transform player;

    public float speed = 2f;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                player.position, 1);
        }
    }
}
