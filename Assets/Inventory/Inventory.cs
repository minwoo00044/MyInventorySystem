using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;
/// <summary>
/// 아이템을 리스트로 관리하는 인벤토리를 만들겠다.
/// 인벤토리는 디비의 정보를 받아서
/// onGUI 통해 UI 렌더링
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
            //데이터베이스의 아이템이 존재하는 경우
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
            //빈 슬롯을 x*y추가
            //item 생성자가 수정되어있기 때문에, 기본 생성자 추가를 진행
            inventory.Add(new Item());
            //인벤토리 추가
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
        //Evnet : GUI에 대한 이벤트, 해당 예제에서는 OnGUI()를 호출
        GUI.Box(toolRect, tooltip, skin.GetStyle("ToolTip"));
        //toolRect 좌표 지점에, 툴팁에 적은 문자열 작성
        //이미지 스킨은 ToolTip으로 설정해 박스를 그려줍니다.

        //1. Event.current : 현재 OnGUI를 호출하게된 Event
        //2. Layout Event : GUI의 요소의 포지션, 크기가 변경될 때 처리되는 Event
        //실제로 드로잉 되는게 아닌 관련 기능과 정보를 조사
        // 배치하는 단계에 대한 조사
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
                    //툴팁이 비어있는 상태라면 비활성화
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
        //이름에 특징을 주고 싶은 경우 rich text 사용도 좋아용
        tooltip = $"아이템 이름 : <color=red>{item.name}\n아이템 공격력 : {item.atk}\n아이템 방어력 : {item.def}\n아이템 속도 : {item.speed}\n\n[아이템 설명]\n{item.description}";
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
