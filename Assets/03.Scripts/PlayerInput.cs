using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float xMove;
    public float yMove;

    public float xSpeed = 3f;
    public float ySpeed = 3f;

    public Rigidbody2D playerRb;
    public Animator playerAnim;

    public VirtualJoyStick virtualJoyStick;

    public bool isRightMove;
    public bool isUpMove;
    public bool isDownMove;
    
    // 필요한 값들 초기화
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // 플레이어 움직임 담당, FixedUpdate 메서드에서 호출
    public void Move()
    {
        // VirtualJoyStick 에서 방향정보 프로퍼티로 받아옴
        xMove = virtualJoyStick.Horizontal;
        yMove = virtualJoyStick.Vertical;
        
        // 실제 움직임 구현
        transform.Translate(xMove * xSpeed * Time.deltaTime, yMove * ySpeed * Time.deltaTime, 0);
    }

    // 플레이어 이동방향에 따른 애니메이션 구현을 위한 상태 정보, Update 메서드에서 호출
    // 플레이어의 애니메이션은 블렌드 트리를 이용해서 구현
    public void PlayerState()
    {   
        // Approximately 메서드로 0과 xMove, yMove의 값을 비교
        // 0과 근사하면 멈춰있다고 판단하고 isMove를 false로 설정
        if (Mathf.Approximately(xMove, 0) && Mathf.Approximately(yMove, 0))
        {
            playerAnim.SetBool("isMove", false);
        }
        // 0과 근사하지않으면 움직이는 상태라고 판단 isMove true 설정
        else
        {
            playerAnim.SetBool("isMove", true);
        }

        // xMove, yMove의 값을 기준으로 left, right, up, down 에 해당하는 애니메이션 재생
        playerAnim.SetFloat("xDir", xMove);
        playerAnim.SetFloat("yDir", yMove);
    }

    private void Update()
    {
        PlayerState();
    }
    
    void FixedUpdate()
    {   
        Move();
    }
}
