using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 destinationPosition;
    private bool canMove;
    private bool startBulletImpact;

    [SerializeField]
    private GameObject bulletImpacePrefab;
    [SerializeField]
    private Vector3 bulletImpactRadiusSize;
    [SerializeField]
    private float bulletImpactDuration;


    void Start()
    {
       
    }

    void Update()
    {
        if(canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationPosition, Time.deltaTime * speed);
            
            if(Vector2.Distance(transform.position,destinationPosition)<0.02f)
            {
                canMove = false;
                startBulletImpact = true;
            }
        }
        
        else if(!canMove)
        {
            if(startBulletImpact)
            {
                GameObject bulletImpact = Instantiate(bulletImpacePrefab, transform.position, Quaternion.identity);
                bulletImpact.GetComponent<BulletImpact>().SetBulletRadiusSize(bulletImpactRadiusSize);
                bulletImpact.GetComponent<BulletImpact>().SetDuration(bulletImpactDuration);
                Destroy(transform.parent.gameObject);

            }
        }

      
    }

    public void SetDestinationPosition(Vector3 destinationPosition)
    {
        this.destinationPosition = destinationPosition;
        canMove = true;
    }

   

    public bool GetBulletImpactStatus()
    {
        return startBulletImpact;
    }
}
