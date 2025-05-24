using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;

    public float scaleFactor = 0.0009f;
    public float minScale = 0.001f;
    public float maxScale = 3f;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Calcula la distancia entre los dos toques
            float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                initialDistance = currentDistance;
                initialScale = transform.localScale;
            }
            else
            {
                if (Mathf.Approximately(initialDistance, 0)) return;

                float difference = currentDistance - initialDistance;
                float factor = 1 + (difference * scaleFactor);
                Vector3 newScale = initialScale * factor;


                // Limitar el escalado entre min y max
                newScale = Vector3.Max(newScale, Vector3.one * minScale);
                newScale = Vector3.Min(newScale, Vector3.one * maxScale);

                transform.localScale = newScale;
            }
        }
    }
}
