using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using System.Timers;
using UnityEngine;

public class ParticleSimulation : MonoBehaviour
{

    private Vector3 x, v, a, f;
    public float m = 1.0f, K = 1.0f, D = 1.0f;
    public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);

    public List<GameObject> particlesConnected = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position;
        v = new Vector3(0.0f, 0.0f, 0.0f);
        a = new Vector3(0.0f, 0.0f, 0.0f);
        f = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        f = m * gravity - D * v;

        for (int i = 0; i < particlesConnected.Count; i++)
        {
            GameObject particle = particlesConnected[i];
            f -= K * (x - particle.transform.position);
        }
        a = f / m;

        v += a * Time.deltaTime;

        x += v * Time.deltaTime;

        transform.position = x;

        for (int i = 0; i < particlesConnected.Count; i++)
        {
            GameObject particle = particlesConnected[i];
            UnityEngine.Debug.DrawLine(particle.transform.position, x, Color.yellow);
        }


    }
}