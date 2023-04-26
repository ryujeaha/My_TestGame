using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Transform targetMain;
    float speed = 5f;
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
    void OnBecameInvisible()//화면밖으로 나가면 호출되는 함수
    {
        Destroy(this.gameObject);// 자기 자신을 지웁니다.
    }
}
