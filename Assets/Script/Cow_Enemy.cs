using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow_Enemy : MonoBehaviour
{
    Player player;

    private Transform target;//추적할 대상;

    public int Cow_Hp;
    public float Cow_Speed =5f;//추적할 속도;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Cow_Move();
    }
    void Cow_Move()
    {
        target = GameObject.Find("Player").transform; //Player 위치받기
        this.transform.position = Vector2.MoveTowards(transform.position, target.position, this.Cow_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            player.Player_HP--;
            player.HP_IMG[player.HP_Cnt].gameObject.SetActive(false);
            player.HP_Cnt++;
        }
    }
}
