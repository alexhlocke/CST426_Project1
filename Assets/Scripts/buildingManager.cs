using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buildingManager : MonoBehaviour 
{
    public GameObject StateManagerObject;
    private StateManager stateManager;

    public GameObject[] objects;
	public GameObject pendingObject;
	private Vector3 position;
	public float rotateAmount;

	public int money = 100;
	
	private TextMeshProUGUI moneyText;
	
	public GameObject cost;

	private RaycastHit hit;
	[SerializeField] private LayerMask layerMask;

	public float gridSize;
	private bool gridIsOn = true;
	[SerializeField] private Toggle gridToggle;

	void Awake()
	{
		moneyText = cost.GetComponent<TextMeshProUGUI>();
        stateManager = StateManagerObject.GetComponent<StateManager>();

		moneyText.text = money.ToString();
    }

	// Update is called once per frame
    void Update()
    {
	    if (pendingObject != null)
	    {
		    if (gridIsOn)
		    {
			    pendingObject.transform.position = new Vector3(
				    RoundToNearestGrid(position.x),
				    RoundToNearestGrid(position.y),
				    RoundToNearestGrid(position.z)
			    );
		    }
		    else
		    {
			    pendingObject.transform.position = position;
		    }

		    if (Input.GetMouseButtonDown(0))
		    {
				    PlaceObject();
		    }

		    if (Input.GetKeyDown(KeyCode.R))
		    {
			    RotateObject();
		    }
	    }

		/*if (stateManager.currentGameState == StateManager.GameState.Placing)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Check if we hit an object
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;

                    // Check if the hit object has the "troop" tag
                    if (hitObject.CompareTag("troop"))
                    {
                        // Disable the object
                        hitObject.SetActive(false);
                        Debug.Log("Clicked");
                    }
                }
            }
        }*/
    }

    public void PlaceObject()
    {
	    pendingObject = null;
    }

    public void RotateObject()
    {
	    pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    void FixedUpdate()
    {
	    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	    if (Physics.Raycast(ray, out hit, 1000, layerMask))
	    {
		    position = hit.point;
	    }
    }

    public void SelectObecjt(int index)
    {
	    if (money > 0)
	    {
		    if (index == 0 && money >= 20)
		    {
			    money -= 20;
			    pendingObject = Instantiate(objects[index], position, transform.rotation);
			    moneyText.text = money.ToString();
		    }
		    if (index == 1 && money >= 40)
		    {
			    money -= 40;
			    pendingObject = Instantiate(objects[index], position, transform.rotation);
			    moneyText.text = money.ToString();
		    }
			if (index == 2 && money >= 30)
		    {
			    money -= 30;
			    pendingObject = Instantiate(objects[index], position, transform.rotation);
			    moneyText.text = money.ToString();
		    }
			if (index == 3)
		    {
			    pendingObject = Instantiate(objects[index], position, transform.rotation);
			    moneyText.text = money.ToString();
		    }
	    }
	    else
	    {
		    Debug.Log("Broke ass motherfucker!");
	    }
    }

    public void ToggleGrid()
    {
	    if (gridToggle.isOn)
	    {
		    gridIsOn = true;
	    }
	    else
	    {
		    gridIsOn = false;
	    }
    }

    float RoundToNearestGrid(float pos)
    {
	    float xDifferent = pos % gridSize;
	    pos -= xDifferent;

	    if (xDifferent > (gridSize / 2))
	    {
		    pos += gridSize;
	    }

	    return pos;
    }
}
