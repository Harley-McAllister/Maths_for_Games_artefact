using UnityEngine;

public class powerOrb : MonoBehaviour
{
    private MyVector2 orb_Pos;

    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CollideWithPlayer();
    }


    private void Respawn()
    {
        int posX = Random.Range(-36, 36);
        int posY = Random.Range(-18, 18);
        orb_Pos = new MyVector2(posX, posY);
        this.transform.position = orb_Pos.ToUnityVector();
    }

    void CollideWithPlayer()
    {
        if (orb_Pos.OverlapVectors(orb_Pos, Player_Movement.instance.GetPos()))
        {
            Respawn();
            Player_Movement.instance.AddScore();
            Player_Movement.instance.ChangepowerState(true);
        }
    }
}
