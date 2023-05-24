using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class Gomoku
    {
        private const int BOARD_SIZEX = 12; // 盤面のサイズ
        private const int BOARD_SIZEY = 8; // 盤面のサイズ
        private const string endKeyWord = "end"; // 盤面のサイズ

        public enum Stone
        {
            BLACK,
            WHITE,

            NONE,
        };

        private static readonly Stone[,] board = new Stone[BOARD_SIZEX, BOARD_SIZEY]; // 盤面を表す二次元配列

        /*コンストラクター*/
        public Gomoku()
        {
            InitBoard();
        }

        /*五目をスタートする関数*/
        public void Start()
        {
            PrintBorad();
            PrintResult();
            CountBoardStone();
        }
        
        /*盤面を表示する関数*/
        private void PrintBorad()
        {
            //盤面の列の数に応じて番号を表示
            Console.Write("   ");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write($"{(i + 1),3}");
            }
            Console.WriteLine("");

            //盤面の行の数に応じて盤面を描画
            for (int row = 0; row < BOARD_SIZEY; row++)
            {
                //番号を表示
                Console.Write($"{row + 1,3}" + " ");
                //ボード配列の値に応じて碁を配置   0:〇  1:●
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    Console.Write(board[col, row] == Stone.BLACK ? "〇 " : "● ");
                }
                Console.WriteLine();
            }
        }

        /*盤面をランダムに初期化する関数*/
        private void InitBoard()
        {
            Random rand = new();

            //ボード配列の値を0or1で初期化
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = (Stone)rand.Next(2);
                }
            }
        }

        /*白と黒の石の数を計算(総当たり)*/
        private void CountBoardStone()
        {
            int blackCount = 0;
            int whiteCount = 0;
            //
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == Stone.BLACK)
                    {
                        blackCount++;
                    }

                    if (board[row, col] == Stone.WHITE)
                    {
                        whiteCount++;
                    }
                }
            }

            //結果を表示
            Console.WriteLine("黒の石の数は{0}だ！！", blackCount);
            Console.WriteLine("白い石の数は{0}だ！！", whiteCount);
        }

        /*入力内容に合う結果を表示*/
        private void PrintResult()
        {
            while (true)
            {
                Console.WriteLine("横と縦のマス目を指定しやがれ！(例:1,3) {0}:終了", endKeyWord);

                //nullを許容する変数
                string? input = Console.ReadLine();
                //nullなら早期リターン
                if (input == null) return;
                //endなら処理を終了
                if (input == endKeyWord) break;
                // 入力された文字列をカンマで分割し、縦と横のマス目を取得する
                string[] split = input.Split(",");
                //配列の長さが2かつ(ボードの列,行)
                //入力されたデータが変更可能かつ
                //ボードのないの大きさ内だった時に処理
                if (split.Length == 2 && int.TryParse(split[0], out int raw) && int.TryParse(split[1], out int con)
                    && raw >= 1 && raw <= Gomoku.board.GetLength(0)
                    && con >= 1 && con <= Gomoku.board.GetLength(1))
                {
                    // 指定されたマス目の石の色を表示する
                    Stone stone = Gomoku.board[raw - 1, con - 1];
                    Console.WriteLine("({0}, {1})の石：{2}", raw, con, stone);
                }
                else
                {
                    Console.WriteLine("無効な入力だ！！");
                }
            }
            Console.WriteLine("これで終わりだ！！！");
        }

        /*プレイヤーの挙動*/

        /*コンピュータの挙動*/
        
        /*勝敗判定*/
        
        /*指定した場所におく*/
        
        /**/
        
        /**/

    }


    internal class MegutanProject
    {
        static void Main(string[] args)
        {

            Gomoku gomoku = new();
            gomoku.Start();
        }
    }

}