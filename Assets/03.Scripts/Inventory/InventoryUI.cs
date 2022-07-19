using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Inventory 컴포넌트 가져오기
    private Inventory inventory;
    // InventoryBGImage 오브젝트 담길 변수
    public GameObject invenImage;

    // InventoryBGImage 오브젝트의 acitve 상태 담당 bool
    private bool invenActive;

    // 사용자 인벤토리의 슬롯이 담길 배열 선언
    public Slot[] slots;
    // slot들을 품고있는 부모 오브젝트(Content) 담길 변수
    public Transform slotHolder;

    private void Start() {
        // slotHolder 의 자식 오브젝트들을 Slot 컴포넌트 slots 배열에 넣기
        slots = GetComponentsInChildren<Slot>();
        // Start하면서 invenImage 비활성화시키기
        invenImage.SetActive(invenActive);
        // inventory 변수 초기화
        inventory = Inventory.instance;
        // inventory > onSlotCountChange 에 SlotChange 메서드 등록
        inventory.onSlotCountChange += SlotChange;
        // inventory > onChangeItem 에 ReDrawSlotUI 메서드 등록
        inventory.onChangeItem += ReDrawSlotUI;
    }

    private void SlotChange(int value)
    {
        for(int i=0; i<slots.Length; i++)
        {
            // inventory내 slot을 SlotCount 의 값보다 적은 갯수만 interactable 을 true 로 설정 
            slots[i].GetComponent<Button>().interactable = i < inventory.SlotCount? true : false;

        }
    }
    
    // 반복문을 통해 슬롯들을 초기화하고 items 개수만큼 slot을 채워넣는 메서드
    private void ReDrawSlotUI()
    {
        for (int i=0; i<slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i=0; i<inventory.items.Count; i++)
        {
            slots[i].item = inventory.items[i];
            slots[i].UpdateSlotUI();
        }
    }

    private void AddSlot()
    {
        inventory.SlotCount++;
    }

    public void OnClickInvenButton() {
        // Inventory BUtton 을 누르면
        // 현재 상태의 반대상태로 SetActive, 활성화/비활성화 담당
        invenActive = !invenActive;
        invenImage.SetActive(invenActive);
    }
}
