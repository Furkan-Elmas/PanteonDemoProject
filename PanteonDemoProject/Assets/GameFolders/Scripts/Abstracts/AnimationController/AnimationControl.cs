using PanteonDemoProject.Abstracts.GameState;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class AnimationControl
    {
        public void WaitOrRun(GameStates gameState, Animator characterAnimator, bool isRunning)
        {
            if (gameState == GameStates.InRunning)
            {
                characterAnimator.SetBool("IsRunning", isRunning);
            }
            else
            {
                characterAnimator.SetBool("IsRunning", false);
            }
        }

    }
}