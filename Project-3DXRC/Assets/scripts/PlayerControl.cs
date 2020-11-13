using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]private float horizontalInput;
    [SerializeField]private float verticalInput;
    private float steerAngle;
    [SerializeField]private bool isBreaking;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    [SerializeField]private float motorForce = 50f;
    public float currentbrakeForce = 0;
    
    public float brakeForce = 3000f;
    
    private AudioManager audioManager;
    private bool isPlaying = false;

    private void Awake() {
        audioManager = (AudioManager)FindObjectOfType(typeof(AudioManager));
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking =  Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        if(verticalInput > 0 && isPlaying == false) {
            audioManager.Play("engineCut");
            isPlaying = true;
        } else if(verticalInput <= 0 && isPlaying == true) {
            audioManager.StopPlaying("engineCut");
            isPlaying = false;
        }
        frontLeftWheelCollider.motorTorque = motorForce * verticalInput;
        frontRightWheelCollider.motorTorque = motorForce * verticalInput;
        currentbrakeForce = isBreaking ? brakeForce : 0f;
        if (isBreaking)
        {
            ApplyBreaking();
        }

        else if(Input.GetKeyUp(KeyCode.Space))
        {
            ResetWheels();
        }
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void ApplyBreaking() {
        frontLeftWheelCollider.brakeTorque = currentbrakeForce;
        frontRightWheelCollider.brakeTorque = currentbrakeForce;
        rearRightWheelCollider.brakeTorque = currentbrakeForce;
        rearLeftWheelCollider.brakeTorque = currentbrakeForce;
    }

    private void ResetWheels(){
        frontRightWheelCollider.brakeTorque = 0f;
        frontLeftWheelCollider.brakeTorque = 0f;
        rearLeftWheelCollider.brakeTorque = 0f;
        rearRightWheelCollider.brakeTorque = 0f;
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
