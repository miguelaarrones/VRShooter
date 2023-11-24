using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] private float recoilForce;
    [SerializeField] private float weaponDamage;

    private Rigidbody rb;
    private XRGrabInteractable interactableWeapon;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        interactableWeapon = GetComponent<XRGrabInteractable>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.activated.AddListener(StartShooting);
        interactableWeapon.deactivated.AddListener(StopShooting);
    }

    protected virtual void StartShooting(ActivateEventArgs args)
    {
        Debug.LogWarning("StartShooting not implemented");
        return;
    }

    protected virtual void StopShooting(DeactivateEventArgs args)
    {
        Debug.LogWarning("StopShooting not implemented");
        return;
    }

    protected virtual void Shoot()
    {
        ApplYRecoil();
    }

    private void ApplYRecoil()
    {
        rb.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce() => shootingForce;

    public float GetDamage() => weaponDamage;
}
