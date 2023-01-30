using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class Turret : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    [SerializeField] private Canvas WeaponSelectionMenu;
    [SerializeField] private IdDetector TurretDetection;

    [SerializeField] private Transform RotatingParent;
    [SerializeField] private Transform StaticParent;
    
    [SerializeField] private GameObject BulletWeaponObject;
    //[SerializeField] private BulletWeapon BulletWeaponScript;
    [SerializeField] private GameObject LaserWeaponObject;
    [SerializeField] private LaserWeapon LaserWeaponScript;
    [SerializeField] private GameObject RocketWeaponObject;
    [SerializeField] private RocketWeapon RocketWeaponScript;
    
    [SerializeField] private GameObject FakeCrew;
    [SerializeField] private Transform CameraTarget;
    
    [SerializeField] private float RotationSpeed = 5f;
    [SerializeField] private float RotateDirection = .25f;
    
    private bool inMenu = false;
    private bool isActivated = false;
    private GameObject Activator = null;
    private WeaponType ActiveWeapon = WeaponType.None;

    public float ZRot;

    private enum WeaponType
    {
        None = 0,
        Bullet = 1,
        Laser = 2,
        Rocket = 3
    }

    private void FixedUpdate()
    {
        if (isActivated)
        {
            switch (ActiveWeapon)
            {
                case WeaponType.None:
                    break;
                case WeaponType.Bullet:
                    //HandleWeapon(BulletWeaponObject, BulletWeaponScript);
                    break;
                case WeaponType.Laser:
                    HandleWeapon(LaserWeaponObject, LaserWeaponScript);
                    break;
                case WeaponType.Rocket:
                    HandleWeapon(RocketWeaponObject, RocketWeaponScript);
                    break;
            }
        }
    }

    private void HandleWeapon(GameObject obj, Weapon weapon)
    {
        if (TurretDetection.DetectedObjects.Count > 0)
        {
            GameObject closestTarget = Proximity.NearestGameObject(
                gameObject, TurretDetection.DetectedObjects);

            RotatingParent.rotation = Orientation.QuarternionFromAToB(
                RotatingParent, closestTarget.transform.position, RotationSpeed);

            if (ActiveWeapon == WeaponType.Laser)
            {
                weapon.TryFire(RotatingParent.position + RotatingParent.up * 100);
            }
            else
            {
                weapon.TryFire(Orientation.DirectionToVector(RotatingParent.position, RotatingParent.up * 100));
                //weapon.TryFire(Proximity.DirectionToObject(RotatingParent.gameObject, closestTarget));
            }
        }

        else
        {
            if (ActiveWeapon == WeaponType.Laser)
            {
                LaserWeaponScript.DeactivateLaser();
            }
        }
    }

    public void OnInteract()
    {
        RotatingParent.rotation = StaticParent.rotation;
        Activator = interactable.ActiveInteractors.Last();
        SetCrewMovement(Activator, false);
        
        Activator.GetComponent<CrewControl>().sprite.enabled = false;
        FakeCrew.SetActive(true);
        
        EnableCameraTarget();
        OpenMenu();
    }

    public void OnCancel()
    {
        RotatingParent.rotation = StaticParent.rotation;
        Activator.GetComponent<CrewControl>().sprite.enabled = true;
        FakeCrew.SetActive(false);
        
        SetCrewMovement(Activator, true);
        DisableCameraTarget();
        CloseMenu();
        
        DeactivateWeapons();
        isActivated = false;
        ActiveWeapon = WeaponType.None;
    }

    public void ActivateWeapon(int weapon)
    {
        DeactivateWeapons();
        switch (weapon)
        {
            case 0:
                isActivated = false;
                ActiveWeapon = WeaponType.None;
                break;
            case 1:
                isActivated = true;
                ActiveWeapon = WeaponType.Bullet;
                BulletWeaponObject.SetActive(true);
                break;
            case 2:
                isActivated = true;
                ActiveWeapon = WeaponType.Laser;
                LaserWeaponObject.SetActive(true);
                break;
            case 3:
                isActivated = true;
                ActiveWeapon = WeaponType.Rocket;
                RocketWeaponObject.SetActive(true);
                break;
        }
        CloseMenu();
    }

    private void DeactivateWeapons()
    {
        BulletWeaponObject.SetActive(false);
        LaserWeaponObject.SetActive(false);
        RocketWeaponObject.SetActive(false);
    }
    
    private void OpenMenu()
    {
        WeaponSelectionMenu.gameObject.SetActive(true);
        GameManager.Player.CanToggle = false;
    }

    private void CloseMenu()
    {
        WeaponSelectionMenu.gameObject.SetActive(false);
        GameManager.Player.CanToggle = true;
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
