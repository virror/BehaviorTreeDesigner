using UnityEngine;
using System;
using System.Collections;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
    [Node(true, "Behavior/Base Node")]
    public abstract class BaseBehaviorNode : Node
    {
        protected string Id;
        [SerializeField]
        protected Texture tex;

        public abstract void Init( Hashtable data );
        public abstract NodeStatus Tick();

        protected void Init(BaseBehaviorNode node)
        {
            node.name = this.GetType().Name;
			node.Id = node.name;
            node.tex = (Texture)Resources.Load("BehavorIcons/" + node.Id);
        }

        protected internal override void NodeGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(tex);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        public override string GetID{get { return Id; } }
    }

    public enum NodeStatus  
    {
        SUCCESS,
        FAILURE,
        RUNNING,
        ERROR
    }

    public class BehaveType : IConnectionTypeDeclaration
    {
        public string Identifier { get { return "Behave"; } }
        public Type Type { get { return typeof(void); } }  // type to pass
        public Color Color { get { return Color.green; } }
        public string InKnobTex { get { return "Textures/In_Knob.png"; } }
        public string OutKnobTex { get { return "Textures/Out_Knob.png"; } }
    }
}
