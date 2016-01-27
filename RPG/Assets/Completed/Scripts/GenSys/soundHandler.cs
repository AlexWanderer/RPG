using UnityEngine;
using System.Collections;

public class soundHandler: MonoBehaviour
{
    private static soundHandler _instance;

    public static soundHandler instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<soundHandler>();

                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //Create first instance.
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //Destroy any duplicates attempting to occur.
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }
}
