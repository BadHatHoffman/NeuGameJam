using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameManager gameMan;
    public FPSController fpsController;
    public int totalEntries = 0;
    public int damage;
    public Health health;
    public Vector3 toVec;

    Ray ray;

    private void Update()
    {
        GameObject.FindGameObjectsWithTag("Enemy").All(x => x.GetComponent<Outline>().enabled = false);

        ray = new Ray(transform.position, transform.forward);

        foreach (var item in Physics.RaycastAll(ray))
        {
            if (item.transform.gameObject.CompareTag("Enemy"))
            {
                toVec = Vector3.Normalize(item.transform.position - transform.position);
                item.transform.GetComponent<Outline>().enabled = true;

                break;
            }

            if(item.transform.gameObject.CompareTag("JournalEntry") && Input.GetButtonDown("Collect"))
            {
                item.transform.gameObject.SetActive(false);
                totalEntries++;
                gameMan.CollectingEntry(totalEntries);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ray);
    }

    public void SwapToHuman()
    {
        fpsController.isTiger = false;
    }

    public void SwapToTiger()
    {
        fpsController.isTiger = true;
    }
}
