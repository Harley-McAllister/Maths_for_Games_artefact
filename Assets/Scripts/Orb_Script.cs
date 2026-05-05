using UnityEngine;

public class Orb_Script : MonoBehaviour
{
    private MyVector2 orb_Pos;
    void Start()
    {
        Respawn();
    }


    void Update()
    {
        CollideWithPlayer();
    }

    void CollideWithPlayer()
    {
        if (orb_Pos.OverlapVectors(orb_Pos, Player_Movement.instance.GetPos()))
        {
            Respawn();
            Player_Movement.instance.AddScore();
        }
    }

    private void Respawn()
    { 
        float posX = Random.Range(-19, 9);
        float posY = Random.Range(-9, 8);
        orb_Pos = new MyVector2(posX, posY);
        this.transform.position = orb_Pos.ToUnityVector();
    }
}
