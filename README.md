# MetaTagger
<a><img src="https://img.shields.io/badge/.NET Core-10.0-blue.svg"></a> ![](https://img.shields.io/badge/TagLibSharp-2.3.0-brightgreen.svg) ![](https://img.shields.io/badge/Avalonia-11.3.12-brightgreen.svg)

A lightweight cross-platform application that allows you to edit tags in the meta data for audio files (`.mp3`, `.wav`, `.m4a`, etc.) on Windows and Linux.

![application in use](https://raw.githubusercontent.com/NikoBK/metatagger/refs/heads/master/Example/readme/app.webp)

---
## Installation
To run MetaTagger, download the latest release from the [Releases](https://github.com/NikoBK/metatagger/releases) page. Check the release notes for which version of the attached zip files to use. Once downloaded extract the contents of the zip folder and make sure everything is contained within the same folder. On windows run `metatagger.exe` to use the application. On Linux run the `metatagger` binary.

---
## Usage
1. Browse, load and edit a single audio file. Selecting a valid audio file will enable all other controls (3, 4, 5, 6, 7, 9 and 10)
2. Browse and select a folder containing one or more audio files. Good for bulk editing audio files that share composers, album and cover image. Selecting a valid audio folder will enable all other controls (3, 4, 5, 6, 7, 9 and 10). Applying changes to the meta data with this load option will apply the contents (unless empty) of each text field to every audio file (be cautious with the `Title` field)
3. The path of the audio file (or folder path) that you have selected and are currently editing for
4. The title of the audio file. This appears as the name of the audio in most media players (VLC, Spotify, WMP)
5. Composers of the audio file, seperated by comma (i.e. `Person A, Person B, Person C`
6. The album that the audio file belongs to (useful for local files in Spotify)
7. The description of the audio file. Usually not visible in media players but can easily be accessed
8. The cover image of the loaded file. When loading a single file this will display the current cover image if the loaded audio file has one, otherwise it will be blank or updated to be the one you browse using (9). **Please note**: The image is only applied to the file after (10)
9. Browse your file system for image files (png, jpg, jpeg, PNG, etc.) to be used for the audio file's (or every audio file in the folder depending on what load option you picked)
10. Applies every change you have made to the meta data by filling out the text boxes and browsing for a cover image. If any textfield is left blank the application will not apply any change to the associated meta data.

![user interface](https://raw.githubusercontent.com/NikoBK/metatagger/refs/heads/master/Example/readme/ui.webp)

Extra: This repository includes example cover art and a audio file located in the `Example` folder. All copyright and trademark rights belong to [Lashlie](https://soundcloud.com/xd-sj) who composed `Smooth` and created the example cover art. The inclusion of these files do not grant anyone the rights to sell, redistribute or use the files outside of their intended purposes.

---
## Credits
A big thank you to [Lashlie](https://soundcloud.com/xd-sj) for letting me use his work to demonstrate the use of this application with his music. Additionally thank you for helping me test and optimize this application.

---
## Disclaimer
This application is not intended to be used for music piracy, it is a utilization tool to quickly edit your own audio files that have been legally obtained for use in popular media players like Spotify.
