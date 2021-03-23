using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class Presistance
    {
        
        public List<Point> Load (string score)
        {
            List<Point> conti = new List<Point>();
            System.IO.StreamReader read = new System.IO.StreamReader(score);
            while(!read.EndOfStream)
            {
                string[] temp = read.ReadLine().Split('-');
                Point asd = new Point();
                asd.ScorePoint = Convert.ToInt32(temp);
                conti.Add(asd);
            }
            read.Close();
            return conti;
        }


        public void Save (List<Point> cont, Command command, string score)
        {
            System.IO.StreamWriter write = new System.IO.StreamWriter(score, true);
            if (command == Command.Add)
            {
                foreach (Point item in cont)
                {
                    write.WriteLine("Score : {0}", item.ScorePoint);
                }
            }
        }



        public enum Command
        {
            Add
        }
    }
    public class Point
    {
        public int _scorepoint;

        public int ScorePoint
        {
            get { return _scorepoint; }
            set { _scorepoint = value; }
        }
        
    }
}
