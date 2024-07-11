using Cinemachine;
using PLAYERTWO.PlatformerProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControlHandler : MonoBehaviour
{

    public static MindControlHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("\n Player Data")]
    [SerializeField] GameObject player1;
    [SerializeField] CinemachineVirtualCamera player1Cam;


    [Header("\n Statue Data")]
    [SerializeField] GameObject player2;
    [SerializeField] CinemachineVirtualCamera player2Cam;
    [SerializeField] SkinnedMeshRenderer player2_SkinnedMeshRenderer;
    [SerializeField] Material player2_Material;
    [SerializeField] Material statueMaterial;
    [SerializeField] Animator statueAnimator;

    bool controlingMind = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToDisableEntityControllerOnGameStart());
    }

    IEnumerator waitToDisableEntityControllerOnGameStart()
    {
        yield return new WaitForSeconds(1f);
        player2.SetActive(true);

        controlingMind = false;
        player2.GetComponent<EntityController>().enabled = false;
        player1.GetComponent<EntityController>().enabled = true;

        statueAnimator.enabled = false;
        player2_SkinnedMeshRenderer.material = statueMaterial;
        CameraManager.SwitchCamera(player1Cam);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && controlingMind)
        {
            SwitchCharacter();
        }
    }

    public void SwitchCharacter()
    {
        if (controlingMind)
        {
            controlingMind = false;
            player2.GetComponent<EntityController>().enabled = false;
            player1.GetComponent<EntityController>().enabled = true;
            player2.GetComponent<Statue>().ActivateOrDeactivateObjectToTrigger(false);

            statueAnimator.enabled = false;
            player2_SkinnedMeshRenderer.material = statueMaterial;
            CameraManager.SwitchCamera(player1Cam);
        }
        else
        {
            controlingMind = true;
            player1.GetComponent<EntityController>().enabled = false;
            player2.GetComponent<EntityController>().enabled = true;
            player2.GetComponent<PlayerAnimator>().enabled = true;

            player2.GetComponent<Statue>().ActivateOrDeactivateObjectToTrigger(true);
            statueAnimator.enabled = true;
            player2_SkinnedMeshRenderer.material = player2_Material;
            CameraManager.SwitchCamera(player2Cam);
        }
    }
}
