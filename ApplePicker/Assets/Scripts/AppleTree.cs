using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set is Inspektor")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float LeftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    void Start()
    {
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position=this.transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x<-LeftAndRightEdge)
         speed = Mathf.Abs(speed); 

        else if (pos.x > LeftAndRightEdge)
         speed=-Mathf.Abs(speed); 

    
    }
    private void FixedUpdate()
    {
        if(Random.value<chanceToChangeDirections)
         speed *= -1;
       
    }
}
