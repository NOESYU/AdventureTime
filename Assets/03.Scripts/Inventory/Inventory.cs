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

}
