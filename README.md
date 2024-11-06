Custom: Packages that I've made myself or edited
  - Animation Curve Drawer creates Scriptable Objects that draw animation curves based on the input values. Updates in the inspector using OnValidate.
    - It also has a Static Extension class for creating, calculating, and evaluating animation curves with code.
  - Audio Manager is my current solution for handling Music and SFX within my games using Scriptable Objects as its base.
  - Editor Shortcuts are any tools I've found or written to make using Unity Editor easier.
    - Will be updated intermittently.
  - Extendable Enums is precisely what it sounds like; it creates a list of Enums that you can customize through scripts or the inspector (based on how you modify it)
    - Essentially finished. But in the future, I will be working on the Editor Window to add the ability to show the current list with a toggle so that you can edit it in the inspector.
  - Game Events Listener is a Scriptable Object-based Event Subscription System.
    - Gets a list of references to Game Events Listeners with a Game Event Scriptable Object that holds the active Listeners' responses and invokes them simultaneously when its Raise method is called.
    - Based on this talk at Unite 2017 by Ryan Hipple: https://www.youtube.com/watch?v=raQ3iHhE_Kk.
  - Group Scene Loading is based on a Git-Amend YouTube video I've heavily edited for my systems.
    - I'd advise against downloading it in this state.
    - But if you do, you will need:
      - This Repository: https://github.com/starikcetin/Eflatun.SceneReference.git#4.1.1
      - Odin Inspector: a paid tool, so you'll either need to buy it or remove the Odin Inspector References by hand.
        - I plan on eventually making an editor for this.
  - Optional Struct is from this video by aartificial: https://www.youtube.com/watch?v=uZmWgQ7cLNI
  - Serialized Interfaces is a property drawerthat allow interfaces and their derived classes to be viewed in the inspector
    - From this video by Git-Amend: https://www.youtube.com/watch?v=xcGPr04Mgm4
  - Thimble is a custom logging tool for Yarn Spinner that I wrote. Instructions are included in the package.
  - UI Tooling is a collection of UI editing tools for stylizing UI objects in Unity.
  - Variable References is a collection of Structs made to hold value references.
    - Based on this talk at Unite 2017 by Ryan Hipple: https://www.youtube.com/watch?v=raQ3iHhE_Kk.
    - Supports Float, Int, Bool, Vector3, & GameObject currently.
    - I plan to add more in the future as my systems require them.
  - World Shaper is my custom method of handling Scene Loading, Camera Movement, and Variables that depend on where the Player is in a Scene.
    - Based on these videos:
      - aartificial: https://www.youtube.com/watch?v=ZjfhGEziEEk&t=71s
      - Sasquatch B Studios: https://www.youtube.com/watch?app=desktop&v=CQEqJ4TJzUk
    - It is unfinished and currently a 2D-only system.
    - I'd advise against downloading it in this state.

GitHub: Packages from repositories that are available via GitHub that I've packaged to make them easier to import or send to other people. 
  - Auto Save saves scenes periodically at intervals you decide in your project settings.
  - Rename In Bulk allows you to rename multiple GameObject and Assets at the same time
  - A-Star_Pathfinding is, well pathfinding, for 2D games
  - Fungus is an older dialogue system with Unity Integration
  - Yarn Spinner is a popular, more updated dialogue system with Unity Integration

Project Set Up: My method of quickly setting up all the packages that I use in my projects. You can reconfigure it for your own purposes if you want.
