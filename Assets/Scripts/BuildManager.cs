using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    
    public GameObject buildEffect;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one build manager");
            return;
        }
        instance = this;
    }
    
    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }
    public bool HasMoney
    {
        get { return PlayerStats.Money >= turretToBuild.cost; }
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret; 
        Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
