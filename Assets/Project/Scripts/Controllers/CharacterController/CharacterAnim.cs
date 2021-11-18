using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    [System.NonSerialized]
    public Animator anim;
    [System.NonSerialized]
    public CharacterController character;
    [System.NonSerialized]
    public SpriteRenderer spriteRenderer;

    public Material whiteMaterial;
    
    private Material originalMaterial;

    public void Awake()
    {
        character = transform.parent.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void Update()
    {
        anim.SetBool("Moving", character.rb2d.velocity.magnitude > 0.1f);
    }

    public void SetWhiteBlink (float pTime)
    {
        spriteRenderer.material = whiteMaterial;
        Invoke("SetOriginalMaterialBlink", pTime);
    }

    public void SetOriginalMaterialBlink()
    {
        spriteRenderer.material = originalMaterial;
    }
}
