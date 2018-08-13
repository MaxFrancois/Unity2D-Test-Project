using UnityEngine;

public class AttackableBush : AttackableBase {

    public Sprite DestroyedSprite;
    SpriteRenderer _spriteRenderer;
    public GameObject DestroyEffect;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void OnAttacked(ItemType itemType, Collider2D collider)
    {
        _spriteRenderer.sprite = DestroyedSprite;

        var bushCollider = GetComponent<Collider2D>();
        if (bushCollider != null)
            bushCollider.enabled = false;
        if (DestroyEffect != null)
        {
            //creates a particle effect, and destroys it when it's finished
            GameObject effect = Instantiate(DestroyEffect);
            var parts = effect.GetComponent<ParticleSystem>();
            float totalDuration = parts.main.duration + parts.main.startLifetime.constant;
            Destroy(effect, totalDuration);
            //Destroy(gameObject, totalDuration);
            //destroys the whole thing, doesn't work in this case because we want to leave the roots showing
            effect.transform.position = transform.position;
            //Finds a method with that name somewhere on the object's hierarchy and calls it.
            BroadcastMessage("GenerateLoot", SendMessageOptions.DontRequireReceiver);
        }
    }
}
