using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnewayPlatformManager : MonoBehaviour
{
    public float timeToDisableEffector = 0.05f; 
    PlatformEffector2D platformEffector2d;

    float _initSurfaceArc;
    int _initLayer;
    void Start()
    {
        platformEffector2d = GetComponent<PlatformEffector2D>();
        _initSurfaceArc = platformEffector2d.surfaceArc;
        _initLayer = gameObject.layer;
    }

    public void DisableEffector()
    {
        gameObject.layer = 2;
        platformEffector2d.surfaceArc = 0f;
        StartCoroutine("OnEffector");

    }

    IEnumerator OnEffector()
    {    
        yield return new WaitForSeconds(timeToDisableEffector);
        platformEffector2d.surfaceArc = _initSurfaceArc;
        gameObject.layer = _initLayer;
    }
}
