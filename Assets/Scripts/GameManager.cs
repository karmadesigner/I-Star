using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{

    static GameManager instance;

    [SerializeField]
    private CelestialSystem celestialSystem;
    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private CinemachineVirtualCamera myCamera;

    private int cameraPointer;
    private float elapsedTime;
    private float startTime;
    private bool paused;

    private void Awake()
    {
        
        // If the instance reference has not been set, yet, 
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);

        cameraPointer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        paused = true;
        Time.timeScale = 0;
        elapsedTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            elapsedTime += Time.deltaTime;
            timer.GetComponent<TextMeshProUGUI>().SetText("Elapsed Time: " +  ((int)elapsedTime).ToString() + " years.");
        }
    }

   public void Pause()
    {
        if(!paused)
        {
            paused = true;
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
        }       
    }

    public void Spawn(int numberOfObjects)
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            CelestialObject newStar = Instantiate<CelestialObject>(celestialSystem.baseCelestialObject, celestialSystem.transform);

            celestialSystem.AddObject( newStar );
        }
    }

    public void Next()
    {
        if(cameraPointer + 1 == celestialSystem.system.Count)
        {
            cameraPointer = 0;
        }  
        else
        {
            cameraPointer += 1;
        }
        myCamera.Follow = celestialSystem.system[cameraPointer].transform;
    }

    public void Previous()
    {
        if (cameraPointer - 1 < 0)
        {
            cameraPointer = 0;
        }
        else
        {
            cameraPointer -= 1;
        }
        myCamera.Follow = celestialSystem.system[cameraPointer].transform;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
