using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterController : MonoBehaviour
{
    public GameObject monHpBar;
    public SpriteRenderer monsterSpr;
    public SpriteRenderer itemSpr;
    public Image barImage;
    public bool isHit;
    public bool isDie;
    public Animator monsterAnim;
    public Color tran = new Color(255, 255, 255, 0);
    public Color origin = new Color(255, 255, 255, 255);
    private float speed = 2f;

    public Rigidbody2D monRb;

    private void Awake() {
        monsterSpr = GetComponent<SpriteRenderer>();
        itemSpr = transform.GetChild(1).GetComponent<SpriteRenderer>();
        monHpBar = transform.GetChild(0).gameObject;
        monsterAnim = GetComponent<Animator>();
    }

    private void Start() {
        itemSpr.color = tran;
        StartCoroutine(MoveControl());

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackEffe")) {
            isHit = true;
            monsterAnim.SetBool("isHit", isHit);
            AttackDamage();
        }

    }

    public void AttackDamage() {
        barImage.fillAmount -= 0.2f;
    }

    private void Update() {
        if(barImage.fillAmount < 0.01)
        {
            monsterAnim.SetTrigger("isDie");
        }
    }

    private void StopHit() {
        isHit = false;
        monsterAnim.SetBool("isHit", isHit);
    }
    
    private void MonsterDie() {
        monHpBar.SetActive(false);
        isDie = true;
        monRb.velocity = Vector2.zero;
        
        monsterSpr.color = tran;
        itemSpr.color = origin;
    }

    IEnumerator MoveControl() {
        monRb = GetComponent<Rigidbody2D>();
        while(!isDie){
            float dirX = Random.Range(-1f, 1f);
            float dirY = Random.Range(-1f, 1f);
            
            monRb.velocity = new Vector2(dirX, dirY) * speed;

            yield return new WaitForSeconds(1);
        }
    }
}
