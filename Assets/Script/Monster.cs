using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    int hp = 0;
    public int max_hp = 0;
    public GameObject hp_bar;
    // Start is called before the first frame update
    void Start()
    {
        max_hp = 20;
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
        float _percent = ((float)hp/(float)max_hp);
        hp_bar.transform.localScale = new Vector3(_percent,hp_bar.transform.localScale.y,hp_bar.transform.localScale.z);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            hp -= 1;
            Destroy(col.gameObject);
        }
    }
}
