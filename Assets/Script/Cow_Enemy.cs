using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow_Enemy : MonoBehaviour
{
    private Transform target;//추적할 대상;

    public float Cow_Speed =0.010f;//추적할 속도;

    // Update is called once per frame
    void Update()
    {
        Cow_Move();
    }
    void Cow_Move()
    {
        target = GameObject.Find("Player").transform; //Player 위치받기
        this.transform.position = Vector2.MoveTowards(transform.position, target.position, this.Cow_Speed);
    }
}
