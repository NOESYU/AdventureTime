using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpController : MonoBehaviour
{
    [SerializeField]
    private BarController hpBar;
    
    private float initHealth = 100;

    private void Start() {
        hpBar.Initialize(initHealth, initHealth);
    }

    // 현재는 테스트용으로 키보드 입력으로 구현
    private void Update() {
        if(Input.GetKeyDown(KeyCode.I))
        {
            print("hptest");
            hpBar.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            print("hptest2");
            hpBar.MyCurrentValue += 10;
        }
    }
}
