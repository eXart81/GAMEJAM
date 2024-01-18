using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class startwave : MonoBehaviour
{
    [SerializeField] private float maxDistance = 5f;

    [SerializeField] private VaguesManager vaguesManager; // Assurez-vous que cette variable est correctement assignée dans l'inspecteur Unity.
    [SerializeField] AudioSource AudioData;
    void Start()
    {
        // Assurez-vous que vaguesManager est correctement assigné
        if (vaguesManager == null)
        {
            Debug.LogError("VaguesManager non assigné au script startwave.");
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed) // Détecte le maintien du clic
        {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                if (hit.collider.CompareTag("Bouton"))
                {
                    Debug.Log("C'est ok");
                    AudioData.Play(0);

                    // Démarrer la vague lorsque le bouton est cliqué
                    vaguesManager.StartNextWave();
                }
            }
        }
    }
}
