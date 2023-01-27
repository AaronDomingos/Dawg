using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Laser : MonoBehaviour
{
    public GameObject impact;
    public LineRenderer line;
    public Material material;
    public Identity identity;
    
    public PolygonCollider2D polyCollider;
    private List<Vector2> colliderPoints;

    private bool IsFiring = true;
    public List<RaycastHit2D> CollidibleHits = new List<RaycastHit2D>();

    public Renderer _sprayRenderer;
    public Renderer _barrelRenderer;
    public Renderer _impactSprayRenderer;
    public Renderer _impactPointRenderer;
    
    private List<Identification.Tags> CollidibleTags =
        new List<Identification.Tags>();
    private List<Identification.Tags> DamagableTags =
        new List<Identification.Tags>();
    private Identification.Tags Shooter;

    public List<Collider2D> CollidedObjects = new List<Collider2D>();
    public List<Collider2D> DamagableObjects = new List<Collider2D>();

    private float Damage = .25f;
    private float Range = 0f;

    private Vector3 LaserOrigin = Vector3.zero;
    private Vector3 LaserTarget = Vector3.zero;
    private Vector3 CollisionPoint = Vector3.zero;
    
    public void Init(List<Identification.Tags> collidable, 
        List<Identification.Tags> damagable, Identification.Tags shooter,
        float range, float damage, Color color)
    {
        CollidibleTags = collidable;
        DamagableTags = damagable;
        identity.Add(shooter);
        
        Range = range;
        Damage = damage;

        //SetColor(colorProfile);
    }

    private void Start()
    {
        OnDisable();
    }

    public void SetColor(Color color)
    {
        // line.material.SetColor("_LowLevelColor", cp.Primary * 1.5f);
        // line.material.SetColor("_HighLevelColor", cp.Secondary * 1.5f);
        //
        // _sprayRenderer.material.color = cp.Secondary * 1f;
        // _barrelRenderer.material.color = cp.Secondary * 1f;
        //
        // _impactSprayRenderer.material.color = cp.Secondary * 1f;
        // _impactPointRenderer.material.color = cp.Secondary * 1f;
    }

    private void AdjustCollider(Vector3 a, Vector3 b)
    {
        Vector3[] positions = new Vector3[] { a, b };

        float startWidth = line.startWidth / 2;
        float endWidth = line.endWidth / 2;

        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (startWidth / 2f) * (m / Mathf.Pow(m * m + 1, .5f));
        float deltaY = (endWidth / 2f) * (1f / Mathf.Pow(1 + m * m, 0.5f));

        Vector3[] offsets = new Vector3[2];
        offsets[0] = new Vector3(-deltaX, deltaY);
        offsets[1] = new Vector3(deltaX, -deltaY);

        List<Vector2> colliderPositions = new List<Vector2>()
        { 
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };
        
        polyCollider.SetPath(0, colliderPositions.ConvertAll(
            p => (Vector2)transform.InverseTransformPoint(p)));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Identity objIdentity))
        {
            if (objIdentity.TagsKnownAs.Intersect(CollidibleTags).Any())
            {
                if (!CollidedObjects.Contains(col))
                {
                    CollidedObjects.Add(col);
                }
            }

            if (objIdentity.TagsKnownAs.Intersect(DamagableTags).Any())
            {
                if (!DamagableObjects.Contains(col))
                {
                    DamagableObjects.Add(col);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (CollidedObjects.Contains(col))
        {
            CollidedObjects.Remove(col);
        }

        if (DamagableObjects.Contains(col))
        {
            DamagableObjects.Remove(col);
        }
    }

    public void SetPoints(Vector3 origin, Vector3 target)
    {
        LaserOrigin = origin;
        LaserTarget = Vector3.Lerp(origin, target,
            Range / Vector3.Distance(origin, target));
        
        ShootRaycast();
        RenderLine();
        AdjustCollider(LaserOrigin, LaserTarget);
    }

    private void RenderLine()
    {
        line.SetPosition(0, LaserOrigin);
        line.SetPosition(1, LaserTarget);
    }

    private void ShootRaycast()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(LaserOrigin, LaserTarget.normalized, 
            Vector3.Distance(LaserOrigin, LaserTarget));
        
        Debug.DrawRay(LaserOrigin, Orientation.DirectionToVector(LaserOrigin, LaserTarget));

        CollidibleHits.Clear();
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.TryGetComponent(out Identity objIdentity))
            {
                if (objIdentity.TagsKnownAs.Intersect(CollidibleTags).Any())
                {
                    CollidibleHits.Add(hits[i]);
                }
            }
        }

        if (CollidibleHits.Count > 0)
        {
            CollidibleHits = CollidibleHits.OrderBy(
                x => Vector3.Distance(x.point, LaserOrigin)).ToList();

            LaserTarget = CollidibleHits[0].point;
            
            //impact.SetActive(true);
            impact.transform.position = LaserTarget;
            _impactSprayRenderer.gameObject.SetActive(true);
            _impactPointRenderer.gameObject.SetActive(true);
        }
        else
        {
            //impact.SetActive(false);
            _impactSprayRenderer.gameObject.SetActive(false);
            _impactPointRenderer.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _sprayRenderer.gameObject.SetActive(true);
        _barrelRenderer.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        identity.Remove(Shooter);
        
        _sprayRenderer.gameObject.SetActive(false);
        _barrelRenderer.gameObject.SetActive(false);
        _impactSprayRenderer.gameObject.SetActive(false);
        _impactPointRenderer.gameObject.SetActive(false);
        //impact.SetActive(false);
    }
}
