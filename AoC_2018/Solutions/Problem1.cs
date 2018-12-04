﻿using System;
using System.Collections.Generic;
using System.IO;
using FileParser;

namespace AoC_2018.Solutions
{
    class Problem1 : IProblem
    {
        public string FilePath => Path.Combine("Inputs", "1.in");

        public void Solve_1()
        {
            IEnumerable<long> frequencyChanges = ParseInput(FilePath);

            long result = 0;

            foreach (long freq in frequencyChanges)
            {
                result += freq;
            }

            Console.WriteLine($"Day 1, part 1: {result}");
        }

        public void Solve_2()
        {
            IEnumerable<long> frequencyChanges = ParseInput(FilePath);
            HashSet<long> uniqueFrequencies = new HashSet<long>() { 0 };

            long result = 0;
            bool exit = false;

            while (!exit)
            {
                foreach (long freq in frequencyChanges)
                {
                    result += freq;

                    if (uniqueFrequencies.Contains(result))
                    {
                        Console.WriteLine($"Day 1, part 2: {result}\n");
                        exit = true;
                        break;
                    }
                    uniqueFrequencies.Add(result);
                }
            }
        }

        private IEnumerable<long> ParseInput(string inputFile)
        {
            IParsedFile parsedFile = new ParsedFile(inputFile);

            while (!parsedFile.Empty)
            {
                IParsedLine parsedLine = parsedFile.NextLine();
                while (!parsedLine.Empty)
                {
                    yield return parsedLine.NextElement<long>();
                }
            }
        }
    }
}