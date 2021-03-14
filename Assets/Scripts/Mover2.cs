using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{
    public float speed = 2f;

    bool switc = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(switc)
        {
        moveEnemyright();
        }
        
        if(!switc)
        {
        moveEnemyleft();
        }

        if(transform.position.x >= 5.5f){
            switc = false;
        }
        
        if(transform.position.x <= 2.5f){
            switc = true;
        }
    }
    
    void moveEnemyright()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
    }
     
    void moveEnemyleft()
    {
        transform.Translate(-speed*Time.deltaTime,0,0);
    }
}
