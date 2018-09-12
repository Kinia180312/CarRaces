using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRaces
{
    public partial class CarRacesForm : Form
    {
        public List<Player> players;
        public List<Car> cars;
        public List<Bet> bets;


        public Random random;

        public CarRacesForm()
        {
            InitializeComponent();
            random = new Random();

            if (bets == null) bets = new List<Bet>();

            if (cars == null)
            {
                cars = new List<Car>();
                cars.Add(ConstructCar("Car1", 12));
                cars.Add(ConstructCar("Car2", 111));
                cars.Add(ConstructCar("Car3", 227));
            }

            if (players == null)
            {
                players = new List<Player>();
                players.Add(ConstructPlayer(1, "John"));

                Player p = ConstructPlayer(2, "Mark");
                players.Add(p);

                players.Add(ConstructPlayer(3, "Donald"));
            }

            UpdateForm();

        }

        public Car ConstructCar(string name, int y)
        {
            return new Car() { Name = name, startPoistion = 12, currentPosition = y };
        }

        public Player ConstructPlayer(int _id, string name)
        {
            Player p = new Player() { Id = _id, Name = name, Wallet = 100 };
            return p;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Bet b1 = new Bet();
            b1.PlayerId = 1;
            b1.Ammount = Convert.ToInt32(bet1.Text);
            var p1 = players.Where(x => x.Id == 1).FirstOrDefault();
            p1.Wallet = p1.Wallet - b1.Ammount;
            textBox1.Text = p1.Wallet.ToString();


            //Bet b2 = new Bet();
            //b1.PlayerId = 2;
            //b1.Ammount = Convert.ToInt32(bet2.Text);

            //Bet b3 = new Bet();
            //b1.PlayerId = 3;
            //b1.Ammount = Convert.ToInt32(bet3.Text);



            timer1.Start();
        }

        public void UpdateForm()
        {
            foreach(Player p in players)
            {
                //1
                Label cntrol = Controls.Find("label" + p.Id.ToString(), false).FirstOrDefault() 
                    as Label;
                cntrol.Text = p.Name;

                TextBox txtBoxcntrol = Controls.Find("textbox" + p.Id.ToString(), false).FirstOrDefault()
                    as TextBox;
                txtBoxcntrol.Text = p.Wallet.ToString();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(Car c in cars)
            {
                PictureBox p = Controls.Find(c.Name, false).FirstOrDefault() as PictureBox;
                int newPosition = random.Next(1, 10);
                int current = p.Location.X + newPosition; 
                p.Location = new Point(current, c.currentPosition);
                if (p.Location.X >= 646) EndRace(c.Name);

            }
        }


        public void EndRace(string carName)
        {
            timer1.Stop();
        }

        private void car1_Click(object sender, EventArgs e)
        {

        }
    }
}

