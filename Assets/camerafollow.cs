using UnityEngine;
using System.Collections;

public class Camerafollow : MonoBehaviour {
    public Transform target;
    public float smoothing = 5f;
    public float angle = 45f; // Adjust this value based on your isometric camera angle
    Vector3 offset;

    // Use this for initialization
    void Start () {
        // Calculate the offset using the isometric angle
        float offsetDistance = Mathf.Abs(offset.z) / Mathf.Tan(Mathf.Deg2Rad * angle);
        offset = new Vector3(0, offsetDistance, -offsetDistance);
    }

    // Update is called once per frame
    void LateUpdate () {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
