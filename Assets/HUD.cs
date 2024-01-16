using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TMP_Text mancheText;
    [SerializeField]
    TMP_Text moneyText;

    public void UpdateMoney(int money)
    {
        if (moneyText != null)
        {
            moneyText.text = money.ToString();
        }
    }
    public void UpdateManche(int manche)
    {
        if (mancheText != null)
        {
            mancheText.text = manche.ToString();
        }
    }

}