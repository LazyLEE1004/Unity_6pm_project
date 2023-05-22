using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    Rigidbody2D my_rigid;
    Rigidbody2D bullet_rigid;

    Vector2 inputVec;
    float speed= 5;

    float cur_timer = 0;
    float delay_timer=.2f;

    public float score;


    public Text score_text;
    public Text score_num;



    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        score_text.text = "SCORE";
        score_num.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;
        inputVec.x = Input.GetAxisRaw("Horizontal"); //(x,y)
        inputVec.y = Input.GetAxisRaw("Vertical");

        if(cur_timer > delay_timer)
        {
            GameObject bulletobj = Instantiate(bullet, transform.position, transform.rotation);
            bullet_rigid = bulletobj.GetComponent<Rigidbody2D>();
            bullet_rigid.AddForce(Vector2.up * 3, ForceMode2D.Impulse);

            cur_timer = 0;
        }

        score_num.text = score.ToString();


    }

    private void FixedUpdate()
    {
        inputVec = inputVec.normalized * Time.fixedDeltaTime * speed;


        my_rigid.MovePosition(my_rigid.position + inputVec);


    }



}
