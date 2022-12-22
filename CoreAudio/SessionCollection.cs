﻿/*
  LICENSE
  -------
  Copyright (C) 2007-2010 Ray Molenkamp

  This source code is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this source code or the software it produces.

  Permission is granted to anyone to use this source code for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this source code must not be misrepresented; you must not
     claim that you wrote the original source code.  If you use this source code
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original source code.
  3. This notice may not be removed or altered from any source distribution.
*/
/* Updated by John de Jong (2020/04/02) */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CoreAudio.Interfaces;

namespace CoreAudio {
    public class SessionCollection : IEnumerable<AudioSessionControl2> {
        readonly IAudioSessionEnumerator audioSessionEnumerator;
        public readonly Guid eventContext;
        internal SessionCollection(IAudioSessionEnumerator realEnumerator, Guid eventContext) {
            audioSessionEnumerator = realEnumerator;
            this.eventContext = eventContext;
        }

        public AudioSessionControl2 this[int index] {
            get {
                Marshal.ThrowExceptionForHR(audioSessionEnumerator.GetSession(index, out IAudioSessionControl2 _Result));
                return new AudioSessionControl2(_Result, eventContext);
            }
        }

        public int Count {
            get {
                Marshal.ThrowExceptionForHR(audioSessionEnumerator.GetCount(out var result));
                return result;
            }
        }

        public IEnumerator<AudioSessionControl2> GetEnumerator() {
            for(var index = 0; index < Count; index++) {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
