using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class Turret : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    
    [SerializeField] private IdDetector TurretDetection;
    [SerializeField] private ShotWeapon TurretWeapon;

    [SerializeField] private Transform RotatingParent;
    [SerializeField] private Transform StaticParent;

    [SerializeField] private GameObject FakeCrew;
    [SerializeField] private Transform CameraTarget;
    
    [SerializeField] private float RotationSpeed = 5f;
    [SerializeField] private float RotateDirection = .25f;
    
    private bool inMenu = false;
    private bool isActivated = false;
    private GameObject Activator = null;

    public float ZRot;

    private void Start()
    {
        RotatingParent.rotation = StaticParent.rotation;
    }
    
    
    private void FixedUpdate()
    {
        if (isActivated)
        {
            if (Activator == GameManager.Player.ActivePlayable)
            {
                //Vector3 rotation = Activator.GetComponent<CrewControl>().
            }
            HandleWeapon();
        }
    }

    private void HandleWeapon()
    {
        if (TurretDetection.DetectedObjects.Count > 0)
        {
            GameObject closestTarget = Proximity.NearestGameObject(
                gameObject, TurretDetection.DetectedObjects);
            RotatingParent.rotation = Orientation.QuarternionFromAToB(
                RotatingParent, closestTarget.transform.position, RotationSpeed);

            TurretWeapon.TryFire();
        }
    }

    private void ChangeColor()
    {
        FakeCrew.GetComponent<SpriteRenderer>().color = 
            Activator.GetComponent<CrewControl>().CrewColor;
    }

    public void OnInteract()
    {
        RotatingParent.rotation = StaticParent.rotation;
        Activator = interactable.ActiveInteractors.Last();
        SetCrewMovement(Activator, false);
        
        Activator.GetComponent<CrewControl>().sprite.enabled = false;
        TurretWeapon.gameObject.SetActive(true);
        FakeCrew.SetActive(true);
        
        EnableCameraTarget();
        ChangeColor();
    }

    public void OnCancel()
    {
        RotatingParent.rotation = StaticParent.rotation;
        Activator.GetComponent<CrewControl>().sprite.enabled = true;
        TurretWeapon.gameObject.SetActive(false);
        FakeCrew.SetActive(false);
        
        SetCrewMovement(Activator, true);
        DisableCameraTarget();
        isActivated = false;
    }

    private void EnableCameraTarget()
    {
        GameManager.Player.proCamera.AddCameraTarget(CameraTarget);
        GameManager.Player.TargetZoom = 10f;
    }

    private void DisableCameraTarget()
    {
        GameManager.Player.proCamera.RemoveCameraTarget(CameraTarget);
        GameManager.Player.TargetZoom = GameManager.Player.CrewZoom;
    }

    private void SetCrewMovement(GameObject crew, bool canMove)
    {
        crew.GetComponent<CrewMovement>().SetCanMove(canMove);
    }
}
