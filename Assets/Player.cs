using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Com.LuisPedroFonseca.ProCamera2D;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler input;

    public Camera camera;
    public ProCamera2D proCamera;

    public float CrewZoom = 6;
    public float DroneZoom = 15;
    public float TargetZoom = 5f;
    private float ZoomSpeed = 5f;

    private int AvailableCount = 0;
    [SerializeField] private int MaxPlayables = 10;
    
    public GameObject ActivePlayable = null;
    private GameObject[] AvailablePlayables = 
        {null, null, null, null, null, null, null, null, null, null};

    [SerializeField] private List<GameObject> InitialPlayables = new List<GameObject>();

    public bool CanToggle = true;

    private void Start()
    {
        foreach (GameObject playable in InitialPlayables)
        {
            if (hasEmptyPlayables())
            {
                AddPlayable(playable);
            }
        }
        SetActivePlayer(0);
    }

    private void Update()
    {
        input.Handle();
        HandleZoom();
    }

    private void HandleZoom()
    {
        if (Mathf.Abs(camera.orthographicSize - TargetZoom) < .5f)
        {
            camera.orthographicSize = TargetZoom;
        }
        else if (camera.orthographicSize > TargetZoom)
        {
            camera.orthographicSize -= ZoomSpeed * Time.deltaTime;
        }
        else if (camera.orthographicSize < TargetZoom)
        {
            camera.orthographicSize += ZoomSpeed * Time.deltaTime;
        }
    }

    public bool hasEmptyPlayables()
    {
        int playablesCount = 0;
        for (int i = 0; i < AvailablePlayables.Length; i++)
        {
            if (AvailablePlayables[i] != null)
            {
                playablesCount++;
            }
        }
        // If number of filled slots is less than max slots
        return playablesCount < MaxPlayables;
    }

    public int FirstAvailableIndex()
    {
        for (int i = 0; i < AvailablePlayables.Length; i++)
        {
            if (AvailablePlayables[i] == null)
            {
                return i;
            }
        }
        Debug.Log("Could not find first available index");
        return -1;
    }
    
    public void AddPlayable(GameObject newPlayable)
    {
        if (newPlayable.GetComponent<InputHandler>() == null)
        {
            Debug.Log("InputHandler could not be found on: " + newPlayable.name);
            return;
        }
        for (int i = 0; i < AvailablePlayables.Length; i++)
        {
            if (AvailablePlayables[i] == null)
            {
                newPlayable.name = newPlayable.GetComponent<InputHandler>().Name + ":" + i;
                newPlayable.transform.SetParent(transform);
                AvailablePlayables[i] = newPlayable;
                break;
            }
        }
    }

    public void RemovePlayable(GameObject playable)
    {
        if (!AvailablePlayables.Contains(playable))
        {
            Debug.Log("AvailablePlayables does not contain: " + playable.name);
            return;
        }
        if (ActivePlayable == playable)
        {
            NextPlayable();
            if (ActivePlayable == playable)
            {
                Debug.Log("Last playable is about to be destroyed");
                Debug.Log("Canceling RemovePlayable on: " + playable.name);
                return;
            }
        }
        if (AvailablePlayables.Contains(playable))
        {
            int index = Array.IndexOf(AvailablePlayables, playable);
            AvailablePlayables[index] = null;
        }
    }

    private void SetActivePlayer(int index)
    {
        DisableAllInputs();
        ActivePlayable = AvailablePlayables[index];
        ActivePlayable.GetComponent<InputHandler>().enabled = true;
        ActivePlayable.name += "[Active]";
        
        proCamera.RemoveAllCameraTargets();
        proCamera.AddCameraTarget(ActivePlayable.transform);

        Identity identity = ActivePlayable.GetComponent<Identity>();
        if (identity.TagsKnownAs.Contains(Identification.Tags.Crew))
        {
            TargetZoom = CrewZoom;
        }
        if (identity.TagsKnownAs.Contains(Identification.Tags.Drone))
        {
            TargetZoom = DroneZoom;
        }
        //Debug.Log("ActivePlayer has been set to: " + ActivePlayable.name);
    }

    private void DisableAllInputs()
    {
        for (int i = 0; i < AvailablePlayables.Length; i++)
        {
            if (AvailablePlayables[i] != null &&
                AvailablePlayables[i].TryGetComponent(out InputHandler input))
            {
                AvailablePlayables[i].name = 
                    AvailablePlayables[i].name.Replace("[Active]", "");
                input.enabled = false;
            }
        }
    }

    public void NextPlayable()
    {
        int startingIndex = Array.IndexOf(AvailablePlayables, ActivePlayable);
        for (int i = 0; i < AvailablePlayables.Length; i++)
        {
            int indexToCheck = startingIndex + i + 1;
            if (indexToCheck >= AvailablePlayables.Length)
            {
                indexToCheck -= AvailablePlayables.Length;
            }
            if (AvailablePlayables[indexToCheck] != null)
            {
                SetActivePlayer(indexToCheck);
                return;
            }
        }
        Debug.Log("Failed to go to NextPlayable");
    }

    public void LastPlayable()
    {
        int startingIndex = Array.IndexOf(AvailablePlayables, ActivePlayable);
        for (int i = 0; i < AvailablePlayables.Length; i++)
        {
            int indexToCheck = startingIndex - i - 1;
            if (indexToCheck < 0)
            {
                indexToCheck += AvailablePlayables.Length;
            }
            if (AvailablePlayables[indexToCheck] != null)
            {
                SetActivePlayer(indexToCheck);
                return;
            }
        }
        Debug.Log("Failed to go to LastPlayable");
    }

    public void GoToPlayableIndex(int index)
    {
        if (index < AvailablePlayables.Length && 
            AvailablePlayables[index] != null)
        {
            SetActivePlayer(index);
            return;
        }
        Debug.Log("Could not SetActivePlayableIndex to: " + index);
    }

    public void ReplaceOldWithNew(GameObject oldPlayable, GameObject newPlayable)
    {
        if (AvailablePlayables.Contains(oldPlayable))
        {
            int index = Array.IndexOf(AvailablePlayables, oldPlayable);
            if (newPlayable.TryGetComponent(out InputHandler inputHandler))
            {
                Destroy(oldPlayable);
                newPlayable.name = inputHandler.Name + ":" + index;
                newPlayable.transform.SetParent(transform);
                AvailablePlayables[index] = newPlayable;
                SetActivePlayer(index);
                return;
            }
        }
        Debug.Log("Replacement Failed");
    }
}
