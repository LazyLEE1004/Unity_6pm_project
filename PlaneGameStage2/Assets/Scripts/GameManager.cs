using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawn_pos;
    public GameObject spawn_pos_boss;
    public GameObject target_pos_boss;
    public GameObject camObj;

    public GameObject bossObj;
    public GameObject enemy_prf;
    public GameObject player_spawn;

    public GameObject boss_hpbar_obj;
    Slider boss_hp_slider;

    Rigidbody2D enemy_rigid;

    float cur_timer = 0;
    float spawn_timer = .4f;

    bool isbossSpawn = true;
    bool isbossInst = false;

    public GameObject playerobj;

    MoveCamera camcs;
    GameObject player_info;
    Player playercs;
    Boss bosscs;

    public Text score_text;
    public Text score_num;

    float max_hp=100;
    float cur_hp = 100;

    

    void Start()
    {

        player_info=Instantiate(playerobj, player_spawn.transform.position, 
                                            player_spawn.transform.rotation);
        playercs = player_info.GetComponent<Player>();
        playercs.score_text = score_text;
        playercs.score_num= score_num;

        camcs = camObj.GetComponent<MoveCamera>();
        camcs.target = player_info;

        boss_hp_slider=boss_hpbar_obj.GetComponent<Slider>();




    }

    // Update is called once per frame
    void Update()
    {
        
        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer > spawn_timer)
        {
            SpawnEnemy();

            cur_hp = cur_hp - 1;

        }

        if (playercs.score >= 100 && isbossSpawn)
        {
            SpawnBoss();

        }
        if (isbossInst)
        {
            boss_hp_slider.value = bosscs.cur_bosshp / bosscs.max_bosshp;

            if (bosscs.isbossDead)
            {
                boss_hpbar_obj.SetActive(false);
            }

        }
        

    }

    void SpawnBoss()
    {
        GameObject boss_info = Instantiate(bossObj, spawn_pos_boss.transform.position,
            spawn_pos_boss.transform.rotation);
        bosscs = boss_info.GetComponent<Boss>();
        bosscs.player = player_info;

        isbossSpawn = false;
        isbossInst = true;

        boss_hpbar_obj.SetActive(true);

        boss_info.transform.Rotate(Vector3.back * 180);

    }

    void SpawnEnemy()
    {
        int randnum = Random.Range(0, 4);
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
