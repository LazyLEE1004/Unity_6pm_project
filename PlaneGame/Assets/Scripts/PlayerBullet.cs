using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody2D my_rigid;
    public float bulletSpeed;

    float destroy_timer = 3;
    float cur_timer = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        my_rigid.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);

        //cur_timer = cur_timer + Time.deltaTime;
        //if (cur_timer > destroy_timer)
        //{
        //    Destroy(gameObject);
        //    cur_timer= 0;
        //}
            


    }
}
