using UnityEngine;

public class Orb_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;

    void Start()
    {
        spawnOrb();
    }
    public void spawnOrb()
    { 
        for (int i = 0; i < 10; i++)
        {
            float posX = Random.Range(-18, 8);
            float posY = Random.Range(-8, 7);
            MyVector2 orb_Pos = new MyVector2(posX, posY);
            Object.Instantiate(orbPrefab).transform.position = orb_Pos.ToUnityVector(); 
        }
    }
}
