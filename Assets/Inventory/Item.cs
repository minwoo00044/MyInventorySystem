using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//item 스크립트는 데이터에 대한 설계만을 목적으로 함
//item DB를 통해 추가할 것으로, 모노비헤이비어 상속 안 받을거임
[System.Serializable]
public class Item
{
    [Header("==========기본 정보==========")]
    public string name;
    public int ID;
    public string description;
    public Texture2D icon;
    [Header("==========능력치==========")]
    public int atk;
    public int def;
    public int speed;
    public ItemType item;

    public Item(string iconText, string name, int iD, string description, int atk, int def, int speed, ItemType item)
    {
        this.name = name;
        ID = iD;
        this.description = description;
        this.atk = atk;
        this.def = def;
        this.speed = speed;
        this.item = item;
        icon = Resources.Load<Texture2D>("Itemicon/" + iconText);
    }
    public Item()
    {

    }

    public enum ItemType
    {
        Weapon,
        Armor,
        Use
    }
}
