using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<UIFillUpdate> uIGunUpdates;

    public List<GunBase> guns;
    public Transform gunPosition;

    private GunBase _currentGun;
    protected override void Init()
    {
        base.Init();
        CreateGun();

        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
    }

    private void CreateGun(int gunChoice = 0)
    {
        _currentGun = Instantiate(guns[gunChoice], gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.eulerAngles = Vector3.zero;
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
    }
    private void CancelShoot()
    {
        _currentGun.StopShoot();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CreateGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CreateGun(1);
        }
    }
}
