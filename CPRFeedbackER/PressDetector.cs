using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CPRFeedbackER {

    internal class PressDetector {
        public static readonly int FULL_RELEASE_MIN = Int32.Parse(ConfigurationManager.AppSettings.Get("FULL_RELEASE_MIN"));
        public static readonly int FULL_RELEASE_MAX = Int32.Parse(ConfigurationManager.AppSettings.Get("FULL_RELEASE_MAX"));
        public static readonly int MIN_PRESS = Int32.Parse(ConfigurationManager.AppSettings.Get("MIN_PRESS"));
        public static readonly int MAX_PRESS = Int32.Parse(ConfigurationManager.AppSettings.Get("MAX_PRESS"));
        public static readonly int GOOD_PRESS_MIN = Int32.Parse(ConfigurationManager.AppSettings.Get("GOOD_PRESS_MIN"));
        public static readonly int GOOD_PRESS_MAX = Int32.Parse(ConfigurationManager.AppSettings.Get("GOOD_PRESS_MAX"));

        public int CprCounter { get; set; }
        public int BpmCounter { get; set; }
        public int GoodPressCounter { get; set; }
        //public int GoodReleaseCounter { get; set; }
        public int LastPressedValue { get; set; }
        public int OverPressedCounter { get; set; }
        public int WeakPressedCounter { get; set; }
        public String LastPressEvaluated { get; set; }

        public PressDetector() {
            CprCounter = 0;
            BpmCounter = 0;
            GoodPressCounter = 0;
            //GoodReleaseCounter = 0;
            LastPressedValue = -1;
            OverPressedCounter = 0;
            WeakPressedCounter = 0;
        }

        public void PeakDetector(ref List<int> input) {
            int input_size = input.Count();
            if (input_size <= 4)
                return;

            int lastValue = input.ElementAt(input_size - 1);
            int prevValue = input.ElementAt(input_size - 2);
            int prevPrevValue = input.ElementAt(input_size - 3);

            if (lastValue < prevValue && prevValue > prevPrevValue &&
                IsPressed(lastValue) && prevPrevValue < prevValue) {
                if (IsPressed(prevValue)) {
                    CprCounter++;
                    PressEvaluator(prevValue);
                    LastPressedValue = prevValue;
                }
            }
        }
        public void PressEvaluator(int value) {
            if (Enumerable.Range(GOOD_PRESS_MIN, GOOD_PRESS_MAX).Contains(value)) {
                GoodPressCounter++;
                LastPressEvaluated = "GOOD";
            }
            if (Enumerable.Range(GOOD_PRESS_MAX, MAX_PRESS).Contains(value)) {
                OverPressedCounter++;
                LastPressEvaluated = "OVERPRESSED";
            }
            if (Enumerable.Range(FULL_RELEASE_MIN, GOOD_PRESS_MIN).Contains(value)) {
                WeakPressedCounter++;
                LastPressEvaluated = "WEAK";
            }
        }

        public void BpmCalculator(int elapsedTime) {
            BpmCounter = CprCounter * (60 / elapsedTime);
        }

        ////private void IsFullRelease(int value) {
            //if (Enumerable.Range(FULL_RELEASE_MIN, FULL_RELEASE_MAX).Contains(value))
                //GoodReleaseCounter++;
        //}

        private Boolean IsPressed(int value) {
            if (Enumerable.Range(MIN_PRESS, MAX_PRESS).Contains(value))
                return true;
            return false;
        }
    }
}