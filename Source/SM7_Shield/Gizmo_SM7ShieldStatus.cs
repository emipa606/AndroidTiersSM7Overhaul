using RimWorld;
using UnityEngine;
using Verse;

namespace SM7
{
    // Token: 0x02000002 RID: 2
    [StaticConstructorOnStartup]
    internal class Gizmo_SM7ShieldStatus : Gizmo
    {
        // Token: 0x04000002 RID: 2
        private static readonly Texture2D FullShieldBarTex =
            SolidColorMaterials.NewSolidColorTexture(new Color(0.2f, 0.2f, 0.24f));

        // Token: 0x04000003 RID: 3
        private static readonly Texture2D EmptyShieldBarTex = SolidColorMaterials.NewSolidColorTexture(Color.clear);

        // Token: 0x04000001 RID: 1
        public SM7_Shield shield;

        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public Gizmo_SM7ShieldStatus()
        {
            order = -100f;
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
        public override float GetWidth(float maxWidth)
        {
            return 140f;
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002080 File Offset: 0x00000280
        public override GizmoResult GizmoOnGUI(Vector2 topLeft, float maxWidth, GizmoRenderParms parms)
        {
            var overRect = new Rect(topLeft.x, topLeft.y, GetWidth(maxWidth), 75f);
            Find.WindowStack.ImmediateWindow(984688, overRect, 0, delegate
            {
                var rect = overRect.AtZero().ContractedBy(6f);
                var rect2 = rect;
                rect2.height = overRect.height / 2f;
                Text.Font = GameFont.Tiny;
                Widgets.Label(rect2, shield.LabelCap);
                var rect3 = rect;
                rect3.yMin = overRect.height / 2f;
                var num = shield.Energy / Mathf.Max(1f, shield.GetStatValue(StatDefOf.EnergyShieldEnergyMax));
                Widgets.FillableBar(rect3, num, FullShieldBarTex, EmptyShieldBarTex, false);
                Text.Font = GameFont.Small;
                Text.Anchor = TextAnchor.MiddleCenter;
                Widgets.Label(rect3,
                    (shield.Energy * 100f).ToString("F0") + " / " +
                    (shield.GetStatValue(StatDefOf.EnergyShieldEnergyMax) * 100f).ToString("F0"));
                Text.Anchor = 0;
            });
            return new GizmoResult(0);
        }
    }
}