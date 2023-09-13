using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeManager : MonoBehaviour
{
    public static placeManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one placeManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTroopPrefab;

    private void Start()
    {
        troopToPlace = standardTroopPrefab;
    }

    private GameObject troopToPlace;

    public GameObject GetTroopToPlace()
    {
        return troopToPlace;
    }
}
