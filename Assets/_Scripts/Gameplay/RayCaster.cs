using MarchingBytes;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _distance = 50f;
    [SerializeField] private ParticleHolder _particlePool;
    [SerializeField] private ScoreEffect scoreEffect;
    [SerializeField] private ScorePresenter scorePresenter;
    
    private IRaycastable _raycastable;
    private Hitable _hitable;
    private BallScore _ballScore;

    private Vector3 touchPos;

    private void Start()
    {
        scoreEffect = GetComponent<ScoreEffect>();
        _particlePool = GetComponent<ParticleHolder>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            touchPos = Input.mousePosition;
            touchPos = Camera.main.ScreenToWorldPoint(touchPos);
            TapRaycast(touchPos);
        }
    }

    private void TapRaycast(Vector3 startTouch)
    {
        RaycastHit hit;
        if (Physics.Raycast(touchPos, Vector3.down * _distance, out hit, _targetLayer))
        {
            _raycastable = hit.transform.GetComponent<IRaycastable>();
            _hitable = hit.transform.GetComponent<Hitable>();
            _ballScore = hit.transform.GetComponent<BallScore>();
            
            if (_raycastable != null)
            {
                if(_hitable.isBomb)
                    _particlePool.PlayParticle(ParticleType.Bomb, hit.transform.position);
                else
                    _particlePool.PlayParticle(ParticleType.Ball, hit.transform.position);
                
                scoreEffect.CreateScoreView(hit.transform.position, _ballScore.score);
                scorePresenter.AddScorePoint(_ballScore.score);
                _raycastable.HitOn();
            }
            
            EasyObjectPool.instance.ReturnObjectToPool(hit.transform.gameObject);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(touchPos, Vector3.down * _distance);
    }
}
