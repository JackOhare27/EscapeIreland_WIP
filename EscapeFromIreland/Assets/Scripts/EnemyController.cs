using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 1f;
    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerInstance.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //returns the distance between the enemy and player
        float distance = Vector3.Distance(target.position, transform.position);

        //if we are in the radius of the enemy it will chase
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }

        //if object is closer than stopping distance ( stoppingdistance is a node of the navmesh in unity editor
        if(distance <= agent.stoppingDistance)
        {
            //shoot

           // looks in direction of player
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        //gets the position of where we are at
        Vector3 direction = (target.position = transform.position).normalized;
       // changes the rotation with new quaternion rotating into our x and z direction
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //Turns smoothly by using slerp which is takes the type of rotation, where to rotate to, and how fast
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    //Destroys projectille and enemy when hit
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Projectille"))
        {
           // Debug.Log("Hit by bullet");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
    }
    //shows us what the detection is for navmesh
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
