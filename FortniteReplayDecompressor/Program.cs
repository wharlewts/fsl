/*
MIT License

Copyright (c) 2020 Shiqan

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

This file incorporates code from https://github.com/Shiqan/FortniteReplayDecompressor,
licensed under the MIT License.
*/



using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FortniteReplayReader;

class Program
{
    static void Main(string[] args)
    {
        string replayFile = null;
        string outputFile = null;
        bool showHelp = false;

        // Parse command-line arguments
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--file":
                case "-f":
                    if (i + 1 < args.Length)
                    {
                        replayFile = args[i + 1];
                        i++; // Skip the next argument as it's the value
                    }
                    else
                    {
                        Console.WriteLine("Error: --file requires a file path.");
                        return;
                    }
                    break;

                case "--output":
                case "-o":
                    if (i + 1 < args.Length)
                    {
                        outputFile = args[i + 1];
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Error: --output requires a file path.");
                        return;
                    }
                    break;

                case "--help":
                case "-h":
                    showHelp = true;
                    break;

                default:
                    Console.WriteLine($"Unknown option: {args[i]}");
                    showHelp = true;
                    break;
            }
        }

        // Show help message if requested or required
        if (showHelp || string.IsNullOrEmpty(replayFile))
        {
            ShowHelp();
            return;
        }

        try
        {
            // Create a replay reader instance
            var reader = new ReplayReader();

            // Read the replay file
            var replay = reader.ReadReplay(replayFile);

            // Set JSON serialization options
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
            };

            // Serialize the replay data to JSON
            string json = JsonSerializer.Serialize(replay, options);

            // Handle output
            if (!string.IsNullOrEmpty(outputFile))
            {
                System.IO.File.WriteAllText(outputFile, json);
                Console.WriteLine($"Replay data has been saved to: {outputFile}");
            }
            else
            {
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void ShowHelp()
    {
        Console.WriteLine("Usage: Program [options]");
        Console.WriteLine("Options:");
        Console.WriteLine("  -f, --file <path>    Specify the replay file to process (required).");
        Console.WriteLine("  -o, --output <path>  Specify the output file to save the JSON (optional).");
        Console.WriteLine("  -h, --help           Show this help message.");
    }
}
