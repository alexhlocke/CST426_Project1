using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementMenu : MonoBehaviour
{
    [Header("References")]
    public GameObject StateManagerObject;
    public GameObject MainCanvas;
    public GameObject PlacementCanvas;

    private StateManager stateManager;


    public void Awake() {
        stateManager = StateManagerObject.GetComponent<StateManager>();
    }

    public void StartFight() {
        // Find all GameObjects with the 'enemy' or 'troop' tag.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject[] troops = GameObject.FindGameObjectsWithTag("troop");

        // Combine the two arrays.
        GameObject[] allUnits = new GameObject[enemies.Length + troops.Length];
        enemies.CopyTo(allUnits, 0);
        troops.CopyTo(allUnits, enemies.Length);

        // Loop through each GameObject and set Movement component to active.
        foreach (GameObject unit in allUnits) {
            Movement movementComponent = unit.GetComponent<Movement>();
            // Catch oopsie woopsie fucky wuckies
            if (movementComponent != null) {
                movementComponent.enabled = true;
                movementComponent.FindEnemies(); // Reset enemy list
            }
            else {
                Debug.LogWarning("No 'Movement' component found on " + unit.name);
            }
        }

        // Change game state
        stateManager.SetGameState(StateManager.GameState.Playing);

        // Set canvases to active/inactive
        MainCanvas.SetActive(true);
        PlacementCanvas.SetActive(false);
    }
}