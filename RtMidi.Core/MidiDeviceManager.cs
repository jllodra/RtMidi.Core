﻿using System.Collections.Generic;
using RtMidi.Core.Unmanaged;
using RtMidi.Core.Devices.Infos;

namespace RtMidi.Core
{
    /// <summary>
    /// This is the MIDI Device Manager, which you shall use to obtain information
    /// about all available input and output devices, information is always up-to-date
    /// so each time you enumerate input or output devices, it will reflect the 
    /// currently available devices.
    /// </summary>
    public class MidiDeviceManager
    {
        /// <summary>
        /// Manager singleton instance to use
        /// </summary>
        public static readonly MidiDeviceManager Instance = new MidiDeviceManager();

        private readonly RtMidiDeviceManager _rtDeviceManager;

        private MidiDeviceManager()
        {
            _rtDeviceManager = RtMidiDeviceManager.Instance;
        }

        /// <summary>
        /// Enumerate all currently available input devices
        /// </summary>
        public IEnumerable<IMidiInputDeviceInfo> InputDevices 
        {
            get
            {
                foreach (var rtInputDeviceInfo in _rtDeviceManager.InputDevices) 
                {
                    yield return new MidiInputDeviceInfo(rtInputDeviceInfo);
                }
            }
        }

        /// <summary>
        /// Enumerate all currently available output devices
        /// </summary>
        public IEnumerable<IMidiOutputDeviceInfo> OutputDevices
        {
            get 
            {
                foreach (var rtOutputDeviceInfo in _rtDeviceManager.OutputDevices) 
                {
                    yield return new MidiOutputDeviceInfo(rtOutputDeviceInfo);
                }
            }
        }
    }
}
