using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/* The idea behind this component is that it is used on the UI elements that represent each tower. When the player clicks and drags the tower,
 * this component will spawn the actual tower in the game world. I call the UI representations of each towers "icons". - Nicolas
 */

public class TowerIconBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    [Tooltip("Used to align the towers to a grid. Only effective when towers are placed down.")]
    private Grid alignmentGrid;
    [SerializeField]
    [Tooltip("The tower that this icon will spawn upon being placed down.")]
    private Towers towerPrefabToSpawn;

    private bool draggingTower = false;

    private Ray ray;
    private RaycastHit hit;



    public void OnPointerDown(PointerEventData eventData)
    {
        draggingTower = true;

    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (draggingTower)
        {
            
            Vector3 towerSpawnLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerSpawnLocation.z = 0;
            towerSpawnLocation = alignmentGrid.GetCellCenterWorld(alignmentGrid.WorldToCell(towerSpawnLocation));

            /* 
             * Try to compare the tag "TowerTile" to instantiate the tower.
             * but it didn't work.
             * 
             * 
            ray = Camera.main.ScreenPointToRay(towerSpawnLocation);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                
                if (hit.transform.CompareTag("TowerTile"))
                {
                    Instantiate(towerPrefabToSpawn, towerSpawnLocation, Quaternion.identity);
                }
            }*/

            Instantiate(towerPrefabToSpawn, towerSpawnLocation, Quaternion.identity);

            draggingTower = false;
        }
    }

}
