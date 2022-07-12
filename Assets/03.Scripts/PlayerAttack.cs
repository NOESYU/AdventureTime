using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnim;
    public VirtualJoyStick virtualJoyStick;
    public PlayerInput playerInput;
    public SpriteRenderer playerSprite;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    public void OnAttackButtonClick()
    {
        playerInput.isAttack = true;

        if (virtualJoyStick.Horizontal < 0) {
            playerSprite.flipX = true;
        }
        else {
            playerSprite.flipX = false;
        }

        playerAnim.SetBool("isAttack", playerInput.isAttack);
    }

    private void Update()
    {
    
    }
}
