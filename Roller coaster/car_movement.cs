using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Points;
    private int index = 0;
    private float speed=10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(index <Points.Length-1)
        {

        
        var angle = transform.rotation.z;
        if (angle > 10)
        {
            speed = 20;

        }
        else if (angle < 10 && angle>0)
        {
            speed = 10;
        }
        else if(angle<0)
        {
            speed = 5;
        }
        var distance = Vector3.Distance(transform.position, Points[index].transform.position);
        if(distance<0.5f)
        {
            index++;
        }
        float step = speed * Time.deltaTime;
        var targetRotation = Quaternion.LookRotation(Points[index].transform.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, Points[index].transform.position,step);
    }
    }
}
