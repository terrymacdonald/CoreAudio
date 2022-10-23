/*
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

using System;

namespace CoreAudio {
    public struct PropertyKey {
        public Guid fmtId;
        public int pId;

        public PropertyKey(Guid fmtId, int pId) {
            this.fmtId = fmtId;
            this.pId = pId;
        }

        public static bool operator ==(PropertyKey pk1, PropertyKey pk2) {
            return (pk1.fmtId == pk2.fmtId) && (pk1.pId == pk2.pId);
        }

        public static bool operator !=(PropertyKey pk1, PropertyKey pk2) {
            return !(pk1 == pk2);
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}