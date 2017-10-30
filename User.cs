using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    class User
    {
        private List<int> scores;
        private int highScore;
        private int lowScore;
        private String userName;
        private String password;

        public List<int> Scores
        {
            get
            {
                return scores;
            }

            set
            {
                scores = value;
            }
        }

        public int HighScore
        {
            get
            {
                return highScore;
            }

            set
            {
                highScore = value;
            }
        }

        public int LowScore
        {
            get
            {
                return lowScore;
            }

            set
            {
                lowScore = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public User(String userName, String password)
        {
            this.scores = new List<int>();
            this.userName = userName;
            this.password = password;
        }

    }
}
