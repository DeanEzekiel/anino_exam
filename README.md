# Documentation

Unity version used: Unity 2020.3.12f1

System setup:
- I used AMVCC (App, MVC, Components) as my pattern.
- The main classes are in the Scripts/MVC, Scripts/Scriptable Object, Scripts/Component
- For the Objects in the Hierarchy, the "Slot Machine", "Game Main", and "Canvas" contains the most important objects.

Data Sources can be found in Assets > Scriptables. There are 2 folders inside for the Line Data and the Symbol Data.

As of writing, this is still incomplete. Below are what I haven't done yet:
- Stop Button functionality
- Advanced Spinning
(I may not be able to finish the above as I was told my supposedly postponed class later would proceed.)

Additional notes:
- as I used Scriptable Objects, the Data for the Lines (Patterns) and the Symbols' Points can be easily modified.
- I incorporated MVC with the interactions with the UI elements
- for future improvements, the Stop and Advanced Spinning functionality could be incorporated. I'm looking at possible remote config as well, but due to time constraints and schedule conflict, I may not be able to do this. Animations on the shown symbols could be added as well.
