using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textTMP : MonoBehaviour
{
    [SerializeField]
    TMP_Text healthText;
    [SerializeField]
    TMP_Text scoreText;

    public void UpdateDeuxText(int healthValue, int scoreValue)
    {
        healthText.text = "manche : " + healthValue.ToString();
        scoreText.text = "monnaie : " + scoreValue.ToString();
    }
    private void Update()
    {
        UpdateDeuxText(100, 7890);
    }
}