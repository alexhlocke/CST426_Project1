using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildingManager : MonoBehaviour 
{
	public GameObject[] objects;
	public GameObject pendingObject;
	private Vector3 position;
	public float rotateAmount;

	private RaycastHit hit;
	[SerializeField] private LayerMask layerMask;

	public float gridSize;
	private bool gridIsOn = false;
	[SerializeField] private Toggle gridToggle;

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
	    pendingObject = Instantiate(objects[index], position, transform.rotation);
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