using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

    public GameObject animalPrefab;
    public static int tankSize = 50;

    static int numAnimal = 20;
    public static GameObject[] allAnimal = new GameObject[numAnimal];

    public static Vector3 goalPos = Vector3.zero;
	// Use this for initialization
	void Start () {
		
        for(int i = 0; i < numAnimal; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize), 0, Random.Range(-tankSize, tankSize));
            allAnimal[i] = (GameObject)Instantiate(animalPrefab, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize), 0, Random.Range(-tankSize, tankSize));
        }
	}
}
