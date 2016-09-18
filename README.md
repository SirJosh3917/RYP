# RYP
RYP is the tool that will find and [R]emove [Y]our [P]asswords!

If you've been logging into EE and saving your passwords, or if you downloaded a bot and have been saving your password, RYP will find and remove your password!

# Cloning project into VS
Just clone this into your github desktop, and double click RYP.sln

# Directories
packages - This is where the nuget packages have been installed. Nothing fancy here.

RYP - This is a tool using RYPbin that finds, deletes, or saves your passwords.

RYPbin - This is the tool that is the fully functioning password finder and remover. This is the brains of the RYP operation.

RYPLauncher - This is the RYPLauncher. It automatically downloads files from this github repository and runs the latest version of RYP, so you never have to update and all your passwords will always be found using the latest password finding definitions.

WebDownload - This directory contains one file, that specifies what RYPLauncher should download and execute.