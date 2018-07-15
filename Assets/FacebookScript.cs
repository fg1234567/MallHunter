using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Firebase;
using Firebase.Auth;
using Firebase.Unity.Editor;

using Facebook.Unity;




public class FacebookScript : MonoBehaviour {


    void Awake()
    {
        FB.Init();

    }


    void Start () {

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Set a flag here indiciating that Firebase is ready to use by your
                // application.
                Debug.Log("Connection with Firebase established");
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
                Debug.Log("Connection with Firebase failed");
            }
        });



    }

    public void facebookButtonClick()
    {
        Debug.Log(FB.IsInitialized);

        Debug.Log("Facebook is clicked");

        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        string accessToken = FB.ClientToken;
        //AccessToken accessToken = AccessToken.CurrentAccessToken;

        Debug.Log("***" + accessToken);

        /*Firebase.Auth.Credential credential = Firebase.Auth.FacebookAuthProvider.GetCredential(accessToken);
         auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
             if (task.IsCanceled)
             {
                 Debug.LogError("SignInWithCredentialAsync was canceled.");
                 return;
             }
             if (task.IsFaulted)
             {
                 Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                 return;
             }

             Firebase.Auth.FirebaseUser newUser = task.Result;
             Debug.LogFormat("User signed in successfully: {0} ({1})",
                 newUser.DisplayName, newUser.UserId);
         });*/


    }


}
