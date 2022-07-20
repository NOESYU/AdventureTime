using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // 싱글턴 패턴 변수 선언
    public static Inventory instance;

    // slotCount 의 변화를 알려줄 delegate 정의
    public delegate void OnSlotCountChange(int value);
    // slotCount 의 변화를 알려줄 delegate 인스턴스화
    public OnSlotCountChange onSlotCountChange;

    // 아이템 추가시 슬롯 UI 에 알려줄 delegate 정의
    public delegate void OnChangeItem();
    // 아이템 추가시 슬롯 UI 에 알려줄 delegate 인스턴스화
    public OnChangeItem onChangeItem;

    // Slot 의 갯수를 지정할 변수
    private int slotCount;

    // slot 갯수 프로퍼티화해서 get, set 설정
    public int SlotCount
    {
        // 외부에서 값을 읽으면 넘겨줌
        get => slotCount;

        // 외부에서 값을 쓸 경우 set
        set
        {
            // slotCount 에 입력값(value)을 할당
            slotCount = value;
            // slotCount 의 변화를 알려줄 delegate 호출
            onSlotCountChange(slotCount);
        }
    }

    // 획득할 아이템을 보관할 List
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        if(instance != null) 
        {
            // instance가 비어있지 않으면 현재 오브젝트 파괴
            Destroy(gameObject);

            return;
        }
        // instance 가 비어잇으면 자기 자신을 instance 에 할당
        instance = this;
    }

    private void Start() {
        SlotCount = 3;
    }

    public bool AddItem(Item item)
    {
        // 만약에 items(List)의 갯수가 실제 사용 가능한
        // 현재 활성화된 slot 갯수보다 작다면
        if(items.Count <slotCount ){
            // items 리스트에 아이템 추가
            items.Add(item);
            // 만약에 onChangeItem이 비어있지 않다면
            if(onChangeItem != null) onChangeItem();

            return true; // 아이템 추가 성공 반환
        }

        return false; // 아이템 추가 실패
    }

    // 플레이어와 필드 아이템 충돌 처리
    private void OnTriggerEnter2D(Collider2D other) {
        // 만약에 충돌한 상대의 태그가 FieldItem 이라면
        if(other.CompareTag("FieldItem")) {
            // 충돌한 아이템에서 FieldItems 컴포넌트를 담기
            // 1. FieldItems 에서 아이템의 정보(데이터)가 들어있다.
            FieldItem fieldItem = other.GetComponent<FieldItem>();

            // 만약에 AddItem 메서드에 아이템의 정보를 보내서 아이템 추가에 성공하면
            // 충돌한 아이템 삭제
            if(AddItem(fieldItem.GetItem())) fieldItem.DestroyItem();
        }    
    }
}
