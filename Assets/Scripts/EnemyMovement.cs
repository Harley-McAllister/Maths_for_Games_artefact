using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private MyVector2 enemyPos;
    private MyVector2 enemyDir;
    private float spawnTimer = 0f;

    void Start()
    {
        enemyPos = new MyVector2(0,0);
        enemyDir = new MyVector2(0,0);
        transform.position = enemyPos.ToUnityVector();

    }

    void Update()
    {
        if (spawnTimer < 2f)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            enemyDir = enemyPos.SubVectors(enemyPos, Player_Movement.instance.GetPos());
            transform.position = enemyPos.ToUnityVector();
            enemyPos = enemyPos.SubVectors(enemyPos, enemyDir);

            if (enemyPos.x >= 18)
            {
                enemyPos = new MyVector2(-19, enemyPos.y);
            }
            else if (enemyPos.x <= -18)
            {
                enemyPos = new MyVector2(19, enemyPos.y);
            }

            if (enemyPos.y >= 10)
            {
                enemyPos = new MyVector2(enemyPos.x, -11);
            }
            else if (enemyPos.y <= -10)
            {
                enemyPos = new MyVector2(enemyPos.x, 11);
            }

            CollisionCheck();
        }
    }

    private void CollisionCheck()
    { 
        if (enemyPos.OverlapVectors(enemyPos, Player_Movement.instance.GetPos()))
        {
            Player_Movement.instance.TakeDamage();
            spawnTimer = 0f;
            enemyPos = new MyVector2(0, 0);
        }
    }
}
