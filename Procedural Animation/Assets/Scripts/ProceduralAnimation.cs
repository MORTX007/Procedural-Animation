using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralAnimation : MonoBehaviour
{
    public Transform body;
    public Transform legIK;
    public Transform target;
    public Transform targetRayOrigin;
    public Transform distanceChecker;
    public Transform distanceRayOrigin;

    private Vector3 targetPos;

    public float smoothTime = 5f;

    public bool canMove = false;
    public bool grounded = true;

    public LayerMask groundMask;

    private void Start()
    {
        targetPos = target.position;
    }

    private void Update()
    {
        MoveLegs();
    }

    private void MoveLegs()
    {

        if (Physics.Raycast(targetRayOrigin.position, Vector3.down, out RaycastHit targetHit, 100, groundMask))
        {
            target.position = targetHit.point;
        }

        if (Physics.Raycast(distanceRayOrigin.position, Vector3.down, out RaycastHit distHit, 100, groundMask))
        {
            distanceChecker.position = distHit.point;
        }

        if (Vector3.Distance(target.position, distanceChecker.position) > 3f)
        {
            targetPos = distanceChecker.position;
        }

        target.position = Vector3.MoveTowards(target.position, targetPos, smoothTime * Time.deltaTime);
    }
}
