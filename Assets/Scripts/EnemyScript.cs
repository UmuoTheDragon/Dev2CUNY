using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public float Speed = 0.5f;
    public float Timer = 10;
    public EnemyScript EnemyPrefab;
    public GameObject Player;
    public bool shouldFollow = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("StartFollowing", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            shouldFollow = true;
        }
            //Following Player.1
            //transform.position = Vector3.MoveTowards(transform.position, MirrPlayer.transform.position, Time.deltaTime * 3);

            //Following Player.2
            if (shouldFollow)
        {
            Vector2 vel = new Vector2(0, 0);
            vel = (Vector2)(Player.transform.position - transform.position);
            vel = vel.normalized * 3;
            RB.linearVelocity = vel;
        }
    }
}
