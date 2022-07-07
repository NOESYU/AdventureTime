using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TESTPLAYERMOVE : MonoBehaviour
{
    public float mx;
    public float my;

    void Update()
    {

        my = Input.GetAxis("Vertical");
        mx = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {            
        // 플레이어 움직임 이동 및 애니메이션 효과
        transform.Translate(new Vector3(mx, my, 0).normalized * Time.fixedDeltaTime * 10);     
    }
}

