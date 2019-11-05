using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public bool afterBuild = false;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager");
        }
        instance = this;
    }

    public GameObject standardTurrentPrefab;
    public GameObject anotherTurrentPrefab;

    private TurrentBlueprint turrentToBuild;
    private MapCube selectedTurret;
    public SelectionUI selectionUI;

    public bool CanBuild { get { return turrentToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turrentToBuild.cost; } }

    public void BuildTurrentOn (MapCube mapCube)
    {
        
        if(afterBuild == false)
        {
            if(PlayerStats.Money < turrentToBuild.cost)
            {
                Debug.Log("No money");
                return;
            }

            PlayerStats.Money -= turrentToBuild.cost;

            GameObject turrent = (GameObject)Instantiate(turrentToBuild.prefab, mapCube.GetBuildPosition(), Quaternion.identity);
            mapCube.turrent = turrent;
        }
        afterBuild = true;
        
    }
    private void Start()
    {

    }

    public void SelectNode(MapCube node)
    {
        selectedTurret = node;
        turrentToBuild = null;

        selectionUI.SetTarget(node);
    }

    public void SelectTurrentBuild (TurrentBlueprint turrent)
    {
        turrentToBuild = turrent;
        selectedTurret = null;
    }
   
}
