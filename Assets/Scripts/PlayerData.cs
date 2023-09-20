using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //current가 있는 값은 default값이 존재함


    //##플레이어 인포 관리##
    [SerializeField]
    private string name;
    [SerializeField]
    private int level;
    [SerializeField]
    private int exp;
    private int currentExp;
    [SerializeField]
    private int gold;

    //##플레이어 스테이터스##
    [SerializeField]
    private int attackDamage;
    [SerializeField]
    private int defense;
    [SerializeField]
    private int health;
    [SerializeField]
    private int critical;

    //##무게##
    [SerializeField]
    private int weight;
    private int currentWeight;

    [SerializeField]
    private TextMeshProUGUI[] Txts_Gauge;
    private const int NAME = 0, LEVEL = 1, EXP = 2, GOLD = 3, AD = 4, DP = 5, HP = 6, CRITICAL = 7, WEIGHT = 8;


    public bool canPickUp = true; //무게 상태 (소지품 한계)


    private void Start()
    {
        InfoUpdate();
    }
    private void Update()
    {        
    }
    //##스테이터스##
    private void InfoUpdate()
    {
        //텍스트 업데이트
        Txts_Gauge[NAME].text = name;
        Txts_Gauge[LEVEL].text = "Lv : " + level;
        Txts_Gauge[EXP].text = "경험치 : " + currentExp + " / " + exp; // 현재 경험치 / 최대경험치
        Txts_Gauge[GOLD].text = gold + " G";
        Txts_Gauge[AD].text = "공격력 : " + attackDamage;
        Txts_Gauge[DP].text = "방어력 : " + defense;
        Txts_Gauge[HP].text = "체력 : " + health;
        Txts_Gauge[CRITICAL].text = "치명타 : " + critical;

        Txts_Gauge[WEIGHT].text = "무게 : " + currentWeight + " / " + weight; // 현재 무게 / 최대 무게 표시
    }


    //여기서 번호가 아닌 string으로 알아보기 쉽게 하는법이 있었는데 까먹음
    //TODO 내일 처리하자
    public void ChangeInfo(int infoType, int _count)
    {
        if(infoType == 0)
        Txts_Gauge[infoType].name += _count;
    }

}
