using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D my_rigid;
    public Vector2 input_vec;
    public Vector2 next_vec;
    


    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
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
        my_rigid.MovePosition(my_rigid.position + next_vec * Time.fixedDeltaTime);

        
    }
}
