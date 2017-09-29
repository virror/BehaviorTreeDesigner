using UnityEngine;
using System;
using System.Collections.Generic;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
    [Node(true, "Behavior/Base Node")]
    public abstract class BaseBehaviorNode : Node
    {
        [SerializeField]
        protected string Id;
        [SerializeField]
        protected Texture tex;
        [SerializeField]
        protected Guid guid;

        public abstract NodeStatus Tick(BehaviorBlackboard data);

        public virtual void Init(BehaviorBlackboard data)
        {
            List<NodeOutput> nodes = this.Outputs;

			foreach(NodeOutput node in nodes)
			{
				if(node.connections.Count == 0)
					continue;
					
				((BaseBehaviorNode)(node.connections[0].body)).Init(data);
            }
            guid = Guid.NewGuid();
        }

        protected void Init(BaseBehaviorNode node)
        {
            node.name = this.GetType().Name;
			node.Id = node.name;
            node.tex = (Texture)Resources.Load("BehavorIcons/" + node.Id);
        }

        protected override void NodeGUI()
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

    public enum EntryType
    {
        CLASS,
        BOOL,
        INTEGER,
        FLOAT
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
