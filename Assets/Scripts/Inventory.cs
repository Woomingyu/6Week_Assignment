using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{

    public static bool inventoryActivated = false; //�κ��丮 Ȱ��ȭ ����


    //�ʿ��� ������Ʈ
    [SerializeField]
    private GameObject InventoryPopup;
    [SerializeField]
    private GameObject slotsGrid; //�׸��� ���� (��� ���԰���)
    [SerializeField]
    private PlayerData player;

    private Animator anim;

    //���Ե�
    private Slot[] slots;
    void Start()
    {
        //���� �迭���� ��� ���� ���� �Է�
        slots = slotsGrid.GetComponentsInChildren<Slot>();
        player = player.GetComponent<PlayerData>();
    }




    public void TryOpenIventory()
    {
        inventoryActivated = !inventoryActivated; //������ Ȱ��ȭ �κ� ��Ȱ��ȭ ����Ī
        anim.SetBool("Appear", inventoryActivated); //�κ� Ȱ��/��Ȱ�� �ִ� 


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

    //�κ��丮 Ȱ��ȭ && ��Ȱ��ȭ
    private void OpenInventory()
    {
        InventoryPopup.SetActive(true);
    }
    private void CloseInventory()
    {
        InventoryPopup.SetActive(false);
    }

    //������ ȹ�� ==> Ore�� Destruction.�ݺ��� &&
    public void AcquireItem(Item _item, int _count = 1)
    {
        if (!player.canPickUp)
            return;


        //���� �������� ���� ��� && ����� ���
        for (int i = 0; i < slots.Length; i++) //���� ������ŭ �ݺ���
        {
            if (slots[i].item == null && player.canPickUp) //�κ��� ���� �������� ���ٸ�
            {
                slots[i].AddItem(_item, _count); // ������ additem �Լ� ȣ��(�� ������ �߰�)
                return;
            }
        }

    }
}

