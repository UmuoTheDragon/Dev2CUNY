using UnityEngine;
using UnityEngine.InputSystem;

public class CoinScript : MonoBehaviour
{
    public CoinScript CoinPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void GetBumped()
    {
        Destroy(gameObject);
    }
}
