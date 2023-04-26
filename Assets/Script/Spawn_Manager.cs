using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject Cow;//���� �� �� ĳ���� ������
    public GameObject[] Spawns;//��������Ʈ���� ���� �迭����

    private void Start()
    {
        InvokeRepeating("Spawn_Cow",1,1);
    }

    void Spawn_Cow()
    {
        int Spawn = Random.Range(0, 3);//��� ���� �� ������ ��ġ ���ϱ� ����
        if(Spawn != 2)
        {
            GameObject cow = (GameObject)Instantiate(Cow, new Vector2(Spawns[Spawn].transform.position.x, Spawns[Spawn].transform.position.y), Quaternion.identity);
        }
        else
        {
            GameObject cow = (GameObject)Instantiate(Cow, new Vector2(Spawns[Spawn].transform.position.x, Spawns[Spawn].transform.position.y), Quaternion.identity);
            cow.transform.localScale = new Vector3(-0.35f, 0.35f, 1f);
            //���ʹ� ��ũ��Ʈ���� ������ x���� -0.35�� �ٲٶ�� �������ֱ�
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
