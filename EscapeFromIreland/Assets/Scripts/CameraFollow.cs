using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] float offsetX = -0.05f;
    [SerializeField] float offsetY = 10.5f;
    [SerializeField] float offsetZ = -9.25f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerOffset = new Vector3(offsetX, offsetY, offsetZ);
        transform.position = player.transform.position + playerOffset;
    }


}
