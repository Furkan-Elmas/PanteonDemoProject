using PanteonDemoProject.Abstracts.GameState;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class AnimationControl
    {
        Animator _characterAnimator;

        public AnimationControl(Animator characterAnimator)
        {
            _characterAnimator = characterAnimator;
        }

        public void WaitOrRun(GameStates gameState, bool isRunning)
        {
            if (gameState == GameStates.InRunning)
            {
                _characterAnimator.SetBool("IsRunning", isRunning);
            }
            else
            {
                _characterAnimator.SetBool("IsRunning", false);
            }
        }

        public void Cheer()
        {
            _characterAnimator.SetTrigger("Victory");
        }

        public void Die()
        {
            _characterAnimator.SetTrigger("Death");
        }

        public void AnimationReset()
        {
            _characterAnimator.Rebind();
        }

    }
}