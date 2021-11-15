using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    private List<Transform> path;
    int currentWaypointTargetIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypointTargetIndex = 0;
        path = waveConfig.GetWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (currentWaypointTargetIndex < path.Count)
        {
            Vector3 currentTarget = path[currentWaypointTargetIndex].position;
            float movementDelta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, movementDelta);

            if (transform.position == currentTarget)
            {
                currentWaypointTargetIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
