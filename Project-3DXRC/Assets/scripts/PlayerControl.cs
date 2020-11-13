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
    [SerializeField]private float currentbrakeForce = 10f;
    private AudioManager audioManager;
    private bool isPlaying = false;
    private bool isPlayingSqueal = false;
    private bool isPlayingBrake = false;

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
        if(isBreaking) {
            ApplyBreaking();
        } else if(isBreaking == false && isPlayingBrake == true) {
            audioManager.StopPlaying("brake");
            isPlayingBrake = false;
        }
    }

    private void HandleSteering()
    {
        if((horizontalInput > 0 || horizontalInput < 0 ) && isPlayingSqueal == false && isPlayingBrake == false) {
            audioManager.Play("tireSqueal");
            isPlayingSqueal = true;
        } else if(horizontalInput == 0 && isPlayingSqueal == true) {
            audioManager.StopPlaying("tireSqueal");
            isPlayingSqueal = false;
        }
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
        currentbrakeForce = isBreaking ?currentbrakeForce: 0f;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void ApplyBreaking() {
        if(isPlayingBrake == false && isPlayingSqueal == false) {
            audioManager.Play("brake");
        }
        isPlayingBrake = true;
        frontLeftWheelCollider.brakeTorque = currentbrakeForce;
        frontRightWheelCollider.brakeTorque = currentbrakeForce;
        rearRightWheelCollider.brakeTorque = currentbrakeForce;
        rearLeftWheelCollider.brakeTorque = currentbrakeForce;
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
