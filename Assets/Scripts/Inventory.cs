using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{

    public static bool inventoryActivated = false; //인벤토리 활성화 상태


    //필요한 컴포넌트
    [SerializeField]
    private GameObject InventoryPopup;
    [SerializeField]
    private GameObject slotsGrid; //그리드 세팅 (모든 슬롯관리)
    [SerializeField]
    private PlayerData player;

    private Animator anim;

    //슬롯들
    private Slot[] slots;
    void Start()
    {
        //슬롯 배열내에 모든 실제 슬롯 입력
        slots = slotsGrid.GetComponentsInChildren<Slot>();
        player = player.GetComponent<PlayerData>();
    }




    public void TryOpenIventory()
    {
        inventoryActivated = !inventoryActivated; //누르면 활성화 인벤 비활성화 스위칭
        anim.SetBool("Appear", inventoryActivated); //인벤 활성/비활성 애니 


        //인벤토리가 열린 경우는 상태변수로 여러 조작/흐름 을 막아놓음(메모)
        if (inventoryActivated)
        {
            OpenInventory();
        }


        else
        {
            CloseInventory();
        }
    }

    //인벤토리 활성화 && 비활성화
    private void OpenInventory()
    {
        InventoryPopup.SetActive(true);
    }
    private void CloseInventory()
    {
        InventoryPopup.SetActive(false);
    }

    //아이템 획득 ==> Ore의 Destruction.반복문 &&
    public void AcquireItem(Item _item, int _count = 1)
    {
        if (!player.canPickUp)
            return;


        //동일 아이템이 없는 경우 && 장비인 경우
        for (int i = 0; i < slots.Length; i++) //슬롯 개수만큼 반복문
        {
            if (slots[i].item == null && player.canPickUp) //인벤에 동일 아이템이 없다면
            {
                slots[i].AddItem(_item, _count); // 슬롯의 additem 함수 호출(새 아이템 추가)
                return;
            }
        }

    }
}

