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
    public Animator AnimBtnShop;
    GameObject ItemTemplate;

    void Start()
    {
        Game.Ins.UpdateAllCoinsUIText();
        for (int i = 0; i < listItem.Count; i++)
        {
            GameObject g = Instantiate(AvatarUITemplate, AvatarScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = listItem[i].item;
            g.transform.GetComponent<Button>().AddEventListener(listItem.Count-1,OnAvatarClick);
        }
        // ItemTemplate = AvatarScrollView.GetChild(0).gameObject;
        for (int i = 0; i < Shop.Ins.listItem.Count; i++)
        {
            if (Shop.Ins.listItem[i].isPurchased)
            {
                AddAvatar(Shop.Ins.listItem[i].iconItem,i);
            }
        }
        // Destroy(AnimIconUI.GetChild(0).GetComponent<Image>());
    }
    public void AddAvatar(Sprite img,int itemIndex)
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
    }
}

[System.Serializable]
public class Avatar
{
    public Sprite item;
}
