In this project, you’ll become a hero navigating a fantasy world filled with obstacles, treasures, and enemies. Your journey through this realm will require the use of multiple data structures, each essential to overcoming challenges and advancing in the game. You may use code from previous projects, and internet, however, you will be asked to explain your code, should you be unable to explain it, you will be heavily docked points, up to a full zero. Never use code you don’t understand.

### Objective

Create a fantasy adventure game where:

- You design a character with specific abilities.
- You navigate a randomly generated map represented by a graph.
- Each room (node) in the map presents a unique challenge or task.
- Challenges are organized in a binary tree of obstacles, which you’ll need to interact with according to each room’s number.

### Instructions

## 1. Character Creation

##### Define Your Hero

- Create a character with the following attributes:
- Strength (affects combat ability)
- Agility (helps evade traps)
- Intelligence (useful for solving puzzles)

#### Inventory Management

Your hero has limited inventory space holding 5 at most. Should you get a 6th item, discard the first item you received. Start with two items.

### 2. Map Generation

- Create the Map Using a Graph

- Represent the map as a graph, where each node is a room or location in the realm.
- Edges between nodes represent paths that connect rooms, some of which may require high Strength or specific items to pass through.
- Each room has a unique number (e.g., Room 1, Room 2).
- Navigate the Map

Traverse the graph from one room to the next. Each new room presents a challenge based on its number.

### 3. Binary Tree of Challenges

Set Up Challenges in a Binary Tree

Each node in the binary tree represents a challenge you might face in a room.
Nodes in the binary tree are assigned numbers that correspond to difficulty levels or challenge types:
Lower numbers represent easier challenges.
Higher numbers represent more difficult tasks.
Examples of Challenges:

Puzzle (requires Intelligence)
Combat (requires Strength or items like a sword)
Trap (requires Agility to avoid or Intelligence to disarm)
Challenge Selection

When entering a room, use the room’s number to find the closest matching node in the binary tree.
For example, in Room 5, search the binary tree for the challenge closest to 5. This node represents the task for that room.
Challenge Completion and Removal

Once a challenge is completed, remove its node from the binary tree and rebalance the tree.
If you re-enter the same room, find the next closest challenge node. Track paths using a structure (e.g., a stack) to avoid repeating dead-end paths by removing those edges from future options.

### 4. Example Encounters and Rules

Scenario: You enter Room 7 in the graph:
Room 7’s number is used to locate the closest challenge node in the binary tree.
The closest node is 8, which is a combat challenge.
Combat Challenge: Requires Strength > 5 or a sword to succeed.
Outcome: If your character’s Strength or items allow you to win, remove node 8 from the binary tree. If you don’t meet the requirement, you lose health points based on the difference. If health reaches zero, you lose. Upon loss, print at least one successful path to the end goal.
Exploring the Map and Facing Challenges

Continue exploring the graph, visiting new rooms, and facing challenges based on room numbers.
As you complete challenges, the binary tree thins out, revealing new challenges in unexplored rooms. If you exhaust all challenges, your character succumbs to the darkness, becoming a vengeful zombie with doubled stats, and is added as a formidable enemy in future combat encounters. 5. Winning Condition and End Goal
Treasure Collection: As you complete rooms, have a low chance to earn a treasure. Treasures are stored randomly in a structure that allows you to remove the last item added first. Each treasure can be redeemed at the end for bonus points or used to help with obstacles.
(Optional) Final Room: The last node in the graph may lead to a final treasure room or boss challenge, requiring specific abilities or items.
(Optional) Until You Fall: If you beat the dungeon, restart and see how many times you can clear it.
\*\*\*You must also implement a dictionary somewhere in your code.
Submission: Github repo to a c# console app

Sample Items(not required to use)

Potion of Strength - Temporarily boosts Strength by +3 for a single challenge.
Smoke Bomb - Automatically evade one trap or enemy encounter.
Puzzle Hint Scroll - Provides a hint for solving one puzzle.
Health Elixir - Restores 10 health points instantly.
Combat Charm - Increases Strength by +5 in one combat encounter.
Trap Disarming Kit - Instantly disarms a single trap.
Lockpick - Opens one locked room or passage.
Torch - Lights up one dark area or room.
Map Fragment - Reveals the shortest path to the next unvisited room.
Strength Charm - Temporarily doubles Strength for one combat encounter.
Silent Cloak - Allows stealth passage through one guarded room.
Antidote - Neutralizes poison from one trap or enemy attack.
Magic Mirror - Reflects a single spell or magical attack back at the caster.
Energy Crystal - Replenishes stamina, allowing you to temporarily increase all stats by 2.
Enchanted Key - Bypasses one magically sealed door.
Sample Obstacles(not required to use)

Locked Iron Door

Stat: Strength > 8
Item: Lockpick
Bottomless Pit

Stat: Agility > 7
Item: Rope of Escape
Enchanted Riddle Wall

Stat: Intelligence > 9
Item: Puzzle Hint Scroll
Sleeping Dragon

Stat: Agility > 6 (to sneak past)
Item: Silent Cloak
Poisonous Gas Trap

Stat: Intelligence > 5 (to identify and avoid the trigger)
Item: Antidote
Magic Barrier

Stat: Intelligence > 10
Item: Magic Mirror
Heavy Boulder Blocking Path

Stat: Strength > 10
Item: Potion of Strength
Narrow Cliff Walkway

Stat: Agility > 8
Item: Smoke Bomb (to distract nearby creatures)
Ancient Puzzle Gate

Stat: Intelligence > 7
Item: Enchanted Key
Guarded Treasure Room

Stat: Agility > 9
Item: Silent Cloak
Swamp of Sluggishness

Stat: Strength > 6 (to wade through)
Item: Energy Crystal (to maintain stamina)
Spike Floor Trap

Stat: Agility > 7
Item: Trap Disarming Kit
Labyrinth of Shadows

Stat: Intelligence > 6 (to remember the path)
Item: Map Fragment
Haunted Mirror Maze

Stat: Intelligence > 8
Item: Magic Mirror (to deflect ghostly illusions)
Raging River Crossing

Stat: Strength > 7
Item: Rope of Escape
Enchanted Forest of Confusion

Stat: Intelligence > 5 (to navigate without getting lost)
Item: Compass
Treacherous Mud Pit

Stat: Agility > 5
Item: Health Elixir (to recover after crossing)
Cursed Idol

Stat: Intelligence > 9 (to break the curse)
Item: Puzzle Hint Scroll
Fiery Gates

Stat: Agility > 6 (to avoid flames)
Item: Smoke Bomb (to obscure and shield)
Frozen Lake

Stat: Strength > 9 (to break through ice)
Item: Torch (to melt the ice)
