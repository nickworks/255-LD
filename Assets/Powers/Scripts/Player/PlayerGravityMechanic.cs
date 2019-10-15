using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityMechanic : MonoBehaviour
{
    [Header("Essential Information")]
    public GameObject scene;
    public GameObject player;
    public GameObject camPivot;
    public float camFlipSpeed = 0.1f;
    public int antigravWaitTime = 10;

    [Header("Effect Objects")]
    public ParticleSystem antigravParticleSystem;
    public Material antigravParticleMaterial;
    public Material antigravFogMaterial;
    public float fogSpeed = 0.2f;
    public float particleSpeed = 0.2f;

    public bool antigravGloveObtained = false;
    public bool antigravGloveUseAllowed = false;

    [HideInInspector]
    public bool antigrav = false;
    [HideInInspector]
    public bool gravButtonDown = false;
    [HideInInspector]
    public bool gravButtonDownPrev = false;

    private float camPosition = 0.5f;
    private float camRotation = 0;

    private float velocityY = 0.0f;

    private int antigravTimer = 0;

    private GameObject handRegular;
    private GameObject handGlove;
    private GameObject handGloveActiveIndicator;
    private GameObject cursorActiveIndicator;

    private float sceneRotation = 0f;
    private float fogAlpha = 0f;
    private Color fogColor;
    private float particleAlpha = 0f;
    private Color particleColor;
    private float cursorIndicatorSize = 100f;

    private bool antigravSwitchActivated = false;

    private void Start()
    {
        handRegular = GameObject.Find("Player/CamPivot/CamLook/MainCamera/player_charHands");
        handGlove = GameObject.Find("Player/CamPivot/CamLook/MainCamera/player_charHands_glove");
        handGloveActiveIndicator = GameObject.Find("Player/CamPivot/CamLook/MainCamera/player_charHands_glove/Armature/mixamorig:LeftShoulder/mixamorig:LeftArm/mixamorig:LeftForeArm/mixamorig:LeftHand/player_charHands_gloveIndicator/Body.001");
        cursorActiveIndicator = GameObject.Find("Player/CamPivot/CamLook/UICamera/Cursor/icon_gravModel");
    }

    void Update()
    {
        gravButtonDownPrev = gravButtonDown;

        if (Input.GetButtonDown("Fire1")) gravButtonDown = true;
        else gravButtonDown = false;

        camPosition = Mathf.Lerp(camPosition, 0.5f, camFlipSpeed);
        camRotation = Mathf.SmoothDamp(camRotation, 0, ref velocityY, camFlipSpeed);

        camPosition = Mathf.Clamp(camPosition, -0.5f, 0.5f);
        camRotation = Mathf.Clamp(camRotation, -180, 0);

        fogColor = antigravFogMaterial.color;
        particleColor = antigravParticleMaterial.color;

        if (antigravGloveObtained)
        {
            if (antigravGloveUseAllowed)
            {
                if (antigravTimer == 0)
                {
                    handRegular.SetActive(false);
                    handGlove.SetActive(true);

                    if (gravButtonDown && !gravButtonDownPrev && !antigrav) antigrav = true;
                    else if (gravButtonDown && !gravButtonDownPrev && antigrav) antigrav = false;

                    if (antigrav && gravButtonDown && !gravButtonDownPrev)
                    {
                        antigravSwitchActivated = true;
                        antigravTimer = antigravWaitTime;
                    }
                    else if (!antigrav && gravButtonDown && !gravButtonDownPrev)
                    {
                        antigravSwitchActivated = true;
                        antigravTimer = antigravWaitTime;
                    }

                    if (antigrav) handGloveActiveIndicator.SetActive(true);
                    else if (!antigrav) handGloveActiveIndicator.SetActive(false);
                }
                else if (antigravTimer != 0) antigravTimer--;
            }
            else if (antigrav && !antigravGloveUseAllowed)
            {
                antigrav = false;
                antigravSwitch(0);
            }
        }
        else
        {
            antigrav = false;
            handRegular.SetActive(true);
            handGlove.SetActive(false);
            handGloveActiveIndicator.SetActive(false);
        }

        if (antigrav)
        {
            antigravParticleSystem.Play();
            fogAlpha = Mathf.Lerp(fogAlpha, 1f, fogSpeed);
            particleAlpha = Mathf.Lerp(particleAlpha, 1f, particleSpeed);
            cursorIndicatorSize = Mathf.Lerp(cursorIndicatorSize, 5000f, particleSpeed);
        }
        else if (!antigrav)
        {
            antigravParticleSystem.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            fogAlpha = Mathf.Lerp(fogAlpha, 0, fogSpeed);
            particleAlpha = Mathf.Lerp(particleAlpha, 0, particleSpeed);
            cursorIndicatorSize = Mathf.Lerp(cursorIndicatorSize, 100f, particleSpeed);
        }

        fogAlpha = Mathf.Clamp(fogAlpha, 0, 1f);
        particleAlpha = Mathf.Clamp(particleAlpha, 0, 1f);
        fogColor.a = fogAlpha;
        particleColor.a = particleAlpha;

        antigravFogMaterial.SetColor("_Color", fogColor);
        antigravParticleMaterial.SetColor("_Color", particleColor);

        camPivot.transform.localPosition = new Vector3(camPivot.transform.localPosition.x, camPosition, camPivot.transform.localPosition.z);
        camPivot.transform.localRotation = Quaternion.Euler(camPivot.transform.localRotation.x, camPivot.transform.localRotation.y, camRotation);
        cursorActiveIndicator.transform.localScale = new Vector3(cursorIndicatorSize, cursorIndicatorSize, 100f);
    }

    private void FixedUpdate()
    {
        if (antigravSwitchActivated && !antigrav) antigravSwitch(0);
        else if (antigravSwitchActivated && antigrav) antigravSwitch(180);
    }

    void antigravSwitch(float desiredRotation)
    {
        sceneRotation = desiredRotation;
        Vector3 playerPos = player.transform.localPosition;

        scene.transform.localEulerAngles = new Vector3(scene.transform.localEulerAngles.x, scene.transform.localEulerAngles.y, sceneRotation);
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, 0);
        player.transform.localPosition = playerPos;

        camPosition = -0.5f;
        camRotation = -180;

        antigravSwitchActivated = false;
    }
}
