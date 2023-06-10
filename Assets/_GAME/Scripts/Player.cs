using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 activeDirection = Vector3.left;
    [SerializeField] protected Vector3 zoneBounds;

    [Header("References")]
    [SerializeField] protected List<Transform> bodyParts = new List<Transform>();
    [SerializeField] protected GameObject bodyPartPrefab;
    [SerializeField] protected VariableJoystick variableJoystick;
    [SerializeField] protected Button speedingButton;

    public static Action<CollectibleType> OnCollectiblePickUp;
    private Player m_Singleton;

    private void Awake()
    {
        m_Singleton = this;
    }

    private void OnEnable()
    {
         OnCollectiblePickUp += ApplyEffect;
    }

    private void OnDisable()
    {
         OnCollectiblePickUp -= ApplyEffect;
    }

    public Player Instance
    {
        get { return m_Singleton; }
    }

    void Update()
    {
        Rotate();
        MoveForward();
        CheckPositionForEvents();
        //if(speedingButton.OnPointerUp())
    }

    public void Rotate()
    {
        if((variableJoystick.Horizontal > 0 || variableJoystick.Vertical > 0) || (variableJoystick.Horizontal < 0 || variableJoystick.Vertical < 0))
        {
            activeDirection = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
            transform.rotation = Quaternion.Euler(activeDirection);
        }
    }
    //Shift all objects
    public void MoveForward()
    {
        //Shift all objects
        for (int i = 0; i < bodyParts.Count - 1; i++)
        {
            bodyParts[i + 1].position = bodyParts[i].position;
            bodyParts[i + 1].rotation = bodyParts[i].rotation;
        }
        //Move main body part
        transform.rotation = Quaternion.Euler(activeDirection);
        transform.Translate(activeDirection * Time.unscaledDeltaTime * speed);
        CheckPositionForEvents();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -zoneBounds.x, zoneBounds.x), 0, Mathf.Clamp(transform.position.z, -zoneBounds.z, zoneBounds.z)) ;
    }
    public void CheckPositionForEvents()
    {
        if (Mathf.Abs(transform.position.x) > zoneBounds.x || Mathf.Abs(transform.position.z) > zoneBounds.z) PlayerDeath();
        //Check the spawn manager

    }

    public void ApplyEffect(CollectibleType type)
    {

    }
    //Kills palyer and ends game
    public void PlayerDeath()
    {

    }

    

}
