using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private MyVector2 enemyPos;
    private MyVector2 enemyDir;
    private MyVector2 defaultPos;
    private MyVector2 playerPos;
    private float spawnTimer = 0f;
    private float speed;
    private float distance;

    void Start()
    {
        if (this.CompareTag("Red"))
        {
            defaultPos = new MyVector2(0, 0);
            speed = 3f;
        }
        else if (this.CompareTag("Blue"))
        {
            defaultPos = new MyVector2(2, 0);
            speed = 4f;
        }
        else if (this.CompareTag("Pink"))
        {
            defaultPos = new MyVector2(4, 0);
            speed = 4.5f;
        }
        else if (this.CompareTag("Orange"))
        {
            defaultPos = new MyVector2(-1.5f, 0);
            speed = 2f;
        }

        enemyPos = defaultPos;
        enemyDir = defaultPos;
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
            playerPos = Player_Movement.instance.GetPos();
            if (Player_Movement.instance.getPowerUpState() == false)
            {
                enemyDir = enemyPos.SubVectors(playerPos, enemyPos);
            }
            else if (Player_Movement.instance.getPowerUpState() == true)
            {
                enemyDir = enemyPos.SubVectors(enemyPos, playerPos);
            }


            distance = enemyDir.VectorLength();
            if (distance > 0.0001f)
            {
                MyVector2 dirNorm = enemyDir.NormalizedVector();
                MyVector2 movement = new MyVector2(dirNorm.x * speed * Time.deltaTime, dirNorm.y * speed * Time.deltaTime);

                enemyPos = enemyPos.AddVectors(enemyPos, movement);
                transform.position = enemyPos.ToUnityVector();
            }


            if (enemyPos.x >= 37)
            {
                enemyPos = new MyVector2(-36, enemyPos.y);
            }
            else if (enemyPos.x <= -37)
            {
                enemyPos = new MyVector2(36, enemyPos.y);
            }

            if (enemyPos.y >= 19)
            {
                enemyPos = new MyVector2(enemyPos.x, -18);
            }
            else if (enemyPos.y <= -19)
            {
                enemyPos = new MyVector2(enemyPos.x, 18);
            }

        }
    }

    private void FixedUpdate()
    {
        CollisionCheck();
    }

    public void ResetToDefault()
    {
        spawnTimer = 0f;
        enemyPos = defaultPos;
        enemyDir = defaultPos;
    }


    private void CollisionCheck()
    {
        if (Player_Movement.instance.getPowerUpState() == false)
        {
            if (enemyPos.OverlapVectors(enemyPos, playerPos))
            {
                Player_Movement.instance.TakeDamage();
                ResetToDefault();
            }
        }
        else if (Player_Movement.instance.getPowerUpState() == true)
        {
            if (enemyPos.OverlapVectors(enemyPos, playerPos))
            {
                Player_Movement.instance.AddEnemyScore();
                ResetToDefault();
            }
        }

    }
}
