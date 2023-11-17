using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //스폰할 오브젝트
    public GameObject enemy;

    public static float xRange = 25; //영역의 x절반넓이
    public static float yRange = 25; //영역의 y절반넓이

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            Spawn(); //처음에 30마리 스폰
        }
    }

    public void Spawn()
    {
        if (Random.Range(-1f,1f)>0) //상하 스폰 (-1~1 사이의 랜덤값이 0보다 클경우 상하스폰)
        {
            GameObject instance = Instantiate(enemy); //적 스폰
            instance.transform.position = new(Random.Range(-xRange, xRange), Mathf.Sign(Random.Range(-1, 1))*yRange,0); //적 좌표 설정 Sign()은 양수면 1, 음수면 -1반환, x좌표는 (-x넓이 ~ x넓이)사이의 랜덤값이고, y좌표는 음수 양수가 랜덤인 y넓이의 값임
            instance.GetComponent<Enemy>().spawner = this; //적 스크립트가 죽었을때 새로 스폰하기위해 스포너 참조 할당
        }
        else //좌우 스폰
        {
            GameObject instance = Instantiate(enemy);
            instance.transform.position = new(Mathf.Sign(Random.Range(-1, 1))*xRange, Random.Range(-yRange, yRange), 0); //위의 것에서 x,y값 바꿈
            instance.GetComponent<Enemy>().spawner = this;
        }
    }
}
