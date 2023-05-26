using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;

    List<GameObject> bullet_arr = new List<GameObject>();
    List<Rigidbody2D> rigid_arr = new List<Rigidbody2D>();

    float cur_timer;
    float delay_timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BossPatten", 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            new Vector3(0, 5.2f, 0), 2*Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
    }

    void BossPatten()
    {

        StartCoroutine(FireCross());

    }

    IEnumerator FireCross()
    {
    
        for (int i = 0; i < 4; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add( bullet_arr[i].GetComponent<Rigidbody2D>() );

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);

        int index = 0;
        Vector2 bullet_dir2 = new Vector2(1, 0);
        for (int i = 0; i < 4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir2 = new Vector2(1, 0);
                    break;

                case 1:
                    bullet_dir2 = new Vector2(-1, 0);
                    break;

                case 2:
                    bullet_dir2 = new Vector2(0, 1);
                    break;

                case 3:
                    bullet_dir2 = new Vector2(0, -1);
                    break;
            }

            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir2 * 5, ForceMode2D.Impulse);
            index++;

        }

        for (int i = 4; i < 8; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);

        for (int i = 8; i < 12; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);



        rigid_arr.Clear();
        bullet_arr.Clear();


        Invoke("BossPatten", 1);

    }




}
