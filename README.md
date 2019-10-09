#MinecraftGoogleImages

Compatible with all version, just select the .jar

##Change settings :
Resolution (64x64, ...)
Resize mode
Tag to add to the search (e.g. blue)
The index to take, from 1 to 20, or randomly
How to fill the background (out of the image when not taking all the area), transparent or fixed color
Aditionnal query tags (e.g. "&tbs=ic:specific,isc:red" for google to search for red images)

##How to use : 
###Buttons :
"Select jar" : Select the jar file that will be used when clicking "Extract jar". If none selected, it looks for any in the data folder (data folder is created at the root directory of the exe)
"Extract jar" : Extract all .png files found from the jar. It outputs to data\work
"Get images from web" : Search individual png files replacing '_' by spaces, and adding the '-minecraft' to have almost no result from minecraft. It then download it, resize, and copy to the data\output folder
"Cancel task" : Cancel task...
"Open data folder" : ...
"Create zip" : Create the zip to be used as resource pack (pack.mcmeta also created with this button)
"Copy to ressource pack folder" : Search the minecraft resource pack folder and copy the created zip to this location

###Settings
The first two boxes are for the resolution, x at the top and y at the bottom. Enter any integer value greater or equal than 1
The selection below is how to resize it, with resize (stretched), keep the ratio with either (x taking all the width, y taking all the height, or auto)
Click the checkbox to enable aditional search tags just below. Add spaces between each
Enter any number between 1 and 20, or select random. It will take the image at this index rather than the first one
How to fill the background, with fixed color or transparent. Click the small square at the right to change the color
Transparent image only search for images that are transparent (saving them as transparent doesn't work so it's disabled for now)
Aditional query tags

The right-most box is the view of folders in the data\work directory. Click the update once a jar has been extracted to see it.
You can exclude directories. Any files in the ones not checked will not be changed by the ones on google images.
RECOMMENDED : Keep font, gui folders disabled because they contains the letters and the user interface. This will be a mess if you change them (it's already a mess btw)

At the bottom is a progress barr, with a status label and the number of png files found in the data\work directories. This number don't depend on the selection of the folders



