using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private Touch touch;
    private float rotationSpeed = 0.3f;
    private Vector2 touchStartPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotationY = touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(0f, -rotationY, 0f);
            }
        }
    }
}
