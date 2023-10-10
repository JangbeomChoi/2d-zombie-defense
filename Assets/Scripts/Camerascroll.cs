
using UnityEngine;

public class Camerascroll : MonoBehaviour
{
    public float scrollSpeed = 2.0f; // ��ũ�� �ӵ� ���� ����

    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ScrollLeft();
        }
        
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ScrollRight();
        }
    }

    
    public void ScrollLeft()
    {
        Vector3 newPosition = transform.position - Vector3.right * scrollSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

   
    public void ScrollRight()
    {
        Vector3 newPosition = transform.position + Vector3.right * scrollSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
