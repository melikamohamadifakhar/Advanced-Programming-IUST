using System;
using System.Collections.Generic;
using System.IO;

namespace A4
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private FileSystemWatcher Watcher;
        public event Action<string> create;
        public event Action<string> delete;



        public DirectoryWatcher(string fileName){
            Watcher = new FileSystemWatcher(fileName);
            Watcher.EnableRaisingEvents = true;
            Watcher.Created += OnCreate;
            Watcher.Deleted += OnDelete;
        }
        public void Register(Action<string> action, ObserverType observer){
            if (observer == ObserverType.Create)
                create += action;
            else
                delete += action;
        }
        public void Unregister(Action<string> action, ObserverType observer){
            if (observer == ObserverType.Create && create != null)
                create -= action;
            else if(delete != null)
                delete -= action;
        }

        public void OnCreate(Object sender, FileSystemEventArgs arg){
            if(create != null)
                create(arg.FullPath);
        }
        public void OnDelete(Object sender, FileSystemEventArgs arg){
            if (delete != null)
                delete(arg.FullPath);
        }

        public void Dispose()
        {
            if(Watcher != null)
                Watcher.Dispose();
        }
    }
}
