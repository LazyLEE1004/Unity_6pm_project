using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    Rigidbody2D my_rigid;

    public Vector2 inputVec;

    public float my_speed = 10;

    float fire_delay= .2f;
    float cur_delay = 0;
    float bullet_speed = 6;

    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cur_delay = cur_delay + Time.deltaTime; //0.001

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        Fire();
        

        
    }

    private void FixedUpdate()
    {
        inputVec = inputVec.normalized * my_speed *Time.deltaTime;

        my_rigid.MovePosition(my_rigid.position + inputVec);

    }

    void Fire()
    {
        if (cur_delay < fire_delay)
            return;

        GameObject bullet_info = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D bullet_rigid = bullet_info.GetComponent<Rigidbody2D>();

        bullet_rigid.AddForce(Vector2.up * bullet_speed, ForceMode2D.Impulse);

        cur_delay = 0;


    }


}
