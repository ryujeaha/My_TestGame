using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Manager manager;
    Gun gun;
    Transform targetMain;
    float speed = 5f;
    int bullet_damage = 0;
    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        gun = FindObjectOfType<Gun>();
    }

    // Start is called before the first frame update
    private void Update()
    {
        Move();
    }
    // Update is called once per frame
    public void Set_Goal(int goal_num,Transform target)
    {
        targetMain = target;
    }
    void Move()
    {
        bullet_damage = (int)(manager.Get_cost(50, 10, 1.07f, gun.Gun_LV)) / (5 / 2);
        transform.position = Vector2.MoveTowards(transform.position, targetMain.position, this.speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            collision.GetComponent<Cow_Enemy>().Cow_Hp = collision.GetComponent<Cow_Enemy>().Cow_Hp - bullet_damage;
            if (collision.GetComponent<Cow_Enemy>().Cow_Hp <= 0)
            {
                Sound_Manager.instance.PlaySound("Cow_Dead", 1);
                Destroy(collision.gameObject);
                manager.GetComponent<Manager>().Money();
            }
        }
    }

    void OnBecameInvisible()//화면밖으로 나가면 호출되는 함수
    {
        Destroy(this.gameObject);// 자기 자신을 지웁니다.
    }
}
