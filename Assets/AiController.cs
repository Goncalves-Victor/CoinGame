using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject[] coins;
    public int aiScore = 0; 
    public AudioClip collectSound; 
    private AudioSource audioSource;
    public float soundVolume = 0.1f; 
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = soundVolume; 
        FindNewTarget();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            CollectCoin();
        }
    }

    void FindNewTarget()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        if (coins.Length > 0)
        {
            GameObject closestCoin = null;
            float closestDistance = Mathf.Infinity;
            
            foreach (GameObject coin in coins)
            {
                if (coin != null) 
                {
                    float distance = Vector3.Distance(transform.position, coin.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestCoin = coin;
                    }
                }
            }
            
            if (closestCoin != null)
            {
                agent.SetDestination(closestCoin.transform.position);
            }
            else
            {
                StopAI(); 
            }
        }
        else
        {
            StopAI();
        }
    }

    void CollectCoin()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin"); 
        if (coins.Length > 0)
        {
            foreach (GameObject coin in coins)
            {
                if (coin != null && Vector3.Distance(transform.position, coin.transform.position) < 1f)
                {
                    if (collectSound != null)
                    {
                        audioSource.PlayOneShot(collectSound, soundVolume);
                    }
                    Destroy(coin);
                    aiScore++;
                    FindNewTarget(); 
                    return;
                }
            }
        }
        FindNewTarget(); 
    }

    void StopAI()
    {
        agent.ResetPath(); 
    }
}
