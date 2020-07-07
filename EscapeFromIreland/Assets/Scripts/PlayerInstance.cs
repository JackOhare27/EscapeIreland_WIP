using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    //USED FOR NAVMESH FOR AI AS NEEDS TO BE AN INSTANCE AND NOT OBJECT
    #region Singleton
    public static PlayerInstance instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject Player;
}
