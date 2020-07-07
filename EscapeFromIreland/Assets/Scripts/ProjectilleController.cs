using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed;
    void Start()
    {
        StartCoroutine(DeleteTimer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }


    IEnumerator DeleteTimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

  
}
