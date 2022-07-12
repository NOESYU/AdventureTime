using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMpController : MonoBehaviour
{
    [SerializeField]
    private BarController mpBar;
    
    private float initMana = 100;

    private void Start() {
        mpBar.Initialize(initMana, initMana);
    }

    // 현재는 테스트용으로 키보드 입력으로 구현
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            print("mptest");
            mpBar.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("mptest2");
            mpBar.MyCurrentValue += 10;
        }
    }
}
