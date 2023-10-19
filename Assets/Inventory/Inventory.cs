using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;
/// <summary>
/// �������� ����Ʈ�� �����ϴ� �κ��丮�� ����ڴ�.
/// �κ��丮�� ����� ������ �޾Ƽ�
/// onGUI ���� UI ������
/// </summary>
public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    [SerializeField] private ItemDB itemDB = null;
    public bool _isOpen = false;

    public int slotX;
    public int slotY;

    public List<Item> slots = new List<Item>();
    public GUISkin skin;

    public int testID;
    private bool isOpenToolTip = false;
    private string tooltip;

    private void Start()
    {
        ReLoadSlotsAndInventory();
        itemDB = FindObjectOfType<ItemDB>();
        //inventory.Add(itemDB.items[0]);
        for (int i = 0; i < slotX * slotY; i++)
        {
            if (i >= itemDB.items.Count)
                break;
            //�����ͺ��̽��� �������� �����ϴ� ���
            if (itemDB.items[i] != null)
            {
                inventory[i] = itemDB.items[i];
            }
        }
    }

    private void ReLoadSlotsAndInventory()
    {
        for (int i = 0; i < slotX * slotY; i++)
        {
            slots.Add(new Item());
            //�� ������ x*y�߰�
            //item �����ڰ� �����Ǿ��ֱ� ������, �⺻ ������ �߰��� ����
            inventory.Add(new Item());
            //�κ��丮 �߰�
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            _isOpen = !_isOpen;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            AddInvetory(testID);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveInvetory(testID);
        }
    }
    private void OnGUI()
    {
        GUI.skin = skin;
        if (_isOpen)
        {
            InventroyRender();
        }
        if(isOpenToolTip)
        {
            ToolTipRender();
        }
    }

    private void ToolTipRender()
    {
        Rect toolRect = new Rect(Event.current.mousePosition.x + 5, Event.current.mousePosition.y + 2, 200,200);
        //Evnet : GUI�� ���� �̺�Ʈ, �ش� ���������� OnGUI()�� ȣ��
        GUI.Box(toolRect, tooltip, skin.GetStyle("ToolTip"));
        //toolRect ��ǥ ������, ������ ���� ���ڿ� �ۼ�
        //�̹��� ��Ų�� ToolTip���� ������ �ڽ��� �׷��ݴϴ�.

        //1. Event.current : ���� OnGUI�� ȣ���ϰԵ� Event
        //2. Layout Event : GUI�� ����� ������, ũ�Ⱑ ����� �� ó���Ǵ� Event
        //������ ����� �Ǵ°� �ƴ� ���� ��ɰ� ������ ����
        // ��ġ�ϴ� �ܰ迡 ���� ����
    }

    private void InventroyRender()
    {
        int idx = 0;
        for(int j = 0; j < slotX; j++)
        {
            for(int i = 0; i < slotY; i++)
            {
                Rect slotRect = new Rect(i * 102 + 100, j * 102 + 30, 100, 100);
                GUI.Box(slotRect, "slot",
                    skin.GetStyle("BackGround"));
                if (idx <= inventory.Count)
                {
                    slots[idx] = inventory[idx];
                    if (slots[idx].name != null)
                    {
                        GUI.DrawTexture(slotRect, slots[idx].icon);
                        if(slotRect.Contains(Event.current.mousePosition))
                        {
                            tooltip = SetToolTip(slots[i]);
                            isOpenToolTip = true;
                        }
                    }
                    //������ ����ִ� ���¶�� ��Ȱ��ȭ
                    if(tooltip == "")
                    {
                        isOpenToolTip = false;
                    }
                    idx++;
                }

            }
        }
    }

    private string SetToolTip(Item item)
    {
        //�̸��� Ư¡�� �ְ� ���� ��� rich text ��뵵 ���ƿ�
        tooltip = $"������ �̸� : <color=red>{item.name}\n������ ���ݷ� : {item.atk}\n������ ���� : {item.def}\n������ �ӵ� : {item.speed}\n\n[������ ����]\n{item.description}";
        return tooltip;
    }

    public void AddInvetory(int id)
    {
        Item addedItem = new Item();
        for (int i = 0; i < itemDB.items.Count; i++)
        {
            if(itemDB.items[i].ID == id)
            {
                addedItem = itemDB.items[i];
                break;
            }
        }
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ID == 0)
            {
                inventory[i] = addedItem;
                break;
            }
        }
    }
    public void RemoveInvetory(int id)
    {

        Item deleteItem = new Item();
        for (int i = inventory.Count - 1; i >= 0; i--)
        {
            if(inventory[i].ID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }
}
