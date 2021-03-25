using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public float speed;
    
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed,0),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime計算時間，常用在解決當性能好的電腦裡更新時間較快，性能差的更新慢，所以造成兩者看的時間不一樣，性能好看的快，性能不好看的慢
        //子彈動起來，Time.deltaTime*60預設60貞刷新，把性能好性能壞時間差補回來
        // this.gameObject.transform.position += new Vector3(speed*Time.deltaTime*60,0,0);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
