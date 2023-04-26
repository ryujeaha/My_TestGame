using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Manager manager;

    Transform targetMain;
    float speed = 5f;
    private void Start()
    {
        manager = FindObjectOfType<Manager>();
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
        transform.position = Vector2.MoveTowards(transform.position, targetMain.position, this.speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            manager.GetComponent<Manager>().Money();
        }
    }

    void OnBecameInvisible()//ȭ������� ������ ȣ��Ǵ� �Լ�
    {
        Destroy(this.gameObject);// �ڱ� �ڽ��� ����ϴ�.
    }
}
