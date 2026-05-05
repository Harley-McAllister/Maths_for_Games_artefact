using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private MyVector2 position;
    private string direction;
    private float lives = 3;
    private int score = 0;
    public static Player_Movement instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        position = new MyVector2(-18, 9);
        transform.position = position.ToUnityVector();
        direction = "right";
    }

    public MyVector2 GetPos()
    { 
        return position;
    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = "right";
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = "down";
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = "left";
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = "up";
            }

            switch (direction)
            {
                case "right":
                    position = position.AddVectors(position, new MyVector2(0.025f, 0));
                    if (position.x >= 18.5)
                    {
                        position = new MyVector2(-19, position.y);
                    }
                    break;
                case "down":
                    position = position.SubVectors(position, new MyVector2(0, 0.025f));
                    if (position.y <= -9.5)
                    {
                        position = new MyVector2(position.x, 9);
                    }
                    break;
                case "left":
                    position = position.SubVectors(position, new MyVector2(0.025f, 0));
                    if (position.x <= -18.5)
                    {
                        position = new MyVector2(19, position.y);
                    }
                    break;
                case "up":
                    position = position.AddVectors(position, new MyVector2(0, 0.025f));
                    if (position.y >= 9.5)
                    {
                        position = new MyVector2(position.x, -9);
                    }
                    break;
            }
        transform.Rotate(0, 0, position.VectorAngle(position));
        transform.position = position.ToUnityVector();
    }


    public void AddScore()
    {
        score+=10;
        Debug.Log("Score: " + score);
    }

    public void TakeDamage()
    {
        if (lives > 0)
        {
            lives--;
            position = new MyVector2(-18, 9);
            transform.position = position.ToUnityVector();
            direction = "right";
            Debug.Log("Ouch bitch");
            if (lives == 0)
            {
                Object.Destroy(this);
                Debug.Log("You lose");
            }
        }
       
    }
}
