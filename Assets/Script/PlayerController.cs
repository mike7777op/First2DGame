using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour

{
    //public在Unity呈現更改按鍵
    public float speed;
    Rigidbody2D rigid2D; 
    public float speed_x_constraint;
    public float jumphigh;
    //血量歸零
    //static靜態變數,playercontroller都共用同個數值,轉場景時跟著改變
    //public static int hp = 10;
    public int hp = 0;
    public int max_hp = 0;
    //prefab物件
    public GameObject bulletPrefab;

    public Image hp_bar;
    
    void Start()
    {
        //換場景時不消除物件,保留損血
        DontDestroyOnLoad(this.gameObject);
        //指定Component
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
        //初始血量
        max_hp = 10;
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {   
        //跳躍
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigid2D.AddForce(new Vector2(0,jumphigh),ForceMode2D.Impulse);
            print("Jump");
        }
        //向右移動
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rigid2D.velocity = new Vector2(speed_x_constraint, rigid2D.velocity.y);
            // rigid2D.AddForce(new Vector2(speed,0), ForceMode2D.Force);
            // this.gameObject.transform.position += new Vector3(speed,0,0);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            rigid2D.velocity = new Vector2(speed_x_constraint, rigid2D.velocity.y);
        }
        //向左移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
            // rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            // this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
        }

        //Fire Controller
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Instantiate從Prefab拉出，並製造物件
            Instantiate(bulletPrefab,this.transform.position,Quaternion.identity);
            print("普攻");
        }
        //其他按鍵
        if (Input.GetKeyDown(KeyCode.Z))
        {
            print("大招");
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            print("小招");
        }
        if(Input.GetKeyDown(KeyCode.C) && Input.GetKeyDown(KeyCode.B))
        {
            print("特殊攻擊");
        }
        //移動速度
        if (rigid2D.velocity.x > speed_x_constraint)
        {
            rigid2D.velocity = new Vector2(speed_x_constraint,rigid2D.velocity.y);
        }
        if (rigid2D.velocity.x < -speed_x_constraint)
        {
            rigid2D.velocity = new Vector2(-speed_x_constraint,rigid2D.velocity.y);
        }
        //腳色扣血
        hp_bar.transform.localScale = new Vector3((float)hp/(float)max_hp,hp_bar.transform.localScale.y,hp_bar.transform.localScale.z);
    }
    //碰到怪物扣血
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {        
            print(collision.gameObject.name);
            //扣血
            hp -= 1;
            // collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
    //傳送場景

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            collision.gameObject.transform.GetComponent<Portal>().ChangeScence();
        }
    }
}
