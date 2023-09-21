using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Vector2 originPos; // ���� ������ġ

    public Item item; // ȹ���� ������
    public int itemCount; // ȹ�� ������ ����
    public Image itemImage; // �������� �̹���

    //��Ŭ���� ����
    private float clickTime; // Ŭ�� ���� �ð�
    [SerializeField]
    private float minClickTime = 1; // �ּ� Ŭ���ð�
    private bool isClick; // Ŭ�� ������ �Ǵ� 

    private bool equipItem = false;
    public GameObject equipItemSym;

    [SerializeField]
    private Inventory inventory;





    //�÷��̾� ����
    [SerializeField]
    private PlayerData player;

    void Start()
    {
        originPos = transform.position; // ���� ���� ��ġ ����
    }

    void Update()
    {
        //��Ŭ�� ������Ʈ
        if (isClick) //Ŭ����
        {
            // Ŭ���ð� ����
            clickTime += Time.deltaTime;
        }
        // Ŭ�� ���� �ƴ϶��
        else
        {
            // Ŭ���ð� �ʱ�ȭ
            clickTime = 0;
        }
    }




    //������ �� ������ �� ������ �̹��� ��ü ����ȭ
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha; // Color�� ���İ�
        itemImage.color = color; //�Ķ���� 1 ���� 0 �Ⱥ���
    }

    //������ ȹ��
    public virtual void AddItem(Item _item, int _count = 1)
    {
        item = _item; // ����
        itemCount = _count; // ����
        itemImage.sprite = item.itemImage; //������ �̹���
        SetColor(1);

    }


    //���� ����(�ʱ�ȭ)
    private void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }

    //���� Ŭ�� & ������ ����, ����
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item != null)
            {
                if (item.itemType == Item.ItemType.Equipment) //������ Ÿ�� = ��� //if�� ���ٴ� �Լ��� ������ ȣ��
                {
                    if (!equipItem) //������ ���� (Ű������ �迭ȭ)
                    {
                        player.ChangeInfo("weight", -item.itemWeight); //������ ����� �ش� ������ ���� ����
                        player.ChangeInfo("attackDamage", item.itemAttackDamage);
                        player.ChangeInfo("defense", item.itemWeight);
                        player.ChangeInfo("health", item.itemHealth);
                        player.ChangeInfo("critical", item.itemCritical);
                        equipItemSym.SetActive(true);
                        equipItem = true;
                    }
                    else // ����
                    {
                        player.ChangeInfo("weight", item.itemWeight); //���� �߰�
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
    //���� �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("�巡��");
        if (item != null)
        {
            Debug.Log("�巡�� if ���");
            DragSlot.instance.dragSlot = this; // �巡�� ������ ������ ��
            DragSlot.instance.DragSetImage(itemImage); // �巡�� ���� �̹����� �־���
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    //���� �巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
        //theItemEffectDatabase.HideToolTip();
    }

    //���� �巡�� ����
    public void OnEndDrag(PointerEventData eventData) //�ٸ����̳� �ڱ� �ڽſ��� �巡�� ������� ����
    {
        //theItemEffectDatabase.HideToolTip();

            DragSlot.instance.SetColor(0);
            DragSlot.instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData) // �ٸ� ���Կ��� �巡�װ� ������츸 ȣ��
    {
        if (DragSlot.instance.dragSlot != null) //�󽽷� ���� ChangeSlot ȣ�� ����
        {
            //theItemEffectDatabase.HideToolTip();
            ChangeSlot();
        }

    }

    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount; //��ü���ϴ� ������ ���������� �̸� ����

        //��ü���ϴ� ���Կ� �巡�� ���� ����ü�� ���� �Է�(������/����)
        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        //��ü ���ϴ� ���Կ� �������� �ִٸ�
        if (_tempItem != null)
        {
            //�巡�� ���Կ� ��ü���ϴ� ������ ���� ����(_tempItem,_tempItemCount) �Է�
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else //��ü ���ϴ� ������ ����ٸ�
        {
            //���� ���� �ʱ�ȭ
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }



    //���� �� Ŭ�� (���� ǥ��) == ������Ʈ)�̺�Ʈ �ý���

    // ��ư �Ϲ� Ŭ��
    public void ButtonClick()
    {
        print("��ư �Ϲ� Ŭ��");
    }


    // ��ư Ŭ���� �������� ��
    public void ButtonDown()
    {
        isClick = true;
    }

    // ��ư Ŭ���� ������ ��
    public void ButtonUp()
    {
        isClick = false;

        // Ŭ�� ���� �ð��� �ּ� Ŭ���ð� �̻��̶��
        if (clickTime >= minClickTime && item != null)
        {
            //���� ȣ��
            //theItemEffectDatabase.ShowToolTip(item, transform.position);
        }
    }

}