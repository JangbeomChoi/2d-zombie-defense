
using UnityEngine;

public class Camerascroll : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float minX;
    public float maxX;

    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveCameraLeft();
        }
        
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveCameraRight();
        }
    }

    
    public void MoveCameraLeft()
    {
        Vector3 newPosition = transform.position - Vector3.right * moveSpeed * Time.deltaTime;
        
        newPosition.x = Mathf.Max(newPosition.x, minX);
        transform.position = newPosition;
    }

    
    public void MoveCameraRight()
    {
        Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        
        newPosition.x = Mathf.Min(newPosition.x, maxX);
        transform.position = newPosition;
    }
}
