using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform[] target;
    public float Atk_Speed=0;
    public GameObject Shot;
    void Start()
    {
        StartCoroutine("Spawn_Shot");
    }
    IEnumerator Spawn_Shot()
    {
        yield return new WaitForSeconds(Atk_Speed);
        if (Input.GetAxisRaw("Horizontal") == 1)//오른쪽 클릭
        {
            GameObject shot = (GameObject)Instantiate(Shot, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0,0,-45));
            shot.GetComponent<Shot>().Set_Goal(2,target[2].transform);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)//왼쪽 클릭
        {
            GameObject shot = (GameObject)Instantiate(Shot, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 45));
            shot.GetComponent<Shot>().Set_Goal(0, target[0].transform);
        }
        else if (Input.GetAxisRaw("Vertical") == 1)//위쪽 클릭
        {
            GameObject shot = (GameObject)Instantiate(Shot, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            shot.GetComponent<Shot>().Set_Goal(1,target[1].transform);
        }
        StartCoroutine("Spawn_Shot");
    }
}
