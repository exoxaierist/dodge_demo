using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //������ ������Ʈ
    public GameObject enemy;

    public static float xRange = 25; //������ x���ݳ���
    public static float yRange = 25; //������ y���ݳ���

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            Spawn(); //ó���� 30���� ����
        }
    }

    public void Spawn()
    {
        if (Random.Range(-1f,1f)>0) //���� ���� (-1~1 ������ �������� 0���� Ŭ��� ���Ͻ���)
        {
            GameObject instance = Instantiate(enemy); //�� ����
            instance.transform.position = new(Random.Range(-xRange, xRange), Mathf.Sign(Random.Range(-1, 1))*yRange,0); //�� ��ǥ ���� Sign()�� ����� 1, ������ -1��ȯ, x��ǥ�� (-x���� ~ x����)������ �������̰�, y��ǥ�� ���� ����� ������ y������ ����
            instance.GetComponent<Enemy>().spawner = this; //�� ��ũ��Ʈ�� �׾����� ���� �����ϱ����� ������ ���� �Ҵ�
        }
        else //�¿� ����
        {
            GameObject instance = Instantiate(enemy);
            instance.transform.position = new(Mathf.Sign(Random.Range(-1, 1))*xRange, Random.Range(-yRange, yRange), 0); //���� �Ϳ��� x,y�� �ٲ�
            instance.GetComponent<Enemy>().spawner = this;
        }
    }
}
