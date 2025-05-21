using RimWorld;
using UnityEngine;
using Verse;

namespace HFWeaponSeries
{
    public class Gizmo_OverchargeStatus : Gizmo
    {
        public CompOvercharge comp;
        private static readonly Texture2D EmptyShieldBarTex = SolidColorMaterials.NewSolidColorTexture(Color.clear);
        private static readonly Texture2D BaseShieldTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.2f, 0.2f, 0.24f));
        private static readonly Texture2D WarmShieldTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.45f, 0.4f, 0.35f));
        private static readonly Texture2D HotShieldTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.7f, 0.45f, 0.35f));
        private static readonly Texture2D ExtremeShieldTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.8f, 0.45f, 0.1f));
        private static readonly Texture2D MaxShieldTex = SolidColorMaterials.NewSolidColorTexture(new Color(1, 0.5f, 0.1f));
        public override float GetWidth(float maxWidth)
        {
            return 140f;
        }

        public override GizmoResult GizmoOnGUI(Vector2 topLeft, float maxWidth, GizmoRenderParms parms)
        {
            Rect main = new Rect(topLeft.x, topLeft.y, GetWidth(maxWidth), 75f);
            Rect innerMain = main.ContractedBy(6f);
            Widgets.DrawWindowBackground(main);
            Rect innerTopRect = innerMain;
            innerTopRect.height = main.height / 2;
            Text.Font = GameFont.Tiny;
            Widgets.Label(innerTopRect,
                "HF_OverchargeDamageStatus".Translate().Resolve() + ": " + comp.CurrentDamageMulti);
            Rect barRect = innerMain;
            barRect.yMin = innerMain.y + innerMain.height / 2;
            Texture2D barColor = null;
            switch (comp.CurrentHeatPercentage)
            {
                case < 0.5f:
                    barColor = BaseShieldTex;
                    break;
                case < 0.65f:
                    barColor = WarmShieldTex;
                    break;
                case < 0.80f:
                    barColor = HotShieldTex;
                    break;
                case < 0.95f:
                    barColor = ExtremeShieldTex;
                    break;
                case > 0.95f:
                    barColor = MaxShieldTex;
                    break;
            }
            Widgets.FillableBar(barRect, comp.CurrentHeatPercentage, barColor, EmptyShieldBarTex, false);
            Text.Font = GameFont.Small;
            Text.Anchor = TextAnchor.MiddleCenter;
            Widgets.Label(barRect, comp.currentHeat + " / " + comp.Props.maxHeat);
            Text.Anchor = TextAnchor.UpperLeft;
            TooltipHandler.TipRegion(innerMain, "HF_OverchargeTooltip".Translate());
            return new GizmoResult(GizmoState.Clear);
        }
    }
}