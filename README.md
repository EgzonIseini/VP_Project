# BBTAN (FINKI)

### 01. Introduction
**BBTan** (FINKI) - is an attempt to recreate the widely famous and popular BBTAN game, whose popularity is especially noticeable in mobile devices. We felt that the re-implementation of this game would be an ideal project as it covers the more important aspects of the Visual Programming course, especially painting using Windows Forms.

In the following documentations we have outlined the more important things of the project and the implementation itself. For anything else, the demo of the game and the source code can be checked.

---
### 02. The Game

The game of **BBTan** (FINKI) was implemented in a fixed size window with an 9:16 aspect ratio. The window is of fixed size to make the implementation easier and to assure that the game will be playable on most modern screens.

The main view of the application features three distinct windows:

 1. The top navigation bar, which includes options such as **"New Game"** - to start a brand new game of BBTan, **"Fast Forward"** - speeds up the game etc.
 2. The main window which includes the game and gameplay itself.
 3. The bottom status bar, which shows the current score and also any power up you might have active.

![Main Window](https://user-images.githubusercontent.com/44554619/60683806-2e45f680-9e9a-11e9-93ee-5f62b4968f5b.png)

Not every detail from the original game of BBTAN was implemented fully. We took the liberty of retaining only the main aspects of the game and altering everything else as we saw fit for this project. Hence one main aspect of the game that was altered were the power ups, as we implemented different powerups than the original in order to make the whole experience more entertaining and glitch free.

The gameplay is very simple and straight forward:

> A new game starts with the score set to 0. In the game you have a "launch" from which a sequence of balls is launched from (in the above picture, the white circle on the bottom of the window). The launchpad is set to a random horizontal position (its vertical position remains always in the same place).
> 
> A new row of blocks is generated in each round. In the beginning there is only one row. At random spots in the window at specified row, either a square block with a predetermined amount of HP (Health Points) is spawned or a power up (ellipse shape).
>  
>  At every round the rows go down by one level, while on top a new row is generated (same procedure as above).
>  
>  The objective of the game is to destroy each and every square block, for as long as possible. The mouse is used on the main window to launch a series of balls (initially just one ball is launched per round) and hit the different square blocks. If no damage multiplier is active, the ball hitting a square causes -1HP damage to the square. If the square reaches 0, it is thereby destroyed.
>  
>  The balls are launched in the direction of the mouse click. Initially only a single ball is launched in the direction of the click and goes on until it reaches the bottom where it is destroyed. If there are more balls in the launchpad, each and every one of them launch at the direction of the mouse click and their path may vary. When all the balls is destroyed i.e. the last one reaches the bottom, the round ends. The launchpad position moves to the place where the first ball fell, the power ups for that round are cleared and the rows go down by one level.
>   
>   If the first row (most bottom one) reaches the end of the screen (i.e. launchpad), the game is lost.

### 03. The Powerups

The game has 5 power ups that serve temporary buffs to elements of the gameplay. They appear randomly during the gameplay in place of normal blocks. When a launched ball goes through the power up, it is picked up and will be automatically activated in the next round. Power ups stack up, hence multiple unique power ups or same type of power ups might be active at the same time at a given round. The power ups are as following:

 - ( +1 ) power up - adds a ball to the launchpad. Initially in a new game the launchpad starts with only one ball, hence it can only launch one ball per round. When this power up is picked up, the amount of balls a launchpad can launch is increased by one. This power up lasts till the end of the game i.e. does not disappear when round ends as other power ups.
- ( Coin ) power up i.e. Score Multiplier - when this power up is picked up, in the next round the score multiplier increases by one (initially its always 1). This means that instead of getting one score per -1HP damage of a square block, with this power up active, the score received is **1HP damage * Score Multiplier** ex. if you had a score multiplier of 3 (picked up 3 powerups of this type on the previous round), instead of score 1 you'd get 1 * 3 = 3 score.
- ( 2x Damage ) power up i.e. Damage Multiplier - picking up this power up buffs in the next round the HP damage done to a block by **x** amounts. If your initial HP damage per block is 1 (default) and you have Damage Multiplier x3, for every square block the damage done to it by a ball would be **-1HP damage * 3 = -3HP damage** .
- ( 2x Balls ) power up i.e. Balls Multiplier - having this power up active in a round means that the launchpad will launch **x** times the balls at the given round. If you have 10 balls in the launchpad (from previously acquiring 9 (+1) ball power ups) and a Ball Multiplier x2, in the given/next round instead of 10 balls the launchpad will contain **10 balls * 2 = 20 balls**.
- (FINKI) power up i.e. Secret Level - due to time constraints not implemented. The idea was for this power up to be super rare. Its main objective would be to remove all the square blocks in the level and replace them with new ones in the shape of the FINKI logo ( IO ). This would be useful if the rows are almost at the bottom an this power up was picked up as it would reset the level to something a bit easier. Gameplay would continue as normal.
