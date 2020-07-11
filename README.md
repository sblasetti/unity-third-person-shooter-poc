# Third person shooter tutorial

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
