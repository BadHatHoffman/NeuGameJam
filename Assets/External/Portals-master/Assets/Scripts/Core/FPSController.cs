using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : PortalTraveller
{
    public GameObject finalBoss;
    public GameObject bossSpawn;
    public float pickupRange = 0;
    public Vector3 camTransformOrig;

    public float walkSpeed = 3;
    public float runSpeed = 6;
    public float smoothMoveTime = 0.1f;
    public float jumpForce = 8;
    public float gravity = 18;
    public int totalEntries = 0;

    public bool lockCursor;
    public float mouseSensitivity = 10;
    public Vector2 pitchMinMax = new Vector2 (-40, 85);
    public float rotationSmoothTime = 0.1f;

    CharacterController controller;
    Camera cam;
    public float yaw;
    public float pitch;
    float smoothYaw;
    float smoothPitch;

    float yawSmoothV;
    float pitchSmoothV;
    float verticalVelocity;
    Vector3 velocity;
    Vector3 smoothV;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    bool jumping;
    float lastGroundedTime;
    public bool disabled;
    public Animator camAnim, joshAnim;
    public GameObject transformParticle, castParticle, castHand;
    public WeaponThrow weaponThrow; //get the script

    Vector3 spawnPos;


    void Start () {
        spawnPos = transform.position;

        cam = Camera.main;
        if (lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        controller = GetComponent<CharacterController> ();

        yaw = transform.eulerAngles.y;
        pitch = cam.transform.localEulerAngles.x;
        smoothYaw = yaw;
        smoothPitch = pitch;

        GetComponent<Health>().Death.AddListener(Die);
    }

    void Update()
    {

        if (disabled)
        {
            return;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 inputDir = new Vector3(input.x, 0, input.y).normalized;
        Vector3 worldInputDir = transform.TransformDirection(inputDir);

        float currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed;
        Vector3 targetVelocity = worldInputDir * currentSpeed;
        velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref smoothV, smoothMoveTime);

        verticalVelocity -= gravity * Time.deltaTime;
        velocity = new Vector3(velocity.x, verticalVelocity, velocity.z);

        var flags = controller.Move(velocity * Time.deltaTime);
        if (flags == CollisionFlags.Below)
        {
            jumping = false;
            lastGroundedTime = Time.time;
            verticalVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float timeSinceLastTouchedGround = Time.time - lastGroundedTime;
            if (controller.isGrounded || (!jumping && timeSinceLastTouchedGround < 0.15f))
            {
                GameManager.Instance.CueAudio(7);
                jumping = true;
                verticalVelocity = jumpForce;
            }
        }

        float mX = Input.GetAxisRaw("Mouse X");
        float mY = Input.GetAxisRaw("Mouse Y");

        // Verrrrrry gross hack to stop camera swinging down at start
        float mMag = Mathf.Sqrt(mX * mX + mY * mY);
        if (mMag > 5)
        {
            mX = 0;
            mY = 0;
        }

        yaw += mX * mouseSensitivity;
        pitch -= mY * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        smoothPitch = Mathf.SmoothDampAngle(smoothPitch, pitch, ref pitchSmoothV, rotationSmoothTime);
        smoothYaw = Mathf.SmoothDampAngle(smoothYaw, yaw, ref yawSmoothV, rotationSmoothTime);

        transform.eulerAngles = Vector3.up * smoothYaw;
        cam.transform.localEulerAngles = Vector3.right * smoothPitch;



        JoshChecks();

        //picking up journal entries
        if (Input.GetButtonDown("Collect"))
        {
            foreach (var item in Physics.SphereCastAll(transform.position, pickupRange, transform.forward))
            {
                if (item.transform.gameObject.CompareTag("JournalEntry"))
                {
                    Destroy(item.transform.gameObject);
                    disabled = true;
                    JournalUI.Instance.CollectingEntry(totalEntries);
                    GetComponentInChildren<MainCamera>().isBWMode = true;
                    totalEntries++;
                    break;
                }
            }
        }

        //triggering boss fight
        if (totalEntries >= 5)
        {
            bossSpawn.SetActive(true);
            totalEntries = 0;
        }
    }

    private void JoshChecks()
    {
        joshAnim.SetFloat("Speed", controller.velocity.magnitude);
        //left mouse click to throw
        if (Input.GetButtonDown("Fire1"))
        {
            //trigger the throw method only IF NOT ALREADY THROW (isThrown == false)
            if (!weaponThrow.isThrown)
            {
                GameManager.Instance.CueAudio(6);
                weaponThrow.Throw();
            }
        }

        //right mouse click to return weapon
        if (Input.GetButtonDown("Fire2"))
        {
            //trigger the return weapon method only IF WEAPON IS THROWN (isThrow == true)
            if (weaponThrow.isThrown)
            {
                weaponThrow.ReturnWeapon();
            }
        }
    }

    public override void Teleport (Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot) {
        transform.position = pos;
        Vector3 eulerRot = rot.eulerAngles;
        float delta = Mathf.DeltaAngle (smoothYaw, eulerRot.y);
        yaw += delta;
        smoothYaw += delta;
        transform.eulerAngles = Vector3.up * smoothYaw;
        velocity = toPortal.TransformVector (fromPortal.InverseTransformVector (velocity));
        Physics.SyncTransforms();
    }

    public void Die()
    {
        Application.Quit();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, pickupRange);
    }
}