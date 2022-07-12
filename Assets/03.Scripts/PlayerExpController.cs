using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpController : MonoBehaviour
{
    // expBar 는 몬스터를 해치울때 증가할 예정
    [SerializeField]
    private BarController expBar;
    
    private float initHealth = 100;

    private void Start() {
        expBar.Initialize(initHealth, initHealth);
    }

    // 현재는 테스트용으로 키보드 입력으로 구현
    private void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            print("test");
            expBar.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("test2");
            expBar.MyCurrentValue += 10;
        }
    }
}
