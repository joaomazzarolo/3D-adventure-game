using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider collider;
        public float startLife = 10f;
        public FlashColor flashColor;
        public ParticleSystem particleSystem;
        public bool lookAtPlayer = false;
        private Player _player;
        private float distanceToPlayer;


        [SerializeField] private float _currentLife;

        [SerializeField]private AnimationBase _animationBase;

        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _player = GameObject.FindObjectOfType<Player>();
        }
        protected void ResetLife() 
        {
            _currentLife = startLife;
        }

        protected virtual void Init() 
        {
            ResetLife();
            if(startWithBornAnimation)
                BornAnimation();
        }
        protected virtual void Kill() 
        {
            OnKill();
        }
        protected virtual void OnKill() 
        {
            if (collider != null) collider.enabled = false;
            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }
        public void OnDamage(float f)   
        {
            if (flashColor != null) flashColor.Flash();
            if (particleSystem != null) particleSystem.Emit(10);

            transform.position -= transform.forward;

            _currentLife -= f;

            if(_currentLife <= 0)
            {
                Kill();
            }
        }

        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }
        #endregion


        public void Damage(float damage)
        {
            OnDamage(damage);
        }
        public void Damage(float damage, Vector3 dir)
        {
            OnDamage(damage);
            transform.DOMove(transform.position - dir, .1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Player p = collision.transform.GetComponent<Player>();

            if (p != null)
            {
                p.Damage(1);
            }
        }

        public virtual void Update()
        {
            distanceToPlayer = Vector3.Distance(_player.transform.position, gameObject.transform.position);
            if (distanceToPlayer < 20)
            {
                transform.LookAt(_player.transform.position);
                PlayAnimationByTrigger(AnimationType.ATTACK);
            }
        }
    }
}
