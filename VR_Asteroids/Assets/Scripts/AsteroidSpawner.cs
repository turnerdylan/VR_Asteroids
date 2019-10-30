using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidSpawner : MonoBehaviour
{
    //some of this code is adapted from the following link: https://answers.unity.com/questions/1380771/random-spawn-gameobject-in-area.html
    private Vector3 Min;
    private  Vector3 Max;
    private  float xAxis;
    private  float yAxis;
    private  float zAxis; 
    private Vector3 randomPosition ;
    public bool canInstantiate;
    public Asteroid asteroid;
    public int objectCount = 0;

    public float spawnTimer = 0f;

    private float spawnDelay = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        SetRanges();
    }

    // Update is called once per frame
    void Update()
    {
        //randomly flips spawn locations for objects to a positive or negative range
        bool boolX = (UnityEngine.Random.value >= 0.5f);
        //bool boolZ = (UnityEngine.Random.value >= 0.5f);
        if(boolX){
            Min.x = Min.x * -1;
            Max.x = Max.x * -1;
        }
        // if(boolZ){
        //     Min.z = Min.z * -1;
        //     Max.x = Max.x * -1;
        // }
        
        //picks random locations within range set by SetRanges, then applies them to randomPosition
        xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        
        randomPosition = new Vector3(xAxis, yAxis, zAxis); 

        spawnTimer += Time.deltaTime;
        
        if(spawnTimer > spawnDelay){
            spawnTimer = 0f;
            if(objectCount < 51){
                InstantiateObjects();
                objectCount++;
            }
        }
        
    }
    //function used to set the range of random spawning
    void SetRanges(){
         Min = new Vector3(0, 0, 400); 
         Max = new Vector3(400, 60, 500);
    }
    
    void InstantiateObjects(){
        if(canInstantiate == true){
            Instantiate(asteroid, randomPosition, Quaternion.identity);
        }
    }
}
