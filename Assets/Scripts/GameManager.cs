using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    
    private void Awake()
    {
        //Singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        instance = this;
    }

    
    
}
