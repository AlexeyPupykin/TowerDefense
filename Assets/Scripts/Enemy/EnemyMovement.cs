using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private int wavepointIndex = 0;
    private Transform target;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(direction);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextWaypoint();

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives -= enemy.damage;
        Destroy(gameObject);
    }
}
