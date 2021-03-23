using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Model
    {
        internal List<Point> cont = new List<Point>();

        Presistance pre;

        public Model()
        {
            pre = new Presistance();
        }


        internal void Import(string score)
        {
            cont = pre.Load(score);
        }

        internal void Export(string score, List<Point> con, Presistance.Command command)
        {
            pre.Save(con, command, score);
        }



        private void Add(int score)
        {
            Point asd = new Point();
            asd.ScorePoint = score;
            cont.Add(asd);
        }

        internal void Switchi (Presistance.Command command, int score)
        {
            switch(command)
            {
                case Presistance.Command.Add:
                    Add(score);
                    break;
            }
        }


    }

    
}
