using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    // 실제 적용할 Item
    public Item m_item;

    // 실제 적용할 Image SprtieRenderer
    public SpriteRenderer Image;

    // 아이템 데이터 생성 메서드
    public void SetItem(Item item)
    {
        m_item.itemName = item.itemName;
        m_item.itemImage = item.itemImage;
        m_item.itemType = item.itemType;

        Image.sprite = m_item.itemImage;
    }

    // 아이템 획득시 실행될 메서드
    public Item GetItem()
    {
        return m_item;
    }

    // 아이템 획득 후 실행될 메서드
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
