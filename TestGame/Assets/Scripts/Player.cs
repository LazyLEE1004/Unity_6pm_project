using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D my_rigid;
    public Vector2 input_vec;
    public Vector2 next_vec;

    public GameObject bullet;

    Vector2 bullet_dir;

    public List<GameObject> enemy_arr = new List<GameObject>();

    float min_distance;
    float cur_distance;

    float fire_delay = 0.3f;
    float cur_delay;


    int min_index;

    Animator my_animator;
    SpriteRenderer my_SR;


    void Start()
    {

        my_rigid= GetComponent<Rigidbody2D>();
        my_animator= GetComponent<Animator>();
        my_SR= GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        cur_delay = cur_delay + Time.deltaTime;

        input_vec.x = Input.GetAxisRaw("Horizontal");
        input_vec.y = Input.GetAxisRaw("Vertical");

        next_vec = input_vec.normalized;

        if (enemy_arr.Count != 0)
        {

            min_distance = 999;
            min_index = 0;

            for(int i=0; i<enemy_arr.Count; i++)
            {
                Debug.DrawRay(transform.position, 
                              enemy_arr[i].transform.position - transform.position, Color.red);

                cur_distance = Vector2.Distance(transform.position, enemy_arr[i].transform.position);

                if (cur_distance <= min_distance)
                {
                    bullet_dir = enemy_arr[i].transform.position - transform.position;
                    bullet_dir = bullet_dir.normalized;
                    min_distance = cur_distance;
                    min_index = i;
                }

            }

            Debug.DrawRay(transform.position,
                             enemy_arr[min_index].transform.position - transform.position, Color.blue);

            if (cur_delay > fire_delay)
            {
                Fire(bullet_dir);

                cur_delay = 0;

            }

            //Vector2 dir = enemy_arr[0].transform.position - transform.position;
            //Debug.Log(Mathf.Sqrt(dir.x*dir.x + dir.y*dir.y));



        }
        

    }

    private void FixedUpdate()
    {
        my_rigid.MovePosition(my_rigid.position + next_vec*4 * Time.fixedDeltaTime);

        my_animator.SetFloat("speed", next_vec.magnitude);

        if (next_vec.x < 0)
        {
            my_SR.flipX= true;
        }
        else if (next_vec.x > 0)
        {
            my_SR.flipX = false;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("parent¸Â´Ù");


        }    



    }

    void Fire(Vector2 target_dir)
    {

        GameObject bullet_info = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D bullet_rigid = bullet_info.GetComponent<Rigidbody2D>();

        bullet_rigid.AddForce(target_dir * 4, ForceMode2D.Impulse);

    }
}
