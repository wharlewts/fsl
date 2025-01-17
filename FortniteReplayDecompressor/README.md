Fortnite Replay Reader App

This project is a console application built against FortniteReplayDecompressor. It processes Fortnite replay files and outputs their data in JSON format.

Features
	•	Parse Fortnite replay files into structured JSON.
	•	Optionally save the output JSON to a file or display it in the console.
	•	Built with .NET 6 and compatible with Linux (self-contained binary).

Build Instructions

Prerequisites
	•	.NET SDK 6.0 or higher
	•	Linux environment (or compatible tools for your OS)

Steps to Build
	1.	Create a new .NET console project:

dotnet new console -n FortniteReplayReaderApp
cd FortniteReplayReaderApp


	2.	Add the FortniteReplayReader package:

dotnet add package FortniteReplayReader


	3.	Copy the program logic:
	•	Replace the contents of Program.cs with your application code.
	4.	Publish as a single self-contained binary:

dotnet publish -c Release -r linux-x64 --self-contained true /p:PublishSingleFile=true -o ./publish


	5.	Run the application from the publish directory:

./publish/FortniteReplayReaderApp

Usage

Command-Line Options

Option	Description
--file, -f	Path to the Fortnite replay file (required).
--output, -o	Path to save the JSON output (optional).
--help, -h	Display help and usage information.

Examples
	1.	Process a replay file and print JSON to the console:

./FortniteReplayReaderApp --file UnsavedReplay.replay


	2.	Process a replay file and save the JSON to output.json:

./FortniteReplayReaderApp --file UnsavedReplay.replay --output output.json


	3.	Show help:

./FortniteReplayReaderApp --help

Reference

This project is built on the FortniteReplayDecompressor library.

License

The application and its dependencies are subject to their respective licenses. See the LICENSE file for more details.

