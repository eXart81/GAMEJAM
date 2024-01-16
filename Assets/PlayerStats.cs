using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{


    int _money;
    public int Money
    {
        get { return _money; }
        set { _money = value; hudObject.UpdateMoney(value); }
    }

    public int startMoney = 400;

    int _lives;
    public int Lives
    {
        get { return _lives; }
        set { _lives = value; }
    }


    public int startLives = 20;

    int _rounds;
    public int Rounds
    {
        get { return _rounds; }
        set { _rounds = value; hudObject.UpdateManche(value);  }
    }


    [SerializeField] HUD hudObject;

    public void Start()
    {
        Rounds = 0;
        Money = startMoney;
        Lives = startLives;
    }

}