using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private float rechargeTime;
    private float _rechargeTime;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject markPrefab;

    private bool canShoot;

    

    void Start()
    {
        _rechargeTime = rechargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Vector3 playerTouch = Camera.main.ScreenToWorldPoint(touch.position);
                playerTouch.z = 0;
                Vector3 direction = transform.position-playerTouch;

                if(canShoot)
                {
                    GameObject mark = SetMark(playerTouch);
                    Shoot(playerTouch, mark.transform);
                    rechargeTime = _rechargeTime;
                    canShoot = false;
                }
               
            }
          
        }

        if (rechargeTime <= 0)
        {
            canShoot = true;
        }

        rechargeTime -= Time.deltaTime;

    }

    public void Shoot(Vector3 destinationPoint,Transform markParent)
    {
        GameObject bullet =  Instantiate(bulletPrefab, transform.position,transform.rotation);
        bullet.transform.SetParent(markParent);
        bullet.GetComponent<Bullet>().SetDestinationPosition(destinationPoint);
    }

    public GameObject SetMark(Vector3 spawnPosition)
    {
       return Instantiate(markPrefab, spawnPosition, Quaternion.identity);
    }



}
