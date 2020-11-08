using MarsProject.Common;
using MarsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Plateau plateau = CreatePlateau();

            var roverlist = CreateRoverListByCount(2);

            ApplayDirecitons(plateau, roverlist);
        }


        private static Plateau CreatePlateau()
        {
            Plateau plateau = null;
            do
            {
                try
                {
                    Console.WriteLine("Plato buyutlarını iki ayrı sayı olarka girin");
                    var plateauDimension = Console.ReadLine().Trim().Split(' ');

                    if (plateauDimension.Count() == 2 && InputValidator.IsPositiveInteger(plateauDimension[0]) && InputValidator.IsPositiveInteger(plateauDimension[1]))
                    {
                        plateau = new Plateau(
                        Convert.ToInt32(plateauDimension[0]),
                        Convert.ToInt32(plateauDimension[1]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (plateau == null);

            return plateau;
        }

        private static string ReadDirectives(int sequence)
        {
            #region getdirectives
            string directives = string.Empty;
            do
            {
                try
                {
                    Console.WriteLine($"{sequence}. Gezginin için yönelndirme  direktiflerini giriniz. ");
                    var tempdirectives = Console.ReadLine().ToUpper();
                    if (InputValidator.IsDirectiveListValid(tempdirectives))
                        directives = tempdirectives;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (string.IsNullOrEmpty(directives));
            #endregion
            return directives;
        }

        private static List<Rover> CreateRoverListByCount(int count)
        {
            var roverlist = new List<Rover>();
            do
            {
                try
                {
                    var sequence = (roverlist.Count() + 1);
                    Rover rover = CreateRover(sequence);
                    var directions = ReadDirectives(sequence);

                    rover.SetDirections(directions);
                    roverlist.Add(rover);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (roverlist.Count() < count);

            return roverlist;
        }
        private static Rover CreateRover(int sequence)
        {
            Rover rover = null;
            do
            {
                try
                {
                    Console.WriteLine($"{sequence}. Gezginin başlangıç bilgilerini 2 kordinat sayısı ve bir yön(harf) olarak giriniz. ");
                    var roverinitialPosition = Console.ReadLine().ToUpper().Trim().Split(' ');

                    if (roverinitialPosition.Count() == 3
                        && InputValidator.IsPositiveInteger(roverinitialPosition[0])
                        && InputValidator.IsPositiveInteger(roverinitialPosition[1])
                        && InputValidator.IsInitialCommpassValid(roverinitialPosition[2])
                        )
                    {
                        rover = new Rover(
                        Convert.ToInt32(roverinitialPosition[0]),
                        Convert.ToInt32(roverinitialPosition[1]),
                        roverinitialPosition[2].ToCharArray()[0]
                        );
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (rover == null);

            return rover;
        }

        private static void ApplayDirecitons(Plateau plateau, List<Rover> rovers)
        {
            foreach (var rover in rovers)
            {
                try
                {
                    rover.ApplyDirectivesOnSpecifiedPlateau(plateau);
                    Console.WriteLine($"{rover.X} {rover.Y} {rover.PositionAsCompassLetter}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            Console.ReadLine();
        }
    }
}
