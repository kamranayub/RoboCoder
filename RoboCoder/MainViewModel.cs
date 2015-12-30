﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboCoder
{
    class MainViewModel
    {
        private readonly InstructionSet _instructionSet;

        public MainViewModel(InstructionSet instructionSet)
        {
            _instructionSet = instructionSet;
        }

        public string Instructions
        {
            get
            {
                return string.Join("\n", _instructionSet.Instructions.ToArray());
            }
            set
            {
                var lines = value.Split('\n');
                _instructionSet.SetInstructions(lines.ToImmutableList());
            }
        }

        public void KeyDown(KeyEventArgs args)
        {
            _instructionSet.AppendKey(args);
        }

        public bool Recording
        {
            get { return _instructionSet.Recording; }
            set
            {
                _instructionSet.Recording = value;
                _instructionSet.Save();
            }
        }

        public void Record()
        {
            _instructionSet.Recording = true;
        }

        public void Stop()
        {
            _instructionSet.Recording = false;
        }

        public void Play()
        {
            _instructionSet.Play();
        }

        public void OpenFile(string fileName)
        {
            _instructionSet.OpenFile(fileName);
        }

        public void Close()
        {
            _instructionSet.Save();
        }
    }
}
