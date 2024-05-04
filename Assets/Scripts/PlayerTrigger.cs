using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    private PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        DetectStuff();
    }

    private void DetectStuff()
    {
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius); 
        foreach (Collider c in detectedObjects)
        {
            if (c.CompareTag("actionpos"))
            {
                EnteredActionZone(c);
            }
        }
    }

    private void EnteredActionZone(Collider actionZoneTrigger)
    {
        ActionZone actionZone = actionZoneTrigger.GetComponentInParent<ActionZone>();
        playerMovement.EnteredActionZone(actionZone);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
