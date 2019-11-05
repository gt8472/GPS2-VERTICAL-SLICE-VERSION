using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    public TurrentBlueprint standardTurrent;
    public TurrentBlueprint rocketTurrent;

    

    private void Start()
    {
        buildManager = BuildManager.instance;

        
    }

    public void SelectArrowTurrent()
    {
        //Debug.Log("Purchase Arrow Turrent");

        // build tower (after click build)
            buildManager.SelectTurrentBuild(standardTurrent);
        buildManager.afterBuild = false;
        
    }
       
        
    public void PurchaseRocketTurrent()
    {
        buildManager.SelectTurrentBuild(rocketTurrent);
        buildManager.afterBuild = false;
    }
}
