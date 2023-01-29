using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    public int coins;
    public void useCoin(int amount){
        coins -= amount;
    }
    public bool hasCoin(int amount){
        return (coins >= amount);
    }
}
