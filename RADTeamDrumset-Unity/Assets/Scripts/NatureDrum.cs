﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureDrum : MonoBehaviour
{
    public char c = '0'; //which bit to set for this drum
    
    public GameObject hitObject;

    WebConnection script;

    // Find the script and set up the bytes for this drum
    void Start()
    {
        this.script = GameObject.Find("Ground").GetComponent<WebConnection>();
    }

    // When drum is hit, set bit
    private void OnTriggerEnter(Collider collider)
    {
        if (c != '0')
        {
            script.AddHit(c);
        }
        if (script.DEBUG)
        {
            Debug.Log("OnTriggerEnter!");
            hitObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.15f, 0.15f, 0.15f));
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (script.DEBUG)
        {
            hitObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }
    }
}