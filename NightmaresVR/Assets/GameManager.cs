using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _Instance = null;
    public static GameManager Instance
    {
        get
        {
            if(_Instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _Instance;
        }
    }

    public Vector3 leftHandVelocity;
    public Vector3 rightHandVelocity;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _Instance = this;
    }
}
