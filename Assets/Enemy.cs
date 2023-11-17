using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed; //이동속도
    private Vector2 dir; //나아가야할 방향
    public Spawner spawner; //영역밖으로 나갔을때 새로 스폰하고 죽기위해 스포너에 대한 참조

    private void Start()
    {
        Vector2 dest = new(Random.Range(-Spawner.xRange, Spawner.xRange), Random.Range(-Spawner.yRange, Spawner.yRange)); //영역 안의 랜덤한 좌표
        dir = (dest - transform.position*Vector2.one).normalized; //영역 안의 랜덤한 좌표를 향하는 방향, 그것을 정규화하여 방향벡터 길이가 1이 되게

        speed = Random.Range(2, 8); //속도값을 2~8사이의 값으로 정함
    }

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed); //start에서 정한 랜덤 방향으로 계속 이동

        if((transform.position.x<-Spawner.xRange-1||transform.position.x>Spawner.xRange+1) || 
            (transform.position.y < -Spawner.yRange-1 || transform.position.y > Spawner.yRange+1)) //현재 본인 좌표가 영역 밖에 있을경우
        {
            spawner.Spawn(); //스포너에 스폰 명령 전달
            Destroy(gameObject); //본인 삭제
        }
    }

}
