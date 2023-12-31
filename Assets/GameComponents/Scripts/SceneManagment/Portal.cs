using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using RPG.Core;
using RPG.Control;

namespace RPG.SceneManagment
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] int sceneIndex = -1;
        [SerializeField] Transform portalSpawnPoint;
        [Range(0, 6)] [SerializeField] float fadeOutTime = 3f;
        [Range(0, 6)] [SerializeField] float fadeInTime = 3f;
        [Range(0, 2)] [SerializeField] float timeToWaitInbetweenScenes = 0f;

        enum portalDestinations
        {
            A, B, C, D
        }

        [SerializeField] portalDestinations portalIdentifier;
        [SerializeField] portalDestinations thisPortal;

        private void Start()
        {
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(PortalLoadWait());
            }
        }

        private IEnumerator PortalLoadWait()
        {
            RemovePlayerControl();
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeOutTime);
            DontDestroyOnLoad(gameObject);
<<<<<<< HEAD
<<<<<<< HEAD
            savingWrapper.Save();
=======
            SavableWrapping saver = FindObjectOfType<SavableWrapping>();
            saver.ResaveSaveFile();
            ReturnPlayerControl();
>>>>>>> parent of 4b410f5 (Final Save System.)
=======
>>>>>>> parent of 38ab555 (Changes)
            yield return SceneManager.LoadSceneAsync(sceneIndex);
            Portal NextPortal = GetPortal();
            UpdatePlayerPosition(NextPortal);
<<<<<<< HEAD
<<<<<<< HEAD
            savingWrapper.Save();
=======
>>>>>>> parent of 4b410f5 (Final Save System.)
=======
>>>>>>> parent of 38ab555 (Changes)
            yield return new WaitForSeconds(timeToWaitInbetweenScenes);
            yield return fader.FadeIn(fadeOutTime);
            Destroy(gameObject);
        }
        private void RemovePlayerControl()
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<ActionSchedular>().CancelCurrentAction();
            player.GetComponent<MovementController>().enabled = false;
        }
        private void ReturnPlayerControl()
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<MovementController>().enabled = true;
        }

        private void UpdatePlayerPosition(Portal nextPortal)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<NavMeshAgent>().Warp(nextPortal.portalSpawnPoint.transform.position);
        }

        private Portal GetPortal()
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal.thisPortal == portalIdentifier) return portal;
            }
            return null;
        }
    }
}
