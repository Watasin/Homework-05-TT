using System;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Address of the imported image data file. : ");
            string InputFile = Console.ReadLine(); //D:\Guide\02\InputImage.txt
            Console.WriteLine("InputFile");
            double[,] imageDataInputFile = ReadImageDataFromFile(InputFile);
            Console.Write("Address of the Convolution Kernel data file. : ");
            string DataFileConvolutionKernel = Console.ReadLine(); //D:\Guide\02\ConvolutionKernel.txt
            Console.WriteLine("DataFileConvolutionKernel");
            double[,] imageDataConvolution = ReadImageDataFromFile(DataFileConvolutionKernel);
            Console.Write("Address of the output image data file. : ");
            string DataFileOutput = Console.ReadLine(); //D:\Guide\02\OutputImage.txt
            double[,] ImageDataInputFileArray = new double[7, 7];
            Console.WriteLine("Convolve");
            for (int i = 0; i <= 6; i++)
            {
                int newi = ((i - 1) + 5) % 5;
                for (int j = 0; j <= 6; j++)
                {
                    int newj = ((j - 1) + 5) % 5;
                    ImageDataInputFileArray[i, j] = imageDataInputFile[newi, newj];
                    Console.Write("{0}  ", imageDataInputFile[newi, newj]);
                }
                Console.WriteLine();
            }
            double[,] ImageDataConvolutionArray = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ImageDataConvolutionArray[i, j] = imageDataConvolution[i, j];
                }
                Console.WriteLine();
            }
            double[,] imageDataArray = new double[5, 5];
            for (int i = 0; i < 5; i++)
            {
                int i1 = i * 1;
                int i2 = i + 1;
                int i3 = i + 2;
                for (int j = 0; j < 5; j++)
                {
                    int j1 = j * 1;
                    int j2 = j + 1;
                    int j3 = j + 2;
                    imageDataArray[i, j] = (ImageDataInputFileArray[i1, j1] * ImageDataConvolutionArray[0, 0]) + (ImageDataInputFileArray[i1, j2] * ImageDataConvolutionArray[0, 1]) + (ImageDataInputFileArray[i1, j3] * ImageDataConvolutionArray[0, 2])
                        + (ImageDataInputFileArray[i2, j1] * ImageDataConvolutionArray[1, 0]) + (ImageDataInputFileArray[i2, j2] * ImageDataConvolutionArray[1, 1]) + (ImageDataInputFileArray[i2, j3] * ImageDataConvolutionArray[1, 2])
                        + (ImageDataInputFileArray[i3, j1] * ImageDataConvolutionArray[2, 0]) + (ImageDataInputFileArray[i3, j2] * ImageDataConvolutionArray[2, 1]) + (ImageDataInputFileArray[i3, j3] * ImageDataConvolutionArray[2, 2]);
                }
                Console.WriteLine();
            }
            WriteImageDataToFile(DataFileOutput, imageDataArray);

        }

        static double[,] ReadImageDataFromFile(string imageDataFilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(imageDataFilePath);
            int imageHeight = lines.Length;
            int imageWidth = lines[0].Split(',').Length;
            double[,] imageDataArray = new double[imageHeight, imageWidth];

            for (int i = 0; i < imageHeight; i++)
            {
                string[] items = lines[i].Split(',');
                for (int j = 0; j < imageWidth; j++)
                {
                    imageDataArray[i, j] = double.Parse(items[j]);
                }
            }
            return imageDataArray;
        }

        static void WriteImageDataToFile(string imageDataFilePath,
                                         double[,] imageDataArray)
        {
            string imageDataString = "";
            for (int i = 0; i < imageDataArray.GetLength(0); i++)
            {
                for (int j = 0; j < imageDataArray.GetLength(1) - 1; j++)
                {
                    imageDataString += imageDataArray[i, j] + ", ";
                }
                imageDataString += imageDataArray[i,
                                                imageDataArray.GetLength(1) - 1];
                imageDataString += "\n";
            }

            System.IO.File.WriteAllText(imageDataFilePath, imageDataString);
        }



    }

}