using UnityEngine;

public class Orb_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private GameObject powerOrb;

    void Start()
    {
        spawnOrb();
    }
    public void spawnOrb()
    { 
        for (int i = 0; i < 45; i++)
        {
            int posX = Random.Range(-36, 36);
            int posY = Random.Range(-18, 18);
            MyVector2 orb_Pos = new MyVector2(posX, posY);
            int s = Random.Range(1, 75);
            if (s < 10)
            {
                Object.Instantiate(powerOrb).transform.position = orb_Pos.ToUnityVector();
            }
            else
            {
                Object.Instantiate(orbPrefab).transform.position = orb_Pos.ToUnityVector();
            }
            
        }
    }
}
