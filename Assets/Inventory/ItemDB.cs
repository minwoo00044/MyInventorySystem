using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
/// <summary>
/// ���α׷� ���� ��, DB�� �߰��ص� ���� ����
/// �ش� ��ũ��Ʈ�� json, scriptable Object �� ���� ������
/// ���� ����� ���� �ʰ� ������ Ŭ������ ���� ������
/// ����Ʈ�� �����ϴ� ������ DB�� ������ ��
/// </summary>
public class ItemDB : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    private void Awake()
    {
        //�����ۿ� ���� �߰� ����
        //ù �Ű������� �̹����� �̸�.
        //�̸��� �ϳ��ϳ� ������ �������ϴϱ� �̹��� ������ ���ڷ� �ϸ� ��������?
        items.Add(new Item("1", "����", 100, "ưư������, ���̴�.", 0, 5, -1, ItemType.Armor));
        items.Add(new Item("2", "���", 1000, "�ż��ϴ�.", 0, 0, 0, ItemType.Use));
        items.Add(new Item("3", "����", 10000, "������ ������ �ȵȴ�.", 5, 0, -1, ItemType.Weapon));
    }
}
