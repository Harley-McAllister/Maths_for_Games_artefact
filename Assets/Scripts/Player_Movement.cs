using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private MyVector2 position;
    private string direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = new MyVector2(-18, 9);
        transform.position = position.ToUnityVector();
        direction = "right";
    }

    // Update is called once per frame
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
                    position = position.AddVectors(position, new MyVector2(0.01f, 0));
                    if (position.x >= 18)
                    {
                        position = new MyVector2(-19, position.y);
                    }
                    break;
                case "down":
                    position = position.SubVectors(position, new MyVector2(0, 0.01f));
                if (position.y <= -9)
                    {
                        position = new MyVector2 (position.x, 9);
                    }
                    break;
                case "left":
                    position = position.SubVectors(position, new MyVector2(0.01f, 0));
                if (position.x <= -18)
                    {
                        position = new MyVector2 (19, position.y);
                    }
                    break;
                case "up":
                    position = position.AddVectors(position, new MyVector2 (0, 0.01f));
                    if (position.y >= 9)
                    {
                        position = new MyVector2 (position.x, -9);
                    }
                    break;
            }
        transform.position = position.ToUnityVector();
    }
}
