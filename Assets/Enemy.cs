using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed; //�̵��ӵ�
    private Vector2 dir; //���ư����� ����
    public Spawner spawner; //���������� �������� ���� �����ϰ� �ױ����� �����ʿ� ���� ����

    private void Start()
    {
        Vector2 dest = new(Random.Range(-Spawner.xRange, Spawner.xRange), Random.Range(-Spawner.yRange, Spawner.yRange)); //���� ���� ������ ��ǥ
        dir = (dest - transform.position*Vector2.one).normalized; //���� ���� ������ ��ǥ�� ���ϴ� ����, �װ��� ����ȭ�Ͽ� ���⺤�� ���̰� 1�� �ǰ�

        speed = Random.Range(2, 8); //�ӵ����� 2~8������ ������ ����
    }

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed); //start���� ���� ���� �������� ��� �̵�

        if((transform.position.x<-Spawner.xRange-1||transform.position.x>Spawner.xRange+1) || 
            (transform.position.y < -Spawner.yRange-1 || transform.position.y > Spawner.yRange+1)) //���� ���� ��ǥ�� ���� �ۿ� �������
        {
            spawner.Spawn(); //�����ʿ� ���� ��� ����
            Destroy(gameObject); //���� ����
        }
    }

}
