using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    public float xMove;
    public float yMove;

    public float speed = 3f;

    public bool isMove;
    public bool isAttack;
    public Coroutine attackRoutine;

    public Rigidbody2D playerRb;
    public Animator playerAnim;

    public VirtualJoyStick virtualJoyStick;
    
    public enum LayerName
    {
        IdleLayer = 0,
        MoveLayer = 1
    }

    // 필요한 값들 초기화
    private void Start()
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
        transform.Translate(xMove * speed * Time.deltaTime, yMove * speed * Time.deltaTime, 0);
    }

    // 플레이어 이동방향에 따른 애니메이션 구현을 위한 상태 정보, Update 메서드에서 호출
    // 플레이어의 애니메이션은 블렌드 트리를 이용해서 구현
    public void PlayerState()
    {   
        // Approximately 메서드로 0과 xMove, yMove의 값을 비교
        // 0과 근사하면 멈춰있다고 판단하고 isMove를 false로 설정
        if (Mathf.Approximately(xMove, 0) && Mathf.Approximately(yMove, 0))
        {
            isMove = false;
            ActivateLayer(LayerName.IdleLayer);
            isMove = true;
        }

        // // 0과 근사하지않으면 움직이는 상태라고 판단 isMove true 설정
        else
        {
            ActivateLayer(LayerName.MoveLayer);
            // xMove, yMove의 값을 기준으로 left, right, up, down 에 해당하는 애니메이션 재생
            playerAnim.SetFloat("xDir", xMove);
            playerAnim.SetFloat("yDir", yMove);
        }
    }

    // 공격 모션 멈추기 위한 메서드
    public void StopAttack() {
        playerAnim.SetBool("isAttack", false);
    }

    public void ActivateLayer(LayerName layerName)
    {
        //원하는 레이어를 활성화하기전에 모든 레이어의 weight 값을 0으로 변경
        for(int i=0; i<playerAnim.layerCount; i++)
        {
            playerAnim.SetLayerWeight(i, 0);
        }

        playerAnim.SetLayerWeight((int)layerName, 1); // 원하는 레이어 활성화
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
