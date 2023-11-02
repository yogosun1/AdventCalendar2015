using System.Net.Http.Headers;

namespace AdventCalendar2023
{
    [TestClass]
    public class WorkInProgress
    {
        [TestMethod]
        public void Day1_1()
        {
            string input = File.ReadAllLines(@"Input\Day1.txt").ToList().FirstOrDefault();
            int finalFloor = input.Where(w => w == '(').Count() - input.Where(w => w == ')').Count();
        }

        [TestMethod]
        public void Day1_2()
        {
            string input = File.ReadAllLines(@"Input\Day1.txt").ToList().FirstOrDefault();
            int position = 0;
            int currentFloor = 0;
            foreach (char c in input)
            {
                position++;
                currentFloor += c == '(' ? 1 : -1;
                if (currentFloor < 0)
                    break;
            }
        }

        [TestMethod]
        public void Day2_1()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day2.txt").ToList();
            int feet = 0;
            foreach (string input in inputList)
            {
                string[] splitInput = input.Split('x');
                int l = int.Parse(splitInput[0]);
                int w = int.Parse(splitInput[1]);
                int h = int.Parse(splitInput[2]);
                int side1 = l * w;
                int side2 = w * h;
                int side3 = h * l;
                feet += 2 * side1 + 2 * side2 + 2 * side3 + new int[] { side1, side2, side3 }.Min();
            }
        }

        [TestMethod]
        public void Day2_2()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day2.txt").ToList();
            int feet = 0;
            foreach (string input in inputList)
            {
                string[] splitInput = input.Split('x');
                int l = int.Parse(splitInput[0]);
                int w = int.Parse(splitInput[1]);
                int h = int.Parse(splitInput[2]);
                List<int> sideList = new List<int> { l, w, h }.OrderBy(o => o).ToList();
                feet += sideList[0] * 2 + sideList[1] * 2 + l * w * h;
            }
        }

        [TestMethod]
        public void Day3_1()
        {
            string input = File.ReadAllLines(@"Input\Day3.txt").ToList().FirstOrDefault();
            List<Day3House> houseList = new List<Day3House>();
            houseList.Add(new Day3House { X = 0, Y = 0, PresentCount = 1 });
            int nextX = 0, nextY = 0;
            foreach (char c in input)
            {
                nextX += c == '<' ? -1 : c == '>' ? 1 : 0;
                nextY += c == 'v' ? -1 : c == '^' ? 1 : 0;
                Day3House house = houseList.FirstOrDefault(w => w.X == nextX && w.Y == nextY);
                if (house == null)
                {
                    house = new Day3House { X = nextX, Y = nextY, PresentCount = 0 };
                    houseList.Add(house);
                }
                house.PresentCount++;
            }
            int housesWithPresentsCount = houseList.Count();
        }

        [TestMethod]
        public void Day3_2()
        {
            string input = File.ReadAllLines(@"Input\Day3.txt").ToList().FirstOrDefault();
            List<Day3House> houseList = new List<Day3House>();
            houseList.Add(new Day3House { X = 0, Y = 0, PresentCount = 2 });
            int santaNextX = 0, santaNextY = 0, roboNextX = 0, roboNextY = 0;
            int i = 0;
            bool santaMove;
            foreach (char c in input)
            {
                santaMove = i % 2 == 0;
                Day3House house;
                if (santaMove)
                {
                    santaNextX += c == '<' ? -1 : c == '>' ? 1 : 0;
                    santaNextY += c == 'v' ? -1 : c == '^' ? 1 : 0;
                    house = houseList.FirstOrDefault(w => w.X == santaNextX && w.Y == santaNextY);
                    if (house == null)
                    {
                        house = new Day3House { X = santaNextX, Y = santaNextY, PresentCount = 0 };
                        houseList.Add(house);
                    }
                }
                else
                {
                    roboNextX += c == '<' ? -1 : c == '>' ? 1 : 0;
                    roboNextY += c == 'v' ? -1 : c == '^' ? 1 : 0;
                    house = houseList.FirstOrDefault(w => w.X == roboNextX && w.Y == roboNextY);
                    if (house == null)
                    {
                        house = new Day3House { X = roboNextX, Y = roboNextY, PresentCount = 0 };
                        houseList.Add(house);
                    }
                }
                house.PresentCount++;
                i++;
            }
            int housesWithPresentsCount = houseList.Count();
        }

        private class Day3House
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int PresentCount { get; set; }
        }

        [TestMethod]
        public void Day4_1()
        {
            string input = File.ReadAllLines(@"Input\Day4.txt").ToList().FirstOrDefault();
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                int i = 1;
                while (!Convert.ToHexString(md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input + i))).StartsWith("00000"))
                    i++;
            }
        }

        [TestMethod]
        public void Day4_2()
        {
            string input = File.ReadAllLines(@"Input\Day4.txt").ToList().FirstOrDefault();
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                int i = 1;
                while (!Convert.ToHexString(md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input + i))).StartsWith("000000"))
                    i++;
            }
        }

        [TestMethod]
        public void Day5()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day5.txt").ToList();
        }

        [TestMethod]
        public void Day6()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day6.txt").ToList();
        }

        [TestMethod]
        public void Day7()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day7.txt").ToList();
        }

        [TestMethod]
        public void Day8()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day8.txt").ToList();
        }

        [TestMethod]
        public void Day9()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day9.txt").ToList();
        }

        [TestMethod]
        public void Day10()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day10.txt").ToList();
        }

        [TestMethod]
        public void Day11()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day11.txt").ToList();
        }

        [TestMethod]
        public void Day12()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day12.txt").ToList();
        }

        [TestMethod]
        public void Day13()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day13.txt").ToList();
        }

        [TestMethod]
        public void Day14()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day14.txt").ToList();
        }

        [TestMethod]
        public void Day15()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day15.txt").ToList();
        }

        [TestMethod]
        public void Day16()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day16.txt").ToList();
        }

        [TestMethod]
        public void Day17()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day17.txt").ToList();
        }

        [TestMethod]
        public void Day18()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day18.txt").ToList();
        }

        [TestMethod]
        public void Day19()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day19.txt").ToList();
        }

        [TestMethod]
        public void Day20()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day20.txt").ToList();
        }

        [TestMethod]
        public void Day21()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day21.txt").ToList();
        }

        [TestMethod]
        public void Day22()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day22.txt").ToList();
        }

        [TestMethod]
        public void Day23()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day23.txt").ToList();
        }

        [TestMethod]
        public void Day24()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day24.txt").ToList();
        }

        [TestMethod]
        public void Day25()
        {
            List<string> inputList = File.ReadAllLines(@"Input\Day25.txt").ToList();
        }
    }
}