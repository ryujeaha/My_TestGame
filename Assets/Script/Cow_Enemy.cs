using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow_Enemy : MonoBehaviour
{
    Player player;

    private Transform target;//������ ���;

    public int Cow_Hp;
    public float Cow_Speed =5f;//������ �ӵ�;

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
        target = GameObject.Find("Player").transform; //Player ��ġ�ޱ�
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
