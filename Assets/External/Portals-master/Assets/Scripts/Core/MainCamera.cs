using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Material normalMat;
    public bool isBWMode = false;
    public Shader bwShader;
    Material bwMat;

    Portal[] portals;

    void Awake () {
        portals = FindObjectsOfType<Portal> ();
    }

    void Start()
    {
        bwMat = new Material(bwShader);
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

}