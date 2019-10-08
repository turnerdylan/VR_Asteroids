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
    public GameObject spawnedObject;
    private int objectCount = 0;

    
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
        bool boolZ = (UnityEngine.Random.value >= 0.5f);
        if(boolX){
            Min.x = Min.x * -1;
            Max.x = Max.x * -1;
        }
        if(boolZ){
            Min.z = Min.z * -1;
            Max.x = Max.x * -1;
        }
        
        //picks random locations within range set by SetRanges, then applies them to randomPosition
        xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        
        randomPosition = new Vector3(xAxis, yAxis, zAxis); 

        if(objectCount < 51){
            InstantiateObjects();
            objectCount++;
        }
    }
    //function used to set the range of random spawning
    void SetRanges(){
         Min = new Vector3(20, 2, 20); 
         Max = new Vector3(30, 20, 30);
    }
    
    void InstantiateObjects(){
        if(canInstantiate == true){
            Instantiate(spawnedObject, randomPosition, Quaternion.identity);
        }
    }
}
