using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class Conductor : MonoBehaviour
{
    public GameObject[] instruments;
    public GameObject[] instrumentLights;
    public float[] instLightIntensity;
    private float[] instLightMaxIntensity = { 20.1f, 16.1f, 16.1f, 16.1f, 16.1f, 12.5f };

    public float[] isntCubeIntensity;
    private float[] instCubeMaxIntensity = { 5.23f, 5.23f, 5.23f, 5.23f, 5.23f, 5.23f };

    public float minHeight = -2.0f;
    public float maxHeight = 0.0f;


    public float moveSpeed = 0.5f;

    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < instruments.Length; i++)
        {
            instruments[i].GetComponent<Light>().intensity = 0.0f;
            instrumentLights[i].GetComponent<Light>().intensity = 0.0f;
            instruments[i].transform.position += new Vector3(0, minHeight, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //[0]
        if (Input.GetKey(KeyCode.S))
        {
            if (instruments[0].transform.position.y > minHeight)
            {
                instruments[0].transform.Translate(Vector3.down * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[0], 0);
                AkSoundEngine.SetRTPCValue("Synth", ((instruments[0].transform.position.y / 2) + 1) * 100);
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (instruments[0].transform.position.y < maxHeight)
            {
                instruments[0].transform.Translate(Vector3.up * moveSpeed * Time.deltaTime,
                    Space.World);


                UpdateLightVals(instruments[0], 0);
                AkSoundEngine.SetRTPCValue("Synth", ((instruments[0].transform.position.y / 2) + 1) * 100);
            }
        }
        //[1]
        if (Input.GetKey(KeyCode.D))
        {
            if (instruments[1].transform.position.y > minHeight)
            {
                instruments[1].transform.Translate(Vector3.down * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[1], 1);
                AkSoundEngine.SetRTPCValue("Drums", ((instruments[1].transform.position.y / 2) + 1) * 100);
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (instruments[1].transform.position.y < maxHeight)
            {
                instruments[1].transform.Translate(Vector3.up * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[1], 1);
                AkSoundEngine.SetRTPCValue("Drums", ((instruments[1].transform.position.y / 2) + 1) * 100);
            }
        }
        //[2]
        if (Input.GetKey(KeyCode.F))
        {
            if (instruments[2].transform.position.y > minHeight)
            {
                instruments[2].transform.Translate(Vector3.down * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[2], 2);
                AkSoundEngine.SetRTPCValue("Counter", ((instruments[2].transform.position.y / 2) + 1) * 100);
            }
        }
        else if (Input.GetKey(KeyCode.R))
        {
            if (instruments[2].transform.position.y < maxHeight)
            {
                instruments[2].transform.Translate(Vector3.up * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[2], 2);
                AkSoundEngine.SetRTPCValue("Counter", ((instruments[2].transform.position.y / 2) + 1) * 100);
            }
        }
        //[3]
        if (Input.GetKey(KeyCode.H))
        {
            if (instruments[3].transform.position.y > minHeight)
            {
                instruments[3].transform.Translate(Vector3.down * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[3], 3);
                AkSoundEngine.SetRTPCValue("Lead", ((instruments[3].transform.position.y / 2) + 1) * 100);
            }
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            if (instruments[3].transform.position.y < maxHeight)
            {
                instruments[3].transform.Translate(Vector3.up * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[3], 3);
                AkSoundEngine.SetRTPCValue("Lead", ((instruments[3].transform.position.y / 2) + 1) * 100);
            }
        }
        //[4]
        if (Input.GetKey(KeyCode.J))
        {
            if (instruments[4].transform.position.y > minHeight)
            {
                instruments[4].transform.Translate(Vector3.down * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[4], 4);
                AkSoundEngine.SetRTPCValue("Pluck", ((instruments[4].transform.position.y / 2) + 1) * 100);
            }
        }
        else if (Input.GetKey(KeyCode.U))
        {
            if (instruments[4].transform.position.y < maxHeight)
            {
                instruments[4].transform.Translate(Vector3.up * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[4], 4);
                AkSoundEngine.SetRTPCValue("Pluck", ((instruments[4].transform.position.y / 2) + 1) * 100);
            }
        }
        //[5]
        if (Input.GetKey(KeyCode.K))
        {
            if (instruments[5].transform.position.y > minHeight)
            {
                instruments[5].transform.Translate(Vector3.down * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[5], 5);
                AkSoundEngine.SetRTPCValue("Bass", ((instruments[5].transform.position.y / 2) + 1) * 100);
            }
        }
        else if (Input.GetKey(KeyCode.I))
        {
            if (instruments[5].transform.position.y < maxHeight)
            {
                instruments[5].transform.Translate(Vector3.up * moveSpeed * Time.deltaTime,
                    Space.World);

                UpdateLightVals(instruments[5], 5);
                AkSoundEngine.SetRTPCValue("Bass", ((instruments[5].transform.position.y / 2) + 1) * 100);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPlaying)
            {
                AkSoundEngine.PostEvent("Play_Music", gameObject);
                isPlaying = true;
            }
            else if (isPlaying)
            {
                AkSoundEngine.PostEvent("Stop_Music", gameObject);
                isPlaying = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            AkSoundEngine.SetState("Music", "Middle");
            Debug.Log("Music State Middle");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            AkSoundEngine.SetState("Music", "Loop");

            Debug.Log("Music State Loop");
        }
    }
    void UpdateLightVals(GameObject instrument, int index)
    {
        float scaledHeight = (instrument.transform.position.y / 2) + 1;
        //Debug.Log(scaledHeight);
        instrument.GetComponent<Light>().intensity = instCubeMaxIntensity[index] * scaledHeight;
        instrumentLights[index].GetComponent<Light>().intensity = instLightMaxIntensity[index] * scaledHeight;
    }
}