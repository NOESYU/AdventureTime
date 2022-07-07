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
    public VirtualJoyStick virtualJoyStick;
    
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // VirtualJoyStick 에서 프로퍼티로 받아옴
    public void Move() {
        xMove = virtualJoyStick.Horizontal;
        yMove = virtualJoyStick.Vertical;
    }

    private void Update()
    {
        Move();
    }
    // Update is called once per frame
    void FixedUpdate()
    {        
        transform.Translate(xMove * xSpeed * Time.deltaTime, yMove * ySpeed * Time.deltaTime, 0);
    }
}
