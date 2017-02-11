# Introduction

This file provides documentation on how to use the included prefabs and scripts.

* [Setting up](#setting-up)
* [What is a Behavior Tree?](#what-is-a-behavior-tree)
* [Example scene](#example-scene)
* [Custom nodes](#custom-nodes)
 * [General](#general)
 * [Decorators](#decorators)
 * [Composites](#composites)
 * [Actions](#actions)
 * [Blackboard](#blackboard)

## Setting up

* Add this repository to your projects Assets folder.
* In Unity, go to Window->Node Editor to open the Behavior Tree Editor.
* In the node editor toolbar, click "File", then "New Canvas" and select "Behavior Canvas".
* Now you can create behaviors by clicking right mouse button and placing nodes.
* NOTE: You must have a "Root" node and no connected nodes with a single output can have it empty.
* Save the Behavior tree using the "Save Canvas" button in a "Resources" folder.
* Add a empty GameObject to the scene and add a "Behavior Manager" script to it.
* Add the behavior tree reference and the agent reference and hit Play.

## What is a behavior tree?

A behavior tree is a way of modeling an agents behavior by connecting different nodes together.
All nodes gets "ticked" at a certain rate, often at a much slower rate than the game loop.
A tick always starts out from the root node, and traverses the nodes from left to right until it 
returns to the root node. There are four basic types of nodes and those are:

* Root node: This is where you tree starts, it can only have one output and no inputs.
* Compositor: This is what performs the logic of the tree, you can see them as if cases and similar.
  They have one input and have at least two outputs.
* Decorator: This node modifies the result or execution in some way, as an example inverts the result.
* Action: This is what actually performs actions in the game, like checking if enemies is nearby, or 
  moving the agent around.

All nodes currently included and their description can be found here:
[Included nodes](IncludedNodes.md)

## Example scene

There is one example scene set up that shows a very basic ai in action.
It can be found in BehaviorTreeDesigner\Examples\Scenes\ and the behavior tree for it can be found in
BehaviorTreeDesigner\Examples\Resources\aiExample.asset. The scene is set up with one agent running 
around shooting down the evil blue balls. The balls are tagged "Enemy" and the agent is setup with a 
"Nav Mesh Agent" for pathfinding and a simple script for controlling the animations.

The behavior tree first checks if the player has a target, if not, a target is assigned based on tag 
"Enemy" and the distance. Then the agent will start walking towards the target until it’s in range, shoot 
3 times and then clear its target. The cycle then repeats itself until no more targets can be found.

## Custom nodes
### General



### Decorators



### Composites



### Actions



### Blackboard

The blackboard is a place for the tree to store Entries (values) between ticks and/or nodes. One example is the Wait
node that uses the Blackboard to keep its time between ticks, and another example for use is holding the agents
target so it can be used by multiple nodes and also to store the agent itself. The Blackboard can store pretty 
much any kind of Entry like int, float, Transforms, GameObjects and much more, and are always referenced with 
a string value, like "Target" for keeping track of the agents target. The Blackboard can be accessed from the Init
and Tick functions in each node using the "data" variable passed in to it. The following functions are available
to read and write values to the Blackboard, note that the values using these functions can only be accessed within
the same tree:

* void Add(string key, object obj):
  > Writes any class type of object to the blackboard, such as strings, Arrays, Unity classes and much more.
    Example: data.Add("Target", myTarget);

* object Get(string key):
  > Reads any class type of object from the blackboard, such as strings, Arrays, Unity classes and much more.
    Example: Transform target = (Transform)data.Get("Target");

You can also use the Blackboard to store global Entries that can be shared between trees. Some caution has to be taken 
when using this function and its recommended to have only one tree responsible to writing to the global Blackboard while
any can read from it because several trees can have a different view of the world and you will end up getting hard to 
predict results. But the global Blackboard can be very useful to share world states that needs to be accessed by all 
agents in the game. The syntax is similar to the one above, and supports exactly the same types. The only difference
is that you call "GetGlobal" or AddGlobal" instead.  
Example:
* void AddGlobal(string key, float obj):
  > Writes a float to the global blackboard.
    Example: data.AddGlobal("SomeValue", 23.5f);
