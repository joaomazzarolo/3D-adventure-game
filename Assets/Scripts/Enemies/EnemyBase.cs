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

        [SerializeField] private float _currentLife;

        [SerializeField]private AnimationBase _animationBase;

        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        private void Awake()
        {
            Init();
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
    }
}
