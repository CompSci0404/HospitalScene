# HospitalScene

Introduction:

-> Rough XR VR system built within Unity 2020.3.0f1
->Players can pick up four different props on a top shelf, that being a syringe, hand sanitize, box of gloves, and a vial. 
-> players can move each item to the bottom shelf on clearly labelled sections, in which once they are all moved a end game screen
   appears, giving time of simulation and a grade, hard coded for A+ :)
-> Can take out a glove and put it on opposite hand. 
-> setup, clone master, open with Unity 2020.3.0f1. 


Known issues: 

1. Glove box prefab instantiation does not work. 
2. Two ray cast interactors on one object sometimes make the UI Description of a object become stuck. 
3. Glove is programmed to interact with the opposite hand that is controlling it. Will not attach to the hand controlling it. 
4. Mock HMD is only supported. 
5. Glove sometimes does not respawn after completing level.Glove box does.


