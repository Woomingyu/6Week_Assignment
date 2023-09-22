# 6Week_Assignment

## 1.필수 요구사항 구현 완료  
1)메인 화면 구성 : 플레이어 정보, Status & Inventory 버튼  
2)각 버튼 구현 완료 (토글 버튼)  


## 2.추가 구현  
1)인벤토리 슬롯(슬롯에 아이템이 존재하면 아이템 슬롯 간 이동 가능)  
2)마우스 조작을 통한 아이템 장착, 스탯 적용, 슬롯 간 이동 (IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler  &&  ScriptableObject 사용)  


## 3.남은 버그, 아쉬운 부분  
1)아이템 장착 후 슬롯 드래그 & 드랍 시 장착 아이콘과 스탯이 남음, 슬롯 이동 후 장착이 가능한 문제  
2)각 토글 키 클릭 시 해당 버튼의 팝업을 제외한 나머지 팝업을 비활성화 했으면 좋았을 듯  
3)stringBuilder를 통해 PlayerData.cs에서 +를 최대한 줄였으면 좋았을 듯(튜터님들 의견)
