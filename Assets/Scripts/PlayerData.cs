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


    //상수값을 통해 할당값과 플레이어 정보의 변수값을 일치시킨다.
    [SerializeField]
    private TextMeshProUGUI[] Txts_Gauge;
    private const int NAME = 0, LEVEL = 1, EXP = 2, GOLD = 3, AD = 4, DP = 5, HP = 6, CRITICAL = 7, WEIGHT = 8;


    public bool canPickUp = true; //무게 상태 (소지품 한계)


    private void Start()
    {
        InfoUpdate();
    }
    //##스테이터스##
    private void InfoUpdate()
    {
        //인자가 가변적인 경우 : params를 사용해본다.
        //텍스트 업데이트(const read only) //for문을 돌 수도 있다.
        Txts_Gauge[NAME].text = name;
        Txts_Gauge[LEVEL].text = "Lv : " + level;
        Txts_Gauge[EXP].text = "경험치 : " + currentExp + " / " + exp; // 현재 경험치 / 최대경험치
        Txts_Gauge[GOLD].text = gold + " G";
        Txts_Gauge[AD].text = "공격력 : " + attackDamage;
        Txts_Gauge[DP].text = "방어력 : " + defense;
        Txts_Gauge[HP].text = "체력 : " + health;
        Txts_Gauge[CRITICAL].text = "치명타 : " + critical;

        Txts_Gauge[WEIGHT].text = "무게 : " + currentWeight + " / " + weight; // 현재 무게 / 최대 무게 표시(stringBulider 사용한다.)
    }


    //여기서 번호가 아닌 string으로 알아보기 쉽게 하는법이 있었는데 까먹음
    //TODO 내일 처리하자
    public void ChangeInfo(string infoType, int _count)
    {
        switch (infoType)
        {
            case "level":
                level += _count;
                break;
            case "currentExp":
                currentExp += _count;
                break;
            case "gold":
                gold += _count;
                break;
            case "attackDamage":
                attackDamage += _count;
                break;
            case "defense":
                defense += _count;
                break;
            case "health":
                health += _count;
                break;
            case "critical":
                critical += _count;
                break;
            case "weight":
                currentWeight += _count;
                break;
            default:
                // 지원하지 않는 정보 유형일 경우 처리할 내용 추가
                break;
        }

        // 정보를 수정한 후에 업데이트 메서드를 호출하여 UI를 업데이트합니다.
        InfoUpdate();
    }

}
