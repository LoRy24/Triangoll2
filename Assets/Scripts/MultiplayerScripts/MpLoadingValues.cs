using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MpLoadingValues {
    
    private static int connectionType = 1;
    private static string address = "localhost";
    private static int port = 7777;
    public static bool timedOut = false;

    public static int ConnectionType {
        get { return connectionType; }
        set { connectionType = value; }
    }

    public static int Port {
        get { return port; }
        set { port = value; }
    }

    public static string Address {
        get { return address; }
        set { address = value; }
    }
}
