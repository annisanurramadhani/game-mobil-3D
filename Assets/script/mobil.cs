using UnityEngine;

public class mobil : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentBrakeForce;

    private bool isBraking;
    private bool isAccelerating;

    private AudioSource engineSound;

    // Joystick
    public FixedJoystick joystick;

    // Settings
    [SerializeField] private float motorForce = 12000f;
    [SerializeField] private float brakeForce = 6000f;
    [SerializeField] private float maxSteerAngle = 30f;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    // Wheel Transforms
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void Start()
    {
        engineSound = GetComponent<AudioSource>();
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
        horizontalInput = 0f;

        if (joystick != null)
        {
            horizontalInput = joystick.Horizontal;
        }

        verticalInput = isAccelerating ? 1f : 0f;
    }

    // ==========================
    // Tombol ACCEL
    // ==========================
    public void AccelDown()
    {
        isAccelerating = true;

        if (engineSound != null && !engineSound.isPlaying)
        {
            engineSound.Play();
        }
    }

    public void AccelUp()
    {
        isAccelerating = false;

        if (engineSound != null && engineSound.isPlaying)
        {
            engineSound.Stop();
        }
    }

    // ==========================
    // Tombol BRAKE
    // ==========================
    public void BrakeDown()
    {
        isBraking = true;
    }

    public void BrakeUp()
    {
        isBraking = false;
    }

    private void HandleMotor()
    {
        if (isBraking)
        {
            rearLeftWheelCollider.motorTorque = 0f;
            rearRightWheelCollider.motorTorque = 0f;

            currentBrakeForce = brakeForce;
        }
        else if (isAccelerating)
        {
            rearLeftWheelCollider.motorTorque = motorForce;
            rearRightWheelCollider.motorTorque = motorForce;

            currentBrakeForce = 0f;
        }
        else
        {
            // Menahan mobil agar tidak mundur
            rearLeftWheelCollider.motorTorque = 0f;
            rearRightWheelCollider.motorTorque = 0f;

            currentBrakeForce = brakeForce;
        }

        ApplyBraking();
    }

    private void ApplyBraking()
    {
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;

        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform, true);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform, false);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform, true);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform, false);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform, bool isLeftWheel)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);

        wheelTransform.position = pos;

        if (isLeftWheel)
        {
            wheelTransform.rotation = rot * Quaternion.Euler(0, 180, 0);
        }
        else
        {
            wheelTransform.rotation = rot;
        }
    }
}