using UnityEngine;
using UnityEngine.EventSystems;
using CW.Common;
using System.Collections;
using System.Collections.Generic;
namespace Lean.Gui
{
	/// <summary>This component allows you to associate text with this GameObject, allowing it to be displayed from a tooltip.
	/// NOTE: If this component is enabled while a finger is hovered over this element, then it will not trigger the <b>OnPointerEnter</b> event.</summary>
	[HelpURL(LeanGui.HelpUrlPrefix + "LeanTooltipData")]
	[AddComponentMenu(LeanGui.ComponentMenuPrefix + "Tooltip Data")]
	public class LeanTooltipData : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		/// <summary>If you want this tooltip to hide when a selectable (e.g. Button) is disabled or non-interactable, then specify it here.</summary>
		public UnityEngine.UI.Selectable Selectable { set { selectable = value; } get { return selectable; } } [SerializeField] private UnityEngine.UI.Selectable selectable;
		public CanvasGroup BackgroundCanvasGroup;
		/// <summary>This allows you to set the tooltip text string that is associated with this object.</summary>
		public string Text { set { text = value; } get { return text; } } [Multiline] [SerializeField] private string text;
		public void SetSelectable(UnityEngine.UI.Selectable selectable1) { selectable = selectable1; }
		[SerializeField]private GameObject GetBackground;
		public void set_Background(GameObject go) { GetBackground = go;lb2 = go.transform; }
		public float xb, yb, zb, xs, ys, zs;//transform & scale
		protected virtual void Update()
		{
			if (LeanTooltip.HoverData == this)
			{
				if (selectable != null)
				{
					LeanTooltip.HoverShow = selectable.enabled == true && selectable.interactable == true;
				}
			}
		}
		public void _setbgCanvas(CanvasGroup group)
        {
			BackgroundCanvasGroup = group;
        }
		protected virtual void OnDisable()
		{
			// These aren't auto called?
			OnPointerUp(default(PointerEventData));
			OnPointerExit(default(PointerEventData));
		}
		Transform lb2;
		protected virtual void Awake()
        {

		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			LeanTooltip.HoverPointer = eventData;
			LeanTooltip.HoverData    = this;
			LeanTooltip.HoverShow    = true;
			if(GetComponent<BoxCollider>() != null) transform.Find("Holly Aura").gameObject.active = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (LeanTooltip.HoverData == this)
			{
				LeanTooltip.HoverPointer = null;
				LeanTooltip.HoverData    = null;
				LeanTooltip.HoverShow    = false;
				if (GetComponent<BoxCollider>() != null) transform.Find("Holly Aura").gameObject.active = false;
				print("OnPointerExit");
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			LeanTooltip.PressPointer = eventData;
			LeanTooltip.PressData    = this;
			LeanTooltip.PressShow    = true;

            if (name == "Pizza")
            {
				GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
				//GetComponent<LeanButton2>().bgNotVisible();
			}
            else
            {
				
				GetBackground.GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.3f, 1.3f);
			}
            selectable.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            print("OnPointerDown");
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (LeanTooltip.PressData == this)
			{
				LeanTooltip.PressPointer = null;
				LeanTooltip.PressData    = null;
				LeanTooltip.PressShow    = false;
				print("OnPointerUp");
			}
		}
	}
}

#if UNITY_EDITOR
namespace Lean.Gui.Editor
{
	using UnityEditor;
	using TARGET = LeanTooltipData;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(TARGET))]
	public class LeanTooltipData_Editor : CwEditor
	{
		protected override void OnInspector()
		{
			TARGET tgt; TARGET[] tgts; GetTargets(out tgt, out tgts);

			Draw("selectable", "If you want this tooltip to hide when a selectable (e.g. Button) is disabled or non-interactable, then specify it here.");
			Draw("text", "This allows you to set the tooltip text string that is associated with this object.");
		}
	}
}
#endif