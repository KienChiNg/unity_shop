using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] List<ShopItem> listItem;
    GameObject ItemTemplate;
    GameObject item;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] Animator NoCoin;
    [SerializeField] Text Coins;
    Button btnBuy;
    void Start()
    {
        setCoinsUI(Game.Ins.coins.ToString());
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;
        int len = listItem.Count;
        for (int i = 0; i < len; i++)
        {
            item = Instantiate(ItemTemplate, ShopScrollView);
            item.transform.GetChild(0).GetComponent<Image>().sprite = listItem[i].iconItem;
            item.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = listItem[i].price.ToString();
            item.transform.GetChild(2).GetComponent<Button>().interactable = !listItem[i].isPurchased;
            btnBuy = item.transform.GetChild(2).GetComponent<Button>();
            btnBuy.AddEventListener(i, OnShopItemBtnClicked);
            // int ind = i;
            // btnBuy.onClick.AddListener(delegate ()
            // {
            //     OnShopItemBtnClicked(ind);
            // });
        }
        Destroy(ItemTemplate);
    }
    void OnShopItemBtnClicked(int itemIndex)
    {
        // Debug.Log(itemIndex); 
        // Instance
        if (Game.Ins.hasCoin(listItem[itemIndex].price))
        {
            Game.Ins.useCoin(listItem[itemIndex].price);
            listItem[itemIndex].isPurchased = true;
            btnBuy = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            btnBuy.interactable = false;
            btnBuy.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
            setCoinsUI(Game.Ins.coins.ToString());
        }else {
            NoCoin.SetTrigger("Nocoin");
        }
    }
    void setCoinsUI(string txt){
        Coins.text = txt;
    }
}

[System.Serializable]
public class ShopItem
{
    public Sprite iconItem;
    public int price;
    public bool isPurchased = false;
    // public
}
