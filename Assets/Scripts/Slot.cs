using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Vector2 originPos; // 슬롯 원래위치

    public Item item; // 획득한 아이템
    public int itemCount; // 획득 아이템 개수
    public Image itemImage; // 아이템의 이미지

    //롱클릭용 변수
    private float clickTime; // 클릭 중인 시간
    [SerializeField]
    private float minClickTime = 1; // 최소 클릭시간
    private bool isClick; // 클릭 중인지 판단 

    private bool equipItem = false;
    public GameObject equipItemSym;

    [SerializeField]
    private Inventory inventory;





    //플레이어 정보
    [SerializeField]
    private PlayerData player;

    void Start()
    {
        originPos = transform.position; // 슬롯 원래 위치 저장
    }

    void Update()
    {
        //롱클릭 업데이트
        if (isClick) //클릭중
        {
            // 클릭시간 측정
            clickTime += Time.deltaTime;
        }
        // 클릭 중이 아니라면
        else
        {
            // 클릭시간 초기화
            clickTime = 0;
        }
    }




    //슬롯이 빈 상태일 때 아이템 이미지 객체 투명화
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha; // Color의 알파값
        itemImage.color = color; //파라미터 1 보임 0 안보임
    }

    //아이템 획득
    public virtual void AddItem(Item _item, int _count = 1)
    {
        item = _item; // 정보
        itemCount = _count; // 개수
        itemImage.sprite = item.itemImage; //아이템 이미지
        SetColor(1);

    }


    //슬롯 비우기(초기화)
    private void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }

    //슬롯 클릭 & 아이템 착용, 해제
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item != null)
            {
                if (item.itemType == Item.ItemType.Equipment) //아이템 타입 = 장비 //if문 보다는 함수를 나눠서 호출
                {
                    if (!equipItem) //아이템 착용 (키값으로 배열화)
                    {
                        player.ChangeInfo("weight", -item.itemWeight); //아이템 착용시 해당 아이템 무게 제거
                        player.ChangeInfo("attackDamage", item.itemAttackDamage);
                        player.ChangeInfo("defense", item.itemWeight);
                        player.ChangeInfo("health", item.itemHealth);
                        player.ChangeInfo("critical", item.itemCritical);
                        equipItemSym.SetActive(true);
                        equipItem = true;
                    }
                    else // 해제
                    {
                        player.ChangeInfo("weight", item.itemWeight); //무게 추가
                        player.ChangeInfo("attackDamage", -item.itemAttackDamage);
                        player.ChangeInfo("defense", -item.itemWeight);
                        player.ChangeInfo("health", -item.itemHealth);
                        player.ChangeInfo("critical", -item.itemCritical);
                        equipItemSym.SetActive(false);
                        equipItem = false;
                    }
                }
            }
        }
    }
    //슬롯 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("드래그");
        if (item != null)
        {
            Debug.Log("드래그 if 통과");
            DragSlot.instance.dragSlot = this; // 드래그 슬롯이 슬롯이 됨
            DragSlot.instance.DragSetImage(itemImage); // 드래그 중인 이미지도 넣어줌
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    //슬롯 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
        //theItemEffectDatabase.HideToolTip();
    }

    //슬롯 드래그 종료
    public void OnEndDrag(PointerEventData eventData) //다른곳이나 자기 자신에서 드래그 끝난경우 오출
    {
        //theItemEffectDatabase.HideToolTip();

            DragSlot.instance.SetColor(0);
            DragSlot.instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData) // 다른 슬롯에서 드래그가 끝난경우만 호출
    {
        if (DragSlot.instance.dragSlot != null) //빈슬롯 간의 ChangeSlot 호출 방지
        {
            //theItemEffectDatabase.HideToolTip();
            ChangeSlot();
        }

    }

    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount; //교체당하는 슬롯의 아이템정보 미리 복사

        //교체당하는 슬롯에 드래그 슬롯 복사체의 정보 입력(아이템/개수)
        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        //교체 당하는 슬롯에 아이템이 있다면
        if (_tempItem != null)
        {
            //드래그 슬롯에 교체당하는 아이템 복사 정보(_tempItem,_tempItemCount) 입력
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else //교체 당하는 슬롯이 비었다면
        {
            //기존 슬롯 초기화
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }



    //슬롯 롱 클릭 (툴팁 표기) == 컴포넌트)이벤트 시스템

    // 버튼 일반 클릭
    public void ButtonClick()
    {
        print("버튼 일반 클릭");
    }


    // 버튼 클릭이 시작했을 때
    public void ButtonDown()
    {
        isClick = true;
    }

    // 버튼 클릭이 끝났을 때
    public void ButtonUp()
    {
        isClick = false;

        // 클릭 중인 시간이 최소 클릭시간 이상이라면
        if (clickTime >= minClickTime && item != null)
        {
            //툴팁 호출
            //theItemEffectDatabase.ShowToolTip(item, transform.position);
        }
    }

}