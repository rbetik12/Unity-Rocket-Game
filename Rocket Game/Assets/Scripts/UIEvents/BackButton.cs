using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    public void OnClick(){
        levelLoader.LoadGameScene(0);
    }
}
