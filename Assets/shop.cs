using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] public Turret tourellePrefab; // R�f�rence au prefab de l'objet � instancier
    [SerializeField] private Transform emplacementTourelleShop; // Emplacement initial o� l'objet doit appara�tre
    [SerializeField] public int _price = 300;
    
    ShopPrice ShopPriceObject;

    PlayerStats playerStats;
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        ShopPriceObject = GetComponent<ShopPrice>();
        ShopPriceObject?.UpdateshopPricetext(_price);
        Spawn();
    }

    void Spawn()
    {
        Turret t = Instantiate(tourellePrefab, emplacementTourelleShop.position, Quaternion.identity);
        t.shop = this;
    }

    internal bool CanBuy()
    {
        if (playerStats.Money >= _price)
        {
            playerStats.Money -= _price;
            Invoke("Spawn", 3f);
            return true;
        }
        
        else //LE JOUEUR PEUT PAS ACHETER
        {
            return false;
        }

    }
}