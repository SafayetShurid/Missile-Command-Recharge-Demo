using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    
    private Vector3 bulletRadiusSize;  
    private float duration;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartBulletImpact();
    }

    public void StartBulletImpact()
    {
       transform.localScale = Vector3.MoveTowards(transform.localScale, bulletRadiusSize, duration * Time.deltaTime);
       if( Vector2.Distance(transform.localScale,bulletRadiusSize)<0.01f)
        {
            Destroy(this.gameObject);
        }

    }

    public void SetBulletRadiusSize(Vector3 bulletRadiusSize)
    {
        this.bulletRadiusSize = bulletRadiusSize;
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>()!=null)
        {
            GameManager.insntance.ScoreUp();
            Destroy(collision.gameObject);
            
        }
       
    }


}
