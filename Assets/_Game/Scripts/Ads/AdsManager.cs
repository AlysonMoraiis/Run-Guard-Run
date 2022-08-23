using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        string gameId = "";
#if UNITY_IOS
        gameId = "4735428";
#elif UNITY_ANDROID
        gameId = "4735429";
#endif

    }

    // Update is called once per frame
    void Update()
    {

    }
}
