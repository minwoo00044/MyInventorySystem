using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
/// <summary>
/// 프로그램 시작 시, DB에 추가해둔 정보 갱신
/// 해당 스크립트는 json, scriptable Object 와 같은 데이터
/// 저장 기능을 쓰지 않고 아이템 클래스에 대한 정보를
/// 리스트로 저장하는 것으로 DB를 연출할 것
/// </summary>
public class ItemDB : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    private void Awake()
    {
        //아이템에 대한 추가 진행
        //첫 매개변수는 이미지의 이름.
        //이름을 하나하나 넣으면 개불편하니까 이미지 네임은 숫자로 하면 편할지도?
        items.Add(new Item("1", "갑빠", 100, "튼튼하지만, 무겁다.", 0, 5, -1, ItemType.Armor));
        items.Add(new Item("2", "사과", 1000, "신선하다.", 0, 0, 0, ItemType.Use));
        items.Add(new Item("3", "도끼", 10000, "연못에 던지면 안된다.", 5, 0, -1, ItemType.Weapon));
    }
}
