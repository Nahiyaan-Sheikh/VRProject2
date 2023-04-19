# project-2-NahiyaanSheikh
project-2-NahiyaanSheikh created by GitHub Classroom

Nahiyaan Sheikh!
![20220324_171725](https://user-images.githubusercontent.com/63805541/200925587-5a0aab7c-2f70-4070-9217-be56103c9da3.jpg)

I made an office or work simulation in VR. The user is placed in an office-like scenario, at first in a waiting room. There are two other characters around the player,
one also sitting and waiting, another one standing up. All characters in the simulation are reactive. The first two change animations as you get closer and farther
away from them. For example the man in the suit starts checking his shoes when you get close, and starts talking on the phone when you walk away (simulating he wants
privacy). Eventually, a secretary from down the hall will come down to show you the way to the bosses office. The woman stares only when not moving. In the boss office,
there is a final character who is the boss who turns around once you get close, including his chair. He also stares at the player, and brings his hand up to shake yours
once you get close enough. This could be used for people who get nervous in office spaces or waiting for any sort of interview, etc.
I did use assets from itch.io, which are free unlicensed assets. The assets I used were simply the office chairs, tables, laptop, etc. I still did use some of my own 
assets such as the lamp however. The link to the asset library from itch.io, by RRFreelance: https://rrfreelance-pixelburner.itch.io/low-poly-office-props

I ran into many issues trying to implement the root motion walking for the secretary. It took me a while to get it to actually look good and work. I also had some 
issues with the bosses hand, it would make the animation controller go crazy and not look right when I tried to tie his hand down to an object. For that same reason I was
having extreme difficulty trying to make it so you could actually shake his hand. I eventually got it down to a point where his hand was connected to a cube which was a
VR Grabbable, but making it a rigidbody so you can actually move it causes the whole animated model to mess up, so I decided to remove that feature. I was also having some
issues with the gaze feature, and the eyeballs would be rotated the complete opposite direction but I just realized the eye bones I made for the gaze were just rotated
the wrong way, easy fix.

The video file size was too big, included in the elc submission.

https://drive.google.com/file/d/1wjIjtHdJ7C-V9WXCEQ5IxPqQ5ddcDwFk/view?usp=sharing
