using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{

    private float durationShotTimer = .25f;
    private float coolDownTimer = 0f;
    public GameObject Projectille;
   //Controls the firing
    void Update()
    {
        Fire();  
    }

    private void Fire()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > coolDownTimer)
        {
            Instantiate(Projectille, transform.position, transform.rotation);

            coolDownTimer = Time.time + durationShotTimer;

        }
    }
}
