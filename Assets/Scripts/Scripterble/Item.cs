using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ʈ â���� ���������ϰ� �����
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject // ���� ������Ʈ�� ���� �ʿ���� ��ũ��Ʈ
{


    public string itemName; // ������ �̸�
    public int itemWeight;
    public int itemAttackDamage;
    public int itemDefense;
    public int itemHealth;
    public int itemCritical;


    public ItemType itemType;
    public Sprite itemImage; // ������ �̹��� = �κ��丮 �̹����� 
    public float itemCost; 
    public float itemBuyCost;

    [TextArea] // �ν����� â���� �����ٷ� ���°��� ��������-�޸���ó�� ��
    public string itemDesc; // �������� ����

    public enum ItemType //������ ������ Ÿ��
    {
        Equipment, // ���
        Used, // �Ҹ�ǰ
        Ingredient, // ���
        ETC // ��Ÿ
    }


}