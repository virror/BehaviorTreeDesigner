# Included nodes
Here is a complete list of all the included nodes and a short description.

## Composites

* Selector:
  > Runs children from left to right until one of them returns SUCCESS.  
    Returns SUCCESS if any child is successful, otherwise FAILURE.

* Sequence:
  > Runs children from left to right until one of them returns FAILURE.  
    Returns SUCCESS if all children is successful, otherwise FAILURE.

* Parallel:
  > Runs all children simultaneously.  
    Returns SUCCESS if all children is successful, otherwise FAILURE. 

## Debug
* FixedValue:
  > Returns the selected value always.

* Logger:
  > Logs name and result of child node.


## Decorators
* Inverter:
  > Inverts the return value of the child if that value is SUCCESS or FAILURE.

* Repeater:
  > Repeats the child node n times always returning after one tick.  
  	Returns RUNNING during the ticks its repeating, after its done, it returns  
	last childs result.


## Actions
* ClearTarget:
  > Clears the current Target of the agent.

* HasTarget:
  > Returns SUCCESS if agent has Target, FAILURE if not.

* TagToTarget:
  > Finds the closest Target with the selected Tag and returns SUCCESS, if no  
    Target was found it returns FAILURE.

* WalkToTarget:
  > Sets the agents Nav Mesh position to Target, returns RUNNING while walking,  
    SUCCESS when clorer than the specified distance and FAILURE if path could  
	not be found.
