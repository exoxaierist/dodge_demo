using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private float survivalTime = 0; //�����ð�

    private void Update()
    {
        survivalTime += Time.deltaTime; //�����ð� ī��Ʈ

        //�̵�
        Vector2 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(input * Time.deltaTime * speed);
    }

    //�� �浹��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("�����ð� : " + survivalTime + "��");

        survivalTime = 0; //�����ð� �ʱ�ȭ
        transform.position = Vector3.zero; //��ġ �ʱ�ȭ
        Spawner.spawner.Reset(); //������ �ʱ�ȭ
    }
}
