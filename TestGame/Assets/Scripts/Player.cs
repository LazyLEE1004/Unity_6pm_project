using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D my_rigid;
    public Vector2 input_vec;
    public Vector2 next_vec;

    public List<GameObject> enemy_arr;
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
        input_vec.x = Input.GetAxisRaw("Horizontal");
        input_vec.y = Input.GetAxisRaw("Vertical");

        next_vec = input_vec.normalized;
        

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


}
