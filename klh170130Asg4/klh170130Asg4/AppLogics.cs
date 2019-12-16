/*
 * Written by Khoa L. D. Ho (klh170130) 
 * for Assignment 4 for class CS6326 Falll 2019, by Professor J. Cole, at UT Dallas,
 * starting Oct 13, 2019, using Visual Studio 2017 on OS Windows 8.1
 * 
 * Text Search Program
 * This program is used to search text from a user-specified input file.
 * 
 * Fist, the user will select an input file, which should be a text file. 
 * Then, the user will enter the search key, i.e text to be searched, and click Search Button
 * The program will search the text from file using another thread (background worker) and keep displaying the results and progress on UI screen
 *
 * 
 * This is the AppLogics module, which contains the main logics/operations of the program.
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace klh170130Asg4
{
    class AppLogics
    {
        public long cumReadLength;
        public int lineIndex;
        public int matchCount;
        public Queue< Tuple< int, string> > resultQueue;
        


        /* Constructor
         */
        public AppLogics()
        {
            cumReadLength = 0;
            lineIndex = 0;
            matchCount = 0;
            resultQueue = new Queue<Tuple<int, string>>();
            
        }


        /* method to reset control variables for search
         * 
         */
        public void resetSearcher()
        {
            // reset control variables before start search
            this.cumReadLength = 0;
            this.lineIndex = 0;
            this.matchCount = 0;
            this.resultQueue.Clear();
        }


        /* method to search 1 line of text, taking 2 parameters
         * aTechServices TechServices instance to perform file I/O
         * searchKey is the term to search for
         * results and related data will be stored in control variables of this AppLogics instance. 
         * 
         * a boolean result will be returned to indicate if the search has reached end of stream reader
         */
         public bool searchLine(TechServices aTechServices, string searchKey)
        {
            bool boolEoS = false;
            string textLine;
            if (!aTechServices.srFile.EndOfStream)
            {
                textLine = aTechServices.srFile.ReadLine();
                lineIndex++;
                this.cumReadLength += textLine.Length; // increase cumulative read length

                // convert all text to lower case
                string searchLine = textLine.ToLower(); 
                searchKey = searchKey.ToLower();

                if(searchLine.Contains(searchKey))
                {
                    matchCount++;
                    Tuple<int, string> matchTup = new Tuple<int, string>(lineIndex, textLine);
                    this.resultQueue.Enqueue(matchTup);

                }

                boolEoS = false;
                
            }
            else
            {
                boolEoS = true;
            }

            return boolEoS;

        }


    }


}
