using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSpawn : MonoBehaviour
{
    public GameObject monster; // 생성할 게임 오브젝트 원본 몬스터 프리팹

    private int curIndex; // 몬스터 생성 인덱스
    private int allMonCount = 3; // 맵에 젠 될 수 있는 몬스터 총 갯수

    private BoxCollider2D map; // BoxCollider 사이즈를 가져와 젠 범위 지정
    private List<GameObject> monsters = new List<GameObject>(); // 미리 생성한 몬스터 오브젝트 리스트

    // 초반에 몬스터를 생성시켜둘 위치
    private Vector2 monPoolPos = new Vector2(20, 20);

    private void Start()
    {
        map = GetComponent<BoxCollider2D>();
        PreMonster();

        StartCoroutine(MonsterSpanwn(2));
    }

    IEnumerator MonsterSpanwn(float delayTime)
    {
        Vector3 spawnPos = GetRandomPosition(); // 랜덤 위치 return 값 받아오기
       
        
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(MonsterSpanwn(2));
    }

    private void PreMonster()
    {
        for (int i = 0; i < allMonCount; i++)
        {
            GameObject instance = Instantiate(monster, monPoolPos, Quaternion.identity);
            monsters.Add(instance);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePos = transform.position; // 오브젝트의 위치
        Vector2 size = new Vector2(map.size.x, map.size.y + map.offset.y); // BoxCollider2D 의 사이즈(맵 크기 벡터)

        // x, y 축 랜덤 좌표
        float xPos = basePos.x + Random.Range(-size.x / 2f, size.x / 2f);
        float yPos = basePos.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(xPos, yPos);

        return spawnPos;
    }
}
