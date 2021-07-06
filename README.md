# TradeWinds custom game
 
#### Theme and Setting

The game is set in the historical Mediterranean region of the 18th century with elements of fantasy intertwined it in.

The elements of the game and the demanded interactions intra-game conveyed this theme with consistency, although with some aspects of the Modern world such as the names of the ports. These objects instead of being other characters in the game or hard-coded obstacles in a grid or maze, factor in the element of chance and luck as the interacting objects are real world places like the market or bazaar in the lanes of the Caribbean island harbours, the bank establishment and so on. The player visits these places at his/her discretion and avails the services provided there, rationalizing the requirement and the repercussion of the same. The only virtual enemy character is the chance encounter with the pirates when travelling between ports at sea. Progress is not made through any fixed benchmarks or levels, but the automatic deliberation of the character’s rank which is calculated based on their total wealth.


#### Target Audience 

On a general scale, this game project caters for a widespread audience with no restrictions as such. If one can interpret the basic rules of the game, they are welcome to explore it and become a user to the interface and submerge themselves into exercising all aspects of the game logic.
In particular two such user groups have been identified as part of the domain and background research and a few informal usability testing and the demographic surveys it comprises of. They are the category of people who either have an interest in the theme of pirates or sea traders in the ancient era, inspired by the pop-culture movies on the same, or those who have an inclination toward the basic practices of trade and the crucial elements of economy. Overall, the audiences who enjoy the simulation of a character set as a merchant who battles pirates while trading goods with essential business acumen are drawn to playing the game and are immersed in it from its commencement.



#### Real-world Mirroring

The game is interlaced with positive business connotations which is beneficial to learn and develop a strong and observatory business acuity along with the tricks of the trade, literally speaking. It prompts the player to take into account many information factors which weigh in heavily in financial decisions in real life. For instance, one is taught to invest in the bank saving when the bank’s interest rate is high in order for that to be cumulative to the principle and to take a loan when the interest rates are low for the same reason. Trading decisions to be made with more accurate predictions of them when the player slowly learns about the process ranges of each item in the market place in order to estimate when the prices are running low in the bracket to buy in bulk and know the highest rise in them one can expect when travelling to other ports in order to sell. Managing assets of the player for instance what proportion to keep in the bank and for what investments the withdraw seems ideal. For example investing in cannons and more ships in the player’s fleet which incur lesser damages when at battle with the pirates leaves the player with lesser repairs to address.
Within the one game, the character details are worked upon the one character, unless a previous setting is reloaded. And within one port visit the all building options are displayed the same once generated.


#### Coding Features 

The coding intricacies which are used to implement the game-Tradewinds’ plan are as follows:
        * The game was coded in C#. The Visual Studio 2019 IDE and text editor was used.
        * It is a graphical game and does not use any arguments passed by the command line.
        * It uses the WinForms open-source graphical class library provided by Microsoft .NET framework to create the forms as screens used in the game. Due to the potentials of this library a tiered approach of applying a suitable pattern merges seamlessly in the final solution and provides structure for this interface-dense game.
        * There are a total of 4 forms being used to design the final game.
        * The Model-View-Presenter pattern is being followed. This is explained in more depth later in the document


##### Class Elements 

        * The Character class hosts the Directory, Cargo, Backend and Ship classes as part of a Association relationship. Almost all classes in the Model have abstract properties because of the frequent access demands by the Presenter and occasionally the form classes. Also because a majority of them are involved in intense updation through the course of the game.
        * The Backend class keeps track of the time of travel of the player across the places using the DateTime and Timesan data types and performing calculation on them. This is an indication of the player’s progress in the game, hence determines the severity of the attack of the pirates, in order to encourage investments in the player’s fleet. This also takes into account the time factor used to calculate the interest on the assets.
        * The Islands class is responsible for initializing and placing the building when the player arrives on a port.
        * The Bank, Moneylender, Shipyard and Marketplace are a type of building in the Port form whose performing capabilities are within their respective Presenters, while their basic attributes in the Model classes.
        * The Pirates class carefully determines when the strike and the degree of damage to inflict taking in the necessary parameters like progress in the game, the defence it is up against (the player’s fleet) and of course probability.
        * The Savegame, Presenter classes and View interfaces are discussed exclusively later in the document according to their role in the game.


##### Inheritance and polymorphism:
One major points of inheritance were immediately identified as part of the abstraction process itself. Where Marketplace, Bank, Moneylender and Shipyard are all types of Buildings. It proved to be beneficial in its implementation as polymorphism in the Islands data member to be displayed in the Port form and to be worked upon by the Presenter classes and Port form. This ensured that it wasn’t initiated or reset repetitively when the building was opened within the same Port.
The other which branched off this very same idea, in the Presenter classes is a Presenter of these buildings as they showed commonality in the methods each one was implementing in their display window on the port. In the parent class of BuildingPresenter, placeholder methods of all core functionalities of each building are mentioned as abstract method declarations and is implemented in their respective specialized ways in each of the subclasses. In the Port Form, there is onlyone instantiation of the object of BuildingPresenter class. Its derived classes are methods are called according to the Buidling selected by the user within the labelClick methods.

In the Port form one method each of two subclasses of BuildingPresenter are invoked. In order to use the same variable name of the parent in the function call, these two methods have also been given placeholders in the parent class as a virtual method with empty definitions. They are eventually overriden in the same way as the abstract ones in these two specific subclasses.

Function overloading is implemented in the ShipyardPresenter class. This class deals with displaying and managing the Shipyard building window in the port. This building provides two service options to the player. First is that of repairing the ship when its damaged from the battle with the pirates. The second is buying cannons and ship upgrades to strengthen the player’s ship in the next battle. Since both deal with the player setting the desired quantities- points of repair for the ship, the number of cannons for purpose and the level of ship set for upgrade. The UpdateQuantity method has two function signatures (different) catering for these two different needs. Similarly the Total method, which displays the quantity multiplied by the prices set is also overloading for the same purpose.
This gave a streamlined view to the programming structure and decluttered the form class from individual instantiation and multiple object use. Since, the buildings are a major portion of what the game is, it became a vessel for me (pun intended) to implement the inheritance and polymorphism dimension of OOP, using the techniques of abstract classes, virtual and overriding methods appropriately. The iterative nature of design in the OOP paradigm was instrumental in me taking all the inputs from current stages in developing the code and being open to be receptive to the emerging patterns and needs of the code and game. This provides flexibility and stability to the programs making the software extensible.

Communication between the objects and other class data members, seen by invoking methods, customizing and manipulating display, was essential in the operation of the final game and was accomplished with the use of the Model-View-Presenter or MVP model.


##### Additional Elements 

        * Model-View-Presenter Design pattern-
MVP is an architectural pattern. It is ideally deployed in the user interface development arena. It is a subset or a more specialized version of the Model-View-Controller or MVC pattern.
The model is the structure of idea.
The View handles the display data and should have no logic within it. The View folder contains the interfaces which communicate the information of the labels, buttons and other UI elements from the form (where it is implemented) to be utilized and managed by the presenter class where the interface is instantiated and accessed.
The Presenter or the Controller hold the operational reigns of the game. It does not know the implementation of the view but takes the access given to it by the view to work on the form fields or UI elements. The presenter classes inhabits the main logic and operational changes in the game taking into account all layers, the model classes, the form elements via the View interfaces.

Multiple interfaces according to their different functionalities are implemented using multiple inheritance form in C# and the only inherited parent class, the default Form class is left undisturbed.
To reduce coupling when transferring the labels and buttons to be programmed and worked upon to the Model via the controller. Only its information and relevant contents are passed worked up and then returned for display. This keeps the UI elements within the target interface of the form, only its information is sent through the different layers via the View interfaces.
To minimize dependencies there's really no gain in having the view knowing anything at all about its presenter. There's an agreed contract between the presenter and the view and that's stated by the view interface. So in summary:
            * The presenter doesn't have any methods that the view can call, but the view has events that the presenter can subscribe to.
            * The presenter knows its view. I prefer to accomplish this with constructor injection on the concrete presenter.
            * The view has no idea what presenter is controlling it; it'll just never be provided any presenter.




        *I have used the Winform Timer UI element from the toolbox. This was used to implement the animation effect of the ship image on the Map to sail between the ports when the next destination is chosen. However, using the threading library methods (Task.delay()) for setting the timing and movement changes was more cohesive with the other operations wanting to happen during the transition and also gave a better performance at run time. Hence, the timer control was replaced with the regular embedded method call for a time delay within the loop.
        * I have also used the progress bar slider as another way to get the information about how much of your cargo space has been taken up by the goods and canons bought on the ship. I have invoked EventListener methods of the form class within other methods.
        * the HoverOver mouse feature in the Characterscreen to read the description and name of the character.
        * the Key Press down feature was attempted to be used for increasing the speed of the ship moving across the Ports on the map. However, the limits of this was that it was only able to detect it within a textbox control.
        * An audio file has been loaded into the Map form class in order to play, resume and stop the sound in the background while the transition of the ship occurs.
        * A text file is parsed in to read the character background stories as descriptions to display on the CharacterChoice screen.

        *Saving and Reloading previous game Settings
The core and pivotal element being manoeuvred and at the center of the network being modified and weaved around it is the one class of the Character. It is instantiated only once through the runtime of the game. Due to this, saving the object of Character class itself at any point in the game after its initialization would make that very game redeemable. This virtuous configuration of the game allowed me to research into how to save and load an object into and from a file.

            * With the appropriate XMLSerializer assembly reference I segregated the code in a separate static class called Savegame. I added in the appropriate catching and throwing of potential exceptions and errors. And added the simple calling statement in the LandingScreen and Map form as required.


##### Developer's Note

It was a great opportunity to learn how to reverse engineer an idea seems fairly straightforward on the surface level and its goals in terms of a game. But to see within the layers the root of the functionalities and to carve out the interactions and dependencies, not only allows you to implement the idea and all the what-if extensions one had envisioned but also see the various routes which can be taken and to weigh them out to champion the best of them (a comparative study is a part of the research project)
On a personal stance, I was on the client-side of this game for a few many years as my Dad used to explain the extravagant real-world concepts of the trading of goods, the travelling salesmen, voyaging on the seven seas to develop the sense of predicting the favourable numbers and most importantly how one allocates and manages ones monetary assets in a judicious manner in order to reap maximum returns.
It was a great joy seeing this game come to life and sometimes just end up playing it like a user letting leisure take over than equip the critical eye towards it constantly. Furthermore, it continuously excited me to think of more feature to add to it as well as learn the essentials of troubleshooting and constantly adapting your design for the better.