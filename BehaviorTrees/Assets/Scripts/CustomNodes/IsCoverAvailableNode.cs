using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCoverAvailableNode : Node
{
    private List<Cover> availableCovers;
    private Transform target;
    private EnemyAI enemyAI;

    public IsCoverAvailableNode(List<Cover> availableCovers, Transform target, EnemyAI ai)
    {
        this.availableCovers = availableCovers;
        this.target = target;
        enemyAI = ai;
    }

    public override NodeState Evaluate()
    {
        Transform bestLoc = FindBestCoverLocation();
        enemyAI.SetBestCoverLocation(bestLoc);
        return bestLoc != null ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    private Transform FindBestCoverLocation()
    {
        float minAngle = 90.0f;
        Transform bestLoc = null;

        for(int i = 0; i < availableCovers.Count; i++)
        {
            Transform bestLocInCover = FindBestSpotInCover(availableCovers[i], ref minAngle);
            if (bestLocInCover != null)
                bestLoc = bestLocInCover;
        }
        return bestLoc;
    }

    private Transform FindBestSpotInCover(Cover cover, ref float minAngle)
    {
        List<Transform> availableSpots = cover.GetCoverTransforms();
        Transform bestSpot = null;

        for(int i = 0; i < availableCovers.Count; i++)
        {
            Vector3 direction = target.position - availableSpots[i].position;
            if (IsSpotValid(availableSpots[i]))
            {
                float angle = Vector3.Angle(availableSpots[i].forward, direction);
                if(angle < minAngle)
                {
                    minAngle = angle;
                    bestSpot = availableSpots[i];
                }
            }
        }
        return bestSpot;
    }

    private bool IsSpotValid(Transform spot)
    {
        RaycastHit hit;
        Vector3 direction = target.position - spot.position;

        if(Physics.Raycast(spot.position, direction, out hit))
        {
            if (hit.collider.transform != target)
                return true;
        }
        return false;
    }
}
