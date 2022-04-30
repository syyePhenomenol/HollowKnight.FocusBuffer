using Modding;
using Vasi;
using HutongGames.PlayMaker.Actions;

namespace FocusBuffer
{
    public class FocusBuffer : Mod
    {
        public override string GetVersion() => "1.0.0";

        public override void Initialize()
        {
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);

            if (self.FsmName == "Spell Control")
            {
                FsmUtil.GetAction<ListenForCast>(self, "Inactive", 1).isPressed = FsmUtil.GetAction<ListenForCast>(self, "Inactive", 1).wasPressed;
            }
        }
    }
}