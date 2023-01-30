using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : Singleton<Game>
{
    [SerializeField] Text[] allCoinUIText;
    public int coins;
    void Start()
    {
        UpdateAllCoinsUIText();
    }
    public void useCoin(int amount){
        coins -= amount;
    }
    public bool hasCoin(int amount){
        return (coins >= amount);
    }
    public void UpdateAllCoinsUIText(){
        for (int i = 0; i < allCoinUIText.Length; i++)
        {
            allCoinUIText[i].text = coins.ToString();
        }
    }
}
