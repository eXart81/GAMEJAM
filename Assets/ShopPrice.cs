using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopPrice : MonoBehaviour
{
    [SerializeField]
    TMP_Text shopPricetext;

    public void UpdateshopPricetext(int _price)
    {
       shopPricetext.text = _price.ToString();
    }
}
