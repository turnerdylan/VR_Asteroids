using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int startingBullets = 10;
    private int bulletCount;
    public GameObject bulletPrefab;
    private Vector3 spawnPoint;
    public GameObject shootPoint;
    
    void Start()
    {
        bulletCount = startingBullets;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Fire1")) {
            //firing code goes here
            Debug.Log("Fire!");
            if(bulletCount > 0){
                GunFire();
            }
            
        } 
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     Destroy(other.gameObject);
    // }
    void GunFire(){
        //spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = shootPoint.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward * 5000);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Asteroid"){
            Destroy(other.gameObject);
        }
        
    }
}
