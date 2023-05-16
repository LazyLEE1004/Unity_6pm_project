using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float cur_timer;
    float destroy_timer=7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cur_timer += Time.deltaTime;

        if(cur_timer> destroy_timer) 
        {

            Destroy(gameObject);
            cur_timer= 0;
        }

        
    }
}
