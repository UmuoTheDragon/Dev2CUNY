using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SceneManager.LoadScene ("Game Scene");
    }

    public Rigidbody2D RB;
    public Transform Transform;
    public TextMeshPro ScoreText;
    public TextMeshPro Dash;
    public CoinScript CoinPrefab;
    public BlueCoinScript BluePrefab;
    public EnemyScript EnemyPrefab;
    public float Speed = 5;
    public float DashTimer = 0;
    public float coinTimer = 3;
    public float blueTimer = 15;
    public int Score = 0;
    private Vector3 x;

    // Update is called once per frame
    void Update()
    {
        coinTimer -= Time.deltaTime;
        if (coinTimer <= 0)
        {
           coinTimer = 3;
           Instantiate(CoinPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f)), Quaternion.identity);
        }

        blueTimer -= Time.deltaTime;
        if (blueTimer <= 0)
        {
            blueTimer = 15;
            Instantiate(BluePrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f)), Quaternion.identity);
        }
        ////Invoke("SpawnCoin", 3);

        

        Vector2 vel = new Vector2(0, 0);
        if (Keyboard.current.dKey.isPressed)
        {
            vel.x = Speed;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            vel.x = -Speed;
        }
        if (Keyboard.current.wKey.isPressed)
        {
            vel.y = Speed;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            vel.y = -Speed;
        }
        RB.linearVelocity = vel;

        DashTimer -= Time.deltaTime;
        DashCooldown();
        if (DashTimer <= 4.5f)
        {
            Speed = 5;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
           if(DashTimer <= 0)
            {
                DashTimer = 5;
                Speed = 10;
            }
        }

    }

    public void UpdateScore()
    {
        ScoreText.text = "Points:" + Score;
    }

    public void DashCooldown()
    {
        Dash.text = "Dash" + DashTimer;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CoinScript coin = other.GetComponent<CoinScript>();
        if (coin != null)
        {
            coin.GetBumped();
            Score++;
            UpdateScore();
        }

        BlueCoinScript blueCoin = other.GetComponent<BlueCoinScript>();
        if (blueCoin != null)
        {
            blueCoin.GetBumped();
            Score+= 2;
            UpdateScore();
        }

        EnemyScript enemyScript = other.GetComponent<EnemyScript>();
        if (enemyScript!= null)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("Game Overs");
    }

}
