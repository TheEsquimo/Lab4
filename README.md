# Lab4
Elvis Sahlén &amp; Luna Lindh's Lab4

=====CLASSES=====
* Properties should always be private when possible. Use get, set

class Player
    * Inventory

abstract class MapTile
  * subclasses:
      * Room (.)
      * Door (D)
      * Wall (#)
    
abstract class Item
  * subclasses:
    * Key (K)
    
class LevelMap

interface IMapSymbol
  * Interface for all classes that are represented as a symbol on the map
      - Contains string property to store symbol
   
   
=====MAP SYSTEM=====
* Enum to represent tiles
* Map should always be rectangular
* WASD to move
* Fog of War
    - Adjacent tiles to player horizontally and vertically are revealed after movement


=====USEFUL FUNCTIONS=====
Console.ReadKey  (använd för att ta emot kommandon från användaren, t.ex. WASD för förflyttningar)
Console.Clear
Console.BackgroundColor, Console.ForegroundColor, Console.ResetColor 

=====GAMEPLAY=====
* Show score
* At least three people to test the game, store their highscore as comment in code
* Superkeys
  - At least 1 of the following:
    * Different colored keys, only usable with associated door
    * Keys have durability, and can be used an amount of times before breaking
    
* Other extras:
  - At least 3 of the following:
    * Obstacles that can be deactivated through buttons (located in certain rooms)
    * Traps that costs extra moves
    * More items to be used on monsters or doors or that give points
    * Hit-point battles
    * Invisible rooms that doesn't reveal what's inside before the player enters
    

