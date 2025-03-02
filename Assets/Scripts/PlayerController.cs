using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float swipeSensitivity = Screen.width/20;
    private float forwardSpeed = 20f;
    private float rotationSpeed = 10f;
    private float rotationOffset = 0.15f;
    private float tiltAngle = 15f;
    private Vector2 touchStartPos;
    private bool isSwiping = false;
    private Vector3 targetPosition = Vector3.left * 2;
    private float laneChangeSpeed = 10f;

    void Update()
    {
        MoveForward();
        HandleSwipe();
        MoveToTargetPosition();
        RotateCar();
    }
    void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    void HandleSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        float swipeDelta = touch.position.x - touchStartPos.x;
                        if (Mathf.Abs(swipeDelta) > swipeSensitivity)
                        {
                            if (swipeDelta > 0)
                            {
                                MoveRight();
                            }
                            else
                            {
                                MoveLeft();
                            }
                            isSwiping = false;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }
    void MoveToTargetPosition()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, transform.position.y, transform.position.z), Time.deltaTime * laneChangeSpeed);
    }
    void MoveRight()
    {
        if (targetPosition.x < 2)
        {
            targetPosition += Vector3.right * 4;
        }
    }

    void MoveLeft()
    {
        if (targetPosition.x > -2)
        {
            targetPosition += Vector3.left * 4;
        }
    }
    void RotateCar()
    {
        float targetRotationY = 0f;

        if (targetPosition.x > transform.position.x + rotationOffset)
        {
            targetRotationY = tiltAngle;
        }
        else if (targetPosition.x < transform.position.x - rotationOffset)
        {
            targetRotationY = -tiltAngle;
        }

        Quaternion targetRotation = Quaternion.Euler(0, targetRotationY, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    public void SpeedBooster()
    {
        if(forwardSpeed <= 100)
        {
            forwardSpeed *= 1.2f;
        }
        else
        {
            forwardSpeed *= 1.05f;
        }

    }
}
