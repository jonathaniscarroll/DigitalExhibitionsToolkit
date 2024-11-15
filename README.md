# DigitalExhibitionsToolkit
 The Mackenzie Art Gallery's Digital Exhibitions Toolkit

# Installation
Using the github repository, either clone the repo into your Unity project's asset folder, or download and place it directly into the Assets folder.

# Scenes
Use the scenes to preview various installations of artwork.

# Prefabs
This folder contains the prefabs used for artwork installations, detailed below, organized by medium:

    - Video
        
        In Unity, videos can be loaded in two ways; via a file imported into the unity editor, or through a URL for a video hosted outside the application that will be built from Unity.
        
        URLs are generally prefered, as it reduces the file size for the resultant application. For WebGL builds this is a requisite, as the Unity file in the browser cannot host a video file itelf.
        
        For hosting options, the file must be hosted on a site that has cross-origin resource sharing (CORS) enabled. This can be your own server, or a web service like AWS. AWS is relatively easy to use if you have the funds for it, it charges you an a usage basis. A service like AWS will require you specify that each file be publicly read accessible, and then set the CORS access as follows:
        
        [
		    {
		        "AllowedHeaders": [],
		        "AllowedMethods": [
		            "GET"
		        ],
		        "AllowedOrigins": [
		            "*"
		        ],
		        "ExposeHeaders": [],
		        "MaxAgeSeconds": 3000
		    }
		]
		
		Each video prefab contains a component called "SetVideoUrl", the url you paste into the VideoURL field will be applied to that prefab's video player.
		
		There are three types of video prefabs:
		
		Video-2D
			This plays the video within a UI Canvas, using a RenderTexture to send a video from the VideoPlayer component to the image contained within the Canvas. The video will be displayed as an overlay across the whole screen.
		
		Video-3DFlat
			This plays the video as a texture on a flat plane in 3D space. 
			There is an optional gameobject contained within called FacePlayer, if enabled the plane will always face the player (known as billboarding)
			
		Video-3D360
			This plays the video as a texture wrapped around an inside out sphere, so that that video will surround the player when they are inside of the sphere. This can be used as a means to play 360 videos in 3d spaces, that the player can choose to move in and out of.
			
		Video-360Skybox
			This makes a video play on the skybox, the background of the Unity scene. This is good for 360 videos, ensuring that the player will always be at the centre of the video.
			
			

        



