using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shoot : MonoBehaviour
{
    private Camera cam;
    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    private bool gunOnCooldown = false;
    private float cooldownTime;


    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (gunOnCooldown && Time.time - cooldownTime > 0.1)
        {
            gunOnCooldown = false;
        }


    }

    public void Fire()
    {
        if (!gunOnCooldown)
        {
            muzzleFlash.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range))
            {
                Debug.Log(hit.transform.name); // Log the name of the object hit
            }
            gunOnCooldown = true;
            cooldownTime = Time.time;
        }
    }


}
