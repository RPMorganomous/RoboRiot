using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // make this a singleton
    public static GameManager instance;
    
    //[SerializeField] public GameObject robotPrefab;
    [SerializeField] public GameObject robotPrefab;
    
    
    // make this singleton static
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if S is pressed, call SpawnManager's Spawn method
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnManager.Instance.spawnRobot(robotPrefab);
        }
    }
}
