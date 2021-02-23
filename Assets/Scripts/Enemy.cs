using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 destinationPosition;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, Time.deltaTime * speed);
        if (Vector2.Distance(transform.position, destinationPosition) < 0.02f)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDestinationPosition(Vector3 destinationPosition)
    {
        this.destinationPosition = destinationPosition;       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerCollider"))
        {
            GameManager.insntance.HealthDown();
        }
            
    }
}
