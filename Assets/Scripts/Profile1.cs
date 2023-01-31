using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile1 : Singleton<Profile1>
{
    [SerializeField] List<Avatar> listItem;
    [SerializeField] Transform AvatarScrollView;
    [SerializeField] GameObject AvatarUITemplate;
    [SerializeField] Transform AnimIconUI;
    [SerializeField] Color DefaultColorUI;
    [SerializeField] Color ChoosedColorUI;
    [SerializeField] Color WhiteColorUI;
    private int CurIndex = 0;
    public Animator AnimBtnShop;
    GameObject ItemTemplate;

    void Start()
    {
        Game.Ins.UpdateAllCoinsUIText();
        for (int i = 0; i < listItem.Count; i++)
        {
            GameObject g = Instantiate(AvatarUITemplate, AvatarScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = listItem[i].item;
            g.transform.GetComponent<Image>().color = ChoosedColorUI;
            g.transform.GetComponent<Button>().AddEventListener(i,OnAvatarClick);
        }
        // AvatarUITemplate.transform.GetChild(0).GetComponent<Image>().color = ChoosedColorUI;
        // ItemTemplate = AvatarScrollView.GetChild(0).gameObject;
        for (int i = 0; i < Shop.Ins.listItem.Count; i++)
        {
            if (Shop.Ins.listItem[i].isPurchased)
            {
                AddAvatar(Shop.Ins.listItem[i].iconItem);
            }
        }
        // Destroy(AnimIconUI.GetChild(0).GetComponent<Image>());
    }
    public void AddAvatar(Sprite img)
    {
        // Debug.Log(itemIndex);
        if (listItem == null)
        {
            listItem = new List<Avatar>();
        }
        Avatar av = new Avatar() { item = img };
        listItem.Add(av);
        GameObject g = Instantiate(AvatarUITemplate, AvatarScrollView);
        g.transform.GetChild(0).GetComponent<Image>().sprite = img;
        g.transform.GetComponent<Button>().AddEventListener(listItem.Count-1,OnAvatarClick);
    }
    void OnAvatarClick(int ind){
        // Debug.Log(ind);
        AnimIconUI.GetChild(0).GetComponent<Image>().sprite = listItem[ind].item;
        AvatarScrollView.GetChild(ind).GetComponent<Image>().color = ChoosedColorUI;
        AvatarScrollView.GetChild(CurIndex).GetComponent<Image>().color = DefaultColorUI;
        // AvatarScrollView.GetChild(ind).GetChild(0).GetComponent<Image>().color = WhiteColorUI;
        // AvatarScrollView.GetChild(CurIndex).GetChild(0).GetComponent<Image>().color = WhiteColorUI;
        CurIndex = ind;
    }
}

[System.Serializable]
public class Avatar
{
    public Sprite item;
}
