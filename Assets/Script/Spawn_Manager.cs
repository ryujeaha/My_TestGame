using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject Cow;//받을 적 소 캐릭터 프리펩
    public GameObject[] Spawns;//스폰포인트들을 담을 배열변수

    private void Start()
    {
        InvokeRepeating("Spawn_Cow",1,1);
    }

    void Spawn_Cow()
    {
        int Spawn = Random.Range(0, 3);//어디서 스폰 할 것인지 위치 정하기 변수
        if(Spawn != 2)
        {
            GameObject cow = (GameObject)Instantiate(Cow, new Vector2(Spawns[Spawn].transform.position.x, Spawns[Spawn].transform.position.y), Quaternion.identity);
        }
        else
        {
            GameObject cow = (GameObject)Instantiate(Cow, new Vector2(Spawns[Spawn].transform.position.x, Spawns[Spawn].transform.position.y), Quaternion.identity);
            cow.transform.localScale = new Vector3(-0.35f, 0.35f, 1f);
            //에너미 스크립트에게 스케일 x값은 -0.35로 바꾸라고 전달해주기
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
