using System.Collections.Generic;
using UnityEngine;


namespace Unity.FPS.ObjectPool
{
    public enum WeaponType
    {
        Blaster,
        Disk,
        Hoverbot,
        Shotgun,
        Turret,
    }

    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool SharedInstance;

        // Lists for all the projectile lists.
        public List<GameObject> pooledBlasterProjectileObjects;
        public List<GameObject> pooledDiskProjectileObjects;
        public List<GameObject> pooledHoverbotProjectileObjects;
        public List<GameObject> pooledShotgunProjectileObjects;
        public List<GameObject> pooledTurretProjectileObjects;

        public GameObject blasterObject;
        public GameObject diskObject;
        public GameObject hoverbotObject;
        public GameObject shotgunObject;
        public GameObject turretObject;

        // Initialize same amount for each pool.
        public int amountToPool;

        private void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            pooledBlasterProjectileObjects = new List<GameObject>();
            pooledDiskProjectileObjects = new List<GameObject>();
            pooledHoverbotProjectileObjects = new List<GameObject>();
            pooledShotgunProjectileObjects = new List<GameObject>();
            pooledTurretProjectileObjects = new List<GameObject>();

            GameObject blasterTmp;
            GameObject diskTmp;
            GameObject hoverbotTmp;
            GameObject shotgunTmp;
            GameObject turretTmp;

            for (int i = 0; i < amountToPool; i++)
            {
                blasterTmp = Instantiate(blasterObject);
                diskTmp = Instantiate(diskObject);
                hoverbotTmp = Instantiate(hoverbotObject);
                shotgunTmp = Instantiate(shotgunObject);
                turretTmp = Instantiate(turretObject);

                blasterTmp.SetActive(false);
                diskTmp.SetActive(false);
                hoverbotTmp.SetActive(false);
                shotgunTmp.SetActive(false);
                turretTmp.SetActive(false);

                pooledBlasterProjectileObjects.Add(blasterTmp);
                pooledDiskProjectileObjects.Add(diskTmp);
                pooledHoverbotProjectileObjects.Add(hoverbotTmp);
                pooledShotgunProjectileObjects.Add(shotgunTmp);
                pooledTurretProjectileObjects.Add(turretTmp);
            }
        }
        public GameObject GetPooledObject(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.Blaster:
                    {
                        for (int i = 0; i < amountToPool; i++)
                        {
                            if (!pooledBlasterProjectileObjects[i].activeInHierarchy)
                            {
                                return pooledBlasterProjectileObjects[i];
                            }
                        }
                        break;
                    }
                case WeaponType.Disk:
                    {
                        for (int i = 0; i < amountToPool; i++)
                        {
                            if (!pooledDiskProjectileObjects[i].activeInHierarchy)
                            {
                                return pooledDiskProjectileObjects[i];
                            }
                        }
                        break;
                    }
                case WeaponType.Hoverbot:
                    {
                        for (int i = 0; i < amountToPool; i++)
                        {
                            if (!pooledHoverbotProjectileObjects[i].activeInHierarchy)
                            {
                                return pooledHoverbotProjectileObjects[i];
                            }
                        }
                        break;
                    }
                case WeaponType.Shotgun:
                    {
                        for (int i = 0; i < amountToPool; i++)
                        {
                            if (!pooledShotgunProjectileObjects[i].activeInHierarchy)
                            {
                                return pooledShotgunProjectileObjects[i];
                            }
                        }
                        break;
                    }
                case WeaponType.Turret:
                    {
                        for (int i = 0; i < amountToPool; i++)
                        {
                            if (!pooledTurretProjectileObjects[i].activeInHierarchy)
                            {
                                return pooledTurretProjectileObjects[i];
                            }
                        }
                        break;
                    }
                default: break;
            }
            return null;
        }
    }
}