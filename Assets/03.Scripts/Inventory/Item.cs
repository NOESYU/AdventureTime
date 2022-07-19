using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 타입 열거형으로 정의
public enum ItemType {
    monster,
    potion,
    Etc
}

[System.Serializable]
public class Item 
{
    public ItemType itemType; // 아이템 타입
    public string itemName; // 아이템 이름
    public Sprite itemImage; // 아이템 이미지

    // 아이템 사용 메서드 : 사용 성공 여부를 return
    public bool Use()
    {
        return true;
    }
}
