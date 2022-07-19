using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackEffe;
    public Animator playerAnim;
    public VirtualJoyStick virtualJoyStick;
    public PlayerInput playerInput;
    public SpriteRenderer playerSprite;

    private void Awake()
    {
        attackEffe = transform.GetChild(1).gameObject;
        playerAnim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        attackEffe.SetActive(playerInput.isAttack);    
    }

    public void OnAttackButtonClick()
    {
        playerInput.isAttack = true;
        attackEffe.SetActive(playerInput.isAttack);

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
