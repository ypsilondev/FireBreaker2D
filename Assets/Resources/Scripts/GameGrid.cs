using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

namespace Resources.Scripts
{
    public class GameGrid
    {
        private readonly GameField[,] _board;
        private readonly uint2 _size;
        
        public GameGrid(uint2 size)
        {
            _board = new GameField[size.x, size.y];
            _size = size;
        }

        public void Generate(uint seed)
        {
            Random random = new Random(seed);

            _board[0, 0] = new FireStationField(Player.Red);
            _board[0, _size.y - 1] = new FireStationField(Player.Green);
            _board[_size.x - 1, 0] = new FireStationField(Player.Blue);
            _board[_size.x - 1, _size.y - 1] = new FireStationField(Player.Yellow);

            FillBoard(random, _size);
        }

        public void Render()
        {
            for (int x = 0; x < _size.x; x++)
            {
                for (int y = 0; y < _size.y; y++)
                {
                    
                }
            }
        }
        
        private static void Shuffle<T>(IList<T> list, Random random)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = random.NextInt(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private List<GameField> GenerateFieldItems(Random random, uint2 size)
        {
            int pondsAmount = (int) Math.Sqrt(_board.GetLength(0) * _board.GetLength(1));
            int heavilyBurning = pondsAmount;
            int slightlyBurning = pondsAmount * 2;
            
            List<GameField> fields = new List<GameField>();
            
            for (uint i = 0; i < pondsAmount; i++)
            {
                fields.Add(new GameField(FieldType.Pond));
            }
            for (uint i = 0; i < heavilyBurning; i++)
            {
                fields.Add(new ForestField(ForestState.HeavilyBurning));
            }
            for (uint i = 0; i < slightlyBurning; i++)
            {
                fields.Add(new ForestField(ForestState.LightlyBurning));
            }
            
            uint amount = size.x * size.y - 4;
            while (fields.Count < amount)
            {
                fields.Add(new ForestField(ForestState.Dry));
            }

            Shuffle(fields, random);
            return fields;
        }

        private void FillBoard(Random random, uint2 size)
        {
            List<GameField> items = GenerateFieldItems(random, size);

            int index = 0;
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    if (_board[x, y] == null)
                    {
                        _board[x, y] = items[index++];
                    }
                }
            }
        }

    }
}