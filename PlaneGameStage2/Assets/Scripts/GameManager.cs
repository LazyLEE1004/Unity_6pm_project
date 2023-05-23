using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawn_pos;
    public GameObject enemy_prf;
    public GameObject player_spawn;

    Rigidbody2D enemy_rigid;

    float cur_timer = 0;
    float spawn_timer = .4f;
    
    public GameObject playerobj;
    Player playercs;

    public Text score_text;
    public Text score_num;


    void Start()
    {

        GameObject player_info=Instantiate(playerobj, player_spawn.transform.position, 
                                            player_spawn.transform.rotation);
        playercs = player_info.GetComponent<Player>();
        playercs.score_text = score_text;
        playercs.score_num= score_num;


    }

    // Update is called once per frame
    void Update()
    {
        

        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer > spawn_timer)
        {
            int randnum = Random.Range(0,4);
            GameObject enemy_obj = Instantiate(enemy_prf, spawn_pos[randnum].transform.position, spawn_pos[randnum].transform.rotation);
            Enemy enemycs = enemy_obj.GetComponent<Enemy>();
            enemycs.playerobj = playerobj;
            enemycs.playercs = playercs;

            enemy_rigid = enemy_obj.GetComponent<Rigidbody2D>();
            enemy_rigid.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            cur_timer = 0;

            //playercs.score = playercs.score + 100;
            
        }

        
    }
}
