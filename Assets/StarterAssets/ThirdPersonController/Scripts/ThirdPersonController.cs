﻿using UnityEngine;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
#endif

/* Note: animations are called via the controller for both the character and capsule using animator null checks
 */


[RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
[RequireComponent(typeof(PlayerInput))]
#endif
public class ThirdPersonController : MonoBehaviour
{
    [Header("Player")]
    [Tooltip("Move speed of the character in m/s")]
    public float MoveSpeed = 2.0f;

    [Tooltip("Sprint speed of the character in m/s")]
    public float SprintSpeed = 5.335f;

    [Tooltip("How fast the character turns to face movement direction")]
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;

    [Tooltip("Acceleration and deceleration")]
    public float SpeedChangeRate = 10.0f;

    public AudioClip LandingAudioClip;
    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

    [Space(10)]
    [Tooltip("The height the player can jump")]
    public float JumpHeight = 1.2f;

    [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
    public float Gravity = -15.0f;

    [Space(10)]
    [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
    public float JumpTimeout = 0.50f;

    [Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
    public float FallTimeout = 0.15f;

    [Header("Player Grounded")]
    [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
    public bool Grounded = true;

    [Header("Player isAttacking")]
    public bool Attacking = false;

    [Tooltip("Useful for rough ground")]
    public float GroundedOffset = -0.14f;

    [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
    public float GroundedRadius = 0.28f;

    [Tooltip("What layers the character uses as ground")]
    public LayerMask GroundLayers;

    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;

    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;

    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;

    [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;

    [Tooltip("For locking the camera position on all axis")]
    public bool LockCameraPosition = false;

    // cinemachine
    private float _cinemachineTargetYaw;
    public float _cinemachineTargetPitch;

    // player
    private float _speed;
    private float _animationBlend;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;

    // timeout deltatime
    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;

    // animation IDs
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed;
    private int _animIDnormal;
    private int _animIDfireball;
    private int _animIDshield;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
    private PlayerInput _playerInput;
#endif
    private Animator _animator;
    private CharacterController _controller;
    private StarterAssetsInputs _input;
    private GameObject _mainCamera;

    private const float _threshold = 0.01f;

    private bool _hasAnimator;

    public GameObject fireball;
    private GameObject fireball_clone;
    public GameObject shield;
    private float startTime;

    public AudioSource audioPlayer;
    public AudioClip bgmshield;
    public AudioClip attack;
    public AudioClip hitsound;

    private bool CameraRotation_status = true;

    public GameObject sword;
    public bool normal_isAttack = false;
    public float shield_c = 1.0f;
    private float player_hp;

    public Image skillmask1;
    public Image skillmask2;

    public item item1;
    public item item2;
    public item item3;
    public inventory playerInventory;

    private bool IsCurrentDeviceMouse
    {
        get
        {
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
            return _playerInput.currentControlScheme == "KeyboardMouse";
#else
			return false;
#endif
        }
    }


    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    private void Start()
    {
        _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;

        _hasAnimator = TryGetComponent(out _animator);
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        _playerInput = GetComponent<PlayerInput>();
#else
		Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif

        AssignAnimationIDs();

        // reset our timeouts on start
        _jumpTimeoutDelta = JumpTimeout;
        _fallTimeoutDelta = FallTimeout;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        player_hp = DontDestroyVariable.PlayerHealth;
    }

    private void Update()
    {
        _hasAnimator = TryGetComponent(out _animator);

        JumpAndGravity();
        GroundedCheck();
        Move();
        Attack();
        CursorVisible();
        SearchMode();
        normal_attack();
        damage_animation();
        load_scene();

        if (Time.time - startTime > 10.0f)
        {
            shield.SetActive(false);
            shield_c = 1.0f;
        }
    }

    void CursorVisible()
    {
        if (Input.GetMouseButtonDown(1)) {
            Cursor.visible = true;
        } else if (Input.GetMouseButtonDown(0) && Cursor.visible) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None;
    }

    void SearchMode()
    {
        if (Input.GetMouseButtonDown(1) && Cursor.visible)
        {
            CameraRotation_status = false;
        }
        else if (Input.GetMouseButtonUp(1) && Cursor.visible)
        {
            CameraRotation_status = true;
        }
    }

    private void LateUpdate()
    {
        if (CameraRotation_status)
        {
             CameraRotation();
        }
    }

    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        _animIDnormal = Animator.StringToHash("normal");
        _animIDfireball = Animator.StringToHash("fireball");
        _animIDshield = Animator.StringToHash("shield");
    }

    private void GroundedCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        // update animator if using character
        if (_hasAnimator)
        {
            _animator.SetBool(_animIDGrounded, Grounded);
        }
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
            _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }

    private void Move()
    {

        // set target speed based on move speed, sprint speed and if sprint is pressed
        float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;

        // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

        // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is no input, set the target speed to 0
        if (_input.move == Vector2.zero) targetSpeed = 0.0f;

        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
            currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                Time.deltaTime * SpeedChangeRate);

            // round speed to 3 decimal places
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }

        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;
        if (Attacking) _speed = 0;
        // normalise input direction
        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (_input.move != Vector2.zero && !Attacking)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                _mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);
            // rotate to face input direction relative to camera position
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }


        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        // move the player
        _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
                            new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        // update animator if using character
        if (_hasAnimator)
        {
            _animator.SetFloat(_animIDSpeed, _animationBlend);
            _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
        }
    }

    private void JumpAndGravity()
    {
        if (Grounded)
        {
            // reset the fall timeout timer
            _fallTimeoutDelta = FallTimeout;

            // update animator if using character
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDJump, false);
                _animator.SetBool(_animIDFreeFall, false);
            }

            // stop our velocity dropping infinitely when grounded
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = -2f;
            }

            // Jump
            if (_input.jump && _jumpTimeoutDelta <= 0.0f)
            {
                // the square root of H * -2 * G = how much velocity needed to reach desired height
                _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);

                // update animator if using character
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDJump, true);
                }
            }

            // jump timeout
            if (_jumpTimeoutDelta >= 0.0f)
            {
                _jumpTimeoutDelta -= Time.deltaTime;
            }
        }
        else
        {
            // reset the jump timeout timer
            _jumpTimeoutDelta = JumpTimeout;

            // fall timeout
            if (_fallTimeoutDelta >= 0.0f)
            {
                _fallTimeoutDelta -= Time.deltaTime;
            }
            else
            {
                // update animator if using character
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDFreeFall, true);
                }
            }

            // if we are not grounded, do not jump
            _input.jump = false;
        }

        // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += Gravity * Time.deltaTime;
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && Grounded)
        {
            if (gameObject.GetComponent<test>().current_skill == 0)
            {
                _animator.SetTrigger("normal");
                Attacking = true;
            }
            else if (gameObject.GetComponent<test>().current_skill == 1 && skillmask1.fillAmount == 0)
            {
                if(DontDestroyVariable.PlayerBlue >= 20.0f){
                    _animator.SetTrigger("fireball");
                    skillmask1.fillAmount = 1;
                    Attacking = true;
                    DontDestroyVariable.PlayerBlue -= 20.0f;
                }
            }
            else if (gameObject.GetComponent<test>().current_skill == 2 && skillmask2.fillAmount == 0)
            {
                if(DontDestroyVariable.PlayerBlue >= 30.0f){
                    _animator.SetTrigger("shield");
                    skillmask2.fillAmount = 1;
                    Attacking = true;
                    DontDestroyVariable.PlayerBlue -= 30.0f;
                }
            }

            
        }
    }

    public void isAttacking()
    {
        Attacking = false;
    }

    public void normal_attack()
    {
        if (normal_isAttack)
        {
            Collider[] collider = Physics.OverlapBox(sword.transform.TransformPoint(sword.gameObject.GetComponent<BoxCollider>().center), sword.gameObject.GetComponent<BoxCollider>().size, Quaternion.identity);

            foreach (var col in collider)
            {
                if (col.tag == "Boss")
                {
                    if(Boss.Health > 0){
                        audioPlayer.PlayOneShot(hitsound);
                    }
                    Boss.Health = Boss.Health - 100f;
                    normal_isAttack = false;
                    break;
                }
                if (col.tag == "enemy")
                {
                    if(Enemy.Health > 0){
                        audioPlayer.PlayOneShot(hitsound);
                    }
                    Enemy.TakeDamage(100f);
                    //Enemy.Health = Enemy.Health - 100f;
                   
                    normal_isAttack = false;
                    break;
                }

                if(col.tag == "Crystal")
                {
                    audioPlayer.PlayOneShot(hitsound);
                    col.GetComponent<CrystalController>().DestoryCrystal();
                }

                // if (col.gameObject.name == "MonsterA") {
                //     MonsterAController.isDamaged = true;
                //     normal_isAttack = false;
                //     break;
                // } 
                // if (col.gameObject.name == "MonsterB") {
                //     MonsterBController.isDamaged = true;
                //     normal_isAttack = false;
                //     break;
                // }
            }
        }
    }

    public void normal_attack_start()
    {
        normal_isAttack = true;
        audioPlayer.PlayOneShot(attack);
    }

    public void normal_attack_stop()
    {
        normal_isAttack = false;
    }

    public void fireball_shoot()
    {
        Vector3 pos = transform.position + new Vector3(transform.TransformDirection(Vector3.forward).x * 2, 1, transform.TransformDirection(Vector3.forward).z * 2);
        Quaternion rot = transform.rotation;
        fireball_clone = (GameObject)Instantiate(fireball, pos, rot);
        fireball_clone.SetActive(true);
    }

    public void shield_open()
    {
        shield.SetActive(true);
        audioPlayer.PlayOneShot(bgmshield);
        shield_c = 0.5f;
        startTime = Time.time;
    }

    public void damage_animation()
    {
        if(player_hp > DontDestroyVariable.PlayerHealth)
        {
            _animator.SetTrigger("damage");
            Attacking = true;
            player_hp = DontDestroyVariable.PlayerHealth;
        }
    }

    public void load_scene()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            DontDestroyVariable.nowplace = 4;
            SceneManager.LoadScene(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DontDestroyVariable.nowplace = 1;
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DontDestroyVariable.nowplace = 2;
            SceneManager.LoadScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DontDestroyVariable.nowplace = 3;
            SceneManager.LoadScene(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            DontDestroyVariable.nowplace = 0;
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            DontDestroyVariable.nowskillnum = 2;
            DontDestroyVariable.getball2 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            DontDestroyVariable.nowskillnum = 3;
            DontDestroyVariable.getball3 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            AddNewItem(item1);
            AddNewItem(item2);
            AddNewItem(item3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Boss.Health = 0;
        }

    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (Grounded) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(
            new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z),
            GroundedRadius);
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
            }
        }
    }

    private void OnLand(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            AudioSource.PlayClipAtPoint(LandingAudioClip, transform.TransformPoint(_controller.center), FootstepAudioVolume);
        }
    }

    public void AddNewItem(item item)
    {
        if (!playerInventory.itemList.Contains(item))
        {
            playerInventory.itemList.Add(item);
        }
        else
        {
            item.itemHeld += 1;
        }
        manager.ReflashItem();
    }
}
