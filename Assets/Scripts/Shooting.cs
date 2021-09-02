using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] GameObject arm;
    [SerializeField] ParticleSystem MuzzleFlash;
    [SerializeField] ParticleSystem Tracer;
    [SerializeField] int ClipAmmo;
    [SerializeField] int AvailableAmmo;
    [SerializeField] TextMeshProUGUI AmmoCount;
    [SerializeField] bool isFiring;
    [SerializeField] Transform AmmoManager;
    [SerializeField] int MaxAvailableAmmo;
    [SerializeField] int MaxClipAmmo = 7;
    RaycastHit hitinfo;
    Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a = gun.GetComponent<Animator>();
        MaxClipAmmo = 7;
        MaxAvailableAmmo = 35;
        ClipAmmo = MaxClipAmmo;
        AvailableAmmo=MaxAvailableAmmo;
        AmmoCount.SetText(ClipAmmo + "/" + AvailableAmmo);
        isFiring = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (ClipAmmo != 7)
            {
                StartCoroutine(Reload());
            }
               
          
        }
       
    }
    private void FixedUpdate()
    {
        if(AvailableAmmo<=0)
        {
            AvailableAmmo = 0;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hitinfo))
        {if(AvailableAmmo<=MaxAvailableAmmo)
            {
                if (hitinfo.collider.gameObject.tag == "Mag")
                {
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if(AvailableAmmo<MaxAvailableAmmo)
                        {
                            AmmoPickup();
                            Destroy(hitinfo.collider.gameObject);
                        }
                        else if(AvailableAmmo==MaxAvailableAmmo)
                        {
                            Debug.Log("Can't Pickup More");
                        }
                       
                    }
                }
            }
        }
    }
    void Fire()
    {
        RaycastHit hitinfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(ClipAmmo>0&&isFiring==true)
        {
            a.SetTrigger("Fire");
            MuzzleFlash.Play();
            Tracer.Play();
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.collider != null)
                {
                   if(hitinfo.collider.gameObject.tag=="Targets")
                    {
                        Destroy(hitinfo.collider.gameObject);
                        TargetManager.tm.destroy();
                    }
                }
            }
            ClipAmmo--;
            AmmoCount.SetText(ClipAmmo + "/" + AvailableAmmo);
        }
        else if(AvailableAmmo>=0&&ClipAmmo<=0)
        {
            isFiring = false;
           if(AvailableAmmo==0&&ClipAmmo==0)
            {
                Debug.Log("PICKUPAMMO!!!");
            }else
            {
                StartCoroutine(Reload());
            }
          }
    
    }
    IEnumerator Reload()
    {
       
        a.SetTrigger("Reload");
        yield return new WaitForSeconds(2.3f);
        if(ClipAmmo<=0&&AvailableAmmo>0)
        {
           ClipAmmo += 7;
           AvailableAmmo -= 7;
        }
        else if(ClipAmmo!=0&&AvailableAmmo!=0)
        {
            AvailableAmmo -= MaxClipAmmo - ClipAmmo;
            ClipAmmo += MaxClipAmmo - ClipAmmo;
            
        }
        AmmoCount.SetText(ClipAmmo + "/" + AvailableAmmo);
        isFiring = true;
    }
    void AmmoPickup()
    {
        if (AvailableAmmo <=28)
        {
            AvailableAmmo += 7;
            AmmoCount.SetText(ClipAmmo + "/" + AvailableAmmo);

        } else if(AvailableAmmo>28)
        {
            AvailableAmmo = 35;
            AmmoCount.SetText(ClipAmmo + "/" + AvailableAmmo);
        }
       
    }
    }

