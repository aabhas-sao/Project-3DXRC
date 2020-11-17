 using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float steerAngle;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;

    private GameObject target;
    public float turnMultiplier = -1;
    private GameManager gameManager;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("player");
            Debug.Log("target Found");
            return;
        }
        
        HandleSteering();
        HandleMotor();
        UpdateWheels();
    }

    private void HandleSteering()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(target.transform.position);
        relativeVector /= relativeVector.magnitude;
        //print(relativeVector);
        steerAngle = -maxSteeringAngle * relativeVector.x;

        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque  = gameManager.currentEnemyMotorForce * 1;
        frontRightWheelCollider.motorTorque = gameManager.currentEnemyMotorForce * 1;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }


    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        rot = rot * Quaternion.Euler(new Vector3(0, 90, 0));
        trans.rotation = rot;
        trans.position = pos;
    }
}

