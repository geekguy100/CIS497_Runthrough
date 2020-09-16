using UnityEngine;

//Singleton class taken from 'Unity Game Development Cookbook' (Buttfield-Addison, Manning, Nugent)
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance{
        get {
            //If we don't have an instance ready, get one by either finding it in the scene or creating one.
            if (_instance == null)
                _instance = FindOrCreateInstance();

            return _instance;
        }
    }

    //This variable is the actual instance. 
    //It's private, and can only be accessed through the 'instance' property above.
    private static T _instance;

    //Attemps to find an instance of this singleton. If one can't be found, a new one is created.
    private static T FindOrCreateInstance()
    {
        //Attempt to locate an instance.
        var instance = GameObject.FindObjectOfType<T>();

        if (instance != null)
        {
            //We found an instance. Return it; it will be used as the shared instance.
            return instance;
        }

        //If an instance hasn't been found, set up a new one.
        //We'll need to create a new game object to hold this instance.
        var name = typeof(T).Name + " Singleton";

        //Create the container gameobject with that name.
        var containerGameObject = new GameObject(name);

        //Create and attach a new instance of whatever 'T' is; we'll return this new instance.
        var singletonComponent = containerGameObject.AddComponent<T>();

        return singletonComponent;
    }
}
