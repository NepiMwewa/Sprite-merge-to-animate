# Sprite-merge-to-animate
This program is to take named values and pull them from a list array of Sprite Library Asset(spritesheet). It then takes each sprite based on index and layers them on top of each other to create a single layered sprite. It does this for the whole spritesheet and then updates the SpriteLibrary to take the spritesheet. This spritesheet is then given to the spriteLibrary/spriteResolver to display the new textures for the animations.

This allows to have multiple different colors and styles of hair, armor, eyes, weapons while not having to each variation into a single layer. While also keeping the rendered image as a single layered image.

Because I am using a single rendered image, it makes it possible to only create 1 animation for the sprite, then editing the images afterwards and simply plug them into the sprite resolver without having to animate each variation.

The next step is to implement it into my game where when you change clothes, weapon or load, it will display the correctly single layer render.

See also https://github.com/NepiMwewa/aseprite-tools, this is a useful export tool to export the different sections of layers, as well as the animation type. For instance, walk-down_eyes will it's own spritesheet, walk-left_eyes will be another spritesheet. After drawing, coloring and animating it in Aseprite, it would take too long to export each layered/animation section. So this tool will export all of them separately.

![Capture](https://user-images.githubusercontent.com/17126294/189271479-24dd164d-3057-4c47-b379-da3ebdd99661.JPG)
Change this Value from "Armor" => to "Peasant" then click update graphics

![Capture2](https://user-images.githubusercontent.com/17126294/189271574-a413e688-7302-4788-8d33-58191d46c01f.JPG)
It changes the animations.

![Capture3](https://user-images.githubusercontent.com/17126294/189271592-0edfa531-873a-40f0-9770-269627bc2ddc.JPG)
Before

![Capture4](https://user-images.githubusercontent.com/17126294/189271622-b4990ef1-13a7-4457-b9ed-b997efa09919.JPG)
After

It works, but it still needs more work. The update graphics is just simulating when your character changes a sword or clothes. It only renders out the layered spritesheet once. So after that it is the normal cost of animating a 2d spritesheet.
