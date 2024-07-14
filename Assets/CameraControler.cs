using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour
{
    public GameObject player;
    public float rotationDuration = 1f; // Duration of the rotation in seconds

    private Vector3 offset;
    private Coroutine rotationCoroutine;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        // Left rotation
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (rotationCoroutine != null)
            {
                StopCoroutine(rotationCoroutine);
            }
            rotationCoroutine = StartCoroutine(SmoothSnapRotate(-90));
        }

        // Right rotation
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rotationCoroutine != null)
            {
                StopCoroutine(rotationCoroutine);
            }
            rotationCoroutine = StartCoroutine(SmoothSnapRotate(90));
        }
    }

    private IEnumerator SmoothSnapRotate(float angle)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = Mathf.Round((startRotation + angle) / 90f) * 90f;
        float t = 0.0f;

        while (t < rotationDuration)
        {
            t += Time.deltaTime;
            float smoothStep = Mathf.Sin(t / rotationDuration * Mathf.PI * 0.5f); // Ease-in and ease-out
            float yRotation = Mathf.Lerp(startRotation, endRotation, smoothStep) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, endRotation % 360.0f, transform.eulerAngles.z);
    }
}
