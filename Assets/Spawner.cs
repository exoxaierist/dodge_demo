using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //������ ������Ʈ
    public GameObject enemy;
    public GameObject followingEnemy;

    public static float xRange = 25; //������ x���ݳ���
    public static float yRange = 25; //������ y���ݳ���

    public static Spawner spawner; //�ٸ������� ���� �� Ŭ������ �θ��� �ϱ� ���� ����ƽ ������ ����

    private void Start()
    {
        spawner = this; //����ƽ �����ʿ� ������ �Ҵ�

        GameStart();
    }

    // ���� ���۵ɶ� 30������ ����� �Լ�
    public void GameStart()
    {
        for (int i = 0; i < 30; i++)
        {
            Spawn(); //ó���� 30���� ����
        }
    }

    // ���� �ʱ�ȭ�ϰ� ���� �����ϴ� �Լ�
    public void Reset()
    {
        //��� �� ��ü ����
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy"); //�±װ� enemy�� ��� ������Ʈ ã��

        for (int i=0; i<enemies.Length;i++) //for������ �� ��� ����
        {
            Destroy(enemies[i]);
        }

        GameStart();
    }

    //�� �ϳ��� �����ϴ� �Լ�
    public void Spawn()
    {
        bool isFollowing = Random.Range(0f, 1f) > 0.8f; //20%Ȯ���� ���󰡴� ���� ����
        if (Random.Range(-1f,1f)>0) //���� ���� (-1~1 ������ �������� 0���� Ŭ��� ���Ͻ���)
        {
            GameObject instance;
            if (isFollowing)
            {
                instance = Instantiate(followingEnemy); //���󰡴��� ����
            }
            else
            {
                instance = Instantiate(enemy); //�׳��� ����
            }
            
            instance.transform.position = new(Random.Range(-xRange, xRange), Mathf.Sign(Random.Range(-1, 1))*yRange,0); //�� ��ǥ ���� Sign()�� ����� 1, ������ -1��ȯ, x��ǥ�� (-x���� ~ x����)������ �������̰�, y��ǥ�� ���� ����� ������ y������ ����
        }
        else //�¿� ����
        {
            GameObject instance;
            if (isFollowing)
            {
                instance = Instantiate(followingEnemy); //���󰡴��� ����
            }
            else
            {
                instance = Instantiate(enemy); //�׳��� ����
            }
            instance.transform.position = new(Mathf.Sign(Random.Range(-1, 1))*xRange, Random.Range(-yRange, yRange), 0); //���� �Ϳ��� x,y�� �ٲ�
        }
    }
}
