using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{

    public int band;
    public float startscale, scalemultiplier;
    public bool useBuffer;
    Material visualMaterial;


    // Start is called before the first frame update
    void Start()
    {
        startscale = 10f;
        scalemultiplier = 20f;
        visualMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBandBuffer[band] * scalemultiplier) + startscale, transform.localScale.z);
            Color color = new Color(AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band]);
            visualMaterial.SetColor("_MyEmission", color);
        }

        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBand[band] * scalemultiplier) + startscale, transform.localScale.z);
            Color color = new Color(AudioPeer.audioBand[band], AudioPeer.audioBand[band], AudioPeer.audioBandBuffer[band]);
            visualMaterial.SetColor("_MyEmission", color);
        }

        
    }
}
