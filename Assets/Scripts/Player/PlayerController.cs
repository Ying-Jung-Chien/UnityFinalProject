using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public float Speed = 2f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float RotationSmoothTime = 0.12f;
    [Header("Player Grounded")]
    public bool Grounded = true;
    public float GroundedOffset = 0.1f;
    [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
    public float GroundedRadius = 0.3f;
    public LayerMask GroundLayers;
    [Header("Cinemachine")]
    public GameObject CinemachineCameraTarget;
    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;
    public float CameraRotationSpeed = 2.0f;
    public float CameraAngleOverride = 0.0f;
    public bool LockCameraPosition = false;
    // cinemachine
    private float _cinemachineTargetYaw;
    public float _cinemachineTargetPitch;
    private float OriginRotationSpeed;
    private const float _threshold = 0.01f;
    private StarterAssetsInputs _input;

    // player
    private CharacterController _controller;
    private Vector3 _velocity;
    private Vector3 move = new Vector3(0, 0, 0);
    private Vector3 targetDirection = new Vector3(0, 0, 0);
    private float _rotationVelocity;
    private float _targetRotation = 0.0f;
    private float _beforeJump = 0.0f;

    // animator
    public static bool isRising;
    public static bool isFalling;
    public static bool isLanding;
    public static bool isAttacking;
    public static bool isWalking;
    public static bool isRunning;
    public static bool isDamaging;

    // camera
    private GameObject _mainCamera;
    
    public AudioClip jump;
    public AudioSource run;
    public AudioSource audioPlayer;
    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }
    void Start()
    {
        _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<CharacterController>();
        OriginRotationSpeed = CameraRotationSpeed;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    private void Update()
    {
        GroundedCheck();
        PlayerInput();
        JumpingProcess();
        CursorVisible();
        SearchMode();

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            run.Play();
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            run.Stop();
        }
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    private void GroundedCheck()
    {
        // Grounded = Physics.Raycast(transform.position, -Vector3.up,  GroundedOffset);
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            _cinemachineTargetYaw += _input.look.x * CameraRotationSpeed;
            _cinemachineTargetPitch += _input.look.y * CameraRotationSpeed;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    void CursorVisible()
    {
        if (Input.GetMouseButtonDown(1)) {
            // Cursor.visible = Cursor.visible ? false : true;
            Cursor.visible = true;
        } else if (Input.GetMouseButtonDown(0) && Cursor.visible) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None;
        
    }

    void SearchMode()
    {
        if (Input.GetMouseButtonDown(1) && Cursor.visible) {
            CameraRotationSpeed = 0;
        } else if (Input.GetMouseButtonUp(1) && Cursor.visible) {
            CameraRotationSpeed = OriginRotationSpeed;
        }
    }
    
    void PlayerInput()
    {
        if (Grounded && _velocity.y < 0) _velocity.y = 0f;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded && !isAttacking) {
            // Enable Jump
            isRising = true;
            _velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            _beforeJump = transform.position.y;
        } else if (Input.GetMouseButtonDown(0) && !Cursor.visible) {
            isAttacking = true;
            move = new Vector3(0, 0, 0);
        }

        if (isAttacking || isLanding) targetDirection = new Vector3(0, 0, 0);
        else if (!isRising && !isFalling) {
            // Get Input
            float v = _input.move.y;
            float h = _input.move.x;
            move = new Vector3(h, 0, v);
            Vector3 inputDirection = new Vector3(h, 0.0f, v).normalized;

            if (Mathf.Sqrt(Mathf.Pow(v, 2) + Mathf.Pow(h, 2)) >= 0.8) {
                isWalking = false;
                isRunning = true;
            } else if (move != Vector3.zero) {
                isRunning = false;
                isWalking = true;
            } else {
                isRunning = false;
                isWalking = false;
            }

            if (_input.move != Vector2.zero)
            {
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                _mainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    RotationSmoothTime);

                // rotate to face input direction relative to camera position
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
                targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
            } else targetDirection = new Vector3(0, 0, 0);
        }
        
        _velocity.y += Gravity * Time.deltaTime;
        _controller.Move((targetDirection.normalized * Speed + _velocity) * Time.deltaTime);
    }

    void JumpingProcess()
    {
        // Debug.Log(_controller.velocity.y);
        if (_controller.velocity.y < 0 && isRising) {
            // Debug.Log("Jumping");
            isRising = false;
            isFalling = true;
        } else if (Grounded && isFalling)
        {
            // Debug.Log("isFalling");
            audioPlayer.PlayOneShot(jump);
            isFalling = false;
            isLanding = true;
        }
    }
}