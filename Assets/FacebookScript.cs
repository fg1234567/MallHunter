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
using Facebook;
using FacebookPlatformServiceClient;



public class FacebookScript : MonoBehaviour {

    void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }

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

    public void LogIn()
    {
        FB.LogInWithReadPermissions(callback: OnLogIn);
    }

    public void OnLogIn(ILoginResult result)
    {
        AccessToken accessToken = AccessToken.CurrentAccessToken;
        Credential credential = FacebookAuthProvider.GetCredential(accessToken.TokenString);

    }

    public void facebookLogIn(Credential firebaseResult)
    {
        Debug.Log(FB.IsInitialized);

        Debug.Log("Facebook is clicked");

        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

         auth.SignInWithCredentialAsync(firebaseResult).ContinueWith(task => {
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
         });

    }

        /*
    private void Awake()
    {



        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void LogIn()
    {
        FB.LogInWithReadPermissions(callback: OnLogIn);


    }
    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            AccessToken tocken = AccessToken.CurrentAccessToken;
            Credential credential = FacebookAuthProvider.GetCredential(tocken.UserId);

        }
        else
        {
            Debug.Log("Login Failed");
        }
    }

    public void accessToken(Credential firebaseResult)
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        if (!FB.IsLoggedIn)
        {
            return;
        }

        auth.SignInWithCredentialAsync(firebaseResult).ContinueWith(task =>
        {
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

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }*/
}
