using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] public Turret tourellePrefab; // R�f�rence au prefab de l'objet � instancier
    [SerializeField] private Transform emplacementTourelleShop; // Emplacement initial o� l'objet doit appara�tre
    [SerializeField] private int price = 100;

    PlayerStats playerStats;
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>(); 
        Spawn();
    }

    void Spawn()
    {
        Turret t = Instantiate(tourellePrefab, emplacementTourelleShop.position, Quaternion.identity);
        t.shop = this;
    }

    internal bool CanBuy()
    {
        if (playerStats.Money >= price)
        {
            playerStats.Money -= price;
            Invoke("Spawn", 3f);
            return true;
        }
        
        else //LE JOUEUR PEUT PAS ACHETER
        {
            return false;
        }

    }
}