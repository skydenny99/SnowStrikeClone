﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezing : MonoBehaviour {

    private SpriteRenderer sr;
    private Transform _transform;
    public int pixelsToUnityUnits = 100;
    public Camera cam;
    public bool followCamera = true;

    private Player _player;

    // Use this for initialization
    void Start()
    {
        _transform = transform;
        sr = GetComponent<SpriteRenderer>();
        cam = (cam != null) ? cam : Camera.main;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        Sprite sprite = sr.sprite;
        float aspectRatio = Screen.width / (float)Screen.height; // in respect to width

        // Guesstimation
        int orthoPixelsY = Mathf.CeilToInt(cam.orthographicSize * 2 * pixelsToUnityUnits);
        int orthoPixelsX = Mathf.CeilToInt(orthoPixelsY * aspectRatio);

        // orthoX and orthoY are obviously not the same as the screen resolution, but we can take advantage of the fact that they're scaled based
        // on unity units and ignore calculating based on screen pixels

        // find the ratio in scales along each respective axis' and assign as the new local scale
        Vector3 newScale = new Vector3(orthoPixelsX / (float)sprite.rect.width, orthoPixelsY / (float)sprite.rect.height, 1f);
        _transform.localScale = newScale;

        if (followCamera)
        {
            Vector3 camPosition = cam.transform.position;
            Vector3 newPosition = new Vector3(camPosition.x, camPosition.y, _transform.position.z);
            _transform.position = newPosition;
        }

        float alpha = scale(0, _player.maxTemp, 1, 0, _player.bodyTemp);
        sr.color = new Color(1, 1, 1, alpha);
    }
    

    public float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }
}
