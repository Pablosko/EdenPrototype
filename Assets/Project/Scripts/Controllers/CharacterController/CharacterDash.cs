using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : MonoBehaviour
{
    
    [System.NonSerialized]
    public Vector2 dashDirection;
    [System.NonSerialized]
    public Dash dashingDash;
    [System.NonSerialized]
    public CharacterController character;
    [System.NonSerialized]
    public Transform trailsTransform;
    [System.NonSerialized]
    public List<GameObject> trails = new List<GameObject>();

    public bool isDashBloqued = false;
    public List<Dash> dashes = new List<Dash>();
    public bool isDashing;
    public float UndashingDrag;
    public int maxDashes = 3;
    public int currentDash;

    public void Awake()
    {
        trailsTransform = transform.Find("Trails");
    }
    public void Start()
    {
        character = GetComponent<CharacterController>();
        character.rb2d.drag = UndashingDrag;
        //GetDashes();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
   
    }
    public virtual void StopDashing() 
    {
        isDashing = false;
        character.rb2d.velocity = Vector2.zero;
        character.rb2d.drag = UndashingDrag;
        dashingDash = null;
    }
    public virtual Vector2 GetDashDir() 
    {
        return character.rb2d.velocity.normalized;
    }
    public virtual void Dash() 
    {
        if (isDashBloqued)
            return; 
        dashDirection = GetDashDir();
        dashes[currentDash].Use();
    }
    public virtual void GetDashes() 
    {
        dashes.AddRange(transform.GetComponents<Dash>());
        foreach (Dash dash in dashes)
        {
            dash.charDash = this;
        }
    }
   
    public bool CanDash() 
    {
        return (!isDashing && dashes[currentDash].isInCd());
    }

    public virtual void ChangeDash(int index)
    {
        trails[currentDash].SetActive(false);
        currentDash += index;
        if (currentDash >= dashes.Count)
            currentDash = 0;
        if (currentDash < 0)
            currentDash = dashes.Count -1;
        UpdateTrail();
    }
    public void UpdateTrail() 
    {
        trails[currentDash].SetActive(true);
    }

    public virtual void AddDash(Dash dash,int layer)
    {
        dashes.Add(dash);
        dash.SetOwner(character,layer);
    }
    public bool HasMaxDashes() 
    {
        return (dashes.Count >= maxDashes);
    }
    public virtual void InterruptAllDashes() 
    {
        foreach (Dash dash in dashes)
        {
            dash.InterruptDash();
        }
    }
    public void CutDash() 
    {
        if (dashingDash != null)
            dashingDash.StopDashing();
    }
}
