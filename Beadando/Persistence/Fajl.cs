using Beadando.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Persistence
{
    public class Fajl
    {
        public static async Task<GameModel> LoadAsync(String path)
        {
            try
            {
                string firstLine;
                int firstLineI;
                List<int[]> coordinates = new();

                using (StreamReader file = new(path))
                {
                    if (!File.Exists(path))
                    {
                        throw new AsteroidDataException();
                    }
                    firstLine = await file.ReadLineAsync() ?? String.Empty;
                    firstLineI = int.Parse(firstLine);

                    string line;
                    while ((line = file.ReadLine()!) != null)
                    {
                        string[] parts = line.Split(' ');

                        int firstCoordinate = int.Parse(parts[0]);
                        int secondCoordinate = int.Parse(parts[1]);
                        int[] temp = new int[2];
                        temp[0] = firstCoordinate;
                        temp[1] = secondCoordinate;

                        coordinates.Add(temp);
                    }
                }
                GameModel _gM = new(coordinates, firstLineI);
                return _gM;
            }
            catch
            {
                throw new AsteroidDataException();
            }
        }


        public static async Task SaveAsync(String path, GameModel model)
        {
            try
            {
                using StreamWriter writer = new(path);
                await writer.WriteLineAsync(model.SaveTime.ToString());
                foreach (int[] array in model.Coordinates)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        await writer.WriteAsync(array[i].ToString());
                        if (i < array.Length - 1)
                        {
                            await writer.WriteAsync(" ");
                        }
                    }
                    await writer.WriteLineAsync();
                }
            }
            catch
            {
                throw new AsteroidDataException();
            }
        }
    }
}

