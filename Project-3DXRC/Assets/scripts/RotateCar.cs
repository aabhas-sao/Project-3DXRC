using UnityEngine;

public class RotateCar : MonoBehaviour
{
    public float rotateSpeed = 4f;
    public Vector3 angle = new Vector3(1, 1, 1);
    void Update()
    {
        transform.Rotate(angle * Time.deltaTime * rotateSpeed);
    }
}
