using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //current�� �ִ� ���� default���� ������


    //##�÷��̾� ���� ����##
    [SerializeField]
    private string name;
    [SerializeField]
    private int level;
    [SerializeField]
    private int exp;
    private int currentExp;
    [SerializeField]
    private int gold;

    //##�÷��̾� �������ͽ�##
    [SerializeField]
    private int attackDamage;
    [SerializeField]
    private int defense;
    [SerializeField]
    private int health;
    [SerializeField]
    private int critical;

    //##����##
    [SerializeField]
    private int weight;
    private int currentWeight;

    [SerializeField]
    private TextMeshProUGUI[] Txts_Gauge;
    private const int NAME = 0, LEVEL = 1, EXP = 2, GOLD = 3, AD = 4, DP = 5, HP = 6, CRITICAL = 7, WEIGHT = 8;


    public bool canPickUp = true; //���� ���� (����ǰ �Ѱ�)


    private void Start()
    {
        InfoUpdate();
    }
    private void Update()
    {        
    }
    //##�������ͽ�##
    private void InfoUpdate()
    {
        //�ؽ�Ʈ ������Ʈ
        Txts_Gauge[NAME].text = name;
        Txts_Gauge[LEVEL].text = "Lv : " + level;
        Txts_Gauge[EXP].text = "����ġ : " + currentExp + " / " + exp; // ���� ����ġ / �ִ����ġ
        Txts_Gauge[GOLD].text = gold + " G";
        Txts_Gauge[AD].text = "���ݷ� : " + attackDamage;
        Txts_Gauge[DP].text = "���� : " + defense;
        Txts_Gauge[HP].text = "ü�� : " + health;
        Txts_Gauge[CRITICAL].text = "ġ��Ÿ : " + critical;

        Txts_Gauge[WEIGHT].text = "���� : " + currentWeight + " / " + weight; // ���� ���� / �ִ� ���� ǥ��
    }


    //���⼭ ��ȣ�� �ƴ� string���� �˾ƺ��� ���� �ϴ¹��� �־��µ� �����
    //TODO ���� ó������
    public void ChangeInfo(int infoType, int _count)
    {
        if(infoType == 0)
        Txts_Gauge[infoType].name += _count;
    }

}
