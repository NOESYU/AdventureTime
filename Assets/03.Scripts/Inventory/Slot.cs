using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item; // 아이템 변수
    public Image itemImage; // 표시된 아이템 이미지 변수

    // 슬롯의 이미지를 초기화하고 활성화시키는 메서드
    public void UpdateSlotUI() {
        itemImage.sprite = item.itemImage;
        itemImage.gameObject.SetActive(true);
    }

    // 슬롯의 정보를 초기화하고 비활성화 시키는 메서드
    public void RemoveSlot()
    {
        item = null;
        itemImage.gameObject.SetActive(false);
    }
}
