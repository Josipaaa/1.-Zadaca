using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame {
    public class CollisionDetector {

        public static bool Overlaps(Sprite s1, Sprite s2) {

            if (s2.Position.Y == 0) { //top paddle

                if ((s1.Position.X >= s2.Position.X - s1.Size.Width / 2.0f) &&
                    (s1.Position.X + s1.Size.Width <= s2.Position.X + s2.Size.Width + s1.Size.Width / 2.0f) &&
                    (s1.Position.Y <= s2.Position.Y + s2.Size.Height)) {
                    return true;
                } else {
                    return false;
                }

            } else { // bottom paddle

                if ((s1.Position.X >= s2.Position.X - s1.Size.Width / 2.0f) &&
                    (s1.Position.X + s1.Size.Width <= s2.Position.X + s2.Size.Width + s1.Size.Width / 2.0f) &&
                    (s1.Position.Y + s1.Size.Height >= s2.Position.Y)) {
                    return true;
                } else {
                    return false;
                }

            }

        }
    }
}
