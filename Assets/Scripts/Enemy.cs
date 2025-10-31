using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float travelTime = 0;
    private float timer = 0;
    [SerializeField] private Vector3 enemyDirection;
    [SerializeField] private float speed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        this.gameObject.transform.position += enemyDirection.normalized * speed * Time.deltaTime;
        
        if (timer >= travelTime)
        {
            
            enemyDirection *= -1;
            timer = 0;

        }
        
    }
    
}
