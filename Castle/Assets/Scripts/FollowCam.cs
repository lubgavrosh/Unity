﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class FollowCam:MonoBehaviour
    {
    static public GameObject POI;
    public float easing = 0.05f;
    public float camZ;
    public Vector2 minXY = Vector2.zero;
    private void Awake()
    {
        camZ=this.transform.position.z;
    }
    private void FixedUpdate()
    {
        if (POI == null) return;
        Vector3 destination = POI.transform.position;
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}

