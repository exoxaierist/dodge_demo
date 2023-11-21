using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private float survivalTime = 0; //생존시간

    private void Update()
    {
        survivalTime += Time.deltaTime; //생존시간 카운트

        //이동
        Vector2 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(input * Time.deltaTime * speed);
    }

    //적 충돌시
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("생존시간 : " + survivalTime + "초");

        survivalTime = 0; //생존시간 초기화
        transform.position = Vector3.zero; //위치 초기화
        Spawner.spawner.Reset(); //스포너 초기화
    }
}
