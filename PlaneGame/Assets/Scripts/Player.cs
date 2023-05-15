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

    float fire_delay= .5f;
    float cur_delay = 0;

    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cur_delay = cur_delay* Time.deltaTime;

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        
        if(cur_delay< fire_delay)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            cur_delay = 0;
        }
        

        
    }

    private void FixedUpdate()
    {
        inputVec = inputVec.normalized * my_speed *Time.deltaTime;

        my_rigid.MovePosition(my_rigid.position + inputVec);

    }


}
