using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class WeaponThrow : MonoBehaviour
{
    public Rigidbody Weapon; //rigidbody weapon
    private Vector3 OldPos; //last position of the weapon (POINT A)

    public Transform CurvePoint; //the curving point (POINT B)
    public Transform Target; //default position of weapon (POINT C)

    public Transform ParentObj; //main parent object of the weapon

    public float ThrowForce = 50f; //force of the throw
    public Vector3 ForceDirection = new Vector3(0f, 0f, 1f); //direction of weapon projection

    public float RotationalTorque = 100f; //the torque force
    public Vector3 TorqueDirection = new Vector3(0f, 1f, 0f); //axis of added torque force

    private float SlerpReturnSpeed = 5f; //the speed of the slerp responsible for weapon rotation back
    [HideInInspector] public bool isThrown = false; //to flag that weapon has been throw
    private bool isReturning = false; //to flag that weapon is currently returning
    private float time = 0.0f;

    public bool ShouldRotate = true; //flag whether to rotate weapon on return or not
    public Vector3 ReturningRotation = new Vector3(0f, -1f, 0f); //apply return rotation on which axis
    public float ReturnRotationSpeed = 500f; //the speed of the returning rotation
    public Vector3 ReceivedRotation = new Vector3(0f, 0f, 0f); //when weapon reaches target, what is the default rotation
    
    public bool reachedEnd = false;


    // Update is called once per frame
    void Update()
    {
        //Returning calculations
        if(isReturning) {

            //if time is less than 1, that means the weapon is still returning
            if(time < 1.0f) {
                
                //if ShouldRotate == true, then rotate weapon on return
                if (ShouldRotate) {
                    Target.Rotate(ReturningRotation * ReturnRotationSpeed * Time.deltaTime);
                }

                //move and slerp weapon back to target position/rotation
                Weapon.position = QuadraticBezierCurve(time, OldPos, CurvePoint.position, Target.position);
                if (ShouldRotate) Weapon.rotation = Target.rotation;

                //increment time
                time += Time.deltaTime;
            }else{
                //weapon has reached the player
                ResetWeapon();
            }
        }
    }


    //method that throws the weapon
    public void Throw(){
        //set returning flag to false
        isReturning = false;

        //set reached end flag to false
        reachedEnd = false;

        //set the thrown state
        isThrown = true;
        
        //set rigidbody kinematic to false
        Weapon.isKinematic = false;
        
        //Unattach weapon from parent
        Weapon.transform.parent = null;
        
        //Apply force to rigidbody
        Weapon.AddForce(Camera.main.transform.TransformDirection(new Vector3(ForceDirection.x, ForceDirection.y, ForceDirection.z)) * ThrowForce, ForceMode.Impulse);
        
        //Add rotational torque to weapon - so that it rotates
        Weapon.AddTorque(Weapon.transform.TransformDirection(new Vector3(TorqueDirection.x, TorqueDirection.y, TorqueDirection.z)) * RotationalTorque, ForceMode.Impulse);
    }
    

    //method that returns the weapon
    public void ReturnWeapon(){
        //reset time
        time = 0.0f;

        //last weapon position
        OldPos = Weapon.position;

        //flag that weapon is currently returning
        isReturning = true;

        //flag that weapon has reached end
        reachedEnd = false;

        //zero out the Rigidbody velocity
        Weapon.velocity = Vector3.zero;

        //flag kinematic to true
        Weapon.isKinematic = true;
    }


    //reset weapon to normal positional/rotational state
    void ResetWeapon(){
        //reset flags
        isReturning = false;
        isThrown = false;
        reachedEnd = true;

        //return weapon to default parent
        Weapon.transform.parent = ParentObj;

        //reset target to default rotation
        Target.rotation = new Quaternion(0f, 0f, 0f, 0f);

        //reset weapon to original target position
        Weapon.position = Target.position;
        
        //reset weapon rotation to specified axis
        Weapon.transform.localRotation = Quaternion.Euler(ReceivedRotation.x, ReceivedRotation.y, ReceivedRotation.z);
    }


    //Quadratic Bezier Curve calculations
    //moves object from point A to point C without touching (curving beside) point B
    Vector3 QuadraticBezierCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2){
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.TryGetComponent(out Health h))
            {
                h.TakeDamage(GameObject.Find("Josh").GetComponent<MainController>().damage);
            }
        }
    }
}
