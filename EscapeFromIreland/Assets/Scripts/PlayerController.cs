using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
  //  [SerializeField] float horizInput;
  //  [SerializeField] float verticalInput;
  //  [SerializeField] float playerRotateSpeed = 20f;
    [SerializeField] float playerForwardSpeed = 15f;
    [SerializeField] float playerBackwardSpeed = 5f;
    [SerializeField] Camera mainCamera;
    

    private bool sprinting = false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        Looking();
      
     
    }

    private void PlayerMove()
    {
        //  horizInput = Input.GetAxis("Horizontal");
        //  verticalInput = Input.GetAxis("Vertical");
        //  transform.Rotate(Vector3.up * horizInput * playerRotateSpeed * Time.deltaTime);

        //Walking
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * playerForwardSpeed * Time.deltaTime);
        }
        //Backwards
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -playerBackwardSpeed * Time.deltaTime);
        }
        //Sprinting
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift)))
        {
        
           
            playerForwardSpeed = 17f;
            transform.Translate(Vector3.forward * playerForwardSpeed * Time.deltaTime);
        }

    }

    private void Looking()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPLane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPLane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

   

}
