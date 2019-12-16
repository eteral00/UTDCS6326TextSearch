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
 * This is the TechServices module, which handles technical services such as input/output
 * 
 */
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace klh170130Asg4
{
    class TechServices
    {

        public StreamReader srFile;
        public long fileLength;


        /* Constructor
         */
        public TechServices()
        {

        }


        /* A method to open/load/read data from file into memory for this program
            * fileName: or file path, location and name of file to read, optional, default value = "CS6326Asg2.txt"
            * 
            * return a bool value indicating if the load process was successful or not, true = successfull, false = error
            */
        public bool loadFile(string fileName)
        {
            bool success = false;
            try
            {
                if (File.Exists(fileName))
                // if file exists, read
                {

                    srFile = new StreamReader(fileName);
                    fileLength = new FileInfo(fileName).Length;

                    return success = true;
                }
                else
                {
                    return success = false;
                }

            }
            catch (IOException e)
            {
                return success = false;
            }

        } // end method loadFile

        /* method to close current stream reader
         * return a bool to indicate if the operation was success (true), or if the stream is null (false) - i.e. already closed previously
         */
        public bool closeFile()
        {
            bool success;

            if (this.srFile == null)
            {
                return success = false;
            }
            else
            {
                this.srFile.Close();
                srFile = null;
            }
            

            return success = true;

        } // end method closeFile

    } // end class TechServices   
} // end namespace
