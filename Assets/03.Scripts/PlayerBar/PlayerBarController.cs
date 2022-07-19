using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarController : MonoBehaviour
{
    [SerializeField]
    private BarController hpBar;
    [SerializeField]
    private BarController mpBar;
    
    private float initHealth = 100;
    private float initMana = 100;

    private void Start() {
        hpBar.Initialize(initHealth, initHealth);
        mpBar.Initialize(initMana, initMana);
    }

    public void OnClickHPPotion() {
        // HP 포션 회복
        print("hptest2");
        hpBar.MyCurrentValue += 10;
    }

    public void OnClickMPPotion() {
        // MP 포션 회복
        print("mptest2");
        mpBar.MyCurrentValue += 10;
    }
}
