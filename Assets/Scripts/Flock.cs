using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    public float speed;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;

    Vector3 vcentre = Vector3.zero;
    Vector3 vavoid = Vector3.zero;
    float dist;
    Vector3 goalPos;
    int groupSize;


    float neighbourDistance = 100.0f;

    bool turning = false;
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, Vector3.zero) >= AnimalManager.tankSize)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }
        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }
        else
        {
            if(Random.Range(0, 0) < 1)
            {
                ApplyRules();
            }
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    void ApplyRules()
    {
        GameObject[] gos;
        gos = AnimalManager.allAnimal;


        vcentre = Vector3.zero;
        vavoid = Vector3.zero;

        goalPos = GetPoint.goalPos;
      
        groupSize = 0;
        foreach (GameObject go in gos)
        {
            if (go == this.gameObject) {
                continue;
            }

            Separate(go);
        }

        if(groupSize > 0)
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            Vector3 direction = (vcentre + vavoid) - transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }
        }
    }

    void Separate(GameObject go) {
        dist = Vector3.Distance(go.transform.position, this.transform.position);
        if(dist <= neighbourDistance)
        {
            vcentre += go.transform.position;
            groupSize++;

            if(dist < 5.0f)
            {
                vavoid = vavoid + (this.transform.position - go.transform.position);
            }

            Flock anotherFlock = go.GetComponent<Flock>();
        }
    }
}
