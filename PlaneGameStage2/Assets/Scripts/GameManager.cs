using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawn_pos;
    public GameObject enemy_prf;

    Rigidbody2D enemy_rigid;

    float cur_timer = 0;
    float spawn_timer = .4f;
    
    public GameObject playerobj;

    Player playercs;


    void Start()
    {
        
        playercs = playerobj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        

        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer > spawn_timer)
        {
            int randnum = Random.Range(0,4);
            GameObject enemy_obj = Instantiate(enemy_prf, spawn_pos[randnum].transform.position, spawn_pos[randnum].transform.rotation);
            enemy_rigid = enemy_obj.GetComponent<Rigidbody2D>();
            enemy_rigid.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            cur_timer = 0;

            playercs.score = playercs.score + 100;
        }

        
    }
}
