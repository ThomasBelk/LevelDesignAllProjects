using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shoot : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float range = 100f;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioClip muzzleSound;
    [SerializeField] private AudioSource civilianSound;
    [SerializeField] private AudioSource goodWorkSound;
    [SerializeField] private float voicelineCooldown;
    private float lastVoiceline;
    private bool voicelineOnCooldown = false;
    private bool gunOnCooldown = false;
    private float cooldownTime;


    private void Start()
    {
        cam = Camera.main;
        lastVoiceline = Time.time - voicelineCooldown;
    }

    private void Update()
    {
        if (gunOnCooldown && Time.time - cooldownTime > 0.1)
        {
            gunOnCooldown = false;
        }
        if (voicelineOnCooldown && Time.time - lastVoiceline > voicelineCooldown)
        {
            voicelineOnCooldown = false;
        }

    }

    public void Fire()
    {
        if (!gunOnCooldown)
        {
            muzzleFlash.Play();
            if (muzzleSound != null)
            {
                AudioSource.PlayClipAtPoint(muzzleSound, transform.position);
            }
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range))
            {
                Debug.Log(hit.transform.name); // Log the name of the object hit
                
                PopupBoard p = hit.transform.GetComponentInParent<PopupBoard>();
                if (p != null)
                {
                    Debug.Log("dlaskfj;aslkf");
                    if (p.isCivilian)
                    {
                        PlaySound(civilianSound);
                    } 
                    else
                    {
                        PlaySound(goodWorkSound);
                    }
                }
            }
            gunOnCooldown = true;
            cooldownTime = Time.time;
        }
    }
    
    private void PlaySound(AudioSource c)
    {
        if (!c.isPlaying)
        {
/*            voicelineCooldown = Time.time;
            voicelineOnCooldown = true;*/
            c.Play();
        }
    }
}
