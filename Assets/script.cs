using UnityEngine;

public class script : MonoBehaviour
{
    private Camera cam;
    private float lastAspect;// initial aspect ratio

    public float ratio = 16f / 9f; // desired aspect ratio (width / height)
    public float size = 5f; // initial orthographic size

    void Start()
    {
        cam = GetComponent<Camera>();// get the Camera component


        if (!cam.orthographic)// check if camera is orthographic
        {
            Debug.LogError("Camera must be orthographic.");
            return;
        }
        AdjustCameraSize();// adjust camera size at start
    }

// Update is called once per frame
    void Update()
    {
        // Adjust orthographic size based on aspect ratio changes
        float current = (float)Screen.width / Screen.height;

        if (Mathf.Abs(current - lastAspect) > 0.01f)// if aspect ratio has changed significantly
        {
            AdjustCameraSize();// adjust camera size
            lastAspect = current;// update last aspect ratio
        }

    }
    void AdjustCameraSize()
    {//function to adjust camera size based on aspect ratio
        float current = (float)Screen.width / Screen.height;

        if (current >= ratio)// wider than target
        {
            cam.orthographicSize = size;// keep original size
        }
        else
        {//if taller than target
            float a =  (ratio / current);//to make both sides fit
            cam.orthographicSize = size * a;
        }
    }
}
