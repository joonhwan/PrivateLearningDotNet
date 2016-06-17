// Get signalr.d.ts.ts from https://github.com/borisyankov/DefinitelyTyped (or delete the reference)
/// <reference path="signalr.d.ts" />
/// <reference path="jquery.d.ts" />

////////////////////
// available hubs //
////////////////////
//#region available hubs

interface SignalR {

    /**
      * The hub implemented by SignalRMyHub.MyHub
      */
    myHub : MyHub;
}
//#endregion available hubs

///////////////////////
// Service Contracts //
///////////////////////
//#region service contracts

//#region MyHub hub

interface MyHub {
    
    /**
      * This property lets you send messages to the MyHub hub.
      */
    server : MyHubServer;

    /**
      * The functions on this property should be replaced if you want to receive messages from the MyHub hub.
      */
    client : IMyHubClient;
}

interface MyHubServer {

    /** 
      * Sends a "send" message to the MyHub hub.
      * Contract Documentation: ---
      * @param name {string} 
      * @param message {string} 
      * @return {JQueryPromise of void}
      */
    send(name : string, message : string) : JQueryPromise<void>
}

interface IMyHubClient
{

    /**
      * Set this function with a "function(name : string, message : string){}" to receive the "addMessage" message from the MyHub hub.
      * Contract Documentation: ---
      * @param name {string} 
      * @param message {string} 
      * @return {void}
      */
    addMessage : (name : string, message : string) => void;
}

//#endregion MyHub hub

//#endregion service contracts



////////////////////
// Data Contracts //
////////////////////
//#region data contracts

//#endregion data contracts

