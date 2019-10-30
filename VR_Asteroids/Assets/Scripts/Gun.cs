using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int startingBullets = 10;
    public int bulletCount;
    public GameObject bulletPrefab;
    private Vector3 spawnPoint;
    public GameObject shootPoint;
    public int bulletSpeed = 10000;
    private float bulletCharger = 0f;
    public AudioClip explode;
    public AudioClip shootSound;
    
    void Start()
    {
        bulletCount = startingBullets;
    }

    // Update is called once per frame
    void Update()
    {
       bulletCharger += Time.deltaTime;
       if(bulletCharger >= 1.75f){
           bulletCount++;
           bulletCharger = 0;
       }
       if (Input.GetButtonDown("Fire1")) {
            //firing code goes here
            Debug.Log("Fire!");
            if(bulletCount > 0){
                GunFire();
                bulletCount--;
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
        bullet.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward * bulletSpeed);
        AudioSource.PlayClipAtPoint(shootSound, transform.position, 0.1f);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.tag == "Asteroid"){
    //         AudioSource.PlayClipAtPoint(explode, other.transform.position, 1f);
    //         Destroy(other.gameObject);
    //     }
        
    // }
}
