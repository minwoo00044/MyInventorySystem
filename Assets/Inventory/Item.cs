using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//item ��ũ��Ʈ�� �����Ϳ� ���� ���踸�� �������� ��
//item DB�� ���� �߰��� ������, �������̺�� ��� �� ��������
[System.Serializable]
public class Item
{
    [Header("==========�⺻ ����==========")]
    public string name;
    public int ID;
    public string description;
    public Texture2D icon;
    [Header("==========�ɷ�ġ==========")]
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
