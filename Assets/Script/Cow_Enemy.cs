using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow_Enemy : MonoBehaviour
{
    private Transform target;//������ ���;

    public float Cow_Speed =0.010f;//������ �ӵ�;

    // Update is called once per frame
    void Update()
    {
        Cow_Move();
    }
    void Cow_Move()
    {
        target = GameObject.Find("Player").transform; //Player ��ġ�ޱ�
        this.transform.position = Vector2.MoveTowards(transform.position, target.position, this.Cow_Speed);
    }
}
