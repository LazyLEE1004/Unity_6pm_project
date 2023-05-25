using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;

    float cur_timer;
    float delay_timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            new Vector3(0, 5.2f, 0), 2*Time.deltaTime);

        // cur_timer += Time.deltaTime;
        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer > delay_timer)
        {
            GameObject bullet_info = 
                        Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D bullet_rigid = bullet_info.GetComponent<Rigidbody2D>();

            Vector2 bullet_dir =  player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            bullet_rigid.AddForce(bullet_dir * 10, ForceMode2D.Impulse);


            cur_timer= 0;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
    }


}