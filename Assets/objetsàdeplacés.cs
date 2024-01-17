using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class objetsàdeplacés : MonoBehaviour
{
    private Transform player;
    public float throwForce = 10;
    private bool hasPlayer = false;
    private bool beingCarried = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
       float dist = Vector3.Distance(transform.position, player.position);
        
       if (dist <=2f)
       {
            hasPlayer = true;
       }
       else
       {
            hasPlayer= false;
       }
       
       if (hasPlayer && Keyboard.current[Key.F].wasPressedThisFrame)
       {
            Turret t = GetComponent<Turret>();
            if(t.TryPickUpByPlayer())
            {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Collider>().enabled = false;
                transform.parent = Camera.main.transform;
                transform.position = Camera.main.transform.position + Camera.main.transform.forward * 3f;
                beingCarried=true;
            }
        }

        if (beingCarried)
       {
            transform.eulerAngles = new Vector3(0f, transform.parent.eulerAngles.y, 0f);


            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Collider>().enabled = true;

                transform.parent = null;
                transform.position = new Vector3(transform.position.x, 2, transform.position.z);
                beingCarried = false;
            }
       }
    }
}
