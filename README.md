<h1>Useful Unity Scripts</h1>
</br>
An assortments of modular scripts that can be chained together or used independently to accomplish a verity of basic and complex tasks. 
</br>
I will often use these scripts at the start of a new project to easily create certain prefabs. They mainly work though unity events calling public methods. This is very helpful as they are easy understand and to put together into something more complex, like building blocks.

<h2>Effects</h2>
A collection of scripts that will preform an effect such as a popup, text scroll or flash.
</br></br></br>
Billboard: Make transform always face main camera.
</br></br>
Destructible: This script spawns a destroyed gameobject and removes the gameobject it is attached to.
</br></br>
FlashObject: Make a gameobject flash by changing it and all its children’s materials then return the original materials.
</br></br>
ItemMovement: Rotate and bob the gameobject up and down.
</br></br>
MoveObjectOverSpeed: Move or rotate an object over a given speed.
</br></br>
MoveObjectOverTime: Move or rotate an object over a given time.
</br></br>
PopdownEffect: Perform the popdown effect on a gameobject.
</br></br>
PopupEffect: Perform popup effect on a gameobject. Gameobject will be scaled from a small size to a larger size then back down to its original size.
</br></br>
SpawnPrefab: Spawn a prefab at a given transfrom.
</br></br>
TextMeshProScrollEffect: Take a string of textmesh. Reveal one character at a time based on the 'charRevealRate' variable. Unreveal the text based on the same variable.
</br></br>

<h2>Modular</h2>
A collection of scripts to help perform useful tasks in Unity. 
</br></br></br>
AlignObjectToSlope: Align game object to the surface normals it is on.
</br></br>
AnimatorController: Set an animator parameter.
</br></br>
BasicEvents: Some basic MonoBehaviour and proxy methods invoking UnityEvents.
</br></br>
CheckTransform: Check transform against target value.
</br></br>
Comment: Attach this script to any GameObject on which you want to put a note.
</br></br>
DestroyObject: Destroy a set GameObject.
</br></br>
DistanceFromObject: Check if target GameObject is within set range and invoke event. Call float event when within threshold of the GameObject.
</br></br>
FindObject: Find an object then pass object referance in a unity event.
</br></br>
IDEventEmitter: Send out delegate with ID variable and gameobject.
</br></br>
IDEventListner: Listen for an ID event matching this classes ID variabel.
</br></br>
Incrementer: Increment towards the target value. Invoke event when target value is reached.
</br></br>
Randomizer: Create a list of events and invoke one at random.  
</br></br>
SceneNavigation: Some basic scene controls.  
</br></br>
SetTransform: Set the position, rotation, scale or offset of this transform.
</br></br>
Stopwatch: Stopwatch to measure the amount of time elapsed in seconds. Invoke an event on stop with the elapsed time.
</br></br>
TestTrigger: Trigger event on key down.
</br></br>
Timer: A timer that will invoke events on start and end of run.   
</br></br>
ToggleEvent: This script will invoke on and off events through a toggle.
</br></br>
TransformFollower: Used to make a transform follow another via parenting or mimicing scale, rotation and position.
</br></br>

<h3>Transform Select</h3>
This set of scripts is designed to create a gaze select system often used in VR.
