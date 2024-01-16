using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class objetsàdeplacés : MonoBehaviour
{
    [SerializeField] public GameObject gameobject;

    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    void Update()
    {
       float dist = Vector3.Distance(gameobject.transform.position, player.position);
        
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
            transform.parent = playerCam;
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
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
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
