using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    public TurrentBlueprint standardTurrent;
    public TurrentBlueprint rocketTurrent;
    public TurrentBlueprint MirrorTurrent;

    

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
    public void PurchaseMirrorTurrent()
    {
        buildManager.SelectTurrentBuild(MirrorTurrent);
        buildManager.afterBuild = false;
    }
}
