# MacSG
GUI frontend for Streamlink.  Developed for the NecroDancer racing community.  You can grab the latest version by grabbing the most recent setup.msi from the [releases](https://github.com/necrommunity/macsg/releases).

Feel free to use the [Issues](https://github.com/Necroummunity/MacSG/issues) tab to request features.

All credit for [Streamlink](https://github.com/streamlink/streamlink) goes to the fine people that continued on Chirppa's work.

## Getting started
Download and install the most recent release's `setup.msi`.  Additionally, you'll need [VLC Media Player](https://www.videolan.org/vlc/download-windows.en_GB.html) and [Streamlink](https://github.com/streamlink/windows-builds/releases).  Open MacSG, type a valid Twitch username into the streamer box, and click the "Generate".  A VLC window should open with the stream playing, titled "First - VLC Media Player".

### Automated text sources
MacSG outputs the streamer names and pronouns provided into plain text files, located at `%AppData%\MacSG` (which can be opened via File > Open AppData Folder).  You can use these inside OBS using the Text GDI+ source type, and checking the "Read from file" checkbox.  By default, streamer names and their pronouns are written to 2 separate files, e.g. `streamer1.txt` and `streamer1-pronouns.txt`.  You can write both the name and pronouns to one file by clicking File > Combine Names and Pronouns, which for `MacND;He/They` results in an output format of `MacND (He/They)`.

### Installing the macsg: protocol
MacSG can be configured to automatically generate streams upon clicking a link or entering one in your browser.

Run MacSG as an Administrator and then select `File > Install macsg: protocol`.  When prompted, restart your computer to finish the installation.  Installing this will allow you to click links to automatically open MacSG.  An example would be `macsg:macnd;he/they` which will open MacSG, aut-opopulate the first streamer details with MacND and He/They pronouns, and then open the stream in VLC.  You can test this functionality by typing `macsg:macnd;he/they` into your browser window. 
