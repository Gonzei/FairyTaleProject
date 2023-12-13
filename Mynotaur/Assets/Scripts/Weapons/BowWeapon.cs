using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeapon : MonoBehaviour
{
    [SerializeField] private int reloadTime;
    [SerializeField] Arrow arrowPrefab;
    [SerializeField] private Transform spawnPoint;

    private Arrow currentArrow;

    private string enemyTag;

    private bool isReloading;

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Reload()
    {
        if(isReloading || currentArrow != null) 
        {
            return;
        }
        else
        {
            isReloading = true;
            StartCoroutine(ReloadAfterTime());
        }

    }

    public IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
        currentArrow.SetEnemyTag(enemyTag);
        isReloading = false;
    }

    public void Fire(float firepower)
    {
        if(isReloading || currentArrow == null)
        {
            return;
        }
        else
        {
            var force = spawnPoint.TransformDirection(Vector3.forward * firepower);
            currentArrow.Fly(force);
            currentArrow = null;
            Reload();
        }
    }

    public bool IsReady()
    {
        return (!isReloading && currentArrow != null);
    }
}
