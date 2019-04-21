using System;
using System.Collections.Generic;
using System.Linq;

namespace CPRFeedbackER {

    internal class PressDetector {
        public static readonly int FULL_RELEASE_MIN = 0;
        public static readonly int FULL_RELEASE_MAX = 50;
        public static readonly int MIN_PRESS = 500;
        public static readonly int MAX_PRESS = 1023;
        public static readonly int GOOD_PRESS_MIN = 800;
        public static readonly int GOOD_PRESS_MAX = 900;

        public int cprCounter { get; set; }
        public int bpmCounter { get; set; }
        public int goodPressCounter { get; set; }
        public int goodReleaseCounter { get; set; }
        public int lastPressedValue { get; set; }
        public int overPressed { get; set; }
        public int weakPressed { get; set; }
        public String lastPressEvaluated { get; set; }

        public PressDetector() {
            cprCounter = 0;
            bpmCounter = 0;
            goodPressCounter = 0;
            goodReleaseCounter = 0;
            lastPressedValue = -1;
            overPressed = 0;
            weakPressed = 0;
        }

        public void PeakDetector(ref List<int> input) {
            //TODO: Peak detection
            int input_size = input.Count();
            if (input_size <= 4)
                return;

            int lastValue = input.ElementAt(input_size - 1);
            int prevValue = input.ElementAt(input_size - 2);
            int prevPrevValue = input.ElementAt(input_size - 3);

            // EZ A MOSTANI ARDUINO KÓDDAL JÓL MŰKÖDIK NINCS HAMIS ÉRZÉKELÉS
            if (lastValue < prevValue && prevValue > prevPrevValue && IsPressed(lastValue) && prevPrevValue < prevValue) {
                cprCounter++;
                if (IsPressed(prevValue)) {
                    pressEvaluator(prevValue);
                    lastPressedValue = prevValue;
                }
            }
        }

        public void pressEvaluator(int value) {
            if (Enumerable.Range(GOOD_PRESS_MIN, GOOD_PRESS_MAX).Contains(value)) {
                goodPressCounter++;
                lastPressEvaluated = "GOOD";
            }
            if (Enumerable.Range(GOOD_PRESS_MAX, MAX_PRESS).Contains(value)) {
                overPressed++;
                lastPressEvaluated = "OVERPRESSED";
                
            }
            if (Enumerable.Range(MIN_PRESS, GOOD_PRESS_MIN).Contains(value)) {
                weakPressed++;
                lastPressEvaluated = "WEAK";
            }
        }

        public void BpmCalculator(int elapsedTime) {
            bpmCounter = cprCounter * (60 / elapsedTime);
        }

        private void IsFullRelease(int value) {
            if (Enumerable.Range(FULL_RELEASE_MIN, FULL_RELEASE_MAX).Contains(value))
                goodReleaseCounter++;
        }

        private Boolean IsPressed(int value) {
            if (Enumerable.Range(MIN_PRESS, MAX_PRESS).Contains(value))
                return true;
            return false;
        }
    }
}