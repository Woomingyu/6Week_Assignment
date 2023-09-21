using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{

    public static bool inventoryActivated = false; //�κ��丮 Ȱ��ȭ ����
    public static bool statusActivated = false; //�κ��丮 Ȱ��ȭ ����

    //�ʿ��� ������Ʈ
    [SerializeField]
    private GameObject inventoryPopup;
    [SerializeField]
    private GameObject statusPopup;
    [SerializeField]
    private GameObject slotsGrid; //�׸��� ���� (��� ���԰���)
    [SerializeField]
    private PlayerData player;

    private Animator anim;

    //���Ե�
    private Slot[] slots;

    //�����ϸ� �ٷ� ���� ������ (�ӽ�)
    public Item[] startItems; // �ν����Ϳ��� �Ҵ�

    void Start()
    {
        //���� �迭���� ��� ���� ���� �Է�
        slots = slotsGrid.GetComponentsInChildren<Slot>();
        player = player.GetComponent<PlayerData>();

        AcquireItem(startItems[0]);
        AcquireItem(startItems[1]);
        AcquireItem(startItems[2]);
        AcquireItem(startItems[3]);

    }




    public void TryOpenIventory()
    {
        inventoryActivated = !inventoryActivated; //������ Ȱ��ȭ �κ� ��Ȱ��ȭ ����Ī
        //anim.SetBool("Appear", inventoryActivated); //�κ� Ȱ��/��Ȱ�� �ִ� 


        //�κ��丮�� ���� ���� ���º����� ���� ����/�帧 �� ���Ƴ���(�޸�)
        if (inventoryActivated)
        {
            OpenInventory();
        }


        else
        {
            CloseInventory();
        }
    }

    public void TryOpenStatus()
    {
        statusActivated = !statusActivated; //������ Ȱ��ȭ �κ� ��Ȱ��ȭ ����Ī

        if (statusActivated)
        {
            OpenStatus();
        }


        else
        {
            CloseStatus();
        }
    }

    private void CloseStatus()
    {
        statusPopup.SetActive(true);
    }

    private void OpenStatus()
    {
        statusPopup.SetActive(false);
    }

    //�κ��丮 Ȱ��ȭ && ��Ȱ��ȭ
    private void OpenInventory()
    {
        inventoryPopup.SetActive(true);
    }
    private void CloseInventory()
    {
        inventoryPopup.SetActive(false);
    }

    //������ ȹ�� ==> Ore�� Destruction.�ݺ��� &&
    public void AcquireItem(Item _item, int _count = 1)
    {
        player.ChangeInfo("weight", _item.itemWeight); //���� �����ֱ�
        for (int i = 0; i < slots.Length; i++) //���� ������ŭ �ݺ���
        {
            if (slots[i].item == null) //���迡 �������� ���ٸ�
            {
                slots[i].AddItem(_item, _count); // ������ additem �Լ� ȣ��(�� ������ �߰�)
                return;
            }
        }

    }
}

