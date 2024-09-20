﻿using MagicHat.Core.Input;

namespace MagicHat.Service.Lib.Input {
    public class MouseWheelEventArgs : EatableEvent {
        private int Delta { get; }

        public MouseWheelEventArgs(int delta) {
            Delta = delta;
        }
    }
}