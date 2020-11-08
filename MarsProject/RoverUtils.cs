using MarsProject.Models;
using System;

namespace MarsProject
{
    public static class RoverUtils
    {

        /// <summary>
        /// başlangıcı birim çember üzeirnde açısal olarak belirlenir ve sonraki 
        /// yön direktifini birim çember üzerinde açısal dönme değerleri döndürülür
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public static int ConvertCompassCharToPositon(char letter)
        {
            var result = 0;
            switch (letter)
            {
                //ilk dört case başlagıçtaki yön atamaları için
                case 'E':
                    result = 0;
                    break;
                case 'N':
                    result = 90;
                    break;
                case 'W':
                    result = 180;
                    break;
                case 'S':
                    result = 270;
                    break;

                //son iki case ise ilk atama sonrasnda gelen yönlendirme komutları için
                case 'L':
                    result = 90;
                    break;

                case 'R':
                    result = -90 + 360;
                    break;

                default:
                    break;
            }

            return result;
        }


        private static double ConvertDegreeToRadian(double degree) => Math.PI / 180 * degree;


        public static char ConvertPositionToCompassLetter(int position)
        {
            char result = ' ';
            switch (position)
            {
                //ilk dört case başlagıçtaki yön atamaları için
                case 0:
                    result = 'E';
                    break;
                case 90:
                    result = 'N';
                    break;
                case 180:
                    result = 'W';
                    break;
                case 270:
                    result = 'S';
                    break;

                default:
                    break;
            }

            return result;
        }


        /// <summary>
        ///  Yön değiştirme direktifi  birim çember esas alınıp açısal hesaplanmıştır
        ///  360 derece döndüğünde aynı yöne geldiğinden bu aralıkla sınırlandırılır
        /// </summary>
        /// <param name="position"></param>
        /// <param name="letter"></param>
        /// <returns></returns>
        public static int CalculateDirectionPositionViaUnitCircle(int position, char letter)
        {
            position += RoverUtils.ConvertCompassCharToPositon(letter); // gelen direktifin yaratacağı açı değişikliği hesaplanır
            position = position % 360;
            return position;
        }


        public static bool IsMoveDirectiveAvailable(Plateau plateue, Rover rover, out int nextX, out int nextY)
        {
            nextX = rover.X + CalculateNextStepMoveCoordinat(rover.Position, Coordinats.X);
            nextY = rover.Y + CalculateNextStepMoveCoordinat(rover.Position, Coordinats.Y);
            return (0 <= nextX && nextX <= plateue.X) && (0 <= nextY && nextY <= plateue.Y);
        }


        /// <summary>
        /// hareket direktifi ile oluşacak koordinat değişikliği  birim çember üzerindeki açısal durumdan 
        /// koordinat bazlı ayrı yarı hesaplanır
        /// </summary>
        /// <param name="position"></param>
        /// <param name="coordinat"></param>
        /// <returns></returns>
        private static int CalculateNextStepMoveCoordinat(int position, Coordinats coordinat)
        {
            var result = 0;
            switch (coordinat)
            {
                case Coordinats.X:
                    result = (int)Math.Cos(RoverUtils.ConvertDegreeToRadian(position));
                    break;
                case Coordinats.Y:
                    result = (int)Math.Sin(RoverUtils.ConvertDegreeToRadian(position));
                    break;
                default:
                    break;
            }

            return result;
        }
    }


    public enum Coordinats
    {
        X,
        Y
    }

    public class Constanst
    {
        public static readonly char[] initialCompass = new char[4] { 'E', 'N', 'W', 'S' };
        public static readonly char[] Directives = new char[3] { 'L', 'R', move, };
        public static readonly int[] Compass = new int[] { 0, 90, 180, 270 };
        public const char move = 'M';
    }


    public static class ErrorMessages
    {
        public const string InvalidDirectivesMessage = "Direktivleri kontrol ediniz";
        public const string InvalidCoordinatsMessage = "Koordinatları kontrol ediniz";
        public const string CompassMessage = "Yön directifi bilgisini kontrol ediniz";
        public const string DimensionMessage = "Boyut bilgileri pozitif değerler olmalıdır";
        public const string InvalidCompassMessageAndCoordinatsMessage = "Yön ve konum bilgilerini kontrol ediniz";
    }
}
