using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public List<UIFillUpdate> uIGunUpdates;

    public float maxShoot = 5f;
    public float timeToRecharge = 1f;

    private float _currentShots;
    private bool _recharging = false;

    private void Awake()
    {
        GetAllUIs();
    }
    protected override IEnumerator ShootCoroutine()
    {
        if (_recharging) yield break;
        while (true)
        {
            if (_currentShots < maxShoot)
            {
                Shoot();
                _currentShots++;
                CheckRecharge();
                UpdateUI();
                yield return new WaitForSeconds(timeBetweenShoot);
            }
        }
    }

    private void CheckRecharge()
    {
        if(_currentShots >= maxShoot)
        {
            StopShoot();
            StartRecharge();
        }
    }

    private void StartRecharge()
    {
        _recharging = true;
        StartCoroutine(RechargeCoroutine());
    }

    IEnumerator RechargeCoroutine()
    {
        float time = 0;
        while(time < timeToRecharge)
        {
            time += Time.deltaTime;
            uIGunUpdates.ForEach(i => i.UpdateValue(time/timeToRecharge));
            yield return new WaitForEndOfFrame();
        }
        _currentShots = 0;
        _recharging = false;
    }

    private void UpdateUI()
    {
        uIGunUpdates.ForEach(i => i.UpdateValue(maxShoot, _currentShots));
    }

    private void GetAllUIs()
    {
        uIGunUpdates = GameObject.FindObjectsOfType<UIFillUpdate>().ToList();
    }
}
