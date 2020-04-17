# Elad's Migration Tool
This tool helps you install add-ons that are compatible with some simulators based on Microsoft's ESP (such as FSX and Lockheed Martin's Prepar3D) to other simulators that are not officially supported by the add-ons' makers.  
This is the original program along with its source code.  
This is the same tool that was previously available on www.migration-tool.co.nf.

## Table of contents
- [Disclaimer](#disclaimer)
- [Download](#download)
- [Requirements](#requirements)
- [How to use](#how-to-use)
- [Warning](#warning)
- [Screenshots](#screenshots)
- [FAQ](#faq)
- [Credits](#credits)

## Disclaimer
This program is still in Beta stage and although unlikely, it may cause problems to your simulators.  
I will not be responsible for any damage this program may do to your simulator nor to your computer.

## Download
You can download the compiled program from the following link: [Download](https://github.com/eladcn/migration_tool/raw/master/MigrationTool.exe).

## Requirements
* Windows operating system (tested on Windows 10 but should support all versions).
* Microsoft .NET Framework which can be downloaded through [here](https://www.microsoft.com/en-us/download/details.aspx?id=17851).

## How to use
1. Select the simulator that the add-ons that you want to install are applicable to - you don't need to have this simulator installed!
2. Select the simulator you would like to install the add-ons to.
3. Press on "Start Migration".
4. Install your add-ons and if required in the installation process - choose the simulator which the add-ons are applicable to (for example FSX if you want to migrate from FSX to Prepar3D).
5. When done installing your add-ons, press on "Stop Migration".

## Warning
Do not force close the program using the Task Manager!  
Doing so may break your simulators' configuration files!

## Screenshots
![Main](/screenshots/1.png)

![Settings](/screenshots/2.png)

![Config Files Restoration Tool](/screenshots/3.png)

## FAQ
Q: When I run the program the following error shows up: "The program could not identify any simulators to migrate to on this computer.", what do I do?  
A: It is most likely that the program could not find any prepar3d simulators on this computer, and therefore it can't do anything.

Q: May I modify the "history.log" file?  
A: You should NEVER touch this file! Deleting or modifying this file means that the changes made by the program may not be reversable by the program!

Q: Why does this program require Administrator Priviliges?  
A: The program requires Administrator Priviliges in order to change the simulators' registry values properly.
   Also, sometimes the simulators' folders require Administrator Priviliges in order to change their content.

Q: Which simulators does this program currently support?  
A: The program currently supports Microsoft Flight Simulator X (FSX), Microsoft Flight Simulator X: Steam Edition (FSX Steam Edition), Prepar3D, Prepar3D v2, Prepar3D v3 and Prepar3D v4.

Q: Is it possible to reverse the program's changes?  
A: It is possible to reverse the changes made to the registry by pressing the "Stop Migration" button.
   It is also possible to restore the original configuration files by using the "Restore Config Files" tool that can be found in this program's menu.
   The program cannot uninstall add-ons that you have installed using this migration tool.

Q: Can I restore manually the config files of the simulator I am migrating from?  
A: If something went wrong and the program was unable to restore the config files, you can find the backup files under a folder called "migrationBackup"
   in the same paths of the simulator's configration files.

## Credits
Elad Giladi - QA for the initial release.  
Josh Heard - Helping me debug an error.  
Adolfo Cruz Hooly - Helping me debug an error in the initial release and version 0.3.0 beta tester.  
Farhad Ahmadi - Version 0.3.0 beta tester.  
John Blanch - Version 0.3.0 beta tester.  
Leemar Yarde - Version 0.3.0 beta tester.
