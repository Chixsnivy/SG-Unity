using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleParticle : MonoBehaviour
{

    public Vector3 g, x, w, a, v, F;
    public float m, k = 1.0f, D = 0.5f;
    //k es rígidez, D es amortiguamiento

    // Start is called before the first frame update
    void Start()
    {
        g = new Vector3(0.0f, -9.81f, 0.0f);
        x = transform.position;
        m = 1.0f;
        w = m * g;
        a = new Vector3(0.0f, 0.0f, 0.0f);
        v = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // peso, rigídez del resorte, viscosidad del medio
        F = w - (k * x) - (D * v);
        a = F / m;
        v += a * Time.deltaTime;
        x += v * Time.deltaTime;
        transform.position = x;
    }
}
