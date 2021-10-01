using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLib
{
    public class Room{
        public int Row;
        public int Column;
        public (int, int) StartPos;
        public List<(int, int)> EnemyPos;
        public List<(int, int)> BossPos;
        public (int, int) ChestPos;
        public (int, int) NextPos;

    }
}