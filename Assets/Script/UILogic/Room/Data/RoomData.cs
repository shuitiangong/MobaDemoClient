using Google.Protobuf.Collections;
using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : Singleton<RoomData>
{
    public RepeatedField<PlayerInfo> playerinfos;

}
