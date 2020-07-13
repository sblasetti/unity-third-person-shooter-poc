# Third person shooter tutorial

Tutorial playlist: https://www.youtube.com/playlist?list=PLJfktYG5YLJGK-ROk1Gj1_i8AtnIyeKTs

## Episode 1

- Setup

## Episode 2

- Research about pros/cons of retrieving components using getters versus getting them in Awake/Start

## Episode 3

- Uses an event in GameManager to hook up the local player to the camera:
  - On player Awake, it assigns itself as local player
  - GameManager triggers the event to notify that local player joined
  - The camera handles the event and gets a reference to the player
- Add the camera script to the MainCamera game object

## Episode 4

- Uses linear interpolation to handle camera movement transitions (LERP)

## Episode 5

- The projectile sets its own movement

## Episode 6

- A destructable handles its hits and damage and triggers events on hits and death

## Episode 7

- 2D textore rendering for the crosshair
