using Modding;
using HutongGames.PlayMaker.Actions;
using Vasi;

namespace FocusBuffer
{
    public class FocusBuffer : Mod
    {
        public override string GetVersion() => "1.0.1";

        public override void Initialize()
        {
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);

            if (self.FsmName == "Spell Control")
            {
                self.GetAction<ListenForCast>("Inactive", 1).isPressed = self.GetAction<ListenForCast>("Inactive", 1).wasPressed;
            }
        }
    }
}