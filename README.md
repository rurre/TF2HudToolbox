# Hud Toolbox
A tool complete with a GUI used to install Team Fortress 2 huds as well as a few extra features.

It compares custom huds with the default hud and strips all values matching default, leaving only the custom values in files. It then zips all this custom data into blueprint files that the intaller can understand.
When installing a hud it will extract fresh default hud files and apply the blueprint on top, ensuring a more or less up to date version with little conflicts. 
This way anyone can keep their custom huds up to date, even update outdated ones with a few clicks.

This tool also features an option to combine two existing huds into one by making use of  cl_hud_minmode 1 and 0. Ideally you'll be able to switch between 2 completely different huds with this command while ingame in a few seconds.

Planned for later:
Options to customize huds by selecting features from a list given by the hud creator, which is also packed into the blueprint file.
