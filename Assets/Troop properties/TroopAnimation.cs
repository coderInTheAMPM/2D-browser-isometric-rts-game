using UnityEngine;

namespace PavleM.SI.PrebivalisteS3
{
    public class TroopAnimation
    {
        private Animator animator;

        private string currentAnimation = "";

        public TroopAnimation(Animator animator)
            => this.animator = animator;

        public void SetAnimation(string animation)
        {
            if (currentAnimation.Equals(animation))
                return;

            animator.Play(animation, 0, 0.25f);
            currentAnimation = animation;
        }

        public bool HasAnimationReachedHalf()
        {
            var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            bool animationReachedHalf = (animatorStateInfo.normalizedTime >= .5f);
            bool animationBeingCheckedIsCurrent = (animatorStateInfo.IsName(currentAnimation));

            return animationReachedHalf && animationBeingCheckedIsCurrent;
        }
    }
}
