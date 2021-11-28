public static int SecondCounter(string password, string numPad)
        {
            List<Key> keyPad = new List<Key>();
            int i = 0;
            int j = 0; 

            foreach (var num in numPad)
            {
                Key n = new Key();
                n.i = i;
                n.j = j;
                n.value = num;
                j++;
                if (j > 2) { i++; j = 0; }
                keyPad.Add(n);
            }

            var thisStep = keyPad.Single(ch => ch.value.Equals(password[0]));
            Key nextStep;
            int seconds = 0; 
            foreach (char c in password)
            { 
                nextStep = keyPad.Single(ch => ch.value.Equals(c));
                if (Math.Abs(thisStep.i - nextStep.i) == 0 && Math.Abs(nextStep.j - thisStep.j) == 0)
                    seconds += 0;
                else if (Math.Abs(thisStep.i - nextStep.i) < 2 && Math.Abs(nextStep.j - thisStep.j) < 2)
                    seconds += 1;
                else
                    seconds += 2;
                thisStep = nextStep;
            }
            return seconds;
        }
        public struct Key
        {
            public int i;
            public int j;
            public char value;
        }
