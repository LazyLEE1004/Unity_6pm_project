using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float cur_timer=0;
    float destory_timer=5;

    float hp = 3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cur_timer += Time.deltaTime;
        //cur_timer = cur_timer + Time.deltaTime;

        if(cur_timer> destory_timer)
        {
            Destroy(gameObject);
            cur_timer= 0;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerBullet")
        {
            hp = hp - 1;
            
            Destroy(collision.gameObject);

            if (hp <= 0)
            {
                Destroy(gameObject);
            }

        }

        
    }


}
