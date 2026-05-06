using TMPro;
using Unity.UI;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private MyVector2 position;
    private string direction;
    private int lives = 3;
    private int score = 0;
    private int livesScore = 0;
    private bool poweredUp = false;
    private float powerTimer = 0f;
    public static Player_Movement instance;
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] TextMeshProUGUI livesText;

    void Start()
    {
        instance = this;
        position = new MyVector2(-35f, 18f);
        transform.position = position.ToUnityVector();
        direction = "right";
        UpdateHud();
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
                    if (position.x >= 37f)
                    {
                        position = new MyVector2(-36f, position.y);
                    }
                    break;
                case "down":
                    position = position.SubVectors(position, new MyVector2(0, 0.025f));
                    if (position.y <= -20f)
                    {
                        position = new MyVector2(position.x, 19);
                    }
                    break;
                case "left":
                    position = position.SubVectors(position, new MyVector2(0.025f, 0));
                    if (position.x <= -37)
                    {
                        position = new MyVector2(36, position.y);
                    }
                    break;
                case "up":
                    position = position.AddVectors(position, new MyVector2(0, 0.025f));
                    if (position.y >= 20)
                    {
                        position = new MyVector2(position.x, -19);
                    }
                    break;
            }

        if (poweredUp)
        {
            powerTimer += Time.deltaTime;
            Debug.Log("Powered up time:" + powerTimer);
            if (powerTimer > 5)
            {

                ChangepowerState(false);
            }
        }

        if (livesScore >= 1000)
        {
            lives++;
            livesScore = 0;
        }

        transform.Rotate(0, 0, position.VectorAngle(position));
        transform.position = position.ToUnityVector();
        
        
    }

    void UpdateHud()
    {
        if (points){points.text = $"Score: {score.ToString()}";}

        if (livesText){livesText.text = $"Lives: {lives.ToString()}"; }
    }


    public void AddScore()
    {
        score+=10;
        livesScore += 10;
        Debug.Log("Score: " + score);
        UpdateHud();
    }

    public void AddEnemyScore()
    {
        score += 100;
        livesScore += 100;
        Debug.Log("Score: " + score);
        UpdateHud();
    }

    public bool getPowerUpState()
    {
        return poweredUp;
    }

    public void TakeDamage()
    {
        if (lives > 0)
        {
            lives--;
            position = new MyVector2(-35f, 18f);
            transform.position = position.ToUnityVector();
            direction = "right";
            Debug.Log("Ouch bitch");
            UpdateHud();
            if (lives == 0)
            {
                Object.Destroy(this);
                Debug.Log("You lose");
            }
        }
       
    }

    public void ChangepowerState(bool newPowerState)
    {
        poweredUp = newPowerState;
        powerTimer = 0;
        Debug.Log("Changing power state");
    }

}
