using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //스폰할 오브젝트
    public GameObject enemy;
    public GameObject followingEnemy;

    public static float xRange = 25; //영역의 x절반넓이
    public static float yRange = 25; //영역의 y절반넓이

    public static Spawner spawner; //다른곳에서 쉽게 이 클래스를 부르게 하기 위해 스태틱 변수를 만듦

    private void Start()
    {
        spawner = this; //스태틱 스포너에 본인을 할당

        GameStart();
    }

    // 게임 시작될때 30마리를 만드는 함수
    public void GameStart()
    {
        for (int i = 0; i < 30; i++)
        {
            Spawn(); //처음에 30마리 스폰
        }
    }

    // 적을 초기화하고 새로 스폰하는 함수
    public void Reset()
    {
        //모든 적 개체 삭제
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy"); //태그가 enemy인 모든 오브젝트 찾기

        for (int i=0; i<enemies.Length;i++) //for루프로 적 모두 제거
        {
            Destroy(enemies[i]);
        }

        GameStart();
    }

    //적 하나를 스폰하는 함수
    public void Spawn()
    {
        bool isFollowing = Random.Range(0f, 1f) > 0.8f; //20%확률로 따라가는 적을 만듦
        if (Random.Range(-1f,1f)>0) //상하 스폰 (-1~1 사이의 랜덤값이 0보다 클경우 상하스폰)
        {
            GameObject instance;
            if (isFollowing)
            {
                instance = Instantiate(followingEnemy); //따라가는적 스폰
            }
            else
            {
                instance = Instantiate(enemy); //그냥적 스폰
            }
            
            instance.transform.position = new(Random.Range(-xRange, xRange), Mathf.Sign(Random.Range(-1, 1))*yRange,0); //적 좌표 설정 Sign()은 양수면 1, 음수면 -1반환, x좌표는 (-x넓이 ~ x넓이)사이의 랜덤값이고, y좌표는 음수 양수가 랜덤인 y넓이의 값임
        }
        else //좌우 스폰
        {
            GameObject instance;
            if (isFollowing)
            {
                instance = Instantiate(followingEnemy); //따라가는적 스폰
            }
            else
            {
                instance = Instantiate(enemy); //그냥적 스폰
            }
            instance.transform.position = new(Mathf.Sign(Random.Range(-1, 1))*xRange, Random.Range(-yRange, yRange), 0); //위의 것에서 x,y값 바꿈
        }
    }
}
