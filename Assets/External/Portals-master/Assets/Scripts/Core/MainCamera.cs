using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Material normalMat;
    public bool isBWMode = false;
    public Shader bwShader;
    Material bwMat;

    Portal[] portals;

    public FPSController player;
    public float camTransitionSpeed = 1;
    public Vector3 camPos;
    private bool moveCam = false;

    void Awake () {
        portals = FindObjectsOfType<Portal> ();
    }

    void Start()
    {
        bwMat = new Material(bwShader);
    }

    private void Update()
    {
        if(moveCam)
        {
            GetComponent<Animator>().Play("CameraTransformRotation", -1, 0);
            GetComponent<Animator>().enabled = false;
            transform.localPosition = Vector3.Lerp(transform.localPosition, camPos, Time.deltaTime * camTransitionSpeed);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, Time.deltaTime * camTransitionSpeed);
            if(Vector3.Distance(transform.localPosition, camPos) <= .1f)
            {
                transform.localPosition = camPos;
                transform.localRotation = Quaternion.identity;
                GetComponentInParent<FPSController>().disabled = false;
                moveCam = false;
            }
        }
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if(isBWMode)
        {
            Graphics.Blit(src, dst, bwMat);
        }
        else
        {
            Graphics.Blit(src, dst);
        }
    }

    void OnPreCull () {

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PrePortalRender ();
        }
        for (int i = 0; i < portals.Length; i++) {
            portals[i].Render ();
        }

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PostPortalRender ();
        }

    }

    public void MoveCamPosition()
    {
        moveCam = true;
    }
}