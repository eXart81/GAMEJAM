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
    private bool touched = false;

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
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = Camera.main.transform;
            beingCarried=true;
       }
    
       if (beingCarried)
       {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            
            if (Mouse.current.leftButton.wasPressedThisFrame)                
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce);
            }

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
       }
    }

    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
