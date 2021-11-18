using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void Event(DamageDealer dealer);
public class CharacterEvents : MonoBehaviour
{
    public CharacterController character;
    public UnityEvent OnDash;
    public List<Event> onDashEvents = new List<Event>();
    public List<Event> onDieEvents = new List<Event>();
    public List<Event> onKillEvents = new List<Event>();
    public List<Event> onHitEvents = new List<Event>();
    public List<Event> onDashingEvents = new List<Event>();
    public List<Event> onEndDashEvents = new List<Event>();
    void Start()
    {
        character = GetComponent<CharacterController>();
      //  OnDash.AddListener(() => SayHi());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnDash.Invoke();
            OnDash.RemoveAllListeners();
        }
        */

    }
}
