using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using TMPro;
using MoreMountains.Feedbacks;

public class Analize : MonoBehaviour
{
    //vigenete effect fedback
    [SerializeField] MMF_Player mPlayer;

    //Mechanic area
    [SerializeField] public CinemachineVirtualCamera analizeCam;
    [SerializeField] public CinemachineFreeLook gameCam;
    private Camera mainCam;
    CinemachineComponentBase componentBase;
    float cameraDistance;
    [SerializeField] float sensitivity;
    public GameObject objectToRotate, pivot, canvas;
    private GameObject placeholder;

    public float rotationSpeed;
    public bool isAnalizing;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interaction;

    CharacterMechanics characterMechanics;
    MovementController controller;

    //TMP area
    public GameObject textContainer;
    public TMP_Text allanText;

    private void Awake()
    {
        mainCam = FindObjectOfType<Camera>();

        analizeCam.gameObject.SetActive(false);
        playerActionsAssets = new ThirdPersonActionsAssets();
        characterMechanics = GetComponentInParent<CharacterMechanics>();
        controller = GetComponentInParent<MovementController>();

        placeholder = new GameObject();
    }
    private void Start()
    {
        OnDisable();
    }

    private void OnEnable()
    {
        interaction = playerActionsAssets.Player.Interact;
        playerActionsAssets.Analize.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Analize.Disable();
    }

    private void Update()
    {
        if (componentBase == null)
        {
            componentBase = analizeCam.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if (playerActionsAssets.Analize.Zoom.ReadValue<float>() != 0 && isAnalizing)
        {
            Zoom();
        }

        if (playerActionsAssets.Analize.Rotate.IsPressed() && isAnalizing)
        {
            Rotate();
        }

        if (playerActionsAssets.Analize.ClickObjects.WasPressedThisFrame() && isAnalizing)
        {
            Click();
        }

    }

    public void GoToAnalize(GameObject target)
    {
        OnEnable();

        if(mPlayer != null)
        {
            mPlayer.PlayFeedbacks();
        }

        placeholder = Instantiate(target, pivot.transform.position, Quaternion.identity);
        objectToRotate = placeholder;

        gameCam.gameObject.SetActive(false);
        analizeCam.gameObject.SetActive(true);

        canvas.SetActive(true);

        characterMechanics.OnDisable();
        controller.OnDisable();

        isAnalizing = true;
    }

    public void BackToGame()
    {
        objectToRotate = null;
        Object.Destroy(placeholder);

        analizeCam.gameObject.SetActive(false);
        gameCam.gameObject.SetActive(true);

        
        characterMechanics.OnEnable();
        controller.OnEnable();

        isAnalizing = false;
        characterMechanics.analizable = false;

        OnDisable();
    }

    public void Zoom()
    {
        cameraDistance = playerActionsAssets.Analize.Zoom.ReadValue<float>() * sensitivity;

        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
        }

        if((componentBase as CinemachineFramingTransposer).m_CameraDistance > 8)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = 7.8f;
        }
        else if((componentBase as CinemachineFramingTransposer).m_CameraDistance < 3)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = 3.2f;
        }
    }

    public void Rotate()
    {
        Vector2 rotationAngle = playerActionsAssets.Analize.DeltaMouse.ReadValue<Vector2>() * rotationSpeed;

        Vector3 globalRightIntoLocalSpace = transform.InverseTransformDirection(Vector3.forward);
        Vector3 globalUpIntoLocalSpace = transform.InverseTransformDirection(Vector3.up);

        Quaternion pitchRotation = Quaternion.AngleAxis(rotationAngle.y, globalRightIntoLocalSpace);
        Quaternion yawRotation = Quaternion.AngleAxis(rotationAngle.x, globalUpIntoLocalSpace);

        pitchRotation.z = 0;
        yawRotation.z = 0;

        objectToRotate.transform.localRotation *= pitchRotation * yawRotation;
    }

    public void Click()
    {
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(playerActionsAssets.Analize.DeltaMouse.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.CompareTag("Clickable"))
                {
                    Debug.Log("Pista encontrada");
                }
            }
        }
    }

    public IEnumerator AllanBothering()
    {
        var count = 0;

        while(count < 3)
        {
            var randomOption = Random.Range(1, 3);

            if (randomOption == 1)
            {
                yield return new WaitForSeconds(5f);

                textContainer.SetActive(true);
                allanText.text = "Deberiamos movernos";

                yield return new WaitForSeconds(1.5f);

                textContainer.SetActive(false);

            }
            else if (randomOption == 2)
            {
                yield return new WaitForSeconds(8f);

                textContainer.SetActive(true);
                allanText.text = "Oye, vas a tardar tanto?";

                yield return new WaitForSeconds(1.5f);

                textContainer.SetActive(false);
            }
            else if (randomOption == 3)
            {
                yield return new WaitForSeconds(12f);

                textContainer.SetActive(true);
                allanText.text = "Que ciego eres";

                yield return new WaitForSeconds(1.5f);

                textContainer.SetActive(false);
            }

            count++;
        }

        count = 0;
    }
}
