using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARSubsystems;

public class SceneActivator : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private string Sign; // The name of your target image
    [SerializeField] private string Bask; // The name of your target image
    public string SignGame; // The name of the scene to activate
    public string BakGaame;
    private void Awake()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDestroy()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            CheckImageAndActivateScene(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                CheckImageAndActivateScene(trackedImage);
            }
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            // Image tracking was lost
        }
    }

    private void CheckImageAndActivateScene(ARTrackedImage trackedImage)
    {
        if (trackedImage.referenceImage.name == Sign && Sign == "Image1")
        {
            ActivateSignGame(); // Call a method to activate your game scene
        }
        else if (trackedImage.referenceImage.name == Bask && Bask == "Image2")
        {
            ActivateBaskGame();
        }
    }

    private void ActivateSignGame()
    {
        LoadScene(2);
    }

    private void ActivateBaskGame()
    {
        LoadScene(3);
    }

    private void LoadScene(int sceneIndex)
    {
        // Load the new scene
        SceneManager.LoadScene(sceneIndex);
    }
}
